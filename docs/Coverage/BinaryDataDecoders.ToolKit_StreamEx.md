# BinaryDataDecoders.ToolKit.IO.StreamEx

## Summary

| Key             | Value                                    |
| :-------------- | :--------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.IO.StreamEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`             |
| Coveredlines    | `0`                                      |
| Uncoveredlines  | `12`                                     |
| Coverablelines  | `12`                                     |
| Totallines      | `26`                                     |
| Linecoverage    | `0`                                      |
| Coveredbranches | `0`                                      |
| Totalbranches   | `0`                                      |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 1          | 0     | 100      | `AsTempFileAsync` |
| 1          | 0     | 100      | `AsTempFile`      |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\IO\StreamEx.cs

```CSharp
〰1:   using System.IO;
〰2:   using System.Threading.Tasks;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.IO
〰5:   {
〰6:       public static class StreamEx
〰7:       {
〰8:           public static async Task<ITempFile> AsTempFileAsync(this Stream stream)
〰9:           {
‼10:              var temp = new TempFileHandle();
‼11:              using var fs = File.OpenWrite(temp.FilePath);
‼12:              await stream.CopyToAsync(fs).ConfigureAwait(false);
‼13:              fs.Close();
‼14:              return temp;
‼15:          }
〰16:  
〰17:          public static ITempFile AsTempFile(this Stream stream)
〰18:          {
‼19:              var temp = new TempFileHandle();
‼20:              using var fs = File.OpenWrite(temp.FilePath);
‼21:              stream.CopyTo(fs);
‼22:              fs.Close();
‼23:              return temp;
‼24:          }
〰25:      }
〰26:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

