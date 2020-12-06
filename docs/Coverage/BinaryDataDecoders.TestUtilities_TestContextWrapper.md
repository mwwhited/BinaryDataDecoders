# BinaryDataDecoders.TestUtilities.Logging.TestContextWrapper

## Summary

| Key             | Value                                                         |
| :-------------- | :------------------------------------------------------------ |
| Class           | `BinaryDataDecoders.TestUtilities.Logging.TestContextWrapper` |
| Assembly        | `BinaryDataDecoders.TestUtilities`                            |
| Coveredlines    | `0`                                                           |
| Uncoveredlines  | `2`                                                           |
| Coverablelines  | `2`                                                           |
| Totallines      | `10`                                                          |
| Linecoverage    | `0`                                                           |
| Coveredbranches | `0`                                                           |
| Totalbranches   | `0`                                                           |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ctor`        |
| 1          | 0     | 100      | `get_Context` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.TestUtilities/Logging/TestContextWrapper.cs

```CSharp
〰1:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰2:   
〰3:   namespace BinaryDataDecoders.TestUtilities.Logging
〰4:   {
〰5:       public class TestContextWrapper : ITestContextWrapper
〰6:       {
‼7:           public TestContextWrapper(TestContext context) => this.Context = context;
‼8:           public TestContext Context { get; }
〰9:       }
〰10:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

