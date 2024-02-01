# BinaryDataDecoders.ToolKit.BcdEx

## Summary

| Key             | Value                              |
| :-------------- | :--------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.BcdEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`       |
| Coveredlines    | `5`                                |
| Uncoveredlines  | `27`                               |
| Coverablelines  | `32`                               |
| Totallines      | `101`                              |
| Linecoverage    | `15.6`                             |
| Coveredbranches | `2`                                |
| Totalbranches   | `24`                               |
| Branchcoverage  | `8.3`                              |
| Coveredmethods  | `1`                                |
| Totalmethods    | `4`                                |
| Methodcoverage  | `25`                               |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 4          | 0     | 0        | `AsBCD` |
| 8          | 0     | 0        | `ToBCD` |
| 4          | 71.42 | 50.0     | `AsBCD` |
| 8          | 0     | 0        | `ToBCD` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/BcdEx.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit;
〰4:   
〰5:   /// <summary>
〰6:   /// Extension methods to support BinaryCode Decimal (BCD)
〰7:   /// </summary>
〰8:   public static class BcdEx
〰9:   {
〰10:      //TODO: extend to support ReadOnlySpan
〰11:  
〰12:      /// <summary>
〰13:      /// convert Binary Code Decimal (BCD) byte to integer
〰14:      /// </summary>
〰15:      /// <param name="input"></param>
〰16:      /// <returns></returns>
〰17:      public static int AsBCD(this byte input)
〰18:      {
‼19:          var low = (int)(input & 0x0f);
‼20:          var high = (int)((input & 0xf0) >> 4);
〰21:  
‼22:          if (low > 9)
‼23:              throw new ArgumentOutOfRangeException("low nibble");
‼24:          if (high > 9)
‼25:              throw new ArgumentOutOfRangeException("high nibble");
〰26:  
‼27:          return low + (high * 10);
〰28:      }
〰29:      /// <summary>
〰30:      /// convert decimal value to Binary code Decimal (BCD)
〰31:      /// </summary>
〰32:      /// <param name="input"></param>
〰33:      /// <returns></returns>
〰34:      public static byte ToBCD(this int input)
〰35:      {
‼36:          if (input > 99 || input < 0)
‼37:              throw new ArgumentOutOfRangeException();
〰38:  
‼39:          var high = input / 10;
‼40:          var low = input - (high * 10);
〰41:  
‼42:          if (low > 9)
‼43:              throw new ArgumentOutOfRangeException("low nibble");
‼44:          if (high > 9)
‼45:              throw new ArgumentOutOfRangeException("high nibble");
〰46:  
〰47:  
‼48:          return (byte)((high << 4) | low);
〰49:      }
〰50:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/BcdEx.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit;
〰4:   
〰5:   /// <summary>
〰6:   /// Extension methods to support BinaryCode Decimal (BCD)
〰7:   /// </summary>
〰8:   public static class BcdEx
〰9:   {
〰10:      //TODO: extend to support ReadOnlySpan
〰11:  
〰12:      /// <summary>
〰13:      /// convert Binary Code Decimal (BCD) byte to integer
〰14:      /// </summary>
〰15:      /// <param name="input"></param>
〰16:      /// <returns></returns>
〰17:      public static int AsBCD(this byte input)
〰18:      {
✔19:          var low = (int)(input & 0x0f);
✔20:          var high = (int)((input & 0xf0) >> 4);
〰21:  
⚠22:          if (low > 9)
‼23:              throw new ArgumentOutOfRangeException("low nibble");
⚠24:          if (high > 9)
‼25:              throw new ArgumentOutOfRangeException("high nibble");
〰26:  
✔27:          return low + (high * 10);
〰28:      }
〰29:      /// <summary>
〰30:      /// convert decimal value to Binary code Decimal (BCD)
〰31:      /// </summary>
〰32:      /// <param name="input"></param>
〰33:      /// <returns></returns>
〰34:      public static byte ToBCD(this int input)
〰35:      {
‼36:          if (input > 99 || input < 0)
‼37:              throw new ArgumentOutOfRangeException();
〰38:  
‼39:          var high = input / 10;
‼40:          var low = input - (high * 10);
〰41:  
‼42:          if (low > 9)
‼43:              throw new ArgumentOutOfRangeException("low nibble");
‼44:          if (high > 9)
‼45:              throw new ArgumentOutOfRangeException("high nibble");
〰46:  
〰47:  
‼48:          return (byte)((high << 4) | low);
〰49:      }
〰50:  }
〰51:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

