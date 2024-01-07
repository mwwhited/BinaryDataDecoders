# BinaryDataDecoders.ToolKit.MemoryEx

## Summary

| Key             | Value                                 |
| :-------------- | :------------------------------------ |
| Class           | `BinaryDataDecoders.ToolKit.MemoryEx` |
| Assembly        | `BinaryDataDecoders.ToolKit`          |
| Coveredlines    | `33`                                  |
| Uncoveredlines  | `75`                                  |
| Coverablelines  | `108`                                 |
| Totallines      | `247`                                 |
| Linecoverage    | `30.5`                                |
| Coveredbranches | `16`                                  |
| Totalbranches   | `68`                                  |
| Branchcoverage  | `23.5`                                |
| Coveredmethods  | `5`                                   |
| Totalmethods    | `18`                                  |
| Methodcoverage  | `27.7`                                |

## Metrics

| Complexity | Lines | Branches | Name                 |
| :--------- | :---- | :------- | :------------------- |
| 1          | 0     | 100      | `AsMemory`           |
| 1          | 0     | 100      | `Distinct`           |
| 2          | 0     | 0        | `BytesFromHexString` |
| 1          | 0     | 100      | `Split`              |
| 1          | 0     | 100      | `Split`              |
| 4          | 0     | 0        | `Split`              |
| 4          | 0     | 0        | `SplitWithExclude`   |
| 4          | 0     | 0        | `SplitWithReturn`    |
| 8          | 0     | 0        | `SplitWithCarry`     |
| 1          | 0     | 100      | `AsMemory`           |
| 1          | 0     | 100      | `Distinct`           |
| 2          | 0     | 0        | `BytesFromHexString` |
| 1          | 100   | 100      | `Split`              |
| 1          | 0     | 100      | `Split`              |
| 4          | 100   | 100      | `Split`              |
| 4          | 80.0  | 75.00    | `SplitWithExclude`   |
| 4          | 80.0  | 75.00    | `SplitWithReturn`    |
| 8          | 83.33 | 75.00    | `SplitWithCarry`     |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.ToolKit/MemoryEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit;
〰6:   
〰7:   /// <summary>
〰8:   /// Extension methods for System.Memory&lt;&gt;
〰9:   /// </summary>
〰10:  public static class MemoryEx
〰11:  {
〰12:      public static Memory<char> AsMemory(this IEnumerable<char> input) =>
‼13:          new(input.ToArray());
〰14:  
〰15:      public static IEnumerable<Memory<T>> Distinct<T>(this IEnumerable<Memory<T>> segments) where T : IEquatable<T> =>
‼16:          segments.Distinct(new MemoryCompare<T>());
〰17:  
〰18:      public static Memory<byte> BytesFromHexString(this Memory<char> input)
〰19:      {
〰20:          static byte charToNibble(char input)
〰21:          {
〰22:              unchecked
〰23:              {
‼24:                  if (input >= '0' && input <= '9') return (byte)(input - '0');
‼25:                  else if (input >= 'A' && input <= 'F') return (byte)(input - 'A' + 10);
‼26:                  else if (input >= 'a' && input <= 'f') return (byte)(input - 'a' + 10);
‼27:                  else throw new InvalidOperationException();
〰28:              }
〰29:          }
〰30:  
‼31:          var memory = new Memory<byte>(new byte[input.Length / 2]);
‼32:          for (var i = 0; i < input.Length; i += 2)
〰33:          {
‼34:              var highNibble = charToNibble(input.Span[i]);
‼35:              var lowNibble = charToNibble(input.Span[i + 1]);
〰36:  
‼37:              var memoryIndex = i >> 1;
‼38:              var newValue = (byte)(highNibble << 4 | lowNibble);
〰39:  
‼40:              memory.Span[memoryIndex] = newValue;
〰41:          }
‼42:          return memory;
〰43:      }
〰44:  
〰45:      public static IEnumerable<Memory<byte>> Split(this Memory<byte> memory, byte delimiter, DelimiterOptions option = DelimiterOptions.Exclude) =>
‼46:          memory.Split<byte>(delimiter, option);
〰47:  
〰48:      public static IEnumerable<Memory<char>> Split(this Memory<char> memory, char delimiter, DelimiterOptions option = DelimiterOptions.Exclude) =>
‼49:          memory.Split<char>(delimiter, option);
〰50:  
〰51:      public static IEnumerable<Memory<T>> Split<T>(this Memory<T> memory, T delimiter, DelimiterOptions option = DelimiterOptions.Exclude) where T : IEquatable<T> =>
‼52:          option switch
‼53:          {
‼54:              DelimiterOptions.Return => SplitWithReturn(memory, delimiter),
‼55:              DelimiterOptions.Carry => SplitWithCarry(memory, delimiter),
‼56:              _ => SplitWithExclude(memory, delimiter),
‼57:          };
〰58:  
〰59:      private static IEnumerable<Memory<T>> SplitWithExclude<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰60:      {
‼61:          var pointer = 0;
‼62:          while (memory.Length > pointer)
〰63:          {
‼64:              var segment = memory.Span[pointer..];
‼65:              var next = segment.IndexOf(delimiter) + 1;
〰66:  
‼67:              if (next <= 0)
〰68:              {
‼69:                  yield return memory[pointer..];
‼70:                  yield break;
〰71:              }
〰72:              else
〰73:              {
‼74:                  yield return memory.Slice(pointer, next - 1);
‼75:                  pointer += next;
〰76:              }
〰77:          }
‼78:      }
〰79:  
〰80:      private static IEnumerable<Memory<T>> SplitWithReturn<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰81:      {
‼82:          var pointer = 0;
‼83:          while (memory.Length > pointer)
〰84:          {
‼85:              var segment = memory.Span[pointer..];
‼86:              var next = segment.IndexOf(delimiter) + 1;
〰87:  
‼88:              if (next <= 0)
〰89:              {
‼90:                  yield return memory[pointer..];
‼91:                  yield break;
〰92:              }
〰93:              else
〰94:              {
‼95:                  yield return memory.Slice(pointer, next);
‼96:                  pointer += next;
〰97:              }
〰98:          }
‼99:      }
〰100: 
〰101:     private static IEnumerable<Memory<T>> SplitWithCarry<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰102:     {
‼103:         var pointer = 0;
‼104:         while (memory.Length > pointer)
〰105:         {
‼106:             var bump = delimiter.Equals(memory.Span[pointer]);
‼107:             var segmentPointer = bump ? pointer + 1 : pointer;
‼108:             var segment = memory.Span[segmentPointer..];
‼109:             var next = segment.IndexOf(delimiter) + (bump ? 1 : 0);
〰110: 
‼111:             if (next <= 0)
〰112:             {
‼113:                 yield return memory[pointer..];
‼114:                 yield break;
〰115:             }
〰116:             else
〰117:             {
‼118:                 yield return memory.Slice(pointer, next);
‼119:                 pointer += next;
〰120:             }
〰121:         }
‼122:     }
〰123: }
```

## File - https://raw.githubusercontent.com/mwwhited/BinaryDataDecoders/8fd359b8b3f932c5cfbd8436ce7fb9059d985101/src/BinaryDataDecoders.ToolKit/MemoryEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit;
〰6:   
〰7:   /// <summary>
〰8:   /// Extension methods for System.Memory&lt;&gt;
〰9:   /// </summary>
〰10:  public static class MemoryEx
〰11:  {
〰12:      public static Memory<char> AsMemory(this IEnumerable<char> input) =>
‼13:          new(input.ToArray());
〰14:  
〰15:      public static IEnumerable<Memory<T>> Distinct<T>(this IEnumerable<Memory<T>> segments) where T : IEquatable<T> =>
‼16:          segments.Distinct(new MemoryCompare<T>());
〰17:  
〰18:      public static Memory<byte> BytesFromHexString(this Memory<char> input)
〰19:      {
〰20:          static byte charToNibble(char input)
〰21:          {
〰22:              unchecked
〰23:              {
‼24:                  if (input >= '0' && input <= '9') return (byte)(input - '0');
‼25:                  else if (input >= 'A' && input <= 'F') return (byte)(input - 'A' + 10);
‼26:                  else if (input >= 'a' && input <= 'f') return (byte)(input - 'a' + 10);
‼27:                  else throw new InvalidOperationException();
〰28:              }
〰29:          }
〰30:  
‼31:          var memory = new Memory<byte>(new byte[input.Length / 2]);
‼32:          for (var i = 0; i < input.Length; i += 2)
〰33:          {
‼34:              var highNibble = charToNibble(input.Span[i]);
‼35:              var lowNibble = charToNibble(input.Span[i + 1]);
〰36:  
‼37:              var memoryIndex = i >> 1;
‼38:              var newValue = (byte)(highNibble << 4 | lowNibble);
〰39:  
‼40:              memory.Span[memoryIndex] = newValue;
〰41:          }
‼42:          return memory;
〰43:      }
〰44:  
〰45:      public static IEnumerable<Memory<byte>> Split(this Memory<byte> memory, byte delimiter, DelimiterOptions option = DelimiterOptions.Exclude) =>
✔46:          memory.Split<byte>(delimiter, option);
〰47:  
〰48:      public static IEnumerable<Memory<char>> Split(this Memory<char> memory, char delimiter, DelimiterOptions option = DelimiterOptions.Exclude) =>
‼49:          memory.Split<char>(delimiter, option);
〰50:  
〰51:      public static IEnumerable<Memory<T>> Split<T>(this Memory<T> memory, T delimiter, DelimiterOptions option = DelimiterOptions.Exclude) where T : IEquatable<T> =>
✔52:          option switch
✔53:          {
✔54:              DelimiterOptions.Return => SplitWithReturn(memory, delimiter),
✔55:              DelimiterOptions.Carry => SplitWithCarry(memory, delimiter),
✔56:              _ => SplitWithExclude(memory, delimiter),
✔57:          };
〰58:  
〰59:      private static IEnumerable<Memory<T>> SplitWithExclude<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰60:      {
✔61:          var pointer = 0;
⚠62:          while (memory.Length > pointer)
〰63:          {
✔64:              var segment = memory.Span[pointer..];
✔65:              var next = segment.IndexOf(delimiter) + 1;
〰66:  
✔67:              if (next <= 0)
〰68:              {
✔69:                  yield return memory[pointer..];
‼70:                  yield break;
〰71:              }
〰72:              else
〰73:              {
✔74:                  yield return memory.Slice(pointer, next - 1);
✔75:                  pointer += next;
〰76:              }
〰77:          }
‼78:      }
〰79:  
〰80:      private static IEnumerable<Memory<T>> SplitWithReturn<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰81:      {
✔82:          var pointer = 0;
⚠83:          while (memory.Length > pointer)
〰84:          {
✔85:              var segment = memory.Span[pointer..];
✔86:              var next = segment.IndexOf(delimiter) + 1;
〰87:  
✔88:              if (next <= 0)
〰89:              {
✔90:                  yield return memory[pointer..];
‼91:                  yield break;
〰92:              }
〰93:              else
〰94:              {
✔95:                  yield return memory.Slice(pointer, next);
✔96:                  pointer += next;
〰97:              }
〰98:          }
‼99:      }
〰100: 
〰101:     private static IEnumerable<Memory<T>> SplitWithCarry<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰102:     {
✔103:         var pointer = 0;
⚠104:         while (memory.Length > pointer)
〰105:         {
⚠106:             var bump = delimiter.Equals(memory.Span[pointer]);
✔107:             var segmentPointer = bump ? pointer + 1 : pointer;
✔108:             var segment = memory.Span[segmentPointer..];
✔109:             var next = segment.IndexOf(delimiter) + (bump ? 1 : 0);
〰110: 
✔111:             if (next <= 0)
〰112:             {
✔113:                 yield return memory[pointer..];
‼114:                 yield break;
〰115:             }
〰116:             else
〰117:             {
✔118:                 yield return memory.Slice(pointer, next);
✔119:                 pointer += next;
〰120:             }
〰121:         }
‼122:     }
〰123: }
〰124: 
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

