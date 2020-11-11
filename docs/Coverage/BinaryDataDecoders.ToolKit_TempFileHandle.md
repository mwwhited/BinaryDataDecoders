# BinaryDataDecoders.ToolKit.IO.TempFileHandle

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.IO.TempFileHandle` |
| Assembly        | `BinaryDataDecoders.ToolKit`                   |
| Coveredlines    | `8`                                            |
| Uncoveredlines  | `11`                                           |
| Coverablelines  | `19`                                           |
| Totallines      | `53`                                           |
| Linecoverage    | `42.1`                                         |
| Coveredbranches | `1`                                            |
| Totalbranches   | `4`                                            |
| Branchcoverage  | `25`                                           |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 100   | 100      | `get_FilePath` |
| 1          | 100   | 100      | `ctor`         |
| 1          | 0     | 100      | `ToString`     |
| 1          | 0     | 100      | `Finalize`     |
| 1          | 100   | 100      | `Dispose`      |
| 4          | 25.00 | 25.00    | `Dispose`      |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\IO\TempFileHandle.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   using System.Runtime.InteropServices;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.IO
〰6:   {
〰7:       public sealed class TempFileHandle : ITempFile
〰8:       {
✔9:           public string FilePath { get; }
〰10:  
✔11:          public TempFileHandle() => FilePath = Path.GetTempFileName();
〰12:  
‼13:          public override string ToString() => FilePath;
〰14:  
‼15:          ~TempFileHandle() => Dispose(false);
〰16:  
〰17:          public void Dispose()
〰18:          {
✔19:              this.Dispose(true);
✔20:              GC.SuppressFinalize(this);
✔21:          }
〰22:  
〰23:          private void Dispose(bool disposing)
〰24:          {
‼25:              if (!File.Exists(FilePath)) return;
〰26:  
〰27:              try
〰28:              {
✔29:                  File.Delete(FilePath);
✔30:              }
‼31:              catch
〰32:              {
〰33:                  //Note: yeah, I don't care why it failed.
‼34:                  if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
‼35:                      throw;
〰36:  
〰37:                  try
〰38:                  {
‼39:                      NativeWin32Methods.MoveFileEx(FilePath, null, NativeWin32Methods.MoveFileFlags.DelayUntilReboot);
〰40:                      //scheduled for reboot so good to go
‼41:                      return;
〰42:                  }
‼43:                  catch
〰44:                  {
〰45:                      //yep, another.  it's just a temp file give up it it doesn't work.
‼46:                  }
〰47:  
〰48:                  //something happen above so throw the original exception.
‼49:                  throw;
〰50:              }
✔51:          }
〰52:      }
〰53:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

