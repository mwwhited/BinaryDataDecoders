# BinaryDataDecoders.ToolKit.Collections.DoubleLinkedListEx

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.DoubleLinkedListEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `0`                                                         |
| Uncoveredlines  | `11`                                                        |
| Coverablelines  | `11`                                                        |
| Totallines      | `98`                                                        |
| Linecoverage    | `0`                                                         |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `24`                                                        |
| Branchcoverage  | `0`                                                         |

## Metrics

| Complexity | Lines | Branches | Name          |
| :--------- | :---- | :------- | :------------ |
| 4          | 0     | 0        | `Rewind`      |
| 4          | 0     | 0        | `FastForward` |
| 4          | 0     | 0        | `Offset`      |
| 6          | 0     | 0        | `Back`        |
| 6          | 0     | 0        | `Forward`     |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Collections\DoubleLinkedListEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   
〰4:   namespace BinaryDataDecoders.ToolKit.Collections
〰5:   {
〰6:       /// <summary>
〰7:       /// Extensions for IDoubleLinkedList
〰8:       /// </summary>
〰9:       internal static class DoubleLinkedListEx
〰10:      {
〰11:          /// <summary>
〰12:          /// move for first element in IDoubleLinkedList
〰13:          /// </summary>
〰14:          /// <typeparam name="T"></typeparam>
〰15:          /// <param name="current"></param>
〰16:          /// <returns></returns>
〰17:          public static IDoubleLinkedList<T> Rewind<T>(this IDoubleLinkedList<T> current)
〰18:          {
‼19:              while (current.Previous != null) current = current.Previous ?? throw new NullReferenceException();
‼20:              return current;
〰21:          }
〰22:          /// <summary>
〰23:          /// move to last element in IDoubleLinkedList
〰24:          /// </summary>
〰25:          /// <typeparam name="T"></typeparam>
〰26:          /// <param name="current"></param>
〰27:          /// <returns></returns>
〰28:          public static IDoubleLinkedList<T> FastForward<T>(this IDoubleLinkedList<T> current)
〰29:          {
‼30:              while (current.Next != null) current = current.Next ?? throw new NullReferenceException();
‼31:              return current;
〰32:          }
〰33:  
〰34:          /// <summary>
〰35:          /// try moving to realative position
〰36:          /// </summary>
〰37:          /// <typeparam name="T"></typeparam>
〰38:          /// <param name="current"></param>
〰39:          /// <param name="count"></param>
〰40:          /// <returns></returns>
〰41:          public static IDoubleLinkedList<T> Offset<T>(this IDoubleLinkedList<T> current, int count) =>
〰42:              count switch
〰43:              {
‼44:                  _ when count > 0 => current.Forward(count),
‼45:                  _ when count < 0 => current.Back(count * -1),
‼46:                  _ => current
〰47:              };
〰48:  
〰49:          /// <summary>
〰50:          /// move backwards at least count steps
〰51:          /// </summary>
〰52:          /// <typeparam name="T"></typeparam>
〰53:          /// <param name="current"></param>
〰54:          /// <param name="count"></param>
〰55:          /// <returns></returns>
〰56:          public static IDoubleLinkedList<T> Back<T>(this IDoubleLinkedList<T> current, int count)
〰57:          {
‼58:              while (current.Previous != null && count-- > 0) current = current.Previous ?? throw new NullReferenceException();
‼59:              return current;
〰60:          }
〰61:  
〰62:          /// <summary>
〰63:          /// move forwards at least count steps
〰64:          /// </summary>
〰65:          /// <typeparam name="T"></typeparam>
〰66:          /// <param name="current"></param>
〰67:          /// <param name="count"></param>
〰68:          /// <returns></returns>
〰69:          public static IDoubleLinkedList<T> Forward<T>(this IDoubleLinkedList<T> current, int count)
〰70:          {
‼71:              while (current.Next != null && count-- > 0) current = current.Next ?? throw new NullReferenceException();
‼72:              return current;
〰73:          }
〰74:  
〰75:          public static IEnumerable<T> AsEnumerable<T>(this IDoubleLinkedList<T> current)
〰76:          {
〰77:              IDoubleLinkedList<T>? list = current;
〰78:              if (list == null) yield break;
〰79:              do
〰80:              {
〰81:                  yield return list.Current;
〰82:                  list = list.Next;
〰83:              }
〰84:              while (list?.Next != null);
〰85:          }
〰86:          public static IEnumerable<T> AsEnumerableReversed<T>(this IDoubleLinkedList<T> current)
〰87:          {
〰88:              IDoubleLinkedList<T>? list = current;
〰89:              if (list == null) yield break;
〰90:              do
〰91:              {
〰92:                  yield return list.Current;
〰93:                  list = list.Previous;
〰94:              }
〰95:              while (list?.Previous != null);
〰96:          }
〰97:      }
〰98:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

