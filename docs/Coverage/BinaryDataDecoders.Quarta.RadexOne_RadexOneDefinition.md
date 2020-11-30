# BinaryDataDecoders.Quarta.RadexOne.RadexOneDefinition

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.RadexOneDefinition` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                    |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `7`                                                     |
| Coverablelines  | `7`                                                     |
| Totallines      | `24`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `get_Encoder`          |
| 1          | 0     | 100      | `get_SegmentDefintion` |
| 1          | 0     | 100      | `ctor`                 |
| 1          | 0     | 100      | `get_Decoder`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/RadexOneDefinition.cs

```CSharp
〰1:   using BinaryDataDecoders.IO;
〰2:   using BinaryDataDecoders.IO.Messages;
〰3:   using BinaryDataDecoders.IO.Pipelines;
〰4:   using BinaryDataDecoders.IO.Ports;
〰5:   using BinaryDataDecoders.IO.Segmenters;
〰6:   using System.ComponentModel;
〰7:   
〰8:   namespace BinaryDataDecoders.Quarta.RadexOne
〰9:   {
〰10:      [SerialPort(9600)]
〰11:      [Description("Radex One")]
〰12:      public class RadexOneDefinition : IDeviceDefinitionTransmitter<IRadexObject>, IDeviceDefinitionReceiver<IRadexObject>
〰13:      {
‼14:          public IMessageEncoder<IRadexObject> Encoder { get; } = new MessageEncoder<IRadexObject>();
〰15:  
‼16:          public ISegmentBuildDefinition SegmentDefintion { get; } =
‼17:              Segment.StartsWith(0x7a)
‼18:                     .AndIsLength(12)
‼19:                     .ExtendedWithLengthAt<ushort>(4, Endianness.Little)
‼20:                     .WithOptions(SegmentionOptions.SkipInvalidSegment);
〰21:  
‼22:          public IMessageDecoder<IRadexObject> Decoder { get; } = new RadexOneDecoder();
〰23:      }
〰24:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

