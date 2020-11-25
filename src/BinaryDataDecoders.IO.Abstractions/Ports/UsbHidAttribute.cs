using System;

namespace BinaryDataDecoders.IO.Ports
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class UsbHidAttribute : Attribute
    {
        public ushort VendorId { get; set; }
        public ushort ProductId { get; set; }
        public ushort ProductMask { get; set; } = 0xffff;
    }
}
