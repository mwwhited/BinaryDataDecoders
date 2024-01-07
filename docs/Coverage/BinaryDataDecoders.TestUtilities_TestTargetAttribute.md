# BinaryDataDecoders.TestUtilities.TestTargetAttribute

## Summary

| Key             | Value                                                  |
| :-------------- | :----------------------------------------------------- |
| Class           | `BinaryDataDecoders.TestUtilities.TestTargetAttribute` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                     |
| Coveredlines    | `1`                                                    |
| Uncoveredlines  | `1`                                                    |
| Coverablelines  | `2`                                                    |
| Totallines      | `51`                                                   |
| Linecoverage    | `50`                                                   |
| Coveredbranches | `0`                                                    |
| Totalbranches   | `0`                                                    |
| Coveredmethods  | `1`                                                    |
| Totalmethods    | `2`                                                    |
| Methodcoverage  | `50`                                                   |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 100   | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/TestTargetAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.TestUtilities;
〰4:   
〰5:   /// <summary>
〰6:   /// This attribute may be used to mark what Class/Member is covered by a particular test method
〰7:   /// </summary>
〰8:   /// <remarks>
〰9:   /// create and instance of TestTargetAttribute
〰10:  /// </remarks>
〰11:  /// <param name="class">type of related class</param>
〰12:  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
‼13:  public class TestTargetAttribute(Type @class) : Attribute
〰14:  {
〰15:  
〰16:      /// <summary>
〰17:      /// required type reference for related test
〰18:      /// </summary>
〰19:      public Type Class { get; } = @class;
〰20:  
〰21:      /// <summary>
〰22:      /// optional member mapping for related test
〰23:      /// </summary>
〰24:      public string? Member { get; set; }
〰25:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.TestUtilities/TestTargetAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.TestUtilities;
〰4:   
〰5:   /// <summary>
〰6:   /// This attribute may be used to mark what Class/Member is covered by a particular test method
〰7:   /// </summary>
〰8:   /// <remarks>
〰9:   /// create and instance of TestTargetAttribute
〰10:  /// </remarks>
〰11:  /// <param name="class">type of related class</param>
〰12:  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
✔13:  public class TestTargetAttribute(Type @class) : Attribute
〰14:  {
〰15:  
〰16:      /// <summary>
〰17:      /// required type reference for related test
〰18:      /// </summary>
〰19:      public Type Class { get; } = @class;
〰20:  
〰21:      /// <summary>
〰22:      /// optional member mapping for related test
〰23:      /// </summary>
〰24:      public string? Member { get; set; }
〰25:  }
〰26:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

