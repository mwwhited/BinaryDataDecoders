# BinaryDataDecoders.ToolKit.Input.DelegateCommand

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Input.DelegateCommand` |
| Assembly        | `BinaryDataDecoders.ToolKit`                       |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `6`                                                |
| Coverablelines  | `6`                                                |
| Totallines      | `25`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `4`                                                |
| Branchcoverage  | `0`                                                |
| Coveredmethods  | `0`                                                |
| Totalmethods    | `6`                                                |
| Methodcoverage  | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 1          | 0     | 100      | `ctor`       |
| 2          | 0     | 0        | `CanExecute` |
| 1          | 0     | 100      | `Execute`    |
| 1          | 0     | 100      | `ctor`       |
| 2          | 0     | 0        | `CanExecute` |
| 1          | 0     | 100      | `Execute`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Input/DelegateCommand.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Input;
〰4:   
‼5:   public class DelegateCommand(Action<object?> execute, Predicate<object?>? canExecute = default) : CommandBase
〰6:   {
〰7:       public override bool CanExecute(object? parameter) =>
‼8:           canExecute?.Invoke(parameter) ?? true;
〰9:   
〰10:      public override void Execute(object? parameter)=>
‼11:          execute(parameter);
〰12:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Input/DelegateCommand.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Input;
〰4:   
‼5:   public class DelegateCommand(Action<object?> execute, Predicate<object?>? canExecute = default) : CommandBase
〰6:   {
〰7:       public override bool CanExecute(object? parameter) =>
‼8:           canExecute?.Invoke(parameter) ?? true;
〰9:   
〰10:      public override void Execute(object? parameter)=>
‼11:          execute(parameter);
〰12:  }
〰13:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

