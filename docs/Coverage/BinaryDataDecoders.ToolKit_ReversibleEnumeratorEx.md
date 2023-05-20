# BinaryDataDecoders.ToolKit.Collections.ReversibleEnumeratorEx

## Summary

| Key             | Value                                                           |
| :-------------- | :-------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.ReversibleEnumeratorEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                    |
| Coveredlines    | `0`                                                             |
| Uncoveredlines  | `13`                                                            |
| Coverablelines  | `13`                                                            |
| Totallines      | `83`                                                            |
| Linecoverage    | `0`                                                             |
| Coveredbranches | `0`                                                             |
| Totalbranches   | `14`                                                            |
| Branchcoverage  | `0`                                                             |
| Coveredmethods  | `0`                                                             |
| Totalmethods    | `6`                                                             |
| Methodcoverage  | `0`                                                             |

## Metrics

| Complexity | Lines | Branches | Name               |
| :--------- | :---- | :------- | :----------------- |
| 1          | 0     | 100      | `Rewind`           |
| 1          | 0     | 100      | `FastForward`      |
| 2          | 0     | 0        | `FastForwardToEnd` |
| 4          | 0     | 0        | `Offset`           |
| 4          | 0     | 0        | `Back`             |
| 4          | 0     | 0        | `Forward`          |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Collections/ReversibleEnumeratorEx.cs

```CSharp
〰1:   namespace BinaryDataDecoders.ToolKit.Collections
〰2:   {
〰3:       public static class ReversibleEnumeratorEx
〰4:       {
〰5:   
〰6:           /// <summary>
〰7:           ///
〰8:           /// </summary>
〰9:           /// <typeparam name="T"></typeparam>
〰10:          /// <param name="current"></param>
〰11:          /// <returns></returns>
〰12:          public static IReversibleEnumerator<T> Rewind<T>(this IReversibleEnumerator<T> current)
〰13:          {
‼14:              current.Reset();
‼15:              return current;
〰16:          }
〰17:  
〰18:          /// <summary>
〰19:          /// move to last element in cache
〰20:          /// </summary>
〰21:          /// <typeparam name="T"></typeparam>
〰22:          /// <param name="current"></param>
〰23:          /// <returns></returns>
〰24:          public static IReversibleEnumerator<T> FastForward<T>(this IReversibleEnumerator<T> current)
〰25:          {
‼26:              current.MoveCurrent();
‼27:              return current;
〰28:          }
〰29:  
〰30:          /// <summary>
〰31:          /// move to last element in IDoubleLinkedList
〰32:          /// </summary>
〰33:          /// <typeparam name="T"></typeparam>
〰34:          /// <param name="current"></param>
〰35:          /// <returns></returns>
〰36:          public static IReversibleEnumerator<T> FastForwardToEnd<T>(this IReversibleEnumerator<T> current)
〰37:          {
‼38:              while (current.MoveNext()) ;
‼39:              return current;
〰40:          }
〰41:  
〰42:          /// <summary>
〰43:          /// try moving to realative position
〰44:          /// </summary>
〰45:          /// <typeparam name="T"></typeparam>
〰46:          /// <param name="current"></param>
〰47:          /// <param name="count"></param>
〰48:          /// <returns></returns>
〰49:          public static IReversibleEnumerator<T> Offset<T>(this IReversibleEnumerator<T> current, int count) =>
〰50:              count switch
〰51:              {
‼52:                  _ when count > 0 => current.Forward(count),
‼53:                  _ when count < 0 => current.Back(count * -1),
‼54:                  _ => current
〰55:              };
〰56:  
〰57:          /// <summary>
〰58:          /// move backwards at least count steps
〰59:          /// </summary>
〰60:          /// <typeparam name="T"></typeparam>
〰61:          /// <param name="current"></param>
〰62:          /// <param name="count"></param>
〰63:          /// <returns></returns>
〰64:          public static IReversibleEnumerator<T> Back<T>(this IReversibleEnumerator<T> current, int count)
〰65:          {
‼66:              for (var i = 0; i < count && current.MovePrevious(); i++) ;
‼67:              return current;
〰68:          }
〰69:  
〰70:          /// <summary>
〰71:          /// move forwards at least count steps
〰72:          /// </summary>
〰73:          /// <typeparam name="T"></typeparam>
〰74:          /// <param name="current"></param>
〰75:          /// <param name="count"></param>
〰76:          /// <returns></returns>
〰77:          public static IReversibleEnumerator<T> Forward<T>(this IReversibleEnumerator<T> current, int count)
〰78:          {
‼79:              for (var i = 0; i < count && current.MoveNext(); i++) ;
‼80:              return current;
〰81:          }
〰82:      }
〰83:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

