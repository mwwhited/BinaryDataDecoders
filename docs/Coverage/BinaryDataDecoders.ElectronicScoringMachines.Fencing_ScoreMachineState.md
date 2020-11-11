# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.ScoreMachineState

## Summary

| Key             | Value                                                                           |
| :-------------- | :------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.ScoreMachineState` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                          |
| Coveredlines    | `10`                                                                            |
| Uncoveredlines  | `3`                                                                             |
| Coverablelines  | `13`                                                                            |
| Totallines      | `41`                                                                            |
| Linecoverage    | `76.9`                                                                          |
| Coveredbranches | `0`                                                                             |
| Totalbranches   | `8`                                                                             |
| Branchcoverage  | `0`                                                                             |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `cctor`       |
| 1          | 100   | 100      | `ctor`        |
| 1          | 100   | 100      | `get_Left`    |
| 1          | 100   | 100      | `get_Right`   |
| 1          | 100   | 100      | `get_Clock`   |
| 1          | 100   | 100      | `get_Match`   |
| 1          | 100   | 100      | `ToString`    |
| 8          | 0     | 0        | `Equals`      |
| 1          | 0     | 100      | `GetHashCode` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\Common\ScoreMachineState.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
〰4:   {
〰5:       public class ScoreMachineState : IScoreMachineState
〰6:       {
‼7:           public static readonly IScoreMachineState Empty = new ScoreMachineState(default, default, default, default);
〰8:   
〰9:           /// <summary>
〰10:          /// </summary>
〰11:          /// <param name="left">Left</param>
〰12:          /// <param name="right">Right</param>
〰13:          /// <param name="clock"></param>
✔14:          public ScoreMachineState(Fencer left, Fencer right, TimeSpan clock, byte match)
〰15:          {
✔16:              Left = left;
✔17:              Right = right;
✔18:              Clock = clock;
✔19:          }
〰20:  
✔21:          public Fencer Left { get; }
✔22:          public Fencer Right { get; }
✔23:          public TimeSpan Clock { get; }
✔24:          public byte Match { get; }
〰25:  
〰26:          public override string ToString()
〰27:          {
✔28:              return $"R:{Left} G:{Right} T:{Clock} M:{Match}";
〰29:          }
〰30:  
〰31:          public override bool Equals(object obj)
〰32:          {
‼33:              return obj is IScoreMachineState i && Left.Equals(i.Left) && Right.Equals(i.Right) && Clock.Equals(i.Clock) && Match.Equals(i.Match);
〰34:          }
〰35:  
〰36:          public override int GetHashCode()
〰37:          {
‼38:              return (Left, Right, Clock).GetHashCode();
〰39:          }
〰40:      }
〰41:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

