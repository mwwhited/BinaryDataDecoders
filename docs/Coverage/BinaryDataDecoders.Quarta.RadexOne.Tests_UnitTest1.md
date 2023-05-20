# BinaryDataDecoders.Quarta.RadexOne.Tests.UnitTest1

## Summary

| Key             | Value                                                |
| :-------------- | :--------------------------------------------------- |
| Class           | `BinaryDataDecoders.Quarta.RadexOne.Tests.UnitTest1` |
| Assembly        | `BinaryDataDecoders.Quarta.RadexOne.Tests`           |
| Coveredlines    | `0`                                                  |
| Uncoveredlines  | `115`                                                |
| Coverablelines  | `115`                                                |
| Totallines      | `167`                                                |
| Linecoverage    | `0`                                                  |
| Coveredbranches | `0`                                                  |
| Totalbranches   | `77`                                                 |
| Branchcoverage  | `0`                                                  |
| Coveredmethods  | `0`                                                  |
| Totalmethods    | `2`                                                  |
| Methodcoverage  | `0`                                                  |

## Metrics

| Complexity | Lines | Branches | Name              |
| :--------- | :---- | :------- | :---------------- |
| 14         | 0     | 0        | `DecoderSelector` |
| 4          | 0     | 0        | `DecoderSelector` |

## Files

## File - /home/runner/work/BinaryDataDecoders/BinaryDataDecoders/src/BinaryDataDecoders.Quarta.RadexOne.Tests/UnitTest1.cs

