# BinaryDataDecoders.Quarta.RadexOne.RadexOneDefinition

## Summary

| Key             | Value                                                   |
| :-------------- | :------------------------------------------------------ |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.RadexOneDefinition` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne`                    |
| Coveredlines    | `0`                                                     |
| Uncoveredlines  | `4`                                                     |
| Coverablelines  | `4`                                                     |
| Totallines      | `25`                                                    |
| Linecoverage    | `0`                                                     |
| Coveredbranches | `0`                                                     |
| Totalbranches   | `0`                                                     |
| Coveredmethods  | `0`                                                     |
| Totalmethods    | `1`                                                     |
| Methodcoverage  | `0`                                                     |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne/RadexOneDefinition.cs

```CSharp
〰1:   using BinaryDataDecoders.IO;
〰2:   using BinaryDataDecoders.IO.Messages;
〰3:   using BinaryDataDecoders.IO.Ports;
〰4:   using BinaryDataDecoders.IO.Segmenters;
〰5:   using System.ComponentModel;
〰6:   using System.Composition;
〰7:   
〰8:   namespace BinaryDataDecoders.Quarta.RadexOne
〰9:   {
〰10:      [SerialPort(9600)]
〰11:      [Description("Radex One")]
〰12:      [Export(typeof(IDeviceDefinition))]
〰13:      public class RadexOneDefinition : IDeviceDefinitionTransmitter<IRadexObject>, IDeviceDefinitionReceiver<IRadexObject>
〰14:      {
〰15:          public IMessageEncoder<IRadexObject> Encoder { get; } = new MessageEncoder<IRadexObject>();
〰16:  
〰17:          public ISegmentBuildDefinition SegmentDefintion { get; } =
‼18:              Segment.StartsWith(0x7a)
‼19:                     .AndIsLength(12)
‼20:                     .ExtendedWithLengthAt<ushort>(4, Endianness.Little)
‼21:                     .WithOptions(SegmentionOptions.SkipInvalidSegment);
〰22:  
〰23:          public IMessageDecoder<IRadexObject> Decoder { get; } = new RadexOneDecoder();
〰24:      }
〰25:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

