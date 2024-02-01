# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltFunctionAttribute

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltFunctionAttribute` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `2`                                                        |
| Coverablelines  | `2`                                                        |
| Totallines      | `23`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |
| Coveredmethods  | `0`                                                        |
| Totalmethods    | `2`                                                        |
| Methodcoverage  | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/XsltFunctionAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl;
〰4:   
〰5:   [AttributeUsage(AttributeTargets.Method)]
‼6:   public class XsltFunctionAttribute(string name) : Attribute
〰7:   {
〰8:       public string Name { get; } = name;
〰9:   
〰10:      public bool HideOriginalName { get; set; }
〰11:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Xml/Xsl/XsltFunctionAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl;
〰4:   
〰5:   [AttributeUsage(AttributeTargets.Method)]
‼6:   public class XsltFunctionAttribute(string name) : Attribute
〰7:   {
〰8:       public string Name { get; } = name;
〰9:   
〰10:      public bool HideOriginalName { get; set; }
〰11:  }
〰12:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

