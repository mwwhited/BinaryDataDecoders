# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.ScoreMachineState

## Summary

| Key             | Value                                                                           |
| :-------------- | :------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.ScoreMachineState` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                          |
| Coveredlines    | `1`                                                                             |
| Uncoveredlines  | `7`                                                                             |
| Coverablelines  | `8`                                                                             |
| Totallines      | `29`                                                                            |
| Linecoverage    | `12.5`                                                                          |
| Coveredbranches | `0`                                                                             |
| Totalbranches   | `8`                                                                             |
| Branchcoverage  | `0`                                                                             |
| Coveredmethods  | `1`                                                                             |
| Totalmethods    | `4`                                                                             |
| Methodcoverage  | `25`                                                                            |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `cctor`       |
| 1          | 100   | 100      | `ToString`    |
| 8          | 0     | 0        | `Equals`      |
| 1          | 0     | 100      | `GetHashCode` |

## Files

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/Common/ScoreMachineState.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
〰4:   
〰5:   /// <summary>
〰6:   /// </summary>
〰7:   /// <param name="left">Left</param>
〰8:   /// <param name="right">Right</param>
〰9:   /// <param name="clock"></param>
〰10:  public class ScoreMachineState(Fencer left, Fencer right, TimeSpan clock, byte match) : IScoreMachineState
〰11:  {
‼12:      public static readonly IScoreMachineState Empty = new ScoreMachineState(default, default, default, default);
〰13:  
〰14:      public Fencer Left { get; } = left;
〰15:      public Fencer Right { get; } = right;
〰16:      public TimeSpan Clock { get; } = clock;
〰17:      public byte Match { get; } = match;
〰18:  
✔19:      public override string ToString() => $"R:{Left} G:{Right} T:{Clock} M:{Match}";
〰20:  
‼21:      public override bool Equals(object obj) => obj switch
‼22:      {
‼23:          IScoreMachineState i => Left.Equals(i.Left) && Right.Equals(i.Right) && Clock.Equals(i.Clock) && Match.Equals(i.Match),
‼24:          _ => false
‼25:      };
〰26:  
‼27:      public override int GetHashCode() => (Left, Right, Clock).GetHashCode();
〰28:  }
〰29:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

