using System.IO;
using SonicAudioLib.CriMw.Serialization;

namespace CsbBuilder.Serialization
{
    [CriSerializable("TBLSYN")]
    public class SerializationSynthTable
    {
        private string synnameField = string.Empty;
        private byte syntypeField = 0;
        private byte cmplxtypeField = 0;
        private string lnknameField = string.Empty;
        private string issetnameField = string.Empty;
        private short volumeField = 1000;
        private short pitchField = 0;
        private uint dlytimField = 0;
        private byte s_cntrlField = 0;
        private ushort eg_dlyField = 0;
        private ushort eg_atkField = 0;
        private ushort eg_hldField = 0;
        private ushort eg_dcyField = 0;
        private ushort eg_relField = 0;
        private ushort eg_susField = 1000;
        private byte f_typeField = 0;
        private ushort f_cof1Field = 0;
        private ushort f_cof2Field = 0;
        private ushort f_resoField = 0;
        private byte f_roffField = 0;
        private string dryonameField = string.Empty;
        private string mtxrtrField = string.Empty;
        private ushort dry0Field = 0;
        private ushort dry1Field = 0;
        private ushort dry2Field = 0;
        private ushort dry3Field = 0;
        private ushort dry4Field = 0;
        private ushort dry5Field = 0;
        private ushort dry6Field = 0;
        private ushort dry7Field = 0;
        private string wetonameField = string.Empty;
        private ushort wet0Field = 0;
        private ushort wet1Field = 0;
        private ushort wet2Field = 0;
        private ushort wet3Field = 0;
        private ushort wet4Field = 0;
        private ushort wet5Field = 0;
        private ushort wet6Field = 0;
        private ushort wet7Field = 0;
        private string wcnct0Field = string.Empty;
        private string wcnct1Field = string.Empty;
        private string wcnct2Field = string.Empty;
        private string wcnct3Field = string.Empty;
        private string wcnct4Field = string.Empty;
        private string wcnct5Field = string.Empty;
        private string wcnct6Field = string.Empty;
        private string wcnct7Field = string.Empty;
        private string vl_gnameField = string.Empty;
        private byte vl_typeField = 0;
        private byte vl_prioField = 0;
        private ushort vl_phtimeField = 0;
        private sbyte vl_pcdltField = 0;

        [CriField("synname", 0)]
        public string SynthName
        {
            get
            {
                return synnameField;
            }
            set
            {
                synnameField = value;
            }
        }

        [CriField("syntype", 1)]
        public byte SynthType
        {
            get
            {
                return syntypeField;
            }
            set
            {
                syntypeField = value;
            }
        }

        [CriField("cmplxtype", 2)]
        public byte ComplexType
        {
            get
            {
                return cmplxtypeField;
            }
            set
            {
                cmplxtypeField = value;
            }
        }

        [CriField("lnkname", 3)]
        public string LinkName
        {
            get
            {
                return lnknameField;
            }
            set
            {
                lnknameField = value;
            }
        }

        [CriField("issetname", 4)]
        public string AisacSetName
        {
            get
            {
                return issetnameField;
            }
            set
            {
                issetnameField = value;
            }
        }

        [CriField("volume", 5)]
        public short Volume
        {
            get
            {
                return volumeField;
            }
            set
            {
                volumeField = value;
            }
        }

        [CriField("pitch", 6)]
        public short Pitch
        {
            get
            {
                return pitchField;
            }
            set
            {
                pitchField = value;
            }
        }

        [CriField("dlytim", 7)]
        public uint DelayTime
        {
            get
            {
                return dlytimField;
            }
            set
            {
                dlytimField = value;
            }
        }

        [CriField("s_cntrl", 8)]
        public byte SControl
        {
            get
            {
                return s_cntrlField;
            }
            set
            {
                s_cntrlField = value;
            }
        }

        [CriField("eg_dly", 9)]
        public ushort EgDelay
        {
            get
            {
                return eg_dlyField;
            }
            set
            {
                eg_dlyField = value;
            }
        }

        [CriField("eg_atk", 10)]
        public ushort EgAttack
        {
            get
            {
                return eg_atkField;
            }
            set
            {
                eg_atkField = value;
            }
        }

        [CriField("eg_hld", 11)]
        public ushort EgHold
        {
            get
            {
                return eg_hldField;
            }
            set
            {
                eg_hldField = value;
            }
        }

        [CriField("eg_dcy", 12)]
        public ushort EgDecay
        {
            get
            {
                return eg_dcyField;
            }
            set
            {
                eg_dcyField = value;
            }
        }

        [CriField("eg_rel", 13)]
        public ushort EgRelease
        {
            get
            {
                return eg_relField;
            }
            set
            {
                eg_relField = value;
            }
        }

        [CriField("eg_sus", 14)]
        public ushort EgSustain
        {
            get
            {
                return eg_susField;
            }
            set
            {
                eg_susField = value;
            }
        }

        [CriField("f_type", 15)]
        public byte FType
        {
            get
            {
                return f_typeField;
            }
            set
            {
                f_typeField = value;
            }
        }

        [CriField("f_cof1", 16)]
        public ushort FCof1
        {
            get
            {
                return f_cof1Field;
            }
            set
            {
                f_cof1Field = value;
            }
        }

        [CriField("f_cof2", 17)]
        public ushort FCof2
        {
            get
            {
                return f_cof2Field;
            }
            set
            {
                f_cof2Field = value;
            }
        }

        [CriField("f_reso", 18)]
        public ushort FReso
        {
            get
            {
                return f_resoField;
            }
            set
            {
                f_resoField = value;
            }
        }

        [CriField("f_roff", 19)]
        public byte FReleaseOffset
        {
            get
            {
                return f_roffField;
            }
            set
            {
                f_roffField = value;
            }
        }

