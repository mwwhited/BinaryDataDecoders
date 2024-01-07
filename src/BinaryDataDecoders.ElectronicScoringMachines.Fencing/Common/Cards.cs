using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;

[Flags]
public enum Cards
{
    None = 0x0,
    Yellow = 0x1,
    Red = 0x2,
    Black = 0x4,
}
