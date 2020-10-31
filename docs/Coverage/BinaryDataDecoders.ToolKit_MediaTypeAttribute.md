# BinaryDataDecoders.ToolKit.MetaData.MediaTypeAttribute

## Summary

| Key             | Value                                                    |
| :-------------- | :------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.MetaData.MediaTypeAttribute` |
| Assembly        | `BinaryDataDecoders.ToolKit`                             |
| Coveredlines    | `0`                                                      |
| Uncoveredlines  | `1`                                                      |
| Coverablelines  | `1`                                                      |
| Totallines      | `12`                                                     |
| Linecoverage    | `0`                                                      |
| Coveredbranches | `0`                                                      |
| Totalbranches   | `0`                                                      |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\MetaData\MediaTypeAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.MetaData
〰4:   {
〰5:       [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
〰6:       public class MediaTypeAttribute : Attribute
〰7:       {
〰8:           public string MediaType { get; }
〰9:   
‼10:          public MediaTypeAttribute(string mediaType) => MediaType = mediaType;
〰11:      }
〰12:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

