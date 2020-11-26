# BinaryDataDecoders.ToolKit.Xml.Schema.XmlValidationResult

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Schema.XmlValidationResult` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `0`                                                         |
| Uncoveredlines  | `3`                                                         |
| Coverablelines  | `3`                                                         |
| Totallines      | `11`                                                        |
| Linecoverage    | `0`                                                         |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `0`                                                         |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 0     | 100      | `get_Exception` |
| 1          | 0     | 100      | `get_Message`   |
| 1          | 0     | 100      | `get_Severity`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Schema/XmlValidationResult.cs

```CSharp
〰1:   using System.Xml.Schema;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.Schema
〰4:   {
〰5:       public class XmlValidationResult
〰6:       {
‼7:           public XmlSchemaException Exception { get; internal set; }
‼8:           public string Message { get; internal set; }
‼9:           public XmlSeverityType Severity { get; internal set; }
〰10:      }
〰11:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

