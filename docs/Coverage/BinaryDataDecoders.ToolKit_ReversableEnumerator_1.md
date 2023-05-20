# BinaryDataDecoders.ToolKit.Collections.ReversableEnumerator`1

## Summary

| Key             | Value                                                           |
| :-------------- | :-------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.ReversableEnumerator`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                    |
| Coveredlines    | `0`                                                             |
| Uncoveredlines  | `64`                                                            |
| Coverablelines  | `64`                                                            |
| Totallines      | `167`                                                           |
| Linecoverage    | `0`                                                             |
| Coveredbranches | `0`                                                             |
| Totalbranches   | `30`                                                            |
| Branchcoverage  | `0`                                                             |
| Coveredmethods  | `0`                                                             |
| Totalmethods    | `10`                                                            |
| Methodcoverage  | `0`                                                             |

## Metrics

| Complexity | Lines | Branches | Name                                      |
| :--------- | :---- | :------- | :---------------------------------------- |
| 1          | 0     | 100      | `ctor`                                    |
| 1          | 0     | 100      | `get_Position`                            |
| 1          | 0     | 100      | `ctor`                                    |
| 2          | 0     | 0        | `get_Current`                             |
| 1          | 0     | 100      | `SystemCollectionsIEnumeratorget_Current` |
| 1          | 0     | 100      | `Dispose`                                 |
| 14         | 0     | 0        | `MoveNext`                                |
| 4          | 0     | 0        | `MoveCurrent`                             |
| 6          | 0     | 0        | `MovePrevious`                            |
| 4          | 0     | 0        | `Reset`                                   |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/Collections/ReversableEnumerator.cs

```CSharp
〰1:   using System.Collections;
〰2:   using System.Collections.Generic;
〰3:   using System.Diagnostics;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Collections
〰6:   {
〰7:       /// <summary>
〰8:       /// this is a enumerator is bidirectional
〰9:       /// </summary>
〰10:      /// <typeparam name="T"></typeparam>
〰11:      [DebuggerDisplay("{Current.ToString()}::{_position}")]
〰12:      public class ReversableEnumerator<T> : IReversibleEnumerator<T>
〰13:      {
〰14:          private const int ResetPosition = -1;
‼15:          private readonly object _lock = new object();
〰16:  
〰17:          private readonly IEnumerator<T> _base;
〰18:          private IDoubleLinkedList<T>? _pointer = null;
〰19:          private bool _reset = false;
〰20:          private bool _end = false;
‼21:          private int _position = ResetPosition;
〰22:  
‼23:          public int Position => _position;
〰24:  
〰25:          /// <summary>
〰26:          /// Wrap existing IEnumerable
〰27:          /// </summary>
〰28:          /// <param name="base"></param>
‼29:          public ReversableEnumerator(IEnumerable<T> @base) : this(@base.GetEnumerator()) { }
〰30:          /// <summary>
〰31:          /// Wrap existing IEnumerator
〰32:          /// </summary>
〰33:          /// <param name="base"></param>
‼34:          public ReversableEnumerator(IEnumerator<T> @base) => _base = @base;
〰35:  
‼36:          public T Current => _pointer == null ? _base.Current : _pointer.Current;
〰37:  
〰38:  #pragma warning disable CS8603 // Possible null reference return.
‼39:          object IEnumerator.Current => Current;
〰40:  #pragma warning restore CS8603 // Possible null reference return.
〰41:  
〰42:          /// <summary>
〰43:          /// free any underlying resources
〰44:          /// </summary>
‼45:          public void Dispose() => _base.Dispose();
〰46:  
〰47:          /// <summary>
〰48:          /// allow playing to end of current state before checking for new values in enumerable set.
〰49:          /// </summary>
〰50:          /// <returns>true if advanced</returns>
〰51:          public bool MoveNext()
〰52:          {
‼53:              lock (_lock)
〰54:              {
‼55:                  if (_end)
〰56:                  {
‼57:                      return false;
〰58:                  }
‼59:                  if (_reset && _pointer != null)
〰60:                  {
‼61:                      _reset = false;
‼62:                      _position++;
‼63:                      return true;
〰64:                  }
〰65:  
‼66:                  if (_pointer == null)
〰67:                  {
‼68:                      var advanceBase = _base.MoveNext();
‼69:                      if (advanceBase)
〰70:                      {
‼71:                          _pointer = new DoubleLinkedList<T>(_base.Current);
‼72:                          _position++;
‼73:                          return true;
〰74:                      }
〰75:                      else
〰76:                      {
‼77:                          return false;
〰78:                      }
〰79:                  }
〰80:                  else
〰81:                  {
‼82:                      var next = _pointer.Next;
‼83:                      if (next != null)
〰84:                      {
‼85:                          _pointer = next;
‼86:                          _position++;
‼87:                          return true;
〰88:                      }
〰89:                      else
〰90:                      {
‼91:                          var advanceBase = _base.MoveNext();
‼92:                          if (advanceBase)
〰93:                          {
‼94:                              _pointer = _pointer.InsertAfter(_base.Current);
‼95:                              _position++;
‼96:                              return true;
〰97:                          }
〰98:                          else
〰99:                          {
‼100:                             _end = true;
‼101:                             return false;
〰102:                         }
〰103:                     }
〰104:                 }
〰105:             }
‼106:         }
〰107: 
〰108:         public bool MoveCurrent()
〰109:         {
‼110:             lock (_lock)
〰111:             {
‼112:                 if (_pointer != null)
〰113:                 {
‼114:                     var next = _pointer.FastForward();
‼115:                     _pointer = next;
‼116:                     if (_pointer is DoubleLinkedList<T> dd)
〰117:                     {
‼118:                         _position = dd.Position;
〰119:                     }
‼120:                     _reset = false;
‼121:                     _end = false;
‼122:                     return true;
〰123:                 }
〰124:                 else
〰125:                 {
‼126:                     _reset = true;
‼127:                     _end = false;
‼128:                     return false;
〰129:                 }
〰130:             }
‼131:         }
〰132: 
〰133:         /// <summary>
〰134:         /// if the enumerator has been advanced it may be stepped back here.
〰135:         /// </summary>
〰136:         /// <returns>true if stepped back</returns>
〰137:         public bool MovePrevious()
〰138:         {
‼139:             lock (_lock)
〰140:             {
‼141:                 var moveTo = _pointer?.Previous;
‼142:                 if (moveTo == null) return false;
‼143:                 _pointer = moveTo;
‼144:                 _position--;
‼145:                 if (_position < 0) _position = 0;
‼146:                 return true;
〰147:             }
‼148:         }
〰149: 
〰150:         /// <summary>
〰151:         /// if the rewind to the beginning.
〰152:         /// </summary>
〰153:         public void Reset()
〰154:         {
‼155:             lock (_lock)
〰156:             {
‼157:                 if (_pointer != null)
〰158:                 {
‼159:                     _pointer = _pointer?.Rewind();
‼160:                     _reset = true;
‼161:                     _end = false;
‼162:                     _position = ResetPosition;
〰163:                 }
‼164:             }
‼165:         }
〰166:     }
〰167: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

