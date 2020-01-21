
namespace BinaryDataDecoders.ToolKit
{
    public static class Bytes
    {
        /// <summary>
        /// Start Of Heading
        /// </summary>
        public const byte Soh = (byte)ControlCharacters.StartOfHeading;
        /// <summary>
        /// Start Of Text
        /// </summary>
        public const byte Sotx = (byte)ControlCharacters.StartOfText;
        /// <summary>
        /// End Of Text
        /// </summary>
        public const byte Eotx = (byte)ControlCharacters.EndOfText;
        /// <summary>
        /// End Of Transmission
        /// </summary>
        public const byte Eotr = (byte)ControlCharacters.EndOfTransmission;
        /// <summary>
        /// Line Feed
        /// </summary>
        public const byte Lf = (byte)ControlCharacters.LineFeed;
        /// <summary>
        /// Device Control 2
        /// </summary>
        public const byte Dc2 = (byte)ControlCharacters.DeviceControl2;
        /// <summary>
        /// Device Control 3
        /// </summary>
        public const byte Dc3 = (byte)ControlCharacters.DeviceControl3;
        /// <summary>
        /// $
        /// </summary>
        public const byte _S = 0x24;
        /// <summary>
        /// 0
        /// </summary>
        public const byte _0 = 0x30;
        /// <summary>
        /// 1
        /// </summary>
        public const byte _1 = 0x31;
        /// <summary>
        /// :
        /// </summary>
        public const byte _C = 0x3a;
        public const byte F = 0x46;
        public const byte G = 0x47;
        public const byte L = 0x4c;
        public const byte P = 0x50;
        public const byte R = 0x52;
        public const byte S = 0x53;
        public const byte T = 0x54;
        public const byte W = 0x57;
        public const byte _ = 0x5f;
        public const byte w = 0x77;
    }
}