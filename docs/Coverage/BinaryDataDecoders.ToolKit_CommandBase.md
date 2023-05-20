# BinaryDataDecoders.ToolKit.Input.CommandBase

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Input.CommandBase` |
| Assembly        | `BinaryDataDecoders.ToolKit`                   |
| Coveredlines    | `0`                                            |
| Uncoveredlines  | `3`                                            |
| Coverablelines  | `3`                                            |
| Totallines      | `21`                                           |
| Linecoverage    | `0`                                            |
| Coveredbranches | `0`                                            |
| Totalbranches   | `2`                                            |
| Branchcoverage  | `0`                                            |
| Coveredmethods  | `0`                                            |
| Totalmethods    | `2`                                            |
| Methodcoverage  | `0`                                            |

## Metrics

| Complexity | Lines | Branches | Name                     |
| :--------- | :---- | :------- | :----------------------- |
| 1          | 0     | 100      | `CanExecute`             |
| 2          | 0     | 0        | `RaiseCanExecuteChanged` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Input/CommandBase.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Input
〰4:   {
〰5:       public abstract class CommandBase : ICommand
〰6:       {
〰7:           public virtual bool CanExecute(object parameter)
〰8:           {
‼9:               return true;
〰10:          }
〰11:  
〰12:          public event EventHandler CanExecuteChanged;
〰13:  
〰14:          public virtual void RaiseCanExecuteChanged()
〰15:          {
‼16:              this.CanExecuteChanged?.Invoke(this, new EventArgs());
‼17:          }
〰18:  
〰19:          public abstract void Execute(object parameter);
〰20:      }
〰21:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

