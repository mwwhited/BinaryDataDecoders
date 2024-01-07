# BinaryDataDecoders.TestUtilities.ContextualTestMethodAttribute

## Summary

| Key             | Value                                                            |
| :-------------- | :--------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.ContextualTestMethodAttribute` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                               |
| Coveredlines    | `0`                                                              |
| Uncoveredlines  | `13`                                                             |
| Coverablelines  | `13`                                                             |
| Totallines      | `39`                                                             |
| Linecoverage    | `0`                                                              |
| Coveredbranches | `0`                                                              |
| Totalbranches   | `0`                                                              |
| Coveredmethods  | `0`                                                              |
| Totalmethods    | `7`                                                              |
| Methodcoverage  | `0`                                                              |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 0     | 100      | `cctor`        |
| 1          | 0     | 100      | `get_Current`  |
| 1          | 0     | 100      | `get_Instance` |
| 1          | 0     | 100      | `set_Instance` |
| 1          | 0     | 100      | `ctor`         |
| 1          | 0     | 100      | `ctor`         |
| 1          | 0     | 100      | `Execute`      |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/ContextualTestMethodAttribute.cs

```CSharp
〰1:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰2:   using System;
〰3:   using System.Threading;
〰4:   
〰5:   namespace BinaryDataDecoders.TestUtilities
〰6:   {
〰7:       [AttributeUsage(AttributeTargets.Method)]
〰8:       public class ContextualTestMethodAttribute : TestMethodAttribute
〰9:       {
〰10:          public const string CurrentTestMethod = nameof(CurrentTestMethod);
〰11:          public const string CurrentTestInstance = nameof(CurrentTestInstance);
〰12:  
‼13:          private readonly static AsyncLocal<ITestMethod?> _current = new();
‼14:          private readonly static AsyncLocal<object?> _instance = new();
〰15:  
‼16:          public static ITestMethod? Current => _current.Value;
〰17:          public static object? Instance
〰18:          {
‼19:              get => _instance.Value;
‼20:              set => _instance.Value = value;
〰21:          }
〰22:  
‼23:          public ContextualTestMethodAttribute()
〰24:          {
‼25:          }
〰26:  
‼27:          public ContextualTestMethodAttribute(string? displayName) : base(displayName)
〰28:          {
‼29:          }
〰30:  
〰31:          public override TestResult[] Execute(ITestMethod testMethod)
〰32:          {
‼33:              _current.Value = testMethod;
‼34:              var ret = base.Execute(testMethod);
‼35:              _current.Value = null;
‼36:              return ret;
〰37:          }
〰38:      }
〰39:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

