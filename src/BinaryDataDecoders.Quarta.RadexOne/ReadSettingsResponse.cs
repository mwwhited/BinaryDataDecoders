using BinaryDataDecoders.IO.Messages;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne;

/// <summary>
/// response from device with current settings
/// </summary>
[MessageMatchPattern("7AFF-2080-1000-********-****|0108+")]
[StructLayout(LayoutKind.Explicit, Size = 28)]
public readonly struct ReadSettingsResponse : IRadexObject
{
    // <: 7AFF 2080 1000 FD05 ____ 577A 0108 ____ 0500 ____ 020A ____ ____ F7ED

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

    [FieldOffset(20)]
    private readonly ulong Settings;

    /// <summary>
    /// Off; Audio; Vibrate; Audio|Vibrate
    /// </summary>
    [FieldOffset(20)]
    public readonly AlarmSettings AlarmSetting;
    /// <summary>
    /// μSv/h  * 100: Alarm trigger threshold: range .01 to 10.00
    /// </summary>
    [FieldOffset(21)]
    public readonly ushort Threshold;
    [FieldOffset(26)]
    private readonly ushort CheckSum1;

    public override string ToString()
    {
        return $"Settings:\t{AlarmSetting}\t{Threshold / 100m} μSv/h\t({PacketNumber}:0x{PacketNumber:X2}) [{SubCommandL:X2}-{Settings:X2}]";
    }
}
