# BinaryDataDecoders.ToolKit.Data.SqlTypes.SqlXmlEx

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Data.SqlTypes.SqlXmlEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                        |
| Coveredlines    | `0`                                                 |
| Uncoveredlines  | `4`                                                 |
| Coverablelines  | `4`                                                 |
| Totallines      | `16`                                                |
| Linecoverage    | `0`                                                 |
| Coveredbranches | `0`                                                 |
| Totalbranches   | `0`                                                 |
| Coveredmethods  | `0`                                                 |
| Totalmethods    | `2`                                                 |
| Methodcoverage  | `0`                                                 |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 1          | 0     | 100      | `ToXFragment` |
| 1          | 0     | 100      | `ToSqlXml`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Data/SqlTypes/SqlXmlEx.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.Xml.Linq;
〰2:   using System.Data.SqlTypes;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Data.SqlTypes
〰5:   {
〰6:       public static class SqlXmlEx
〰7:       {
〰8:           public static XFragment ToXFragment(this SqlXml sqlxml)
〰9:           {
‼10:              using var xmlReader = sqlxml.CreateReader();
‼11:              return XFragment.Parse(xmlReader);
‼12:          }
〰13:  
‼14:          public static SqlXml ToSqlXml(this XFragment xFragment) => new SqlXml(xFragment.CreateReader());
〰15:      }
〰16:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

