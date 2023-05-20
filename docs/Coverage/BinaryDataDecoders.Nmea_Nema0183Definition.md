# BinaryDataDecoders.Nmea.Nema0183Definition

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.Nmea.Nema0183Definition` |
| Assembly        | `BinaryDataDecoders.Nmea`                    |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `1`                                          |
| Coverablelines  | `1`                                          |
| Totallines      | `21`                                         |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `0`                                          |
| Coveredmethods  | `0`                                          |
| Totalmethods    | `1`                                          |
| Methodcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `get_SegmentDefintion` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Nmea/Nema0183Definition.cs

```CSharp
〰1:   using BinaryDataDecoders.IO;
〰2:   using BinaryDataDecoders.IO.Messages;
〰3:   using BinaryDataDecoders.IO.Ports;
〰4:   using BinaryDataDecoders.IO.Segmenters;
〰5:   using BinaryDataDecoders.IO.UsbHids;
〰6:   using System.ComponentModel;
〰7:   using System.Composition;
〰8:   using static BinaryDataDecoders.IO.Bytes;
〰9:   
〰10:  namespace BinaryDataDecoders.Nmea
〰11:  {
〰12:      [SerialPort(4800)]
〰13:      [UsbHid(0x1163, 0x200)]
〰14:      [Description("NEMA 0183")]
〰15:      [Export(typeof(IDeviceDefinition))]
〰16:      public class Nema0183Definition : IDeviceDefinitionReceiver<INema0183Message>
〰17:      {
‼18:          public ISegmentBuildDefinition SegmentDefintion => Segment.StartsWith(_S, _E).AndEndsWith(Lf);
〰19:          public IMessageDecoder<INema0183Message> Decoder { get; } = new Nema0183Decoder();
〰20:      }
〰21:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

