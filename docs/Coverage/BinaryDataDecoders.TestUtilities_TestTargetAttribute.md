# BinaryDataDecoders.TestUtilities.TestTargetAttribute

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.TestTargetAttribute` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                     |
| Coveredlines    | `1`                                                    |
| Uncoveredlines  | `0`                                                    |
| Coverablelines  | `1`                                                    |
| Totallines      | `27`                                                   |
| Linecoverage    | `100`                                                  |
| Coveredbranches | `0`                                                    |
| Totalbranches   | `0`                                                    |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.TestUtilities\TestTargetAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.TestUtilities
〰4:   {
〰5:       /// <summary>
〰6:       /// This attribute may be used to mark what Class/Member is covered by a particular test method
〰7:       /// </summary>
〰8:       [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
〰9:       public class TestTargetAttribute : Attribute
〰10:      {
〰11:          /// <summary>
〰12:          /// create and instance of TestTargetAttribute
〰13:          /// </summary>
〰14:          /// <param name="class">type of related class</param>
✔15:          public TestTargetAttribute(Type @class) => Class = @class;
〰16:  
〰17:          /// <summary>
〰18:          /// required type reference for related test
〰19:          /// </summary>
〰20:          public Type Class { get; }
〰21:  
〰22:          /// <summary>
〰23:          /// optional member mapping for related test
〰24:          /// </summary>
〰25:          public string? Member { get; set; }
〰26:      }
〰27:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

