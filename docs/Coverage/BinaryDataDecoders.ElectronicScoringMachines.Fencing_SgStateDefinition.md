# BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateDefinition

## Summary

| Key             | Value                                                                                |
| :-------------- | :----------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateDefinition` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                               |
| Coveredlines    | `0`                                                                                  |
| Uncoveredlines  | `4`                                                                                  |
| Coverablelines  | `4`                                                                                  |
| Totallines      | `25`                                                                                 |
| Linecoverage    | `0`                                                                                  |
| Coveredbranches | `0`                                                                                  |
| Totalbranches   | `0`                                                                                  |
| Coveredmethods  | `0`                                                                                  |
| Totalmethods    | `1`                                                                                  |
| Methodcoverage  | `0`                                                                                  |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

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
〰8:   using System.Composition;
〰9:   
〰10:  namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge
〰11:  {
〰12:      [SerialPort(9600, Parity.None, 8, StopBits.One)]
〰13:      [Description("Saint George")]
〰14:      [Export(typeof(IDeviceDefinition))]
〰15:      public class SgStateDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
〰16:      {
〰17:          public ISegmentBuildDefinition SegmentDefintion { get; } =
‼18:              Segment.StartsWith(ControlCharacters.StartOfHeading)
‼19:                     .AndEndsWith(ControlCharacters.EndOfTransmission)
‼20:                     .WithMaxLength(100)
‼21:                     .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);
〰22:  
〰23:          public IMessageDecoder<IScoreMachineState> Decoder { get; } = new SgStateDecoder();
〰24:      }
〰25:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

