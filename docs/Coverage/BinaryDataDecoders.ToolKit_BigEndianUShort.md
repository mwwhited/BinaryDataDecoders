﻿# BinaryDataDecoders.ToolKit.BigEndianUShort

## Summary

| Key             | Value                                        |
| :-------------- | :------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.BigEndianUShort` |
| Assembly        | `BinaryDataDecoders.ToolKit`                 |
| Coveredlines    | `0`                                          |
| Uncoveredlines  | `32`                                         |
| Coverablelines  | `32`                                         |
| Totallines      | `131`                                        |
| Linecoverage    | `0`                                          |
| Coveredbranches | `0`                                          |
| Totalbranches   | `0`                                          |
| Coveredmethods  | `0`                                          |
| Totalmethods    | `24`                                         |
| Methodcoverage  | `0`                                          |

## Metrics

| Complexity | Lines | Branches | Name            |
| :--------- | :---- | :------- | :-------------- |
| 1          | 0     | 100      | `ctor`          |
| 1          | 0     | 100      | `ctor`          |
| 1          | 0     | 100      | `get_Value`     |
| 1          | 0     | 100      | `ToString`      |
| 1          | 0     | 100      | `Equals`        |
| 1          | 0     | 100      | `GetHashCode`   |
| 1          | 0     | 100      | `op_Implicit`   |
| 1          | 0     | 100      | `op_Implicit`   |
| 1          | 0     | 100      | `op_Implicit`   |
| 1          | 0     | 100      | `op_Explicit`   |
| 1          | 0     | 100      | `op_Equality`   |
| 1          | 0     | 100      | `op_Inequality` |
| 1          | 0     | 100      | `ctor`          |
| 1          | 0     | 100      | `ctor`          |
| 1          | 0     | 100      | `get_Value`     |
| 1          | 0     | 100      | `ToString`      |
| 1          | 0     | 100      | `Equals`        |
| 1          | 0     | 100      | `GetHashCode`   |
| 1          | 0     | 100      | `op_Implicit`   |
| 1          | 0     | 100      | `op_Implicit`   |
| 1          | 0     | 100      | `op_Implicit`   |
| 1          | 0     | 100      | `op_Explicit`   |
| 1          | 0     | 100      | `op_Equality`   |
| 1          | 0     | 100      | `op_Inequality` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/BigEndianUShort.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit;
〰5:   
〰6:   /// <summary>
〰7:   /// Structure type to support conversion from unsigned Big Endian 16bit values
〰8:   /// </summary>
〰9:   [StructLayout(LayoutKind.Explicit, Size = 0x2)]
〰10:  public readonly struct BigEndianUShort
〰11:  {
〰12:      /// <summary>
〰13:      /// convert little endian 16bit value to big endian
〰14:      /// </summary>
〰15:      /// <param name="input"></param>
〰16:      public BigEndianUShort(ushort input)
〰17:      {
‼18:          HH = (byte)(input >> 8);
‼19:          LL = (byte)(input);
‼20:      }
〰21:      /// <summary>
〰22:      /// create unsigned big endian 16bit from ReadOnlySpan&lt;byte&gt;
〰23:      /// </summary>
〰24:      /// <param name="input"></param>
〰25:      public BigEndianUShort(ReadOnlySpan<byte> input)
〰26:      {
‼27:          HH = input[0];
‼28:          LL = input[1];
‼29:      }
〰30:  
〰31:      /// <summary>
〰32:      /// High byte for big Endian 16bit value
〰33:      /// </summary>
〰34:      [FieldOffset(0)]
〰35:      public readonly byte HH;
〰36:      /// <summary>
〰37:      /// Low byte for big Endian 16bit value
〰38:      /// </summary>
〰39:      [FieldOffset(1)]
〰40:      public readonly byte LL;
〰41:  
〰42:      /// <summary>
〰43:      /// Converted big Endian to little Endian
〰44:      /// </summary>
‼45:      public ushort Value => (ushort)(HH << 8 | LL);
〰46:  
‼47:      public override string ToString() => Value.ToString();
‼48:      public override bool Equals(object? obj) => Value.Equals(obj);
‼49:      public override int GetHashCode() => Value.GetHashCode();
〰50:  
‼51:      public static implicit operator ushort(BigEndianUShort input) => input.Value;
‼52:      public static implicit operator BigEndianUShort(ushort input) => new(input);
‼53:      public static implicit operator int(BigEndianUShort input) => input.Value;
‼54:      public static explicit operator BigEndianUShort(int input) => new((ushort)input);
〰55:  
〰56:      public static bool operator ==(BigEndianUShort left, BigEndianUShort right)
〰57:      {
‼58:          return left.Equals(right);
〰59:      }
〰60:  
〰61:      public static bool operator !=(BigEndianUShort left, BigEndianUShort right)
〰62:      {
‼63:          return !(left == right);
〰64:      }
〰65:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/BigEndianUShort.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit;
〰5:   
〰6:   /// <summary>
〰7:   /// Structure type to support conversion from unsigned Big Endian 16bit values
〰8:   /// </summary>
〰9:   [StructLayout(LayoutKind.Explicit, Size = 0x2)]
〰10:  public readonly struct BigEndianUShort
〰11:  {
〰12:      /// <summary>
〰13:      /// convert little endian 16bit value to big endian
〰14:      /// </summary>
〰15:      /// <param name="input"></param>
〰16:      public BigEndianUShort(ushort input)
〰17:      {
‼18:          HH = (byte)(input >> 8);
‼19:          LL = (byte)(input);
‼20:      }
〰21:      /// <summary>
〰22:      /// create unsigned big endian 16bit from ReadOnlySpan&lt;byte&gt;
〰23:      /// </summary>
〰24:      /// <param name="input"></param>
〰25:      public BigEndianUShort(ReadOnlySpan<byte> input)
〰26:      {
‼27:          HH = input[0];
‼28:          LL = input[1];
‼29:      }
〰30:  
〰31:      /// <summary>
〰32:      /// High byte for big Endian 16bit value
〰33:      /// </summary>
〰34:      [FieldOffset(0)]
〰35:      public readonly byte HH;
〰36:      /// <summary>
〰37:      /// Low byte for big Endian 16bit value
〰38:      /// </summary>
〰39:      [FieldOffset(1)]
〰40:      public readonly byte LL;
〰41:  
〰42:      /// <summary>
〰43:      /// Converted big Endian to little Endian
〰44:      /// </summary>
‼45:      public ushort Value => (ushort)(HH << 8 | LL);
〰46:  
‼47:      public override string ToString() => Value.ToString();
‼48:      public override bool Equals(object? obj) => Value.Equals(obj);
‼49:      public override int GetHashCode() => Value.GetHashCode();
〰50:  
‼51:      public static implicit operator ushort(BigEndianUShort input) => input.Value;
‼52:      public static implicit operator BigEndianUShort(ushort input) => new(input);
‼53:      public static implicit operator int(BigEndianUShort input) => input.Value;
‼54:      public static explicit operator BigEndianUShort(int input) => new((ushort)input);
〰55:  
〰56:      public static bool operator ==(BigEndianUShort left, BigEndianUShort right)
〰57:      {
‼58:          return left.Equals(right);
〰59:      }
〰60:  
〰61:      public static bool operator !=(BigEndianUShort left, BigEndianUShort right)
〰62:      {
‼63:          return !(left == right);
〰64:      }
〰65:  }
〰66:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

