# BinaryDataDecoders.ToolKit.Xml.Linq.XAttributeEx

## Summary

| Key             | Value                                              |
| :-------------- | :------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Linq.XAttributeEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                       |
| Coveredlines    | `0`                                                |
| Uncoveredlines  | `6`                                                |
| Coverablelines  | `6`                                                |
| Totallines      | `31`                                               |
| Linecoverage    | `0`                                                |
| Coveredbranches | `0`                                                |
| Totalbranches   | `8`                                                |
| Branchcoverage  | `0`                                                |
| Coveredmethods  | `0`                                                |
| Totalmethods    | `2`                                                |
| Methodcoverage  | `0`                                                |

## Metrics

| Complexity | Lines | Branches | Name     |
| :--------- | :---- | :------- | :------- |
| 4          | 0     | 0        | `AsEnum` |
| 4          | 0     | 0        | `AsEnum` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Xml/Linq/XAttributeEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Xml.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰5:   
〰6:   public static class XAttributeEx
〰7:   {
〰8:       public static TEnum AsEnum<TEnum>(this XAttribute xAttribute)
〰9:           where TEnum : struct
〰10:      {
‼11:          if (xAttribute != null && Enum.TryParse<TEnum>((string)xAttribute, out  var value))
‼12:              return value;
‼13:          return default;
〰14:      }
〰15:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Xml/Linq/XAttributeEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Xml.Linq;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Xml.Linq;
〰5:   
〰6:   public static class XAttributeEx
〰7:   {
〰8:       public static TEnum AsEnum<TEnum>(this XAttribute xAttribute)
〰9:           where TEnum : struct
〰10:      {
‼11:          if (xAttribute != null && Enum.TryParse<TEnum>((string)xAttribute, out  var value))
‼12:              return value;
‼13:          return default;
〰14:      }
〰15:  }
〰16:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

