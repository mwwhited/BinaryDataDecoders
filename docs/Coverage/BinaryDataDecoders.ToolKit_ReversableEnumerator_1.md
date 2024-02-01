# BinaryDataDecoders.ToolKit.Collections.ReversableEnumerator`1

## Summary

| Key             | Value                                                           |
| :-------------- | :-------------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Collections.ReversableEnumerator`1` |
| Assembly        | `BinaryDataDecoders.ToolKit`                                    |
| Coveredlines    | `0`                                                             |
| Uncoveredlines  | `126`                                                           |
| Coverablelines  | `126`                                                           |
| Totallines      | `327`                                                           |
| Linecoverage    | `0`                                                             |
| Coveredbranches | `0`                                                             |
| Totalbranches   | `60`                                                            |
| Branchcoverage  | `0`                                                             |
| Coveredmethods  | `0`                                                             |
| Totalmethods    | `20`                                                            |
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
〰5:   namespace BinaryDataDecoders.ToolKit.Collections;
〰6:   
〰7:   /// <summary>
〰8:   /// this is a enumerator is bidirectional
〰9:   /// </summary>
〰10:  /// <typeparam name="T"></typeparam>
〰11:  /// <remarks>
〰12:  /// Wrap existing IEnumerator
〰13:  /// </remarks>
〰14:  /// <param name="base"></param>
〰15:  [DebuggerDisplay("{Current.ToString()}::{_position}")]
〰16:  public class ReversableEnumerator<T>(IEnumerator<T> @base) : IReversibleEnumerator<T>
〰17:  {
〰18:      private const int ResetPosition = -1;
‼19:      private readonly object _lock = new();
〰20:      private IDoubleLinkedList<T>? _pointer = null;
〰21:      private bool _reset = false;
〰22:      private bool _end = false;
‼23:      private int _position = ResetPosition;
〰24:  
‼25:      public int Position => _position;
〰26:  
〰27:      /// <summary>
〰28:      /// Wrap existing IEnumerable
〰29:      /// </summary>
〰30:      /// <param name="base"></param>
‼31:      public ReversableEnumerator(IEnumerable<T> @base) : this(@base.GetEnumerator()) { }
〰32:  
‼33:      public T Current => _pointer == null ? @base.Current : _pointer.Current;
〰34:  
〰35:  #pragma warning disable CS8603 // Possible null reference return.
‼36:      object IEnumerator.Current => Current;
〰37:  #pragma warning restore CS8603 // Possible null reference return.
〰38:  
〰39:      /// <summary>
〰40:      /// free any underlying resources
〰41:      /// </summary>
‼42:      public void Dispose() => @base.Dispose();
〰43:  
〰44:      /// <summary>
〰45:      /// allow playing to end of current state before checking for new values in enumerable set.
〰46:      /// </summary>
〰47:      /// <returns>true if advanced</returns>
〰48:      public bool MoveNext()
〰49:      {
‼50:          lock (_lock)
〰51:          {
‼52:              if (_end)
〰53:              {
‼54:                  return false;
〰55:              }
‼56:              if (_reset && _pointer != null)
〰57:              {
‼58:                  _reset = false;
‼59:                  _position++;
‼60:                  return true;
〰61:              }
〰62:  
‼63:              if (_pointer == null)
〰64:              {
‼65:                  var advanceBase = @base.MoveNext();
‼66:                  if (advanceBase)
〰67:                  {
‼68:                      _pointer = new DoubleLinkedList<T>(@base.Current);
‼69:                      _position++;
‼70:                      return true;
〰71:                  }
〰72:                  else
〰73:                  {
‼74:                      return false;
〰75:                  }
〰76:              }
〰77:              else
〰78:              {
‼79:                  var next = _pointer.Next;
‼80:                  if (next != null)
〰81:                  {
‼82:                      _pointer = next;
‼83:                      _position++;
‼84:                      return true;
〰85:                  }
〰86:                  else
〰87:                  {
‼88:                      var advanceBase = @base.MoveNext();
‼89:                      if (advanceBase)
〰90:                      {
‼91:                          _pointer = _pointer.InsertAfter(@base.Current);
‼92:                          _position++;
‼93:                          return true;
〰94:                      }
〰95:                      else
〰96:                      {
‼97:                          _end = true;
‼98:                          return false;
〰99:                      }
〰100:                 }
〰101:             }
〰102:         }
‼103:     }
〰104: 
〰105:     public bool MoveCurrent()
〰106:     {
‼107:         lock (_lock)
〰108:         {
‼109:             if (_pointer != null)
〰110:             {
‼111:                 var next = _pointer.FastForward();
‼112:                 _pointer = next;
‼113:                 if (_pointer is DoubleLinkedList<T> dd)
〰114:                 {
‼115:                     _position = dd.Position;
〰116:                 }
‼117:                 _reset = false;
‼118:                 _end = false;
‼119:                 return true;
〰120:             }
〰121:             else
〰122:             {
‼123:                 _reset = true;
‼124:                 _end = false;
‼125:                 return false;
〰126:             }
〰127:         }
‼128:     }
〰129: 
〰130:     /// <summary>
〰131:     /// if the enumerator has been advanced it may be stepped back here.
〰132:     /// </summary>
〰133:     /// <returns>true if stepped back</returns>
〰134:     public bool MovePrevious()
〰135:     {
‼136:         lock (_lock)
〰137:         {
‼138:             var moveTo = _pointer?.Previous;
‼139:             if (moveTo == null) return false;
‼140:             _pointer = moveTo;
‼141:             _position--;
‼142:             if (_position < 0) _position = 0;
‼143:             return true;
〰144:         }
‼145:     }
〰146: 
〰147:     /// <summary>
〰148:     /// if the rewind to the beginning.
〰149:     /// </summary>
〰150:     public void Reset()
〰151:     {
‼152:         lock (_lock)
〰153:         {
‼154:             if (_pointer != null)
〰155:             {
‼156:                 _pointer = _pointer?.Rewind();
‼157:                 _reset = true;
‼158:                 _end = false;
‼159:                 _position = ResetPosition;
〰160:             }
‼161:         }
‼162:     }
〰163: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8f631c73b86dfbff461b431d62cf8c3119f222f7/src/BinaryDataDecoders.ToolKit/Collections/ReversableEnumerator.cs

```CSharp
〰1:   using System.Collections;
〰2:   using System.Collections.Generic;
〰3:   using System.Diagnostics;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit.Collections;
〰6:   
〰7:   /// <summary>
〰8:   /// this is a enumerator is bidirectional
〰9:   /// </summary>
〰10:  /// <typeparam name="T"></typeparam>
〰11:  /// <remarks>
〰12:  /// Wrap existing IEnumerator
〰13:  /// </remarks>
〰14:  /// <param name="base"></param>
〰15:  [DebuggerDisplay("{Current.ToString()}::{_position}")]
〰16:  public class ReversableEnumerator<T>(IEnumerator<T> @base) : IReversibleEnumerator<T>
〰17:  {
〰18:      private const int ResetPosition = -1;
‼19:      private readonly object _lock = new();
〰20:      private IDoubleLinkedList<T>? _pointer = null;
〰21:      private bool _reset = false;
〰22:      private bool _end = false;
‼23:      private int _position = ResetPosition;
〰24:  
‼25:      public int Position => _position;
〰26:  
〰27:      /// <summary>
〰28:      /// Wrap existing IEnumerable
〰29:      /// </summary>
〰30:      /// <param name="base"></param>
‼31:      public ReversableEnumerator(IEnumerable<T> @base) : this(@base.GetEnumerator()) { }
〰32:  
‼33:      public T Current => _pointer == null ? @base.Current : _pointer.Current;
〰34:  
〰35:  #pragma warning disable CS8603 // Possible null reference return.
‼36:      object IEnumerator.Current => Current;
〰37:  #pragma warning restore CS8603 // Possible null reference return.
〰38:  
〰39:      /// <summary>
〰40:      /// free any underlying resources
〰41:      /// </summary>
‼42:      public void Dispose() => @base.Dispose();
〰43:  
〰44:      /// <summary>
〰45:      /// allow playing to end of current state before checking for new values in enumerable set.
〰46:      /// </summary>
〰47:      /// <returns>true if advanced</returns>
〰48:      public bool MoveNext()
〰49:      {
‼50:          lock (_lock)
〰51:          {
‼52:              if (_end)
〰53:              {
‼54:                  return false;
〰55:              }
‼56:              if (_reset && _pointer != null)
〰57:              {
‼58:                  _reset = false;
‼59:                  _position++;
‼60:                  return true;
〰61:              }
〰62:  
‼63:              if (_pointer == null)
〰64:              {
‼65:                  var advanceBase = @base.MoveNext();
‼66:                  if (advanceBase)
〰67:                  {
‼68:                      _pointer = new DoubleLinkedList<T>(@base.Current);
‼69:                      _position++;
‼70:                      return true;
〰71:                  }
〰72:                  else
〰73:                  {
‼74:                      return false;
〰75:                  }
〰76:              }
〰77:              else
〰78:              {
‼79:                  var next = _pointer.Next;
‼80:                  if (next != null)
〰81:                  {
‼82:                      _pointer = next;
‼83:                      _position++;
‼84:                      return true;
〰85:                  }
〰86:                  else
〰87:                  {
‼88:                      var advanceBase = @base.MoveNext();
‼89:                      if (advanceBase)
〰90:                      {
‼91:                          _pointer = _pointer.InsertAfter(@base.Current);
‼92:                          _position++;
‼93:                          return true;
〰94:                      }
〰95:                      else
〰96:                      {
‼97:                          _end = true;
‼98:                          return false;
〰99:                      }
〰100:                 }
〰101:             }
〰102:         }
‼103:     }
〰104: 
〰105:     public bool MoveCurrent()
〰106:     {
‼107:         lock (_lock)
〰108:         {
‼109:             if (_pointer != null)
〰110:             {
‼111:                 var next = _pointer.FastForward();
‼112:                 _pointer = next;
‼113:                 if (_pointer is DoubleLinkedList<T> dd)
〰114:                 {
‼115:                     _position = dd.Position;
〰116:                 }
‼117:                 _reset = false;
‼118:                 _end = false;
‼119:                 return true;
〰120:             }
〰121:             else
〰122:             {
‼123:                 _reset = true;
‼124:                 _end = false;
‼125:                 return false;
〰126:             }
〰127:         }
‼128:     }
〰129: 
〰130:     /// <summary>
〰131:     /// if the enumerator has been advanced it may be stepped back here.
〰132:     /// </summary>
〰133:     /// <returns>true if stepped back</returns>
〰134:     public bool MovePrevious()
〰135:     {
‼136:         lock (_lock)
〰137:         {
‼138:             var moveTo = _pointer?.Previous;
‼139:             if (moveTo == null) return false;
‼140:             _pointer = moveTo;
‼141:             _position--;
‼142:             if (_position < 0) _position = 0;
‼143:             return true;
〰144:         }
‼145:     }
〰146: 
〰147:     /// <summary>
〰148:     /// if the rewind to the beginning.
〰149:     /// </summary>
〰150:     public void Reset()
〰151:     {
‼152:         lock (_lock)
〰153:         {
‼154:             if (_pointer != null)
〰155:             {
‼156:                 _pointer = _pointer?.Rewind();
‼157:                 _reset = true;
‼158:                 _end = false;
‼159:                 _position = ResetPosition;
〰160:             }
‼161:         }
‼162:     }
〰163: }
〰164: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

