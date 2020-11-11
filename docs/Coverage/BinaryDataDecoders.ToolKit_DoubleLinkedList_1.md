# BinaryDataDecoders.ToolKit.Collections.DoubleLinkedList`1

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.DoubleLinkedList`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `0`                                                         |
| Uncoveredlines  | `33`                                                        |
| Coverablelines  | `33`                                                        |
| Totallines      | `66`                                                        |
| Linecoverage    | `0`                                                         |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `12`                                                        |
| Branchcoverage  | `0`                                                         |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 0     | 100      | `ctor`         |
| 1          | 0     | 100      | `get_Previous` |
| 1          | 0     | 100      | `get_Current`  |
| 1          | 0     | 100      | `get_Next`     |
| 1          | 0     | 100      | `get_Position` |
| 4          | 0     | 0        | `SyncPosition` |
| 4          | 0     | 0        | `InsertBefore` |
| 4          | 0     | 0        | `InsertAfter`  |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Collections\DoubleLinkedList.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Collections
〰4:   {
〰5:       internal class DoubleLinkedList<T> : IDoubleLinkedList<T>
〰6:       {
‼7:           private readonly object _lock = new object();
〰8:           private int _position;
〰9:   
‼10:          public DoubleLinkedList(T item) => Current = item;
〰11:  
‼12:          public IDoubleLinkedList<T>? Previous { get; private set; }
‼13:          public T Current { get; }
‼14:          public IDoubleLinkedList<T>? Next { get; private set; }
〰15:  
‼16:          public int Position => _position;
〰17:  
〰18:          private static void SyncPosition(DoubleLinkedList<T> from)
〰19:          {
‼20:              var seed = from._position;
‼21:              while (from?.Next is DoubleLinkedList<T> next)
〰22:              {
‼23:                  next._position = ++seed;
‼24:                  from = next;
‼25:              }
‼26:          }
〰27:  
〰28:          public IDoubleLinkedList<T> InsertBefore(T item)
〰29:          {
‼30:              lock (_lock)
〰31:              {
‼32:                  var newItem = new DoubleLinkedList<T>(item) { Previous = this.Previous, Next = this };
‼33:                  if (this.Previous is DoubleLinkedList<T> previous)
〰34:                  {
‼35:                      previous.Next = newItem;
‼36:                      newItem._position = previous._position + 1;
〰37:                  }
‼38:                  else if (this.Previous != null)
〰39:                  {
‼40:                      throw new NotSupportedException();
〰41:                  }
‼42:                  this.Previous = newItem;
‼43:                  SyncPosition(newItem);
‼44:                  return newItem;
〰45:              }
‼46:          }
〰47:          public IDoubleLinkedList<T> InsertAfter(T item)
〰48:          {
‼49:              lock (_lock)
〰50:              {
‼51:                  var newItem = new DoubleLinkedList<T>(item) { Previous = this, Next = this.Next, _position = this._position + 1, };
‼52:                  if (this.Next is DoubleLinkedList<T> next)
〰53:                  {
‼54:                      next.Previous = newItem;
〰55:                  }
‼56:                  else if (this.Next != null)
〰57:                  {
‼58:                      throw new NotSupportedException();
〰59:                  }
‼60:                  this.Next = newItem;
‼61:                  SyncPosition(newItem);
‼62:                  return newItem;
〰63:              }
‼64:          }
〰65:      }
〰66:  }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

