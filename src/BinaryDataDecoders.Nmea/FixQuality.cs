namespace BinaryDataDecoders.Nmea;

public enum FixQuality
{
    Invalid = 0,
    GpsFixSps = 1,
    DgpsFix = 2,
    PpsFix = 3,
    RealTimeKinematic = 4,
    FloatRtk = 5,
    Estimated = 6,
    Manual = 7,
    Simulation = 8,
}