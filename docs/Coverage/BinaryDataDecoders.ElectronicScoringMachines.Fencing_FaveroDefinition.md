# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero.FaveroDefinition

## Summary

| Key             | Value                                                                          |
| :-------------- | :----------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero.FaveroDefinition` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                         |
| Coveredlines    | `0`                                                                            |
| Uncoveredlines  | `3`                                                                            |
| Coverablelines  | `3`                                                                            |
| Totallines      | `23`                                                                           |
| Linecoverage    | `0`                                                                            |
| Coveredbranches | `0`                                                                            |
| Totalbranches   | `0`                                                                            |
| Coveredmethods  | `0`                                                                            |
| Totalmethods    | `1`                                                                            |
| Methodcoverage  | `0`                                                                            |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/Favero/FaveroDefinition.cs

```CSharp
〰1:   using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
〰2:   using BinaryDataDecoders.IO;
〰3:   using BinaryDataDecoders.IO.Messages;
〰4:   using BinaryDataDecoders.IO.Ports;
〰5:   using BinaryDataDecoders.IO.Segmenters;
〰6:   using System.ComponentModel;
〰7:   using System.Composition;
〰8:   
〰9:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero;
〰10:  
〰11:  [SerialPort(2400, Parity.None, 8, StopBits.One)]
〰12:  [Description("Favero")]
〰13:  [Export(typeof(IDeviceDefinition))]
〰14:  public class FaveroDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
〰15:  {
〰16:      public ISegmentBuildDefinition SegmentDefintion { get; } =
‼17:          Segment.StartsWith(0xff)
‼18:                 .AndIsLength(10)
‼19:                 .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);
〰20:  
〰21:      public IMessageDecoder<IScoreMachineState> Decoder { get; } = new FaveroDecoder();
〰22:  }
〰23:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