```CSharp
〰1:   using BinaryDataDecoders.IO.Messages;
〰2:   using BinaryDataDecoders.TestUtilities;
〰3:   using Microsoft.VisualStudio.TestTools.UnitTesting;
〰4:   using System;
〰5:   using System.Collections.Generic;
〰6:   using System.Linq;
〰7:   using System.Reflection;
〰8:   using System.Runtime.InteropServices;
〰9:   
〰10:  namespace BinaryDataDecoders.Quarta.RadexOne.Tests
〰11:  {
〰12:      [TestClass]
〰13:      public class UnitTest1
〰14:      {
〰15:          [TestMethod, TestCategory(TestCategories.DevLocal)]
〰16:          [Ignore]
〰17:          public void DecoderSelector()
〰18:          {
‼19:              var typeQuery = from type in typeof(IRadexObject).Assembly.GetTypes()
‼20:                              where type.IsValueType && !type.IsEnum
‼21:                              let length = Marshal.SizeOf(Activator.CreateInstance(type))
‼22:                              from patternAttribute in type.GetCustomAttributes<MessageMatchPatternAttribute>()
‼23:                              let pattern = buildPatternMatch(patternAttribute.Pattern, patternAttribute.Mask).ToArray()
‼24:                              let firstByte = pattern.First().match
‼25:                              group new
‼26:                              {
‼27:                                  firstByte,
‼28:                                  length,
‼29:                                  pattern,
‼30:                                  type,
‼31:                                  patternAttribute.Priority,
‼32:                              } by firstByte into grouped
‼33:                              orderby grouped.Min(i => i.Priority)
‼34:                              select new
‼35:                              {
‼36:                                  firstByte = grouped.Key,
‼37:                                  minLength = grouped.Min(i => i.length),
‼38:                                  maxLength = grouped.Max(i => i.length),
‼39:                                  patterns = (from i in grouped
‼40:                                              select new
‼41:                                              {
‼42:                                                  i.pattern,
‼43:                                                  i.length,
‼44:                                                  i.type,
‼45:                                              }).ToArray(),
‼46:                              };
〰47:  
‼48:              var checkTypes = typeQuery.ToArray();
〰49:  
〰50:  
‼51:              Span<byte> buffer = new byte[] {
‼52:  
‼53:                  0xde, 0xad, 0xbe, 0xef, //noise
‼54:  
‼55:                  //ReadSettingsResponse
‼56:                  //7AFF 2080 1000 FD05 ____ 577A 0108 ____ 0500 ____ 020A ____ ____ F7ED
‼57:                  0x7A, 0xFF, //prefix
‼58:                  0x20, 0x80, // request
‼59:                  0x10, 0x00, // extended length
‼60:                  0x4e, 0x01, 0x00, 0x00, //packet number
‼61:                  0x00, 0x00, //checksum 0
‼62:  
‼63:                  0x01, 0x08, // request type
‼64:                  0x00, 0x00, //
‼65:                  0x05, 0x00, // r
‼66:                  0x00, 0x00, //
‼67:                  0x02, 0x0A, 0x00, //
‼68:                  0x00, //
‼69:                  0xf7, 0xed, //
‼70:  
‼71:                  0xde, 0xad, 0xbe, 0xef, //noise
‼72:              };
〰73:  
‼74:              foreach (var checkType in checkTypes)
〰75:              {
‼76:                  if (buffer.Length < checkType.minLength) continue;
‼77:                  var indexOf = buffer.IndexOf(checkType.firstByte);
‼78:                  if (indexOf < 0) continue;
‼79:                  var firstPass = buffer.Slice(indexOf);
‼80:                  foreach (var pattern in checkType.patterns)
〰81:                  {
‼82:                      if (buffer.Length < pattern.length) continue;
〰83:  
‼84:                      var subBuffer = firstPass.Slice(0, pattern.length);
‼85:                      if (checkPattern(subBuffer, pattern.pattern))
〰86:                      {
‼87:                          var innerBuffer = subBuffer.ToArray();
‼88:                          var handle = GCHandle.Alloc(innerBuffer, GCHandleType.Pinned);
〰89:                          try
〰90:                          {
‼91:                              IntPtr rawDataPtr = handle.AddrOfPinnedObject();
‼92:                              var result = Marshal.PtrToStructure(rawDataPtr, pattern.type);
‼93:                          }
‼94:                          catch
〰95:                          {
‼96:                              handle.Free();
‼97:                          }
〰98:  
〰99:                      }
〰100:                 }
〰101:             }
〰102: 
〰103:             static bool checkPattern(Span<byte> input, IEnumerable<(byte match, byte mask)> pattern)
〰104:             {
‼105:                 var bufferEnumerator = input.GetEnumerator();
‼106:                 var patternEnumerator = pattern.GetEnumerator();
〰107: 
‼108:                 while (bufferEnumerator.MoveNext() && patternEnumerator.MoveNext())
‼109:                     if ((bufferEnumerator.Current & patternEnumerator.Current.mask) != patternEnumerator.Current.match) return false;
‼110:                 return true;
〰111:             }
〰112:             static IEnumerable<(byte match, byte mask)> buildPatternMatch(string match, string mask)
〰113:             {
‼114:                 Func<char, bool> predicate = c => (('0' <= c && c <= '9') || ('A' <= c && c <= 'F') || ('a' <= c && c <= 'f'));
‼115:                 Func<char, bool> predicateExtended = c => predicate(c) || c == '?' || c == '*';
‼116:                 var matchChain = getBytes((!string.IsNullOrWhiteSpace(mask) ? match.Where(predicate) : match.Where(predicateExtended).Select(c => c == '?' || c == '*' ? '0' : c))).ToArray();
‼117:                 var maskChain = getBytes((!string.IsNullOrWhiteSpace(mask) ? mask.Where(predicate) : match.Where(predicateExtended).Select(c => c == '?' || c == '*' ? '0' : 'f'))).ToArray();
〰118:                 static IEnumerable<byte> getBytes(IEnumerable<char> chars)
〰119:                 {
‼120:                     var e = chars.GetEnumerator();
〰121:                     byte temp;
‼122:                     while (e.MoveNext())
〰123:                     {
‼124:                         temp = (byte)(toByte(e.Current) << 4);
〰125: 
‼126:                         if (e.MoveNext())
〰127:                         {
‼128:                             temp |= toByte(e.Current);
〰129:                         }
‼130:                         yield return temp;
〰131:                     }
〰132: 
‼133:                     static byte toByte(char c) => c switch
‼134:                     {
‼135:                         '0' => 0,
‼136:                         '1' => 1,
‼137:                         '2' => 2,
‼138:                         '3' => 3,
‼139:                         '4' => 4,
‼140:                         '5' => 5,
‼141:                         '6' => 6,
‼142:                         '7' => 7,
‼143:                         '8' => 8,
‼144:                         '9' => 9,
‼145: 
‼146:                         'a' => 0xa,
‼147:                         'b' => 0xb,
‼148:                         'c' => 0xc,
‼149:                         'd' => 0xd,
‼150:                         'e' => 0xe,
‼151:                         'f' => 0xf,
‼152: 
‼153:                         'A' => 0xa,
‼154:                         'B' => 0xb,
‼155:                         'C' => 0xc,
‼156:                         'D' => 0xd,
‼157:                         'E' => 0xe,
‼158:                         'F' => 0xf,
‼159: 
‼160:                         _ => 0,
‼161:                     };
‼162:                 }
‼163:                 return matchChain.Zip(maskChain);
〰164:             }
‼165:         }
〰166:     }
〰167: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

