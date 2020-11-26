# BinaryDataDecoders.ToolKit.Input.DelegateCommand

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Input.DelegateCommand` |
| Assembly        | `BinaryDataDecoders.ToolKit`                       |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `9`                                                |
| Coverablelines  | `9`                                                |
| Totallines      | `31`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `2`                                                |
| Branchcoverage  | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 0     | 100      | `ctor`       |
| 2          | 0     | 0        | `CanExecute` |
| 1          | 0     | 100      | `Execute`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Input/DelegateCommand.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Input
〰4:   {
〰5:       public class DelegateCommand : CommandBase
〰6:       {
〰7:           private readonly Predicate<object> _canExecute;
〰8:           private readonly Action<object> _execute;
〰9:   
‼10:          public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
〰11:          {
‼12:              _execute = execute;
‼13:              _canExecute = canExecute;
‼14:          }
〰15:  
〰16:          public override bool CanExecute(object parameter)
〰17:          {
‼18:              if (_canExecute == null)
〰19:              {
‼20:                  return true;
〰21:              }
〰22:  
‼23:              return _canExecute(parameter);
〰24:          }
〰25:  
〰26:          public override void Execute(object parameter)
〰27:          {
‼28:              _execute(parameter);
‼29:          }
〰30:      }
〰31:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

