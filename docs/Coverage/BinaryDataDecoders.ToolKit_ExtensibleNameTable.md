# BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNameTable

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.XPath.ExtensibleNameTable` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `2`                                                        |
| Uncoveredlines  | `8`                                                        |
| Coverablelines  | `10`                                                       |
| Totallines      | `39`                                                       |
| Linecoverage    | `20`                                                       |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |
| Coveredmethods  | `2`                                                        |
| Totalmethods    | `10`                                                       |
| Methodcoverage  | `20`                                                       |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `Add`   |
| 1          | 0     | 100      | `Add`   |
| 1          | 0     | 100      | `Get`   |
| 1          | 0     | 100      | `Get`   |
| 1          | 100   | 100      | `ctor`  |
| 1          | 0     | 100      | `Add`   |
| 1          | 100   | 100      | `Add`   |
| 1          | 0     | 100      | `Get`   |
| 1          | 0     | 100      | `Get`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleNameTable.cs

```CSharp
〰1:   using System.Xml;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰4:   
〰5:   internal class ExtensibleNameTable : XmlNameTable
〰6:   {
‼7:       private readonly NameTable _nameTable = new();
〰8:   
〰9:       public override string Add(char[] array, int offset, int length) =>
‼10:          _nameTable.Add(array, offset, length);
〰11:      public override string Add(string array) =>
‼12:          _nameTable.Add(array);
〰13:  
〰14:      public override string Get(char[] array, int offset, int length) =>
‼15:          _nameTable.Get(array, offset, length);
〰16:  
〰17:      public override string Get(string array) =>
‼18:          _nameTable.Add(array);
〰19:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/XPath/ExtensibleNameTable.cs

```CSharp
〰1:   using System.Xml;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.XPath;
〰4:   
〰5:   internal class ExtensibleNameTable : XmlNameTable
〰6:   {
✔7:       private readonly NameTable _nameTable = new();
〰8:   
〰9:       public override string Add(char[] array, int offset, int length) =>
‼10:          _nameTable.Add(array, offset, length);
〰11:      public override string Add(string array) =>
✔12:          _nameTable.Add(array);
〰13:  
〰14:      public override string Get(char[] array, int offset, int length) =>
‼15:          _nameTable.Get(array, offset, length);
〰16:  
〰17:      public override string Get(string array) =>
‼18:          _nameTable.Add(array);
〰19:  }
〰20:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

