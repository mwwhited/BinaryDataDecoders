# BinaryDataDecoders.Nmea.GlobalPositioningFixData

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.Nmea.GlobalPositioningFixData` |
| Assembly        | `BinaryDataDecoders.Nmea`                          |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `48`                                               |
| Coverablelines  | `48`                                               |
| Totallines      | `93`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `24`                                               |
| Branchcoverage  | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name                     |
| :--------- | :---- | :------- | :----------------------- |
| 1          | 0     | 100      | `get_Fix`                |
| 1          | 0     | 100      | `get_Latitude`           |
| 1          | 0     | 100      | `get_LatitudeDirection`  |
| 1          | 0     | 100      | `get_Longitude`          |
| 1          | 0     | 100      | `get_LongitudeDirection` |
| 1          | 0     | 100      | `get_FixQuality`         |
| 1          | 0     | 100      | `get_NumberOfSatellites` |
| 1          | 0     | 100      | `get_HorizontalDilution` |
| 1          | 0     | 100      | `get_Altitude`           |
| 1          | 0     | 100      | `get_AltitudeUnits`      |
| 1          | 0     | 100      | `get_Height`             |
| 1          | 0     | 100      | `get_HeightUnits`        |
| 24         | 0     | 0        | `ctor`                   |
| 1          | 0     | 100      | `ToString`               |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/GlobalPositioningFixData.cs

```CSharp
〰1:   using System;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.Nmea
〰5:   {
〰6:       public class GlobalPositioningFixData : INema0183Message
〰7:       {
〰8:           /*
〰9:           GGA - essential fix data which provide 3D location and accuracy data.
〰10:          $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47
〰11:  
〰12:          Where:
〰13:               GGA          Global Positioning System Fix Data
〰14:               123519       Fix taken at 12:35:19 UTC
〰15:               4807.038,N   Latitude 48 deg 07.038' N
〰16:               01131.000,E  Longitude 11 deg 31.000' E
〰17:               1            Fix quality: 0 = invalid
〰18:                                         1 = GPS fix (SPS)
〰19:                                         2 = DGPS fix
〰20:                                         3 = PPS fix
〰21:  			                           4 = Real Time Kinematic
〰22:  			                           5 = Float RTK
〰23:                                         6 = estimated (dead reckoning) (2.3 feature)
〰24:  			                           7 = Manual input mode
〰25:  			                           8 = Simulation mode
〰26:               08           Number of satellites being tracked
〰27:               0.9          Horizontal dilution of position
〰28:               545.4,M      Altitude, Meters, above mean sea level
〰29:               46.9,M       Height of geoid (mean sea level) above WGS84
〰30:                                ellipsoid
〰31:               (empty field) time in seconds since last DGPS update
〰32:               (empty field) DGPS station ID number
〰33:               *47          the checksum data, always begins with
〰34:          */
〰35:  
‼36:          public TimeSpan Fix { get; }
‼37:          public decimal Latitude { get; }
‼38:          public char LatitudeDirection { get; }
‼39:          public decimal Longitude { get; }
‼40:          public char LongitudeDirection { get; }
‼41:          public FixQuality FixQuality { get; }
‼42:          public int NumberOfSatellites { get; }
‼43:          public decimal HorizontalDilution { get; }
‼44:          public decimal Altitude { get; }
‼45:          public string AltitudeUnits { get; }
‼46:          public decimal Height { get; }
‼47:          public string HeightUnits { get; }
〰48:  
‼49:          public GlobalPositioningFixData(string[] data)
〰50:          {
‼51:              var fixTime = data.ElementAtOrDefault(1) ?? "0000000000";
‼52:              Fix = new TimeSpan(
‼53:                  0,
‼54:                  int.TryParse(fixTime[0..2], out var hr) ? hr : 0,
‼55:                  int.TryParse(fixTime[2..4], out var min) ? min : 0,
‼56:                  int.TryParse(fixTime[4..6], out var sec) ? sec : 0,
‼57:                  int.TryParse(fixTime[7..10], out var mill) ? mill : 0
‼58:                  );
〰59:  
‼60:              if (decimal.TryParse(data.ElementAtOrDefault(2), out var latitude)) Latitude = latitude;
‼61:              LatitudeDirection = data.ElementAtOrDefault(3)[0];
〰62:  
‼63:              if (decimal.TryParse(data.ElementAtOrDefault(4), out var longitude)) Longitude = longitude;
‼64:              LongitudeDirection = data.ElementAtOrDefault(5)[0];
〰65:  
‼66:              if (int.TryParse(data.ElementAtOrDefault(6), out var fixQuality)) FixQuality = (FixQuality)fixQuality;
‼67:              if (int.TryParse(data.ElementAtOrDefault(7), out var numberOfSatellites)) NumberOfSatellites = numberOfSatellites;
‼68:              if (decimal.TryParse(data.ElementAtOrDefault(8), out var horizontalDilution)) HorizontalDilution = horizontalDilution;
〰69:  
‼70:              if (decimal.TryParse(data.ElementAtOrDefault(9), out var altitude)) Altitude = altitude;
‼71:              AltitudeUnits = data.ElementAtOrDefault(10);
〰72:  
‼73:              if (decimal.TryParse(data.ElementAtOrDefault(11), out var height)) Height = height;
‼74:              HeightUnits = data.ElementAtOrDefault(12);
‼75:          }
〰76:  
‼77:          public override string ToString() => $@"GPS Fix:{new
‼78:          {
‼79:              Fix,
‼80:              Latitude,
‼81:              LatitudeDirection,
‼82:              Longitude,
‼83:              LongitudeDirection,
‼84:              FixQuality,
‼85:              NumberOfSatellites,
‼86:              HorizontalDilution,
‼87:              Altitude,
‼88:              AltitudeUnits,
‼89:              Height,
‼90:              HeightUnits,
‼91:          }}";
〰92:      }
〰93:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

