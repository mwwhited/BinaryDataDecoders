# BinaryDataDecoders.ToolKit.Security.SandboxPath

## Summary

| Key             | Value                                             |
| :-------------- | :------------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.Security.SandboxPath` |
| Assembly        | `BinaryDataDecoders.ToolKit`                      |
| Coveredlines    | `0`                                               |
| Uncoveredlines  | `18`                                              |
| Coverablelines  | `18`                                              |
| Totallines      | `97`                                              |
| Linecoverage    | `0`                                               |
| Coveredbranches | `0`                                               |
| Totalbranches   | `8`                                               |
| Branchcoverage  | `0`                                               |
| Coveredmethods  | `0`                                               |
| Totalmethods    | `2`                                               |
| Methodcoverage  | `0`                                               |

## Metrics

| Complexity | Lines | Branches | Name             |
| :--------- | :---- | :------- | :--------------- |
| 4          | 0     | 0        | `EnsureSafePath` |
| 4          | 0     | 0        | `EnsureSafePath` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Security/SandboxPath.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.IO;
〰2:   using System;
〰3:   using System.IO;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Security;
〰6:   
〰7:   /// <summary>
〰8:   /// File IO sandboxing operation
〰9:   /// </summary>
〰10:  public static class SandboxPath
〰11:  {
〰12:      /// <summary>
〰13:      /// Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
〰14:      /// </summary>
〰15:      /// <param name="basePath"></param>
〰16:      /// <param name="filePath"></param>
〰17:      /// <returns></returns>
〰18:      /// <exception cref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>
〰19:      public static string EnsureSafePath(string basePath, string filePath)
〰20:      {
‼21:          var sandbox = Path.GetFullPath(basePath);
‼22:          var currentDirectory = Path.GetFullPath(Environment.CurrentDirectory);
〰23:  
‼24:          var composedPath = Path.GetFullPath(
‼25:              currentDirectory.StartsWith(sandbox) ?
‼26:                  filePath :
‼27:                  Path.Combine(basePath, filePath)
‼28:              );
〰29:  
‼30:          if (!composedPath.StartsWith(sandbox)) throw new ApplicationException($"invalid path requested: {filePath}");
‼31:          return PathEx.FixUpPath(composedPath);
〰32:      }
〰33:  
〰34:      ///// <summary>
〰35:      ///// Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
〰36:      ///// </summary>
〰37:      ///// <param name="basePath"></param>
〰38:      ///// <param name="filePath"></param>
〰39:      ///// <returns></returns>
〰40:      ///// <exception cref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>
〰41:      //public static bool IsSafePath(string basePath, string filePath)
〰42:      //{
〰43:      //    var sandbox = Path.GetFullPath(basePath);
〰44:      //    var composedPath = Path.Combine(basePath, filePath);
〰45:      //    var fullPath = Path.GetFullPath(composedPath);
〰46:      //    return fullPath.StartsWith(sandbox);
〰47:      //}
〰48:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/Security/SandboxPath.cs

```CSharp
〰1:   using BinaryDataDecoders.ToolKit.IO;
〰2:   using System;
〰3:   using System.IO;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Security;
〰6:   
〰7:   /// <summary>
〰8:   /// File IO sandboxing operation
〰9:   /// </summary>
〰10:  public static class SandboxPath
〰11:  {
〰12:      /// <summary>
〰13:      /// Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
〰14:      /// </summary>
〰15:      /// <param name="basePath"></param>
〰16:      /// <param name="filePath"></param>
〰17:      /// <returns></returns>
〰18:      /// <exception cref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>
〰19:      public static string EnsureSafePath(string basePath, string filePath)
〰20:      {
‼21:          var sandbox = Path.GetFullPath(basePath);
‼22:          var currentDirectory = Path.GetFullPath(Environment.CurrentDirectory);
〰23:  
‼24:          var composedPath = Path.GetFullPath(
‼25:              currentDirectory.StartsWith(sandbox) ?
‼26:                  filePath :
‼27:                  Path.Combine(basePath, filePath)
‼28:              );
〰29:  
‼30:          if (!composedPath.StartsWith(sandbox)) throw new ApplicationException($"invalid path requested: {filePath}");
‼31:          return PathEx.FixUpPath(composedPath);
〰32:      }
〰33:  
〰34:      ///// <summary>
〰35:      ///// Ensure the path under <c>filePath</c> is a child of <c>basePath</c>.
〰36:      ///// </summary>
〰37:      ///// <param name="basePath"></param>
〰38:      ///// <param name="filePath"></param>
〰39:      ///// <returns></returns>
〰40:      ///// <exception cref="System.ApplicationException">this will be throw if <c>filePath</c> is not a child of <c>basePath</c>.</exception>
〰41:      //public static bool IsSafePath(string basePath, string filePath)
〰42:      //{
〰43:      //    var sandbox = Path.GetFullPath(basePath);
〰44:      //    var composedPath = Path.Combine(basePath, filePath);
〰45:      //    var fullPath = Path.GetFullPath(composedPath);
〰46:      //    return fullPath.StartsWith(sandbox);
〰47:      //}
〰48:  }
〰49:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

