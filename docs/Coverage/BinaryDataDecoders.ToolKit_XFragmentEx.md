# BinaryDataDecoders.ToolKit.Xml.Linq.XFragmentEx

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XFragmentEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                      |
| Coveredlines    | `1`                                               |
| Uncoveredlines  | `1`                                               |
| Coverablelines  | `2`                                               |
| Totallines      | `19`                                              |
| Linecoverage    | `50`                                              |
| Coveredbranches | `0`                                               |
| Totalbranches   | `0`                                               |
| Coveredmethods  | `1`                                               |
| Totalmethods    | `2`                                               |
| Methodcoverage  | `50`                                              |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToXFragment` |
| 1          | 100   | 100      | `ToXFragment` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Linq/XFragmentEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Xml.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰5:   
〰6:   public static class XFragmentEx
〰7:   {
‼8:       public static XFragment ToXFragment(this IEnumerable<XNode> nodes) => new(nodes);
〰9:   }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/Linq/XFragmentEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.Xml.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰5:   
〰6:   public static class XFragmentEx
〰7:   {
✔8:       public static XFragment ToXFragment(this IEnumerable<XNode> nodes) => new(nodes);
〰9:   }
〰10:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

