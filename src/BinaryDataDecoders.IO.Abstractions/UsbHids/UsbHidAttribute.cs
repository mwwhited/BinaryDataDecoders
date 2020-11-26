using System;

namespace BinaryDataDecoders.IO.UsbHids
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class UsbHidAttribute : Attribute
    {
        public UsbHidAttribute() { }
        public UsbHidAttribute(
            ushort vendorId,
            ushort productId
            )
        {
            VendorId = vendorId;
            ProductId = productId;
        }
        public UsbHidAttribute(
            ushort vendorId,
            ushort productId,
            ushort productMask
            ) : this(vendorId, productId)
        {
            ProductMask = productMask;
        }

        public ushort VendorId { get; set; }
        public ushort ProductId { get; set; }
        public ushort ProductMask { get; set; } = 0xffff;
    }
}
