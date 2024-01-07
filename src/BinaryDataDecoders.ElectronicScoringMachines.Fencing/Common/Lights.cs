using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;

[Flags]
public enum Lights
{
    None = 0x0,
    White = 0x1,
    Yellow = 0x2,
    Touch = 0x4,
}
