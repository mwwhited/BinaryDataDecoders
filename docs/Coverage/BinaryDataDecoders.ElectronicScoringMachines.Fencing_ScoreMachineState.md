# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.ScoreMachineState

## Summary

| Key             | Value                                                                           |
| :-------------- | :------------------------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.ScoreMachineState` |
| Assembly        | `BinaryDataDecoders.ElectronicScoringMachines.Fencing`                          |
| Coveredlines    | `11`                                                                            |
| Uncoveredlines  | `7`                                                                             |
| Coverablelines  | `18`                                                                            |
| Totallines      | `37`                                                                            |
| Linecoverage    | `61.1`                                                                          |
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

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ElectronicScoringMachines.Fencing/Common/ScoreMachineState.cs

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
✔19:              Match = match;
✔20:          }
〰21:  
✔22:          public Fencer Left { get; }
✔23:          public Fencer Right { get; }
✔24:          public TimeSpan Clock { get; }
✔25:          public byte Match { get; }
〰26:  
✔27:          public override string ToString() => $"R:{Left} G:{Right} T:{Clock} M:{Match}";
〰28:  
‼29:          public override bool Equals(object obj) => obj switch
‼30:          {
‼31:              IScoreMachineState i => Left.Equals(i.Left) && Right.Equals(i.Right) && Clock.Equals(i.Clock) && Match.Equals(i.Match),
‼32:              _ => false
‼33:          };
〰34:  
‼35:          public override int GetHashCode() => (Left, Right, Clock).GetHashCode();
〰36:      }
〰37:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

