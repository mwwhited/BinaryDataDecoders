using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
{
    [Flags]
    public enum Lights
    {
        None = 0x0,
        White = 0x1,
        Touch = 0x2,
        Yellow = 0x3,
    }
}
