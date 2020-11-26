# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltFunctionAttribute

## Summary

| Key             | Value                                                      |
| :-------------- | :--------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltFunctionAttribute` |
| Assembly        | `BinaryDataDecoders.ToolKit`                               |
| Coveredlines    | `0`                                                        |
| Uncoveredlines  | `3`                                                        |
| Coverablelines  | `3`                                                        |
| Totallines      | `14`                                                       |
| Linecoverage    | `0`                                                        |
| Coveredbranches | `0`                                                        |
| Totalbranches   | `0`                                                        |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 1          | 0     | 100      | `get_Name`             |
| 1          | 0     | 100      | `get_HideOriginalName` |
| 1          | 0     | 100      | `ctor`                 |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Xsl/XsltFunctionAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰4:   {
〰5:       [AttributeUsage(AttributeTargets.Method)]
〰6:       public class XsltFunctionAttribute : Attribute
〰7:       {
‼8:           public string Name { get; }
〰9:   
‼10:          public bool HideOriginalName { get; set; }
〰11:  
‼12:          public XsltFunctionAttribute(string name) => Name = name;
〰13:      }
〰14:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

