# BinaryDataDecoders.Nmea.Nema0183Definition

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Nmea.Nema0183Definition` |
| Assembly        | `BinaryDataDecoders.Nmea`                    |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `2`                                          |
| Coverablelines  | `2`                                          |
| Totallines      | `19`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `get_SegmentDefintion` |
| 1          | 0     | 100      | `get_Decoder`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/Nema0183Definition.cs

```CSharp
〰1:   using BinaryDataDecoders.IO;
〰2:   using BinaryDataDecoders.IO.Messages;
〰3:   using BinaryDataDecoders.IO.Ports;
〰4:   using BinaryDataDecoders.IO.Segmenters;
〰5:   using BinaryDataDecoders.IO.UsbHids;
〰6:   using System.ComponentModel;
〰7:   using static BinaryDataDecoders.IO.Bytes;
〰8:   
〰9:   namespace BinaryDataDecoders.Nmea
〰10:  {
〰11:      [SerialPort(4800)]
〰12:      [UsbHid(0x1163, 0x200)]
〰13:      [Description("NEMA 0183")]
〰14:      public class Nema0183Definition : IDeviceDefinitionReceiver<INema0183Message>
〰15:      {
‼16:          public ISegmentBuildDefinition SegmentDefintion => Segment.StartsWith(_S, _E).AndEndsWith(Lf);
‼17:          public IMessageDecoder<INema0183Message> Decoder { get; } = new Nema0183Decoder();
〰18:      }
〰19:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

