using System;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [Flags]
    public enum AlarmSettings : byte
    {
        Off = 0x00,
        Audio = 0x02,
        Vibrate = 0x01,
    }
}
