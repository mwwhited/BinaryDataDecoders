namespace BinaryDataDecoders.Zoom.H4n
{
    public enum H4nRequests : ushort
    {
        None = 0,

        Mic = 0x8001,
        Channel1 = 0x8002,
        Channel2 = 0x8004,
        VolumeUp = 0x8008,
        VolumnDown = 0x8010,
        Record = 0x8100,
        Play = 0x8200,
        Stop = 0x8400,
        FastForward = 0x8800,
        Rewind = 0x9000,

        Poll = 0x8000,
    }
}
