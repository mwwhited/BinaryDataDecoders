# BinaryDataDecoders.Quarta.RadexOne.Tests.UnitTest1

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.Tests.UnitTest1` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne.Tests`           |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `115`                                                |
| Coverablelines  | `115`                                                |
| Totallines      | `165`                                                |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `77`                                                 |
| Branchcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 14         | 0     | 0        | `DecoderSelector` |
| 4          | 0     | 0        | `DecoderSelector` |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.Quarta.RadexOne.Tests\UnitTest1.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰3:   using System;
〰4:   using System.Collections.Generic;
〰5:   using System.Linq;
〰6:   using System.Reflection;
〰7:   using System.Runtime.InteropServices;
〰8:   
〰9:   namespace BinaryDataDecoders.Quarta.RadexOne.Tests
〰10:  {
〰11:      [TestClass]
〰12:      public class UnitTest1
〰13:      {
〰14:          [TestMethod, Ignore]
〰15:          public void DecoderSelector()
〰16:          {
‼17:              var typeQuery = from type in typeof(IRadexObject).Assembly.GetTypes()
‼18:                              where type.IsValueType && !type.IsEnum
‼19:                              let length = Marshal.SizeOf(Activator.CreateInstance(type))
‼20:                              from patternAttribute in type.GetCustomAttributes<MessageMatchPatternAttribute>()
‼21:                              let pattern = buildPatternMatch(patternAttribute.Pattern, patternAttribute.Mask).ToArray()
‼22:                              let firstByte = pattern.First().match
‼23:                              group new
‼24:                              {
‼25:                                  firstByte,
‼26:                                  length,
‼27:                                  pattern,
‼28:                                  type,
‼29:                                  patternAttribute.Priority,
‼30:                              } by firstByte into grouped
‼31:                              orderby grouped.Min(i => i.Priority)
‼32:                              select new
‼33:                              {
‼34:                                  firstByte = grouped.Key,
‼35:                                  minLength = grouped.Min(i => i.length),
‼36:                                  maxLength = grouped.Max(i => i.length),
‼37:                                  patterns = (from i in grouped
‼38:                                              select new
‼39:                                              {
‼40:                                                  i.pattern,
‼41:                                                  i.length,
‼42:                                                  i.type,
‼43:                                              }).ToArray(),
‼44:                              };
〰45:  
‼46:              var checkTypes = typeQuery.ToArray();
〰47:  
〰48:  
‼49:              Span<byte> buffer = new byte[] {
‼50:  
‼51:                  0xde, 0xad, 0xbe, 0xef, //noise
‼52:  
‼53:                  //ReadSettingsResponse
‼54:                  //7AFF 2080 1000 FD05 ____ 577A 0108 ____ 0500 ____ 020A ____ ____ F7ED
‼55:                  0x7A, 0xFF, //prefix
‼56:                  0x20, 0x80, // request
‼57:                  0x10, 0x00, // extended length
‼58:                  0x4e, 0x01, 0x00, 0x00, //packet number
‼59:                  0x00, 0x00, //checksum 0
‼60:  
‼61:                  0x01, 0x08, // request type
‼62:                  0x00, 0x00, //
‼63:                  0x05, 0x00, // r
‼64:                  0x00, 0x00, //
‼65:                  0x02, 0x0A, 0x00, //
‼66:                  0x00, //
‼67:                  0xf7, 0xed, //
‼68:  
‼69:                  0xde, 0xad, 0xbe, 0xef, //noise
‼70:              };
〰71:  
‼72:              foreach (var checkType in checkTypes)
〰73:              {
‼74:                  if (buffer.Length < checkType.minLength) continue;
‼75:                  var indexOf = buffer.IndexOf(checkType.firstByte);
‼76:                  if (indexOf < 0) continue;
‼77:                  var firstPass = buffer.Slice(indexOf);
‼78:                  foreach (var pattern in checkType.patterns)
〰79:                  {
‼80:                      if (buffer.Length < pattern.length) continue;
〰81:  
‼82:                      var subBuffer = firstPass.Slice(0, pattern.length);
‼83:                      if (checkPattern(subBuffer, pattern.pattern))
〰84:                      {
‼85:                          var innerBuffer = subBuffer.ToArray();
‼86:                          var handle = GCHandle.Alloc(innerBuffer, GCHandleType.Pinned);
〰87:                          try
〰88:                          {
‼89:                              IntPtr rawDataPtr = handle.AddrOfPinnedObject();
‼90:                              var result = Marshal.PtrToStructure(rawDataPtr, pattern.type);
‼91:                          }
‼92:                          catch
〰93:                          {
‼94:                              handle.Free();
‼95:                          }
〰96:  
〰97:                      }
〰98:                  }
〰99:              }
〰100: 
〰101:             static bool checkPattern(Span<byte> input, IEnumerable<(byte match, byte mask)> pattern)
〰102:             {
‼103:                 var bufferEnumerator = input.GetEnumerator();
‼104:                 var patternEnumerator = pattern.GetEnumerator();
〰105: 
‼106:                 while (bufferEnumerator.MoveNext() && patternEnumerator.MoveNext())
‼107:                     if ((bufferEnumerator.Current & patternEnumerator.Current.mask) != patternEnumerator.Current.match) return false;
‼108:                 return true;
〰109:             }
〰110:             static IEnumerable<(byte match, byte mask)> buildPatternMatch(string match, string mask)
〰111:             {
‼112:                 Func<char, bool> predicate = c => (('0' <= c && c <= '9') || ('A' <= c && c <= 'F') || ('a' <= c && c <= 'f'));
‼113:                 Func<char, bool> predicateExtended = c => predicate(c) || c == '?' || c == '*';
‼114:                 var matchChain = getBytes((!string.IsNullOrWhiteSpace(mask) ? match.Where(predicate) : match.Where(predicateExtended).Select(c => c == '?' || c == '*' ? '0' : c))).ToArray();
‼115:                 var maskChain = getBytes((!string.IsNullOrWhiteSpace(mask) ? mask.Where(predicate) : match.Where(predicateExtended).Select(c => c == '?' || c == '*' ? '0' : 'f'))).ToArray();
〰116:                 static IEnumerable<byte> getBytes(IEnumerable<char> chars)
〰117:                 {
‼118:                     var e = chars.GetEnumerator();
〰119:                     byte temp;
‼120:                     while (e.MoveNext())
〰121:                     {
‼122:                         temp = (byte)(toByte(e.Current) << 4);
〰123: 
‼124:                         if (e.MoveNext())
〰125:                         {
‼126:                             temp |= toByte(e.Current);
〰127:                         }
‼128:                         yield return temp;
〰129:                     }
〰130: 
‼131:                     static byte toByte(char c) => c switch
‼132:                     {
‼133:                         '0' => 0,
‼134:                         '1' => 1,
‼135:                         '2' => 2,
‼136:                         '3' => 3,
‼137:                         '4' => 4,
‼138:                         '5' => 5,
‼139:                         '6' => 6,
‼140:                         '7' => 7,
‼141:                         '8' => 8,
‼142:                         '9' => 9,
‼143: 
‼144:                         'a' => 0xa,
‼145:                         'b' => 0xb,
‼146:                         'c' => 0xc,
‼147:                         'd' => 0xd,
‼148:                         'e' => 0xe,
‼149:                         'f' => 0xf,
‼150: 
‼151:                         'A' => 0xa,
‼152:                         'B' => 0xb,
‼153:                         'C' => 0xc,
‼154:                         'D' => 0xd,
‼155:                         'E' => 0xe,
‼156:                         'F' => 0xf,
‼157: 
‼158:                         _ => 0,
‼159:                     };
‼160:                 }
‼161:                 return matchChain.Zip(maskChain);
〰162:             }
‼163:         }
〰164:     }
〰165: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

