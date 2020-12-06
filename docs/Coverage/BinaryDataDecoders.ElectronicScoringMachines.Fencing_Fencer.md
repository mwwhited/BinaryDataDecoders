# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.Fencer

## Summary

| Key             | Value                                                                |
| :-------------- | :------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.Fencer` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`               |
| Coveredlines    | `10`                                                                 |
| Uncoveredlines  | `8`                                                                  |
| Coverablelines  | `18`                                                                 |
| Totallines      | `31`                                                                 |
| Linecoverage    | `55.5`                                                               |
| Coveredbranches | `0`                                                                  |
| Totalbranches   | `8`                                                                  |
| Branchcoverage  | `0`                                                                  |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 100   | 100      | `ctor`          |
| 1          | 100   | 100      | `get_Score`     |
| 1          | 100   | 100      | `get_Cards`     |
| 1          | 100   | 100      | `get_Lights`    |
| 1          | 100   | 100      | `get_Priority`  |
| 1          | 100   | 100      | `ToString`      |
| 8          | 0     | 0        | `Equals`        |
| 1          | 0     | 100      | `GetHashCode`   |
| 1          | 0     | 100      | `op_Equality`   |
| 1          | 0     | 100      | `op_Inequality` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/Common/Fencer.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   
〰3:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
〰4:   {
〰5:       [DebuggerDisplay("S{Score} L{Lights} C{Cards} P{Priority}")]
〰6:       public struct Fencer
〰7:       {
〰8:           public Fencer(byte score, Cards cards, Lights lights, bool priority)
〰9:           {
✔10:              Score = score;
✔11:              Cards = cards;
✔12:              Lights = lights;
✔13:              Priority = priority;
✔14:          }
〰15:  
✔16:          public byte Score { get; }
✔17:          public Cards Cards { get; }
✔18:          public Lights Lights { get; }
✔19:          public bool Priority { get; }
〰20:  
✔21:          public override string ToString() => $"S>{Score:000} L>{Lights} C>{Cards} P>{Priority}";
‼22:          public override bool Equals(object obj) => obj switch
‼23:          {
‼24:              Fencer i => Score == i.Score && Cards == i.Cards && Lights == i.Lights && Priority == i.Priority,
‼25:              _ => false
‼26:          };
‼27:          public override int GetHashCode() => (Score, Cards, Lights, Priority).GetHashCode();
‼28:          public static bool operator ==(Fencer left, Fencer right) => left.Equals(right);
‼29:          public static bool operator !=(Fencer left, Fencer right) => !(left == right);
〰30:      }
〰31:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

