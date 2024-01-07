# BinaryDataDecoders.CodeAnalysis.StructuredLog.StructuredLogNavigator

## Summary

| Key             | Value                                                                  |
| :-------------- | :--------------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.CodeAnalysis.StructuredLog.StructuredLogNavigator` |
| Assembly        | `BinaryDataDecoders.CodeAnalysis.StructuredLog`                        |
| Coveredlines    | `0`                                                                    |
| Uncoveredlines  | `2`                                                                    |
| Coverablelines  | `2`                                                                    |
| Totallines      | `15`                                                                   |
| Linecoverage    | `0`                                                                    |
| Coveredbranches | `0`                                                                    |
| Totalbranches   | `0`                                                                    |
| Coveredmethods  | `0`                                                                    |
| Totalmethods    | `2`                                                                    |
| Methodcoverage  | `0`                                                                    |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToNavigable` |
| 1          | 0     | 100      | `ToNavigable` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.CodeAnalysis.StructuredLog/StructuredLogNavigator.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.MetaData;
〰2:   using BinaryDataDecoders.ToolKit.Xml.XPath;
〰3:   using Microsoft.Build.Logging.StructuredLogger;
〰4:   using System.IO;
〰5:   using System.Xml.XPath;
〰6:   
〰7:   namespace BinaryDataDecoders.CodeAnalysis.StructuredLog;
〰8:   
〰9:   [FileExtension(".binlog")]
〰10:  public class StructuredLogNavigator : IToXPathNavigable
〰11:  {
‼12:      public IXPathNavigable ToNavigable(string filePath) => Serialization.Read(filePath).ToNavigable();
〰13:  
‼14:      public IXPathNavigable ToNavigable(Stream stream) => Serialization.ReadBinLog(stream).ToNavigable();
〰15:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

