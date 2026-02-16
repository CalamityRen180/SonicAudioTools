using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace SonicAudioLib.IO
{
    public class StringPool
    {
        private List<StringItem> items = new List<StringItem>();

        private long startPosition = 0;
        private long length = 0;
        private Encoding encoding = Encoding.Default;

        public const string AdxBlankString = "<NULL>";

        public long Position
        {
            get
            {
                return startPosition;
            }
        }

        public long Length
        {
            get
            {
                return length;
            }
        }

        public long Put(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            long position = length;
            items.Add(new StringItem() { Value = value, Position = position });

            length += encoding.GetByteCount(value) + 1;
            return position;
        }

        /// <summary>
        /// Aligns the current string pool length to the specified byte boundary.
        /// The next string added via Put() will start at this aligned offset.
        /// Used to match the original CRI tool behavior where certain tables
        /// require alignment padding at specific points in the string pool
        /// (e.g., TBLCUE requires 2-byte alignment after the first row's strings).
        /// </summary>
        public void Align(int boundary)
        {
            if (boundary <= 1)
            {
                return;
            }

            long remainder = length % boundary;
            if (remainder != 0)
            {
                length += boundary - remainder;
            }
        }

        public void Write(Stream destination)
        {
            startPosition = (uint)destination.Position;

            for (int i = 0; i < items.Count; i++)
            {
                // Pad to the position that was calculated in Put() / Align().
                long expectedPosition = startPosition + items[i].Position;
                while (destination.Position < expectedPosition)
                {
                    destination.WriteByte(0);
                }

                DataStream.WriteCString(destination, items[i].Value, encoding);
            }
        }

        public bool ContainsString(string value)
        {
            return items.Any(item => item.Value == value);
        }

        public long GetStringPosition(string value)
        {
            return items.First(item => item.Value == value).Position;
        }

        public void Clear()
        {
            items.Clear();
            length = 0;
        }

        public StringPool(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public StringPool()
        {
        }

        private class StringItem
        {
            public string Value { get; set; }
            public long Position { get; set; }
        }
    }
}