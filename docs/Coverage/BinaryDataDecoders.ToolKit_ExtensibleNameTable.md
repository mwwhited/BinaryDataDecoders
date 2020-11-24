# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNameTable

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNameTable` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `2`                                                        |
| Uncoveredlines  | `3`                                                        |
| Coverablelines  | `5`                                                        |
| Totallines      | `20`                                                       |
| Linecoverage    | `40`                                                       |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 100   | 100      | `ctor`  |
| 1          | 0     | 100      | `Add`   |
| 1          | 100   | 100      | `Add`   |
| 1          | 0     | 100      | `Get`   |
| 1          | 0     | 100      | `Get`   |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\XPath\ExtensibleNameTable.cs

```CSharp
〰1:   using System.Xml;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.XPath
〰4:   {
〰5:       internal class ExtensibleNameTable : XmlNameTable
〰6:       {
✔7:           private readonly NameTable _nameTable = new NameTable();
〰8:   
〰9:           public override string Add(char[] array, int offset, int length) =>
‼10:              _nameTable.Add(array, offset, length);
〰11:          public override string Add(string array) =>
✔12:              _nameTable.Add(array);
〰13:  
〰14:          public override string Get(char[] array, int offset, int length) =>
‼15:              _nameTable.Get(array, offset, length);
〰16:  
〰17:          public override string Get(string array) =>
‼18:              _nameTable.Add(array);
〰19:      }
〰20:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

