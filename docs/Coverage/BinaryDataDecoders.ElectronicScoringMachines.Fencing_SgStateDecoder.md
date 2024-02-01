# BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateDecoder

## Summary

| Key             | Value                                                                             |
| :-------------- | :-------------------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge.SgStateDecoder` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                            |
| Coveredlines    | `0`                                                                               |
| Uncoveredlines  | `4`                                                                               |
| Coverablelines  | `4`                                                                               |
| Totallines      | `18`                                                                              |
| Linecoverage    | `0`                                                                               |
| Coveredbranches | `0`                                                                               |
| Totalbranches   | `0`                                                                               |
| Coveredmethods  | `0`                                                                               |
| Totalmethods    | `2`                                                                               |
| Methodcoverage  | `0`                                                                               |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 1          | 0     | 100      | `ctor`   |
| 1          | 0     | 100      | `Decode` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/SaintGeorge/SgStateDecoder.cs

```CSharp
〰1:   using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
〰2:   using BinaryDataDecoders.IO.Messages;
〰3:   using System;
〰4:   using System.Buffers;
〰5:   
〰6:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge;
〰7:   
〰8:   public class SgStateDecoder : IMessageDecoder<IScoreMachineState>
〰9:   {
‼10:      private readonly IParseScoreMachineState _parser = new SgStateParser();
〰11:  
〰12:      public IScoreMachineState Decode(ReadOnlySequence<byte> response)
〰13:      {
‼14:          Span<byte> buffer = new byte[response.Length];
‼15:          response.CopyTo(buffer);
‼16:          return _parser.Parse(buffer);
〰17:      }
〰18:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

