# BinaryDataDecoders.Nmea.GpsDopAndActiveSatellites

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.Nmea.GpsDopAndActiveSatellites` |
| Assembly        | `BinaryDataDecoders.Nmea`                           |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `21`                                                |
| Coverablelines  | `21`                                                |
| Totallines      | `89`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `12`                                                |
| Branchcoverage  | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `2`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 12         | 0     | 0        | `ctor`     |
| 1          | 0     | 100      | `ToString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/GpsDopAndActiveSatellites.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.Nmea;
〰6:   
〰7:   public enum SelectionModes
〰8:   {
〰9:       Manual = 0,
〰10:      Automatic = 1,
〰11:  }
〰12:  public enum FixModes
〰13:  {
〰14:      Unknown = 0,
〰15:      FixNone = 1,
〰16:      Fix2D = 2,
〰17:      Fix3D = 3,
〰18:  }
〰19:  public class GpsDopAndActiveSatellites : INema0183Message
〰20:  {
〰21:      /*
〰22:      GSA - GPS DOP and active satellites
〰23:      This is one of the sentences commonly emitted by GPS units.
〰24:  
〰25:  	        1 2 3                        14 15  16  17  18
〰26:  	        | | |                         |  |   |   |   |
〰27:       $--GSA,a,a,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x.x,x.x,x.x*hh<CR><LF>
〰28:      Field Number:
〰29:  
〰30:      Selection mode: M=Manual, forced to operate in 2D or 3D, A=Automatic, 2D/3D
〰31:      Mode (1 = no fix, 2 = 2D fix, 3 = 3D fix)
〰32:      ID of 1st satellite used for fix
〰33:      ID of 2nd satellite used for fix
〰34:      ID of 3rd satellite used for fix
〰35:      ID of 4th satellite used for fix
〰36:      ID of 5th satellite used for fix
〰37:      ID of 6th satellite used for fix
〰38:      ID of 7th satellite used for fix
〰39:      ID of 8th satellite used for fix
〰40:      ID of 9th satellite used for fix
〰41:      ID of 10th satellite used for fix
〰42:      ID of 11th satellite used for fix
〰43:      ID of 12th satellite used for fix
〰44:      PDOP
〰45:      HDOP
〰46:      VDOP
〰47:      Checksum
〰48:      Example: $GNGSA,A,3,80,71,73,79,69,,,,,,,,1.83,1.09,1.47*17
〰49:      Note: NMEA 4.1+ systems (in particular u-blox 9) emit an extra field just before the checksum.
〰50:  
〰51:      1 = GPS L1C/A, L2CL, L2CM
〰52:      2 = GLONASS L1 OF, L2 OF
〰53:      3 = Galileo E1C, E1B, E5 bl, E5 bQ
〰54:      4 = BeiDou B1I D1, B1I D2, B2I D1, B2I D12
〰55:  
〰56:      */
〰57:      public SelectionModes Selection { get; }
〰58:      public FixModes Fix { get; }
〰59:      public IReadOnlyList<string> Satellites { get; }
〰60:      public decimal PDOP { get; }
〰61:      public decimal HDOP { get; }
〰62:      public decimal VDOP { get; }
〰63:  
〰64:  
〰65:      public GpsDopAndActiveSatellites(string[] data)
〰66:      {
‼67:          Selection = data[1] switch
‼68:          {
‼69:              "M" => SelectionModes.Manual,
‼70:              "A" => SelectionModes.Automatic,
‼71:              _ => throw new NotSupportedException($"{nameof(Selection)}: {data[1]}")
‼72:          };
‼73:          Fix = int.TryParse(data[2], out var fixMode) ? (FixModes)fixMode : 0;
‼74:          Satellites = data[3..15].ToList().AsReadOnly();
‼75:          PDOP = decimal.TryParse(data[16], out var pdop) ? pdop : 0m;
‼76:          HDOP = decimal.TryParse(data[16], out var hdop) ? hdop : 0m;
‼77:          VDOP = decimal.TryParse(data[16], out var vdop) ? vdop : 0m;
‼78:      }
〰79:  
‼80:      public override string ToString() => $@"GPS DOP: {new
‼81:      {
‼82:          Selection,
‼83:          Fix,
‼84:          Satellites = string.Join(';',Satellites),
‼85:          PDOP,
‼86:          HDOP,
‼87:          VDOP,
‼88:      }}";
〰89:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

