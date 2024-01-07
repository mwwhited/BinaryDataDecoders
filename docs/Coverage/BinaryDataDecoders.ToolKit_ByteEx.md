# BinaryDataDecoders.ToolKit.ByteEx

## Summary

| Key             | Value                               |
| :-------------- | :---------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.ByteEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`        |
| Coveredlines    | `14`                                |
| Uncoveredlines  | `16`                                |
| Coverablelines  | `30`                                |
| Totallines      | `85`                                |
| Linecoverage    | `46.6`                              |
| Coveredbranches | `0`                                 |
| Totalbranches   | `8`                                 |
| Branchcoverage  | `0`                                 |
| Coveredmethods  | `2`                                 |
| Totalmethods    | `6`                                 |
| Methodcoverage  | `33.3`                              |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 4          | 0     | 0        | `ToHexString` |
| 1          | 0     | 100      | `Decompress`  |
| 1          | 0     | 100      | `Compress`    |
| 4          | 0     | 0        | `ToHexString` |
| 1          | 100   | 100      | `Decompress`  |
| 1          | 100   | 100      | `Compress`    |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/ByteEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.IO;
〰3:   using System.IO.Compression;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit;
〰7:   
〰8:   /// <summary>
〰9:   /// Extensions for byte and IEnumerable&lt;byte&gt;
〰10:  /// </summary>
〰11:  public static class ByteEx
〰12:  {
〰13:      /// <summary>
〰14:      /// Convert enumerable byte set as
〰15:      /// </summary>
〰16:      /// <param name="data"></param>
〰17:      /// <param name="delimiter"></param>
〰18:      /// <returns></returns>
〰19:      public static string ToHexString(this IEnumerable<byte> data, string delimiter = "")=>
‼20:          string.Join(delimiter ?? "", (data ?? Enumerable.Empty<byte>()).Select(b => b.ToString("x2")));
〰21:  
〰22:  
〰23:      public static byte[] Decompress(this byte[] input)
〰24:      {
‼25:          using var inputStream = new MemoryStream(input);
‼26:          using var outputStream = new MemoryStream();
‼27:          using var deflate = new DeflateStream(inputStream, CompressionMode.Decompress);
‼28:          deflate.CopyTo(outputStream);
‼29:          deflate.Close();
‼30:          return outputStream.ToArray();
‼31:      }
〰32:  
〰33:      public static byte[] Compress(this byte[] input)
〰34:      {
‼35:          using var inputStream = new MemoryStream(input);
‼36:          using var outputStream = new MemoryStream();
‼37:          using var deflate = new DeflateStream(outputStream, CompressionLevel.Optimal);
‼38:          inputStream.CopyTo(deflate);
‼39:          deflate.Close();
‼40:          return outputStream.ToArray();
‼41:      }
〰42:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/ByteEx.cs

```CSharp
〰1:   using System.Collections.Generic;
〰2:   using System.IO;
〰3:   using System.IO.Compression;
〰4:   using System.Linq;
〰5:   
〰6:   namespace BinaryDataDecoders.ToolKit;
〰7:   
〰8:   /// <summary>
〰9:   /// Extensions for byte and IEnumerable&lt;byte&gt;
〰10:  /// </summary>
〰11:  public static class ByteEx
〰12:  {
〰13:      /// <summary>
〰14:      /// Convert enumerable byte set as
〰15:      /// </summary>
〰16:      /// <param name="data"></param>
〰17:      /// <param name="delimiter"></param>
〰18:      /// <returns></returns>
〰19:      public static string ToHexString(this IEnumerable<byte> data, string delimiter = "")=>
‼20:          string.Join(delimiter ?? "", (data ?? Enumerable.Empty<byte>()).Select(b => b.ToString("x2")));
〰21:  
〰22:  
〰23:      public static byte[] Decompress(this byte[] input)
〰24:      {
✔25:          using var inputStream = new MemoryStream(input);
✔26:          using var outputStream = new MemoryStream();
✔27:          using var deflate = new DeflateStream(inputStream, CompressionMode.Decompress);
✔28:          deflate.CopyTo(outputStream);
✔29:          deflate.Close();
✔30:          return outputStream.ToArray();
✔31:      }
〰32:  
〰33:      public static byte[] Compress(this byte[] input)
〰34:      {
✔35:          using var inputStream = new MemoryStream(input);
✔36:          using var outputStream = new MemoryStream();
✔37:          using var deflate = new DeflateStream(outputStream, CompressionLevel.Optimal);
✔38:          inputStream.CopyTo(deflate);
✔39:          deflate.Close();
✔40:          return outputStream.ToArray();
✔41:      }
〰42:  }
〰43:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

