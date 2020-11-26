using System;

namespace BinaryDataDecoders.Velleman.K8055
{
    [Flags]
    public enum DigitalOutputs : byte
    {
        O1 = 0x01,
        O2 = 0x02,
        O3 = 0x04,
        O4 = 0x08,
        O5 = 0x10,
        O6 = 0x20,
        O7 = 0x40,
        O8 = 0x80,
    }
}
