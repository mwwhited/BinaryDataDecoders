# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero.FaveroDefinition

## Summary

| Key             | Value                                                                          |
| :-------------- | :----------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero.FaveroDefinition` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                         |
| Coveredlines    | `0`                                                                            |
| Uncoveredlines  | `5`                                                                            |
| Coverablelines  | `5`                                                                            |
| Totallines      | `22`                                                                           |
| Linecoverage    | `0`                                                                            |
| Coveredbranches | `0`                                                                            |
| Totalbranches   | `0`                                                                            |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `get_SegmentDefintion` |
| 1          | 0     | 100      | `ctor`                 |
| 1          | 0     | 100      | `get_Decoder`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/Favero/FaveroDefinition.cs

```CSharp
〰1:   using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
〰2:   using BinaryDataDecoders.IO;
〰3:   using BinaryDataDecoders.IO.Messages;
〰4:   using BinaryDataDecoders.IO.Pipelines;
〰5:   using BinaryDataDecoders.IO.Ports;
〰6:   using BinaryDataDecoders.IO.Segmenters;
〰7:   using System.ComponentModel;
〰8:   
〰9:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero
〰10:  {
〰11:      [SerialPort(2400, Parity.None, 8, StopBits.One)]
〰12:      [Description("Favero")]
〰13:      public class FaveroDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
〰14:      {
‼15:          public ISegmentBuildDefinition SegmentDefintion { get; } =
‼16:              Segment.StartsWith(0xff)
‼17:                     .AndIsLength(10)
‼18:                     .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);
〰19:  
‼20:          public IMessageDecoder<IScoreMachineState> Decoder { get; } = new FaveroDecoder();
〰21:      }
〰22:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

