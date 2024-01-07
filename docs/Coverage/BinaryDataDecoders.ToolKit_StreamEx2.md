# BinaryDataDecoders.ToolKit.StreamEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.StreamEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`          |
| Coveredlines    | `0`                                   |
| Uncoveredlines  | `28`                                  |
| Coverablelines  | `28`                                  |
| Totallines      | `75`                                  |
| Linecoverage    | `0`                                   |
| Coveredbranches | `0`                                   |
| Totalbranches   | `12`                                  |
| Branchcoverage  | `0`                                   |
| Coveredmethods  | `0`                                   |
| Totalmethods    | `6`                                   |
| Methodcoverage  | `0`                                   |

## Metrics

| Complexity | Lines | Branches | Name                |
| :--------- | :---- | :------- | :------------------ |
| 2          | 0     | 0        | `ReadAsStringAsync` |
| 2          | 0     | 0        | `AsBytesAsync`      |
| 2          | 0     | 0        | `AsBytes`           |
| 2          | 0     | 0        | `ReadAsStringAsync` |
| 2          | 0     | 0        | `AsBytesAsync`      |
| 2          | 0     | 0        | `AsBytes`           |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/StreamEx.cs

```CSharp
〰1:   using System.IO;
〰2:   using System.Threading.Tasks;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit;
〰5:   
〰6:   /// <summary>
〰7:   /// extensions for <c>System.IO.Stream</c>
〰8:   /// </summary>
〰9:   public static class StreamEx
〰10:  {
〰11:      /// <summary>
〰12:      /// simple wrapper to get stream content as string
〰13:      /// </summary>
〰14:      /// <param name="stream"></param>
〰15:      /// <returns></returns>
〰16:      public static async Task<string?> ReadAsStringAsync(this Stream? stream)
〰17:      {
‼18:          if (stream == null) return null;
‼19:          using var sr = new StreamReader(stream); //TODO: should this leave the underlying stream open?
‼20:          return await sr.ReadToEndAsync().ConfigureAwait(false);
‼21:      }
〰22:  
〰23:      public static async Task<byte[]?> AsBytesAsync(this Stream? stream)
〰24:      {
‼25:          if (stream == null) return null;
‼26:          using var ms = new MemoryStream();
‼27:          await stream.CopyToAsync(ms).ConfigureAwait(false);
‼28:          return ms.ToArray();
‼29:      }
〰30:      public static byte[]? AsBytes(this Stream? stream)
〰31:      {
‼32:          if (stream == null) return null;
‼33:          using var ms = new MemoryStream();
‼34:          stream.CopyTo(ms);
‼35:          return ms.ToArray();
‼36:      }
〰37:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/StreamEx.cs

```CSharp
〰1:   using System.IO;
〰2:   using System.Threading.Tasks;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit;
〰5:   
〰6:   /// <summary>
〰7:   /// extensions for <c>System.IO.Stream</c>
〰8:   /// </summary>
〰9:   public static class StreamEx
〰10:  {
〰11:      /// <summary>
〰12:      /// simple wrapper to get stream content as string
〰13:      /// </summary>
〰14:      /// <param name="stream"></param>
〰15:      /// <returns></returns>
〰16:      public static async Task<string?> ReadAsStringAsync(this Stream? stream)
〰17:      {
‼18:          if (stream == null) return null;
‼19:          using var sr = new StreamReader(stream); //TODO: should this leave the underlying stream open?
‼20:          return await sr.ReadToEndAsync().ConfigureAwait(false);
‼21:      }
〰22:  
〰23:      public static async Task<byte[]?> AsBytesAsync(this Stream? stream)
〰24:      {
‼25:          if (stream == null) return null;
‼26:          using var ms = new MemoryStream();
‼27:          await stream.CopyToAsync(ms).ConfigureAwait(false);
‼28:          return ms.ToArray();
‼29:      }
〰30:      public static byte[]? AsBytes(this Stream? stream)
〰31:      {
‼32:          if (stream == null) return null;
‼33:          using var ms = new MemoryStream();
‼34:          stream.CopyTo(ms);
‼35:          return ms.ToArray();
‼36:      }
〰37:  }
〰38:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

