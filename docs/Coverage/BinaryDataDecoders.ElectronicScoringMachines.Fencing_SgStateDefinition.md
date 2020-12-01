# BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateDefinition

## Summary

| Key             | Value                                                                                |
| :-------------- | :----------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateDefinition` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                               |
| Coveredlines    | `0`                                                                                  |
| Uncoveredlines  | `6`                                                                                  |
| Coverablelines  | `6`                                                                                  |
| Totallines      | `23`                                                                                 |
| Linecoverage    | `0`                                                                                  |
| Coveredbranches | `0`                                                                                  |
| Totalbranches   | `0`                                                                                  |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `get_SegmentDefintion` |
| 1          | 0     | 100      | `ctor`                 |
| 1          | 0     | 100      | `get_Decoder`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/SaintGeorge/SgStateDefinition.cs

```CSharp
〰1:   using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
〰2:   using BinaryDataDecoders.IO;
〰3:   using BinaryDataDecoders.IO.Messages;
〰4:   using BinaryDataDecoders.IO.Pipelines;
〰5:   using BinaryDataDecoders.IO.Ports;
〰6:   using BinaryDataDecoders.IO.Segmenters;
〰7:   using System.ComponentModel;
〰8:   
〰9:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge
〰10:  {
〰11:      [SerialPort(9600, Parity.None, 8, StopBits.One)]
〰12:      [Description("Saint George")]
〰13:      public class SgStateDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
〰14:      {
‼15:          public ISegmentBuildDefinition SegmentDefintion { get; } =
‼16:              Segment.StartsWith(ControlCharacters.StartOfHeading)
‼17:                     .AndEndsWith(ControlCharacters.EndOfTransmission)
‼18:                     .WithMaxLength(100)
‼19:                     .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);
〰20:  
‼21:          public IMessageDecoder<IScoreMachineState> Decoder { get; } = new SgStateDecoder();
〰22:      }
〰23:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

