# BinaryDataDecoders.Quarta.RadexOne.RadexOneDefinition

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.RadexOneDefinition` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                    |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `7`                                                     |
| Coverablelines  | `7`                                                     |
| Totallines      | `26`                                                    |
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
〰7:   using System.Composition;
〰8:   
〰9:   namespace BinaryDataDecoders.Quarta.RadexOne
〰10:  {
〰11:      [SerialPort(9600)]
〰12:      [Description("Radex One")]
〰13:      [Export(typeof(IDeviceDefinition))]
〰14:      public class RadexOneDefinition : IDeviceDefinitionTransmitter<IRadexObject>, IDeviceDefinitionReceiver<IRadexObject>
〰15:      {
‼16:          public IMessageEncoder<IRadexObject> Encoder { get; } = new MessageEncoder<IRadexObject>();
〰17:  
‼18:          public ISegmentBuildDefinition SegmentDefintion { get; } =
‼19:              Segment.StartsWith(0x7a)
‼20:                     .AndIsLength(12)
‼21:                     .ExtendedWithLengthAt<ushort>(4, Endianness.Little)
‼22:                     .WithOptions(SegmentionOptions.SkipInvalidSegment);
〰23:  
‼24:          public IMessageDecoder<IRadexObject> Decoder { get; } = new RadexOneDecoder();
〰25:      }
〰26:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

