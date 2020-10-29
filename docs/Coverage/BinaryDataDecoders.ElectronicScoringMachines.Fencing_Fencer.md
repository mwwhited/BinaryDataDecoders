
# BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common.Fencer
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ElectronicScoringMachines.Fencing_Fencer.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common. | 
| Assembly             | BinaryDataDecoders.ElectronicScoringMachines.Fencing         | 
| Coveredlines         | 6                                                            | 
| Uncoveredlines       | 4                                                            | 
| Coverablelines       | 10                                                           | 
| Totallines           | 46                                                           | 
| Linecoverage         | 60                                                           | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 8                                                            | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\Common\Fencer.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 100   | 100      | ctor | 
| 1          | 100   | 100      | ToString | 
| 8          | 0     | 0        | Equals | 
| 1          | 0     | 100      | GetHashCode | 
| 1          | 0     | 100      | op_Equality | 
| 1          | 0     | 100      | op_Inequality | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ElectronicScoringMachines.Fencing\Common\Fencer.cs

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
〰16:          public byte Score { get; }
〰17:          public Cards Cards { get; }
〰18:          public Lights Lights { get; }
〰19:          public bool Priority { get; }
〰20:  
〰21:          public override string ToString()
〰22:          {
✔23:              return $"S>{Score:000} L>{Lights} C>{Cards} P>{Priority}";
〰24:          }
〰25:  
〰26:          public override bool Equals(object obj)
〰27:          {
‼28:              return obj is Fencer i && Score == i.Score && Cards == i.Cards && Lights == i.Lights && Priority == i.Priority;
〰29:          }
〰30:  
〰31:          public override int GetHashCode()
〰32:          {
‼33:              return (Score, Cards, Lights, Priority).GetHashCode();
〰34:          }
〰35:  
〰36:          public static bool operator ==(Fencer left, Fencer right)
〰37:          {
‼38:              return left.Equals(right);
〰39:          }
〰40:  
〰41:          public static bool operator !=(Fencer left, Fencer right)
〰42:          {
‼43:              return !(left == right);
〰44:          }
〰45:      }
〰46:  }

```
## Footer 
[Return to Summary](Summary.md)

