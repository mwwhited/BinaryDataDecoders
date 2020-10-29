
# BinaryDataDecoders.ToolKit.MemoryEx
Source: C:\Repos\mwwhited\BinaryDataDecoders\Publish\Results\Coverage\BinaryDataDecoders.ToolKit_MemoryEx.xml

## Summary

| Key                  | Value                                                            |
| :------------------- | :--------------------------------------------------------------- |
| Class                | BinaryDataDecoders.ToolKit.MemoryEx                          | 
| Assembly             | BinaryDataDecoders.ToolKit                                   | 
| Coveredlines         | 7                                                            | 
| Uncoveredlines       | 11                                                           | 
| Coverablelines       | 18                                                           | 
| Totallines           | 126                                                          | 
| Linecoverage         | 38.8                                                         | 
| Coveredbranches      | 4                                                            | 
| Totalbranches        | 6                                                            | 
| Branchcoverage       | 66.6                                                         | 
| Title                | C:\Repos\mwwhited\BinaryDataDecoders\src\..\src\BinaryDataDe | 

### Files
 * C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\MemoryEx.cs

## Metrics

| Complexity | Lines | Branches | Name                                          |
| :--------- | :---- | :------- | :-------------------------------------------- |
| 1          | 0     | 100      | AsMemory | 
| 1          | 0     | 100      | Distinct | 
| 2          | 0     | 0        | BytesFromHexString | 
| 1          | 100   | 100      | Split | 
| 1          | 0     | 100      | Split | 
| 4          | 100   | 100      | Split | 
## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\MemoryEx.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   
〰5:   namespace BinaryDataDecoders.ToolKit
〰6:   {
〰7:       /// <summary>
〰8:       /// Extension methods for System.Memory&lt;&gt;
〰9:       /// </summary>
〰10:      public static class MemoryEx
〰11:      {
〰12:  #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
〰13:          public static Memory<char> AsMemory(this IEnumerable<char> input) =>
‼14:              new Memory<char>(input.ToArray());
〰15:  
〰16:          public static IEnumerable<Memory<T>> Distinct<T>(this IEnumerable<Memory<T>> segments) where T : IEquatable<T> =>
‼17:              segments.Distinct(new MemoryCompare<T>());
〰18:  
〰19:          public static Memory<byte> BytesFromHexString(this Memory<char> input)
〰20:          {
〰21:              static byte charToNibble(char input)
〰22:              {
〰23:                  unchecked
〰24:                  {
〰25:                      if (input >= '0' && input <= '9') return (byte)(input - '0');
〰26:                      else if (input >= 'A' && input <= 'F') return (byte)(input - 'A' + 10);
〰27:                      else if (input >= 'a' && input <= 'f') return (byte)(input - 'a' + 10);
〰28:                      else throw new InvalidOperationException();
〰29:                  }
〰30:              }
〰31:  
‼32:              var memory = new Memory<byte>(new byte[input.Length / 2]);
‼33:              for (var i = 0; i < input.Length; i += 2)
〰34:              {
‼35:                  var highNibble = charToNibble(input.Span[i]);
‼36:                  var lowNibble = charToNibble(input.Span[i + 1]);
〰37:  
‼38:                  var memoryIndex = i >> 1;
‼39:                  var newValue = (byte)(highNibble << 4 | lowNibble);
〰40:  
‼41:                  memory.Span[memoryIndex] = newValue;
〰42:              }
‼43:              return memory;
〰44:          }
〰45:  
〰46:          public static IEnumerable<Memory<byte>> Split(this Memory<byte> memory, byte delimiter, DelimiterOptions option = DelimiterOptions.Exclude) =>
✔47:              memory.Split<byte>(delimiter, option);
〰48:  
〰49:          public static IEnumerable<Memory<char>> Split(this Memory<char> memory, char delimiter, DelimiterOptions option = DelimiterOptions.Exclude) =>
‼50:              memory.Split<char>(delimiter, option);
〰51:  
〰52:          public static IEnumerable<Memory<T>> Split<T>(this Memory<T> memory, T delimiter, DelimiterOptions option = DelimiterOptions.Exclude) where T : IEquatable<T> =>
✔53:              option switch
✔54:              {
✔55:                  DelimiterOptions.Return => SplitWithReturn(memory, delimiter),
✔56:                  DelimiterOptions.Carry => SplitWithCarry(memory, delimiter),
✔57:                  _ => SplitWithExclude(memory, delimiter),
✔58:              };
〰59:  
〰60:          private static IEnumerable<Memory<T>> SplitWithExclude<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰61:          {
〰62:              var pointer = 0;
〰63:              while (memory.Length > pointer)
〰64:              {
〰65:                  var segment = memory.Span.Slice(pointer);
〰66:                  var next = segment.IndexOf(delimiter) + 1;
〰67:  
〰68:                  if (next <= 0)
〰69:                  {
〰70:                      yield return memory.Slice(pointer);
〰71:                      yield break;
〰72:                  }
〰73:                  else
〰74:                  {
〰75:                      yield return memory.Slice(pointer, next - 1);
〰76:                      pointer += next;
〰77:                  }
〰78:              }
〰79:          }
〰80:  
〰81:          private static IEnumerable<Memory<T>> SplitWithReturn<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰82:          {
〰83:              var pointer = 0;
〰84:              while (memory.Length > pointer)
〰85:              {
〰86:                  var segment = memory.Span.Slice(pointer);
〰87:                  var next = segment.IndexOf(delimiter) + 1;
〰88:  
〰89:                  if (next <= 0)
〰90:                  {
〰91:                      yield return memory.Slice(pointer);
〰92:                      yield break;
〰93:                  }
〰94:                  else
〰95:                  {
〰96:                      yield return memory.Slice(pointer, next);
〰97:                      pointer += next;
〰98:                  }
〰99:              }
〰100:         }
〰101: 
〰102:         private static IEnumerable<Memory<T>> SplitWithCarry<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
〰103:         {
〰104:             var pointer = 0;
〰105:             while (memory.Length > pointer)
〰106:             {
〰107:                 var bump = delimiter.Equals(memory.Span[pointer]);
〰108:                 var segmentPointer = bump ? pointer + 1 : pointer;
〰109:                 var segment = memory.Span.Slice(segmentPointer);
〰110:                 var next = segment.IndexOf(delimiter) + (bump ? 1 : 0);
〰111: 
〰112:                 if (next <= 0)
〰113:                 {
〰114:                     yield return memory.Slice(pointer);
〰115:                     yield break;
〰116:                 }
〰117:                 else
〰118:                 {
〰119:                     yield return memory.Slice(pointer, next);
〰120:                     pointer += next;
〰121:                 }
〰122:             }
〰123:         }
〰124: #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
〰125:     }
〰126: }

```
## Footer 
[Return to Summary](Summary.md)

