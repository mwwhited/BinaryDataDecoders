# BinaryDataDecoders.ToolKit.ReadOnlySpanEx

## Summary

| Key             | Value                                       |
| :-------------- | :------------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.ReadOnlySpanEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                |
| Coveredlines    | `23`                                        |
| Uncoveredlines  | `1`                                         |
| Coverablelines  | `24`                                        |
| Totallines      | `71`                                        |
| Linecoverage    | `95.8`                                      |
| Coveredbranches | `10`                                        |
| Totalbranches   | `10`                                        |
| Branchcoverage  | `100`                                       |

## Metrics

| Complexity | Lines | Branches | Name                  |
| :--------- | :---- | :------- | :-------------------- |
| 1          | 0     | 100      | `StartsWith`          |
| 1          | 100   | 100      | `CopyWithTransform`   |
| 10         | 100   | 100      | `CopyToWithTransform` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\ReadOnlySpanEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Runtime.InteropServices;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit
〰5:   {
〰6:       /// <summary>
〰7:       /// Set of extension methods for ReadOnlySpan&lt;&gt;
〰8:       /// </summary>
〰9:       public static partial class ReadOnlySpanEx
〰10:      {
〰11:          /// <summary>
〰12:          /// simple extension to allow using ReadOnlySpan&lt;&gt;.StartsWith(...) with an array
〰13:          /// </summary>
〰14:          /// <param name="data"></param>
〰15:          /// <param name="pattern"></param>
〰16:          /// <returns></returns>
‼17:          public static bool StartsWith(this ReadOnlySpan<byte> data, params byte[] pattern) => data.StartsWith(new ReadOnlySpan<byte>(pattern));
〰18:  
〰19:          /// <summary>
〰20:          ///  transform provided ReadOnlySpan<typeparamref name="TIn"/> into a new Span<typeparamref name="TOut"/>
〰21:          /// </summary>
〰22:          /// <typeparam name="TIn"></typeparam>
〰23:          /// <typeparam name="TOut"></typeparam>
〰24:          /// <param name="input"></param>
〰25:          /// <param name="transform"></param>
〰26:          /// <returns></returns>
〰27:          public static Span<TOut> CopyWithTransform<TIn, TOut>(this ReadOnlySpan<TIn> input, Func<TIn, TOut> transform)
〰28:              where TOut : struct
〰29:          {
✔30:              var size = Marshal.SizeOf<TOut>();
✔31:              var data = new byte[size * input.Length];
✔32:              Span<TOut> target = MemoryMarshal.Cast<byte, TOut>(data);
✔33:              CopyToWithTransform(input, target, transform);
✔34:              return target;
〰35:          }
〰36:  
〰37:          /// <summary>
〰38:          /// transform provided ReadOnlySpan<typeparamref name="TIn"/> into Existing Span<typeparamref name="TOut"/>
〰39:          /// </summary>
〰40:          /// <typeparam name="TIn"></typeparam>
〰41:          /// <typeparam name="TOut"></typeparam>
〰42:          /// <param name="input"></param>
〰43:          /// <param name="target"></param>
〰44:          /// <param name="transform"></param>
〰45:          public static void CopyToWithTransform<TIn, TOut>(this ReadOnlySpan<TIn> input, Span<TOut> target, Func<TIn, TOut> transform)
〰46:          {
✔47:              int index = input.Length % 8;
〰48:              switch (index)
〰49:              {
✔50:                  case 7: target[6] = transform(input[6]); goto case 6;
✔51:                  case 6: target[5] = transform(input[5]); goto case 5;
✔52:                  case 5: target[4] = transform(input[4]); goto case 4;
✔53:                  case 4: target[3] = transform(input[3]); goto case 3;
✔54:                  case 3: target[2] = transform(input[2]); goto case 2;
✔55:                  case 2: target[1] = transform(input[1]); goto case 1;
✔56:                  case 1: target[0] = transform(input[0]); break;
〰57:              }
✔58:              for (; index < input.Length; index += 8)
〰59:              {
✔60:                  target[index + 0] = transform(input[index + 0]);
✔61:                  target[index + 1] = transform(input[index + 1]);
✔62:                  target[index + 2] = transform(input[index + 2]);
✔63:                  target[index + 3] = transform(input[index + 3]);
✔64:                  target[index + 4] = transform(input[index + 4]);
✔65:                  target[index + 5] = transform(input[index + 5]);
✔66:                  target[index + 6] = transform(input[index + 6]);
✔67:                  target[index + 7] = transform(input[index + 7]);
〰68:              }
✔69:          }
〰70:      }
〰71:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

