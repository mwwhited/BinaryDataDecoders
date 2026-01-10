using System;
using System.Linq;

namespace BinaryDataDecoders.Nmea;

public class GlobalPositioningFixData : INema0183Message
{
    /*
    GGA - essential fix data which provide 3D location and accuracy data.
    $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47

    Where:
         GGA          Global Positioning System Fix Data
         123519       Fix taken at 12:35:19 UTC
         4807.038,N   Latitude 48 deg 07.038' N
         01131.000,E  Longitude 11 deg 31.000' E
         1            Fix quality: 0 = invalid
                                   1 = GPS fix (SPS)
                                   2 = DGPS fix
                                   3 = PPS fix
			                           4 = Real Time Kinematic
			                           5 = Float RTK
                                   6 = estimated (dead reckoning) (2.3 feature)
			                           7 = Manual input mode
			                           8 = Simulation mode
         08           Number of satellites being tracked
         0.9          Horizontal dilution of position
         545.4,M      Altitude, Meters, above mean sea level
         46.9,M       Height of geoid (mean sea level) above WGS84
                          ellipsoid
         (empty field) time in seconds since last DGPS update
         (empty field) DGPS station ID number
         *47          the checksum data, always begins with
    */

    public TimeSpan Fix { get; }
    public decimal Latitude { get; }
    public char LatitudeDirection { get; }
    public decimal Longitude { get; }
    public char LongitudeDirection { get; }
    public FixQuality FixQuality { get; }
    public int NumberOfSatellites { get; }
    public decimal HorizontalDilution { get; }
    public decimal Altitude { get; }
    public string AltitudeUnits { get; }
    public decimal Height { get; }
    public string HeightUnits { get; }

    public GlobalPositioningFixData(string[] data)
    {
        var fixTime = data.ElementAtOrDefault(1) ?? "0000000000";
        Fix = new TimeSpan(
            0,
            int.TryParse(fixTime[0..2], out var hr) ? hr : 0,
            int.TryParse(fixTime[2..4], out var min) ? min : 0,
            int.TryParse(fixTime[4..6], out var sec) ? sec : 0,
            fixTime.Length > 7 && int.TryParse(fixTime[7..Math.Min(10, fixTime.Length)], out var mill) ? mill : 0
            );

        if (decimal.TryParse(data.ElementAtOrDefault(2), out var latitude)) Latitude = latitude;
        LatitudeDirection = data.ElementAtOrDefault(3)[0];

        if (decimal.TryParse(data.ElementAtOrDefault(4), out var longitude)) Longitude = longitude;
        LongitudeDirection = data.ElementAtOrDefault(5)[0];

        if (int.TryParse(data.ElementAtOrDefault(6), out var fixQuality)) FixQuality = (FixQuality)fixQuality;
        if (int.TryParse(data.ElementAtOrDefault(7), out var numberOfSatellites)) NumberOfSatellites = numberOfSatellites;
        if (decimal.TryParse(data.ElementAtOrDefault(8), out var horizontalDilution)) HorizontalDilution = horizontalDilution;

        if (decimal.TryParse(data.ElementAtOrDefault(9), out var altitude)) Altitude = altitude;
        AltitudeUnits = data.ElementAtOrDefault(10);

        if (decimal.TryParse(data.ElementAtOrDefault(11), out var height)) Height = height;
        HeightUnits = data.ElementAtOrDefault(12);
    }

    public override string ToString() => $@"GPS Fix:{new
    {
        Fix,
        Latitude,
        LatitudeDirection,
        Longitude,
        LongitudeDirection,
        FixQuality,
        NumberOfSatellites,
        HorizontalDilution,
        Altitude,
        AltitudeUnits,
        Height,
        HeightUnits,
    }}";
}