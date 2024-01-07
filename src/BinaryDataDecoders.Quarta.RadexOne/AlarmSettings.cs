using System;

namespace BinaryDataDecoders.Quarta.RadexOne;

/// <summary>
/// Flag enumeration for setting Radex One Alarm type
/// </summary>
[Flags]
public enum AlarmSettings : byte
{
    /// <summary>
    /// No Alarm
    /// </summary>
    Off = 0x00,
    /// <summary>
    /// Beep
    /// </summary>
    Audio = 0x02,
    /// <summary>
    /// Vibration
    /// </summary>
    Vibrate = 0x01,
}
