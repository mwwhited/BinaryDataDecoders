﻿using BinaryDataDecoders.IO.Messages;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne;
/// <summary>
/// Read Values result from current device values
/// </summary>
[MessageMatchPattern("7AFF-2080-1600-????????-????|0008+")]
[StructLayout(LayoutKind.Explicit, Size = 32)]
public readonly struct ReadValuesResponse : IRadexObject
{
    // <: 7AFF 2080 1600 1800 ____ 3680 0008 ____ 0C00 ____ 1200 ____ 1200 ____ 1500 ____ BAF7

    [FieldOffset(0)]
    private readonly ushort Prefix;
    [FieldOffset(2)]
    private readonly ushort Command;
    [FieldOffset(4)]
    private readonly ushort ExtensionLength;
    /// <summary>
    /// packetnumber is returned by response and may be used for correlation.
    /// </summary>
    [FieldOffset(6)]
    public readonly uint PacketNumber;
    [FieldOffset(10)]
    private readonly ushort CheckSum0;

    [FieldOffset(12)]
    private readonly ulong SubCommandL;
    [FieldOffset(12)]
    private readonly ushort SubCommand;
    [FieldOffset(14)]
    private readonly ushort Reserved1;
    [FieldOffset(16)]
    private readonly ushort Reserved2;
    [FieldOffset(18)]
    private readonly ushort Reserved3;
    /// <summary>
    /// μSv/h * 100: Stated range .05 to 999.00 (Requires 17 bits?)
    /// </summary>
    [FieldOffset(20)]
    public readonly int Ambient;
    /// <summary>
    /// μSv * 100: Stated range 0 to 9,990,000 (Requires 30 bits?)
    /// </summary>
    [FieldOffset(24)]
    public readonly int Accumulated;
    /// <summary>
    /// clicks/minute: State range 0 to 99,900 (Requires 17 bits?)
    /// </summary>
    [FieldOffset(28)]
    public readonly int ClicksPerMinute;
    [FieldOffset(32)]
    private readonly ushort CheckSum1;

    public override string ToString()
    {
        return $"Data:\t{Ambient / 100m} μSv/h\t{Accumulated / 100m} μSv\t{ClicksPerMinute} cpm\t({PacketNumber}:0x{PacketNumber:X2})\t[{SubCommandL:X2}]";
    }
}
