# BinaryDataDecoders.ToolKit.Xml.Linq.XFragmentEx

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XFragmentEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                      |
| Coveredlines    | `1`                                               |
| Uncoveredlines  | `0`                                               |
| Coverablelines  | `1`                                               |
| Totallines      | `10`                                              |
| Linecoverage    | `100`                                             |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |
| Coveredmethods  | `1`                                               |
| Totalmethods    | `1`                                               |
| Methodcoverage  | `100`                                             |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 100   | 100      | `ToXFragment` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Linq/XFragmentEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Xml.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.Linq
〰5:   {
〰6:       public static class XFragmentEx
〰7:       {
✔8:           public static XFragment ToXFragment(this IEnumerable<XNode> nodes) => new XFragment(nodes);
〰9:       }
〰10:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

