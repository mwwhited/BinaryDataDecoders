# BinaryDataDecoders.ToolKit.StreamEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.StreamEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`          |
| Coveredlines    | `0`                                   |
| Uncoveredlines  | `4`                                   |
| Coverablelines  | `4`                                   |
| Totallines      | `23`                                  |
| Linecoverage    | `0`                                   |
| Coveredbranches | `0`                                   |
| Totalbranches   | `2`                                   |
| Branchcoverage  | `0`                                   |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 2          | 0     | 0        | `ReadAsStringAsync` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\StreamEx.cs

```CSharp
〰1:   using System.IO;
〰2:   using System.Threading.Tasks;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit
〰5:   {
〰6:       /// <summary>
〰7:       /// extensions for <c>System.IO.Stream</c>
〰8:       /// </summary>
〰9:       public static class StreamEx
〰10:      {
〰11:          /// <summary>
〰12:          /// simple wrapper to get stream content as string
〰13:          /// </summary>
〰14:          /// <param name="stream"></param>
〰15:          /// <returns></returns>
〰16:          public static async Task<string?> ReadAsStringAsync(this Stream? stream)
〰17:          {
‼18:              if (stream == null) return null;
‼19:              using var sr = new StreamReader(stream); //TODO: should this leave the underlying stream open?
‼20:              return await sr.ReadToEndAsync().ConfigureAwait(false);
‼21:          }
〰22:      }
〰23:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

