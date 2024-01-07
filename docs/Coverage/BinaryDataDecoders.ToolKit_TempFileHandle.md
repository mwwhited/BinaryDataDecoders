# BinaryDataDecoders.ToolKit.IO.TempFileHandle

## Summary

| Key             | Value                                          |
| :-------------- | :--------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.IO.TempFileHandle` |
| Assembly        | `BinaryDataDecoders.ToolKit`                   |
| Coveredlines    | `7`                                            |
| Uncoveredlines  | `31`                                           |
| Coverablelines  | `38`                                           |
| Totallines      | `111`                                          |
| Linecoverage    | `18.4`                                         |
| Coveredbranches | `1`                                            |
| Totalbranches   | `12`                                           |
| Branchcoverage  | `8.3`                                          |
| Coveredmethods  | `2`                                            |
| Totalmethods    | `8`                                            |
| Methodcoverage  | `25`                                           |

## Metrics

| Complexity | Lines | Branches | Name       |
| :--------- | :---- | :------- | :--------- |
| 1          | 0     | 100      | `ToString` |
| 1          | 0     | 100      | `Finalize` |
| 1          | 0     | 100      | `Dispose`  |
| 6          | 0     | 0        | `Dispose`  |
| 1          | 0     | 100      | `ToString` |
| 1          | 0     | 100      | `Finalize` |
| 1          | 100   | 100      | `Dispose`  |
| 6          | 28.57 | 16.66    | `Dispose`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/IO/TempFileHandle.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   using System.Runtime.InteropServices;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.IO;
〰6:   
〰7:   public sealed class TempFileHandle : ITempFile
〰8:   {
〰9:       public string FilePath { get; }
〰10:  
〰11:      public TempFileHandle() => FilePath = Path.GetTempFileName();
〰12:  
‼13:      public override string ToString() => FilePath;
〰14:  
‼15:      ~TempFileHandle() => Dispose(false);
〰16:  
〰17:      public void Dispose()
〰18:      {
‼19:          this.Dispose(true);
‼20:          GC.SuppressFinalize(this);
‼21:      }
〰22:  
〰23:      private void Dispose(bool disposing)
〰24:      {
‼25:          if (!File.Exists(FilePath)) return;
〰26:  
〰27:          try
〰28:          {
‼29:              File.Delete(FilePath);
‼30:          }
‼31:          catch
〰32:          {
〰33:              //Note: yeah, I don't care why it failed.
‼34:              if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
‼35:                  throw;
〰36:  
〰37:              try
〰38:              {
‼39:                  NativeWin32Methods.MoveFileEx(FilePath, null, NativeWin32Methods.MoveFileFlags.DelayUntilReboot);
〰40:                  //scheduled for reboot so good to go
‼41:                  return;
〰42:              }
‼43:              catch
〰44:              {
〰45:                  //yep, another.  it's just a temp file give up it it doesn't work.
‼46:              }
〰47:  
‼48:              if (disposing)
〰49:              {
〰50:                  //something happen above so throw the original exception.
‼51:                  throw;
〰52:              }
‼53:          }
‼54:      }
〰55:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/IO/TempFileHandle.cs

```CSharp
〰1:   using System;
〰2:   using System.IO;
〰3:   using System.Runtime.InteropServices;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.IO;
〰6:   
〰7:   public sealed class TempFileHandle : ITempFile
〰8:   {
〰9:       public string FilePath { get; }
〰10:  
〰11:      public TempFileHandle() => FilePath = Path.GetTempFileName();
〰12:  
‼13:      public override string ToString() => FilePath;
〰14:  
‼15:      ~TempFileHandle() => Dispose(false);
〰16:  
〰17:      public void Dispose()
〰18:      {
✔19:          this.Dispose(true);
✔20:          GC.SuppressFinalize(this);
✔21:      }
〰22:  
〰23:      private void Dispose(bool disposing)
〰24:      {
⚠25:          if (!File.Exists(FilePath)) return;
〰26:  
〰27:          try
〰28:          {
✔29:              File.Delete(FilePath);
✔30:          }
‼31:          catch
〰32:          {
〰33:              //Note: yeah, I don't care why it failed.
‼34:              if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
‼35:                  throw;
〰36:  
〰37:              try
〰38:              {
‼39:                  NativeWin32Methods.MoveFileEx(FilePath, null, NativeWin32Methods.MoveFileFlags.DelayUntilReboot);
〰40:                  //scheduled for reboot so good to go
‼41:                  return;
〰42:              }
‼43:              catch
〰44:              {
〰45:                  //yep, another.  it's just a temp file give up it it doesn't work.
‼46:              }
〰47:  
‼48:              if (disposing)
〰49:              {
〰50:                  //something happen above so throw the original exception.
‼51:                  throw;
〰52:              }
‼53:          }
✔54:      }
〰55:  }
〰56:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

