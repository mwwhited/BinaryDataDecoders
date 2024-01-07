# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.Fencer

## Summary

| Key             | Value                                                                |
| :-------------- | :------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.Fencer` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`               |
| Coveredlines    | `1`                                                                  |
| Uncoveredlines  | `8`                                                                  |
| Coverablelines  | `9`                                                                  |
| Totallines      | `22`                                                                 |
| Linecoverage    | `11.1`                                                               |
| Coveredbranches | `0`                                                                  |
| Totalbranches   | `8`                                                                  |
| Branchcoverage  | `0`                                                                  |
| Coveredmethods  | `1`                                                                  |
| Totalmethods    | `5`                                                                  |
| Methodcoverage  | `20`                                                                 |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 100   | 100      | `ToString`      |
| 8          | 0     | 0        | `Equals`        |
| 1          | 0     | 100      | `GetHashCode`   |
| 1          | 0     | 100      | `op_Equality`   |
| 1          | 0     | 100      | `op_Inequality` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/Common/Fencer.cs

```CSharp
〰1:   using System.Diagnostics;
〰2:   
〰3:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
〰4:   
〰5:   [DebuggerDisplay("S{Score} L{Lights} C{Cards} P{Priority}")]
〰6:   public readonly struct Fencer(byte score, Cards cards, Lights lights, bool priority)
〰7:   {
〰8:       public byte Score { get; } = score;
〰9:       public Cards Cards { get; } = cards;
〰10:      public Lights Lights { get; } = lights;
〰11:      public bool Priority { get; } = priority;
〰12:  
✔13:      public override string ToString() => $"S>{Score:000} L>{Lights} C>{Cards} P>{Priority}";
‼14:      public override bool Equals(object obj) => obj switch
‼15:      {
‼16:          Fencer i => Score == i.Score && Cards == i.Cards && Lights == i.Lights && Priority == i.Priority,
‼17:          _ => false
‼18:      };
‼19:      public override int GetHashCode() => (Score, Cards, Lights, Priority).GetHashCode();
‼20:      public static bool operator ==(Fencer left, Fencer right) => left.Equals(right);
‼21:      public static bool operator !=(Fencer left, Fencer right) => !(left == right);
〰22:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

