﻿# BinaryDataDecoders.ToolKit.MetaData.FileExtensionAttribute

## Summary

| Key             | Value                                                        |
| :-------------- | :----------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.MetaData.FileExtensionAttribute` |
| Assembly        | `BinaryDataDecoders.ToolKit.Abstractions`                    |
| Coveredlines    | `0`                                                          |
| Uncoveredlines  | `1`                                                          |
| Coverablelines  | `1`                                                          |
| Totallines      | `9`                                                          |
| Linecoverage    | `0`                                                          |
| Coveredbranches | `0`                                                          |
| Totalbranches   | `0`                                                          |
| Coveredmethods  | `0`                                                          |
| Totalmethods    | `1`                                                          |
| Methodcoverage  | `0`                                                          |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit.Abstractions/MetaData/FileExtensionAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.MetaData;
〰4:   
〰5:   [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
‼6:   public class FileExtensionAttribute(string fileExtension) : Attribute
〰7:   {
〰8:       public string FileExtension { get; } = fileExtension;
〰9:   }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

