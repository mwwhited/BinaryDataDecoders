# BinaryDataDecoders.ToolKit.IO.PathNavigator

## Summary

| Key             | Value                                         |
| :-------------- | :-------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.IO.PathNavigator` |
| Assembly        | `BinaryDataDecoders.ToolKit`                  |
| Coveredlines    | `0`                                           |
| Uncoveredlines  | `2`                                           |
| Coverablelines  | `2`                                           |
| Totallines      | `13`                                          |
| Linecoverage    | `0`                                           |
| Coveredbranches | `0`                                           |
| Totalbranches   | `0`                                           |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\IO\PathNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰2:   using System;
〰3:   using System.IO;
〰4:   using System.Xml.XPath;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit.IO
〰7:   {
〰8:       public class PathNavigator : IToXPathNavigable
〰9:       {
‼10:          public IXPathNavigable ToNavigable(string filePath) => new DirectoryInfo(filePath).ToNavigable();
‼11:          public IXPathNavigable ToNavigable(Stream stream) => throw new NotSupportedException();
〰12:      }
〰13:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

