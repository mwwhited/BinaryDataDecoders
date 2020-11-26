# BinaryDataDecoders.ToolKit.MetaData.FileExtensionAttribute

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.MetaData.FileExtensionAttribute` |
| Assembly        | `BinaryDataDecoders.ToolKit.Abstractions`                    |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `2`                                                          |
| Coverablelines  | `2`                                                          |
| Totallines      | `12`                                                         |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 1          | 0     | 100      | `get_FileExtension` |
| 1          | 0     | 100      | `ctor`              |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Abstractions/MetaData/FileExtensionAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.MetaData
〰4:   {
〰5:       [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
〰6:       public class FileExtensionAttribute : Attribute
〰7:       {
‼8:           public string FileExtension { get; }
〰9:   
‼10:          public FileExtensionAttribute(string fileExtension) => FileExtension = fileExtension;
〰11:      }
〰12:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

