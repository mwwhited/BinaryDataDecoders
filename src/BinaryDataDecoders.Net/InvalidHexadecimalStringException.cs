using System;
using System.Diagnostics;

namespace BinaryDataDecoders.Net
{
    public class InvalidHexadecimalStringException : Exception
    {
        public string Hexadecimal { get; private set; }

        public InvalidHexadecimalStringException(string hexString)
            : base(string.Format("\"{0}\" is not a valid Hexadecimal Number", hexString))
        {
            this.Hexadecimal = hexString;
        }

        [DebuggerNonUserCode]
        public static void Check(string hexString)
        {
            if (!ConvertEx.IsHexString(hexString))
                throw new InvalidHexadecimalStringException(hexString);
        }
    }
}
