# BinaryDataDecoders.ToolKit.SecureStringEx

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.SecureStringEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                |
| Coveredlines    | `0`                                         |
| Uncoveredlines  | `8`                                         |
| Coverablelines  | `8`                                         |
| Totallines      | `27`                                        |
| Linecoverage    | `0`                                         |
| Coveredbranches | `0`                                         |
| Totalbranches   | `2`                                         |
| Branchcoverage  | `0`                                         |
| Coveredmethods  | `0`                                         |
| Totalmethods    | `1`                                         |
| Methodcoverage  | `0`                                         |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 2          | 0     | 0        | `GetUnsecureString` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/SecureStringEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   using System.Security;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit
〰6:   {
〰7:       public static class SecureStringEx
〰8:       {
〰9:           public static string? GetUnsecureString(this SecureString? secure)
〰10:          {
〰11:              // http://blogs.msdn.com/b/fpintos/archive/2009/06/12/how-to-properly-convert-securestring-to-string.aspx
‼12:              if (secure == null)
‼13:                  return null;
〰14:  
‼15:               IntPtr unmanagedString = IntPtr.Zero;
〰16:              try
〰17:              {
‼18:                  unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secure);
‼19:                  return Marshal.PtrToStringUni(unmanagedString);
〰20:              }
〰21:              finally
〰22:              {
‼23:                  Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
‼24:              }
‼25:          }
〰26:      }
〰27:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

