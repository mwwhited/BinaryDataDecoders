# BinaryDataDecoders.ToolKit.Codecs.RomanExtensions

## Summary

| Key             | Value                                               |
| :-------------- | :-------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Codecs.RomanExtensions` |
| Assembly        | `BinaryDataDecoders.ToolKit`                        |
| Coveredlines    | `25`                                                |
| Uncoveredlines  | `3`                                                 |
| Coverablelines  | `28`                                                |
| Totallines      | `57`                                                |
| Linecoverage    | `89.2`                                              |
| Coveredbranches | `22`                                                |
| Totalbranches   | `28`                                                |
| Branchcoverage  | `78.5`                                              |
| Coveredmethods  | `3`                                                 |
| Totalmethods    | `3`                                                 |
| Methodcoverage  | `100`                                               |

## Metrics

| Complexity | Lines | Branches | Name         |
| :--------- | :---- | :------- | :----------- |
| 6          | 87.50 | 83.33    | `FirstPass`  |
| 6          | 88.88 | 83.33    | `SecondPass` |
| 16         | 90.90 | 75.00    | `GetValue`   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Codecs/RomanExtensions.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Codecs
〰5:   {
〰6:       internal static class RomanExtensions
〰7:       {
〰8:           internal static IEnumerable<int> FirstPass(this IEnumerable<char> value)
〰9:           {
✔10:              var enumerator = value.GetEnumerator();
✔11:              while (enumerator.MoveNext())
〰12:              {
✔13:                  if (enumerator.Current == '/')
〰14:                  {
⚠15:                      if (!enumerator.MoveNext())
‼16:                          throw new ApplicationException("invalid. unexpected end of input");
✔17:                      yield return enumerator.Current.GetValue() * 1000;
〰18:                  }
〰19:                  else
〰20:                  {
✔21:                      yield return enumerator.Current.GetValue();
〰22:                  }
〰23:              }
✔24:          }
〰25:  
〰26:          internal static IEnumerable<int> SecondPass(this IEnumerable<int> inputs)
〰27:          {
✔28:              var enumerator = inputs.GetEnumerator();
⚠29:              if (!enumerator.MoveNext())
‼30:                  yield break;
〰31:  
✔32:              var last = enumerator.Current;
〰33:  
✔34:              while (enumerator.MoveNext())
〰35:              {
✔36:                  yield return last < enumerator.Current ? -last : last;
✔37:                  last = enumerator.Current;
〰38:              }
〰39:  
✔40:              yield return last;
✔41:          }
〰42:  
〰43:          internal static int GetValue(this char v) =>
⚠44:              v switch
✔45:              {
✔46:                  'I' => 1,
✔47:                  'V' => 5,
✔48:                  'X' => 10,
✔49:                  'L' => 50,
✔50:                  'C' => 100,
✔51:                  'D' => 500,
✔52:                  'M' => 1000,
‼53:                  _ => throw new NotSupportedException()
✔54:              };
〰55:  
〰56:      }
〰57:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