        [CriField("dryoname", 20)]
        public string DryOName
        {
            get
            {
                return dryonameField;
            }
            set
            {
                dryonameField = value;
            }
        }

        [CriField("mtxrtr", 21)]
        public string Mtxrtr
        {
            get
            {
                return mtxrtrField;
            }
            set
            {
                mtxrtrField = value;
            }
        }

        [CriField("dry0", 22)]
        public ushort Dry0
        {
            get
            {
                return dry0Field;
            }
            set
            {
                dry0Field = value;
            }
        }

        [CriField("dry1", 23)]
        public ushort Dry1
        {
            get
            {
                return dry1Field;
            }
            set
            {
                dry1Field = value;
            }
        }

        [CriField("dry2", 24)]
        public ushort Dry2
        {
            get
            {
                return dry2Field;
            }
            set
            {
                dry2Field = value;
            }
        }

        [CriField("dry3", 25)]
        public ushort Dry3
        {
            get
            {
                return dry3Field;
            }
            set
            {
                dry3Field = value;
            }
        }

        [CriField("dry4", 26)]
        public ushort Dry4
        {
            get
            {
                return dry4Field;
            }
            set
            {
                dry4Field = value;
            }
        }

        [CriField("dry5", 27)]
        public ushort Dry5
        {
            get
            {
                return dry5Field;
            }
            set
            {
                dry5Field = value;
            }
        }

        [CriField("dry6", 28)]
        public ushort Dry6
        {
            get
            {
                return dry6Field;
            }
            set
            {
                dry6Field = value;
            }
        }

        [CriField("dry7", 29)]
        public ushort Dry7
        {
            get
            {
                return dry7Field;
            }
            set
            {
                dry7Field = value;
            }
        }

        [CriField("wetoname", 30)]
        public string WetOName
        {
            get
            {
                return wetonameField;
            }
            set
            {
                wetonameField = value;
            }
        }

        [CriField("wet0", 31)]
        public ushort Wet0
        {
            get
            {
                return wet0Field;
            }
            set
            {
                wet0Field = value;
            }
        }

        [CriField("wet1", 32)]
        public ushort Wet1
        {
            get
            {
                return wet1Field;
            }
            set
            {
                wet1Field = value;
            }
        }

        [CriField("wet2", 33)]
        public ushort Wet2
        {
            get
            {
                return wet2Field;
            }
            set
            {
                wet2Field = value;
            }
        }

        [CriField("wet3", 34)]
        public ushort Wet3
        {
            get
            {
                return wet3Field;
            }
            set
            {
                wet3Field = value;
            }
        }

        [CriField("wet4", 35)]
        public ushort Wet4
        {
            get
            {
                return wet4Field;
            }
            set
            {
                wet4Field = value;
            }
        }

        [CriField("wet5", 36)]
        public ushort Wet5
        {
            get
            {
                return wet5Field;
            }
            set
            {
                wet5Field = value;
            }
        }

        [CriField("wet6", 37)]
        public ushort Wet6
        {
            get
            {
                return wet6Field;
            }
            set
            {
                wet6Field = value;
            }
        }

        [CriField("wet7", 38)]
        public ushort Wet7
        {
            get
            {
                return wet7Field;
            }
            set
            {
                wet7Field = value;
            }
        }

        [CriField("wcnct0", 39)]
        public string Wcnct0
        {
            get
            {
                return wcnct0Field;
            }
            set
            {
                wcnct0Field = value;
            }
        }

        [CriField("wcnct1", 40)]
        public string Wcnct1
        {
            get
            {
                return wcnct1Field;
            }
            set
            {
                wcnct1Field = value;
            }
        }

        [CriField("wcnct2", 41)]
        public string Wcnct2
        {
            get
            {
                return wcnct2Field;
            }
            set
            {
                wcnct2Field = value;
            }
        }

        [CriField("wcnct3", 42)]
        public string Wcnct3
        {
            get
            {
                return wcnct3Field;
            }
            set
            {
                wcnct3Field = value;
            }
        }

        [CriField("wcnct4", 43)]
        public string Wcnct4
        {
            get
            {
                return wcnct4Field;
            }
            set
            {
                wcnct4Field = value;
            }
        }

        [CriField("wcnct5", 44)]
        public string Wcnct5
        {
            get
            {
                return wcnct5Field;
            }
            set
            {
                wcnct5Field = value;
            }
        }

        [CriField("wcnct6", 45)]
        public string Wcnct6
        {
            get
            {
                return wcnct6Field;
            }
            set
            {
                wcnct6Field = value;
            }
        }

        [CriField("wcnct7", 46)]
        public string Wcnct7
        {
            get
            {
                return wcnct7Field;
            }
            set
            {
                wcnct7Field = value;
            }
        }

        [CriField("vl_gname", 47)]
        public string VoiceLimitGroupName
        {
            get
            {
                return vl_gnameField;
            }
            set
            {
                vl_gnameField = value;
            }
        }

        [CriField("vl_type", 48)]
        public byte VoiceLimitType
        {
            get
            {
                return vl_typeField;
            }
            set
            {
                vl_typeField = value;
            }
        }

        [CriField("vl_prio", 49)]
        public byte VoiceLimitPriority
        {
            get
            {
                return vl_prioField;
            }
            set
            {
                vl_prioField = value;
            }
        }

        [CriField("vl_phtime", 50)]
        public ushort VoiceLimitPhTime
        {
            get
            {
                return vl_phtimeField;
            }
            set
            {
                vl_phtimeField = value;
            }
        }

        [CriField("vl_pcdlt", 51)]
        public sbyte VoiceLimitPcdlt
        {
            get
            {
                return vl_pcdltField;
            }
            set
            {
                vl_pcdltField = value;
            }
        }        
    }
}
