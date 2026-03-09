using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SonicAudioLib.CriMw
{
    [StructLayout(LayoutKind.Sequential)]
    struct CriTableHeader
    {
        public static readonly byte[] SignatureBytes = { 0x40, 0x55, 0x54, 0x46 };

        public const byte EncodingTypeShiftJis = 0;
        public const byte EncodingTypeUtf8 = 1;

        public byte[] Signature;
        public uint Length;
        public byte UnknownByte;
        public byte EncodingType;
        public ushort RowsPosition;
        public uint StringPoolPosition;
        public uint DataPoolPosition;
        public uint TableNamePosition;
        public string TableName;
        public ushort FieldCount;
        public ushort RowLength;
        public uint RowCount;
    }

    [Flags]
    enum CriFieldFlag : byte
    {
        Name = 16,
        DefaultValue = 32,
        RowStorage = 64,
        
        Byte = 0,
        SByte = 1,
        UInt16 = 2,
        Int16 = 3,
        UInt32 = 4,
        Int32 = 5,
        UInt64 = 6,
        Int64 = 7,
        Single = 8,
        Double = 9,
        String = 10,
        Data = 11,
        Guid = 12,

        TypeMask = 15,
    };

    [StructLayout(LayoutKind.Sequential)]
    struct CriTableField
    {
        public CriFieldFlag Flag;
        public string Name;
        public uint Position;
        public uint Length;
        public uint Offset;
        public object Value;
    }

    public static class CriCseMasker
    {
        public const int MaskLength = 64;

        private static readonly byte[] Key =
        {
            0x63, 0x38, 0x34, 0x35, 0x4D, 0x42, 0x41, 0x61, 0x2A, 0x21, 0x32, 0x26, 0x29, 0xA3, 0x5F, 0x29,
            0x28, 0x3E, 0x3C, 0x50, 0x66, 0x61, 0x70, 0x64, 0x2C, 0x68, 0x79, 0x61, 0x49, 0x48, 0x26, 0x25,
            0x26, 0x31, 0x4C, 0x44, 0x39, 0x26, 0x2A, 0x2A, 0x55, 0x75, 0x6B, 0x7A, 0x6D, 0x5E, 0x21, 0x7B,
            0x7D, 0x3A, 0x40, 0x26, 0x5E, 0x2A, 0x2B, 0x3F, 0x39, 0x36, 0x39, 0x64, 0x66, 0x60, 0x60, 0x40,
        };

        public static bool IsCseMasked(byte[] header)
        {
            if (header == null || header.Length < 4)
            {
                return false;
            }

            return (header[0] ^ Key[0]) == CriTableHeader.SignatureBytes[0]
                && (header[1] ^ Key[1]) == CriTableHeader.SignatureBytes[1]
                && (header[2] ^ Key[2]) == CriTableHeader.SignatureBytes[2]
                && (header[3] ^ Key[3]) == CriTableHeader.SignatureBytes[3];
        }

        public static void Mask(Stream source, long length)
        {
            long currentPosition = source.Position;
            long end = Math.Min(currentPosition + length, currentPosition + MaskLength);

            int index = 0;
            while (source.Position < end)
            {
                byte maskedByte = (byte)(source.ReadByte() ^ Key[index++]);
                source.Position--;
                source.WriteByte(maskedByte);
            }
        }

        public static void Mask(byte[] data, int offset, int length)
        {
            int end = Math.Min(offset + length, offset + MaskLength);

            int keyIndex = 0;
            for (int i = offset; i < end && i < data.Length; i++)
            {
                data[i] ^= Key[keyIndex++];
            }
        }

        public static Stream Unmask(Stream source)
        {
            if (source == null || !source.CanRead)
            {
                return source;
            }

            long startPosition = source.Position;

            byte[] header = new byte[4];
            int bytesRead = source.Read(header, 0, 4);
            source.Position = startPosition;

            if (bytesRead < 4 || !IsCseMasked(header))
            {
                return source;
            }

            int length = (int)(source.Length - startPosition);
            byte[] data = new byte[length];
            source.Read(data, 0, length);

            Mask(data, 0, length);

            return new MemoryStream(data);
        }
    }

    static class CriTableMasker
    {
        public static void FindKeys(byte[] signature, out uint xor, out uint xorMultiplier)
        {
            for (int x = 0; x < 0x100; x++)
            {
                // Find XOR using first byte
                if ((signature[0] ^ (byte)x) == CriTableHeader.SignatureBytes[0])
                {
                    // Matched the first byte, try finding the multiplier with the second byte
                    for (int m = 0; m < 0x100; m++)
                    {
                        // Matched the second byte, now make sure the other bytes match as well
                        if ((signature[1] ^ (byte)(x * m)) == CriTableHeader.SignatureBytes[1])
                        {
                            byte _x = (byte)(x * m);

                            bool allMatches = true;
                            for (int i = 2; i < 4; i++)
                            {
                                _x = (byte)(_x * m);

                                if ((signature[i] ^ _x) != CriTableHeader.SignatureBytes[i])
                                {
                                    allMatches = false;
                                    break;
                                }
                            }

                            // All matches, return the xor and multiplier
                            if (allMatches)
                            {
                                xor = (uint)x;
                                xorMultiplier = (uint)m;
                                return;
                            }
                        }
                    }
                }
            }

            throw new InvalidDataException("'@UTF' signature could not be found. Your file might be corrupted.");
        }

        public static void Mask(Stream source, Stream destination, long length, uint xor, uint xorMultiplier)
        {
            uint currentXor = xor;
            long currentPosition = source.Position;

            while (source.Position < currentPosition + length)
            {
                byte maskedByte = (byte)(source.ReadByte() ^ currentXor);
                currentXor *= xorMultiplier;

                destination.WriteByte(maskedByte);
            }
        }

        public static void Mask(Stream source, long length, uint xor, uint xorMultiplier)
        {
            if (source.CanRead && source.CanWrite)
            {
                uint currentXor = xor;
                long currentPosition = source.Position;

                while (source.Position < currentPosition + length)
                {
                    byte maskedByte = (byte)(source.ReadByte() ^ currentXor);
                    currentXor *= xorMultiplier;

                    source.Position--;
                    source.WriteByte(maskedByte);
                }
            }
        }
    }
}
