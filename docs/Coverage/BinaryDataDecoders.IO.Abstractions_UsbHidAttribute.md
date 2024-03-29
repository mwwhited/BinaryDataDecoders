﻿# BinaryDataDecoders.IO.UsbHids.UsbHidAttribute

## Summary

| Key             | Value                                           |
| :-------------- | :---------------------------------------------- |
| Class           | `BinaryDataDecoders.IO.UsbHids.UsbHidAttribute` |
| Assembly        | `BinaryDataDecoders.IO.Abstractions`            |
| Coveredlines    | `0`                                             |
| Uncoveredlines  | `22`                                            |
| Coverablelines  | `22`                                            |
| Totallines      | `59`                                            |
| Linecoverage    | `0`                                             |
| Coveredbranches | `0`                                             |
| Totalbranches   | `0`                                             |
| Coveredmethods  | `0`                                             |
| Totalmethods    | `6`                                             |
| Methodcoverage  | `0`                                             |

## Metrics

| Complexity | Lines | Branches | Name    |
| :--------- | :---- | :------- | :------ |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |
| 1          | 0     | 100      | `ctor`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.IO.Abstractions/UsbHids/UsbHidAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.UsbHids;
〰4:   
〰5:   [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
〰6:   public class UsbHidAttribute : Attribute
〰7:   {
‼8:       public UsbHidAttribute() { }
‼9:       public UsbHidAttribute(
‼10:          ushort vendorId,
‼11:          ushort productId
‼12:          )
〰13:      {
‼14:          VendorId = vendorId;
‼15:          ProductId = productId;
‼16:      }
〰17:      public UsbHidAttribute(
〰18:          ushort vendorId,
〰19:          ushort productId,
〰20:          ushort productMask
‼21:          ) : this(vendorId, productId)
〰22:      {
‼23:          ProductMask = productMask;
‼24:      }
〰25:  
〰26:      public ushort VendorId { get; set; }
〰27:      public ushort ProductId { get; set; }
〰28:      public ushort ProductMask { get; set; } = 0xffff;
〰29:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.IO.Abstractions/UsbHids/UsbHidAttribute.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.IO.UsbHids;
〰4:   
〰5:   [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
〰6:   public class UsbHidAttribute : Attribute
〰7:   {
‼8:       public UsbHidAttribute() { }
‼9:       public UsbHidAttribute(
‼10:          ushort vendorId,
‼11:          ushort productId
‼12:          )
〰13:      {
‼14:          VendorId = vendorId;
‼15:          ProductId = productId;
‼16:      }
〰17:      public UsbHidAttribute(
〰18:          ushort vendorId,
〰19:          ushort productId,
〰20:          ushort productMask
‼21:          ) : this(vendorId, productId)
〰22:      {
‼23:          ProductMask = productMask;
‼24:      }
〰25:  
〰26:      public ushort VendorId { get; set; }
〰27:      public ushort ProductId { get; set; }
〰28:      public ushort ProductMask { get; set; } = 0xffff;
〰29:  }
〰30:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

