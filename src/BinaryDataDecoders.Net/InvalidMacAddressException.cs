using System;
using System.Diagnostics;

namespace BinaryDataDecoders.Net
{
    public class InvalidMacAddressException : Exception
    {
        public string MACAddress { get; private set; }

        public InvalidMacAddressException(string macAddress)
            : base(string.Format("\"{0}\" is not a valid MAC Address", macAddress))
        {
            this.MACAddress = macAddress;
        }

        [DebuggerNonUserCode]
        public static void Check(string macAddress)
        {
            if (!MacAddressEx.IsValid(macAddress))
                throw new InvalidMacAddressException(macAddress);
        }
    }
}
