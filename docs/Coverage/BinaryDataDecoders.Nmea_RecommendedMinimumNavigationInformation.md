# BinaryDataDecoders.Nmea.RecommendedMinimumNavigationInformation

## Summary

| Key             | Value                                                             |
| :-------------- | :---------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.Nmea.RecommendedMinimumNavigationInformation` |
| Assembly        | `BinaryDataDecoders.Nmea`                                         |
| Coveredlines    | `0`                                                               |
| Uncoveredlines  | `9`                                                               |
| Coverablelines  | `9`                                                               |
| Totallines      | `55`                                                              |
| Linecoverage    | `0`                                                               |
| Coveredbranches | `0`                                                               |
| Totalbranches   | `10`                                                              |
| Branchcoverage  | `0`                                                               |
| Coveredmethods  | `0`                                                               |
| Totalmethods    | `1`                                                               |
| Methodcoverage  | `0`                                                               |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 10         | 0     | 0        | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/RecommendedMinimumNavigationInformation.cs

```CSharp
〰1:   using System;
〰2:   using System.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.Nmea;
〰5:   
〰6:   public class RecommendedMinimumNavigationInformation : INema0183Message
〰7:   {
〰8:       /*
〰9:       RMC - Recommended Minimum Navigation Information
〰10:      This is one of the sentences commonly emitted by GPS units.
〰11:  
〰12:                                                                12
〰13:              1         2 3       4 5        6  7   8   9    10 11|  13
〰14:              |         | |       | |        |  |   |   |    |  | |   |
〰15:       $--RMC,hhmmss.ss,A,llll.ll,a,yyyyy.yy,a,x.x,x.x,xxxx,x.x,a,m,*hh<CR><LF>
〰16:      Field Number:
〰17:  
〰18:      UTC Time of position
〰19:  
〰20:      Status, A = Valid, V = Warning
〰21:      Latitude        N or S
〰22:      Longitude        E or W
〰23:      Speed over ground, knots
〰24:      Track made good, degrees true
〰25:      Date, ddmmyy
〰26:      Magnetic Variation, degrees        E or W
〰27:      FAA mode indicator (NMEA 2.3 and later)
〰28:      Checksum
〰29:  
〰30:      A status of V means the GPS has a valid fix that is below an internal quality threshold, e.g. because the dilution of precision is too high or an elevation mask test failed.
〰31:  
〰32:      Example: $GNRMC,001031.00,A,4404.13993,N,12118.86023,W,0.146,,100117,,,A*7B
〰33:  
〰34:  $GPRMC,090033.000,V,3957.088,N,08259.335,W,0.0,0.0,220600,0.0,E*69
〰35:  $GPRMC,090035.000,V,3957.088,N,08259.335,W,0.0,0.0,220600,0.0,E*6F
〰36:  $GPRMC,090034.000,V,3957.088,N,08259.335,W,0.0,0.0,220600,0.0,E*6E
〰37:      */
〰38:      public TimeSpan Fix { get; }
〰39:      public RecommendedMinimumNavigationInformation(string[] data)
〰40:      {
‼41:          var fixTime = data.ElementAtOrDefault(1) ?? "0000000000";
‼42:          Fix = new TimeSpan(
‼43:              0,
‼44:              int.TryParse(fixTime[0..2], out var hr) ? hr : 0,
‼45:              int.TryParse(fixTime[2..4], out var min) ? min : 0,
‼46:              int.TryParse(fixTime[4..6], out var sec) ? sec : 0,
‼47:              int.TryParse(fixTime[7..10], out var mill) ? mill : 0
‼48:              );
〰49:  
〰50:          //TODO: needs filled out
〰51:  
〰52:          //if (decimal.TryParse(data.ElementAtOrDefault(2), out var latitude)) Latitude = latitude;
〰53:          //LatitudeDirection = data.ElementAtOrDefault(3)[0];
‼54:      }
〰55:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

