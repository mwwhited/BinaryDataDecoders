
# BinaryDataDecoders.Archives.Tar.IOUtilities
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.Archives_IOUtilities.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.Archives.Tar.IOUtilities                  | 
| Assembly             | BinaryDataDecoders.Archives                                  | 
| Coveredlines         | 0                                                            | 
| Uncoveredlines       | 41                                                           | 
| Coverablelines       | 41                                                           | 
| Totallines           | 72                                                           | 
| Linecoverage         | 0                                                            | 
| Coveredbranches      | 0                                                            | 
| Totalbranches        | 21                                                           | 
| Branchcoverage       | 0                                                            | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Archives\Tar\IOUtilities.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | cctor | 
| 4          | 0     | 0        | OpenFileStream | 
| 4          | 0     | 0        | Convert | 
| 6          | 0     | 0        | Convert | 
| 7          | 0     | 0        | Convert | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Archives\Tar\IOUtilities.cs

```CSharp
〰1:   using Microsoft.Win32.SafeHandles;
〰2:   using System;
〰3:   using System.IO;
〰4:   using System.Runtime.InteropServices;
〰5:   
〰6:   namespace BinaryDataDecoders.Archives.Tar
〰7:   {
〰8:       public static class IOUtilities
〰9:       {
〰10:          [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
〰11:          internal static extern SafeFileHandle CreateFile(
〰12:              string lpFileName,
〰13:              EFileAccess dwDesiredAccess,
〰14:              EFileShare dwShareMode,
〰15:              IntPtr lpSecurityAttributes,
〰16:              ECreationDisposition dwCreationDisposition,
〰17:              EFileAttributes dwFlagsAndAttributes,
〰18:              IntPtr hTemplateFile);
〰19:  
‼20:          internal static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
‼21:          internal static int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
〰22:          internal const int MAX_PATH = 260;
〰23:  
〰24:          public static FileStream OpenFileStream(string fileName, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
〰25:          {
‼26:              if (fileName.Length <= 260)
‼27:                  return new FileStream(fileName, fileMode, fileAccess);
〰28:  
‼29:              var handle = CreateFile(
‼30:                  @"\\?\" + fileName,
‼31:                  fileAccess.Convert(),
‼32:                  fileShare.Convert(),
‼33:                  IntPtr.Zero,
‼34:                  fileMode.Convert(),
‼35:                  0, IntPtr.Zero);
‼36:              var stream = new FileStream(handle, fileAccess);
‼37:              if (fileMode == FileMode.Append)
‼38:                  stream.Seek(0, SeekOrigin.End);
〰39:  
‼40:              return stream;
〰41:          }
〰42:  
‼43:          internal static EFileAccess Convert(this FileAccess fileAccess) => fileAccess switch
‼44:          {
‼45:              FileAccess.Read => EFileAccess.GenericRead,
‼46:              FileAccess.ReadWrite => EFileAccess.GenericRead | EFileAccess.GenericRead,
‼47:              FileAccess.Write => EFileAccess.GenericWrite,
‼48:              _ => throw new NotSupportedException(),
‼49:          };
〰50:  
‼51:          internal static EFileShare Convert(this FileShare fileShare) => fileShare switch
‼52:          {
‼53:              FileShare.Delete => EFileShare.Delete,
‼54:              FileShare.Read => EFileShare.Read,
‼55:              FileShare.ReadWrite => EFileShare.Write | EFileShare.Read,
‼56:              FileShare.Write => EFileShare.Write,
‼57:              FileShare.None => EFileShare.None,
‼58:              _ => throw new NotSupportedException(),
‼59:          };
〰60:  
‼61:          internal static ECreationDisposition Convert(this FileMode fileMode) => fileMode switch
‼62:          {
‼63:              FileMode.Append => ECreationDisposition.OpenAlways,
‼64:              FileMode.Create => ECreationDisposition.CreateAlways,
‼65:              FileMode.CreateNew => ECreationDisposition.New,
‼66:              FileMode.Open => ECreationDisposition.OpenExisting,
‼67:              FileMode.OpenOrCreate => ECreationDisposition.OpenAlways,
‼68:              FileMode.Truncate => ECreationDisposition.TruncateExisting,
‼69:              _ => throw new NotSupportedException(),
‼70:          };
〰71:      }
〰72:  }

```
## Footer 
[Return to Summary](Summary.md)

