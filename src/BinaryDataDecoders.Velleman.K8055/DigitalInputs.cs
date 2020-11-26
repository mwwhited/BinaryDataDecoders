using System;

namespace BinaryDataDecoders.Velleman.K8055
{
    [Flags]
    public enum DigitalInputs : byte
    {
        I1 = 0x10,
        I2 = 0x20,
        I3 = 0x01,
        I4 = 0x40,
        I5 = 0x80,
    }
}
