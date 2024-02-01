# BinaryDataDecoders.ToolKit.Collections.DoubleLinkedList`1

## Summary

| Key             | Value                                                       |
| :-------------- | :---------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.DoubleLinkedList`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                |
| Coveredlines    | `0`                                                         |
| Uncoveredlines  | `60`                                                        |
| Coverablelines  | `60`                                                        |
| Totallines      | `127`                                                       |
| Linecoverage    | `0`                                                         |
| Coveredbranches | `0`                                                         |
| Totalbranches   | `24`                                                        |
| Branchcoverage  | `0`                                                         |
| Coveredmethods  | `0`                                                         |
| Totalmethods    | `10`                                                        |
| Methodcoverage  | `0`                                                         |

## Metrics

| Complexity | Lines | Branches | Name           |
| :--------- | :---- | :------- | :------------- |
| 1          | 0     | 100      | `ctor`         |
| 1          | 0     | 100      | `get_Position` |
| 4          | 0     | 0        | `SyncPosition` |
| 4          | 0     | 0        | `InsertBefore` |
| 4          | 0     | 0        | `InsertAfter`  |
| 1          | 0     | 100      | `ctor`         |
| 1          | 0     | 100      | `get_Position` |
| 4          | 0     | 0        | `SyncPosition` |
| 4          | 0     | 0        | `InsertBefore` |
| 4          | 0     | 0        | `InsertAfter`  |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Collections/DoubleLinkedList.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Collections;
〰4:   
〰5:   internal class DoubleLinkedList<T>(T item) : IDoubleLinkedList<T>
〰6:   {
‼7:       private readonly object _lock = new();
〰8:       private int _position;
〰9:   
〰10:      public IDoubleLinkedList<T>? Previous { get; private set; }
‼11:      public T Current { get; } = item;
〰12:      public IDoubleLinkedList<T>? Next { get; private set; }
〰13:  
‼14:      public int Position => _position;
〰15:  
〰16:      private static void SyncPosition(DoubleLinkedList<T> from)
〰17:      {
‼18:          var seed = from._position;
‼19:          while (from?.Next is DoubleLinkedList<T> next)
〰20:          {
‼21:              next._position = ++seed;
‼22:              from = next;
‼23:          }
‼24:      }
〰25:  
〰26:      public IDoubleLinkedList<T> InsertBefore(T item)
〰27:      {
‼28:          lock (_lock)
〰29:          {
‼30:              var newItem = new DoubleLinkedList<T>(item) { Previous = this.Previous, Next = this };
‼31:              if (this.Previous is DoubleLinkedList<T> previous)
〰32:              {
‼33:                  previous.Next = newItem;
‼34:                  newItem._position = previous._position + 1;
〰35:              }
‼36:              else if (this.Previous != null)
〰37:              {
‼38:                  throw new NotSupportedException();
〰39:              }
‼40:              this.Previous = newItem;
‼41:              SyncPosition(newItem);
‼42:              return newItem;
〰43:          }
‼44:      }
〰45:      public IDoubleLinkedList<T> InsertAfter(T item)
〰46:      {
‼47:          lock (_lock)
〰48:          {
‼49:              var newItem = new DoubleLinkedList<T>(item) { Previous = this, Next = this.Next, _position = this._position + 1, };
‼50:              if (this.Next is DoubleLinkedList<T> next)
〰51:              {
‼52:                  next.Previous = newItem;
〰53:              }
‼54:              else if (this.Next != null)
〰55:              {
‼56:                  throw new NotSupportedException();
〰57:              }
‼58:              this.Next = newItem;
‼59:              SyncPosition(newItem);
‼60:              return newItem;
〰61:          }
‼62:      }
〰63:  }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Collections/DoubleLinkedList.cs

```CSharp
〰1:   using System;
〰2:   
〰3:   namespace BinaryDataDecoders.ToolKit.Collections;
〰4:   
〰5:   internal class DoubleLinkedList<T>(T item) : IDoubleLinkedList<T>
〰6:   {
‼7:       private readonly object _lock = new();
〰8:       private int _position;
〰9:   
〰10:      public IDoubleLinkedList<T>? Previous { get; private set; }
‼11:      public T Current { get; } = item;
〰12:      public IDoubleLinkedList<T>? Next { get; private set; }
〰13:  
‼14:      public int Position => _position;
〰15:  
〰16:      private static void SyncPosition(DoubleLinkedList<T> from)
〰17:      {
‼18:          var seed = from._position;
‼19:          while (from?.Next is DoubleLinkedList<T> next)
〰20:          {
‼21:              next._position = ++seed;
‼22:              from = next;
‼23:          }
‼24:      }
〰25:  
〰26:      public IDoubleLinkedList<T> InsertBefore(T item)
〰27:      {
‼28:          lock (_lock)
〰29:          {
‼30:              var newItem = new DoubleLinkedList<T>(item) { Previous = this.Previous, Next = this };
‼31:              if (this.Previous is DoubleLinkedList<T> previous)
〰32:              {
‼33:                  previous.Next = newItem;
‼34:                  newItem._position = previous._position + 1;
〰35:              }
‼36:              else if (this.Previous != null)
〰37:              {
‼38:                  throw new NotSupportedException();
〰39:              }
‼40:              this.Previous = newItem;
‼41:              SyncPosition(newItem);
‼42:              return newItem;
〰43:          }
‼44:      }
〰45:      public IDoubleLinkedList<T> InsertAfter(T item)
〰46:      {
‼47:          lock (_lock)
〰48:          {
‼49:              var newItem = new DoubleLinkedList<T>(item) { Previous = this, Next = this.Next, _position = this._position + 1, };
‼50:              if (this.Next is DoubleLinkedList<T> next)
〰51:              {
‼52:                  next.Previous = newItem;
〰53:              }
‼54:              else if (this.Next != null)
〰55:              {
‼56:                  throw new NotSupportedException();
〰57:              }
‼58:              this.Next = newItem;
‼59:              SyncPosition(newItem);
‼60:              return newItem;
〰61:          }
‼62:      }
〰63:  }
〰64:  
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

