using BinaryDataDecoders.IO.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, Ignore]
        public void DecoderSelector()
        {
            var typeQuery = from type in typeof(IRadexObject).Assembly.GetTypes()
                            where type.IsValueType && !type.IsEnum
                            let length = Marshal.SizeOf(Activator.CreateInstance(type))
                            from patternAttribute in type.GetCustomAttributes<MessageMatchPatternAttribute>()
                            let pattern = buildPatternMatch(patternAttribute.Pattern, patternAttribute.Mask).ToArray()
                            let firstByte = pattern.First().match
                            group new
                            {
                                firstByte,
                                length,
                                pattern,
                                type,
                                patternAttribute.Priority,
                            } by firstByte into grouped
                            orderby grouped.Min(i => i.Priority)
                            select new
                            {
                                firstByte = grouped.Key,
                                minLength = grouped.Min(i => i.length),
                                maxLength = grouped.Max(i => i.length),
                                patterns = (from i in grouped
                                            select new
                                            {
                                                i.pattern,
                                                i.length,
                                                i.type,
                                            }).ToArray(),
                            };

            var checkTypes = typeQuery.ToArray();


            Span<byte> buffer = new byte[] {

                0xde, 0xad, 0xbe, 0xef, //noise

                //ReadSettingsResponse
                //7AFF 2080 1000 FD05 ____ 577A 0108 ____ 0500 ____ 020A ____ ____ F7ED
                0x7A, 0xFF, //prefix
                0x20, 0x80, // request
                0x10, 0x00, // extended length
                0x4e, 0x01, 0x00, 0x00, //packet number                
                0x00, 0x00, //checksum 0

                0x01, 0x08, // request type
                0x00, 0x00, //
                0x05, 0x00, // r
                0x00, 0x00, //
                0x02, 0x0A, 0x00, //
                0x00, //
                0xf7, 0xed, //
                
                0xde, 0xad, 0xbe, 0xef, //noise
            };

            foreach (var checkType in checkTypes)
            {
                if (buffer.Length < checkType.minLength) continue;
                var indexOf = buffer.IndexOf(checkType.firstByte);
                if (indexOf < 0) continue;
                var firstPass = buffer.Slice(indexOf);
                foreach (var pattern in checkType.patterns)
                {
                    if (buffer.Length < pattern.length) continue;

                    var subBuffer = firstPass.Slice(0, pattern.length);
                    if (checkPattern(subBuffer, pattern.pattern))
                    {
                        var innerBuffer = subBuffer.ToArray();
                        var handle = GCHandle.Alloc(innerBuffer, GCHandleType.Pinned);
                        try
                        {
                            IntPtr rawDataPtr = handle.AddrOfPinnedObject();
                            var result = Marshal.PtrToStructure(rawDataPtr, pattern.type);
                        }
                        catch
                        {
                            handle.Free();
                        }

                    }
                }
            }

            static bool checkPattern(Span<byte> input, IEnumerable<(byte match, byte mask)> pattern)
            {
                var bufferEnumerator = input.GetEnumerator();
                var patternEnumerator = pattern.GetEnumerator();

                while (bufferEnumerator.MoveNext() && patternEnumerator.MoveNext())
                    if ((bufferEnumerator.Current & patternEnumerator.Current.mask) != patternEnumerator.Current.match) return false;
                return true;
            }
            static IEnumerable<(byte match, byte mask)> buildPatternMatch(string match, string mask)
            {
                Func<char, bool> predicate = c => (('0' <= c && c <= '9') || ('A' <= c && c <= 'F') || ('a' <= c && c <= 'f'));
                Func<char, bool> predicateExtended = c => predicate(c) || c == '?' || c == '*';
                var matchChain = getBytes((!string.IsNullOrWhiteSpace(mask) ? match.Where(predicate) : match.Where(predicateExtended).Select(c => c == '?' || c == '*' ? '0' : c))).ToArray();
                var maskChain = getBytes((!string.IsNullOrWhiteSpace(mask) ? mask.Where(predicate) : match.Where(predicateExtended).Select(c => c == '?' || c == '*' ? '0' : 'f'))).ToArray();
                static IEnumerable<byte> getBytes(IEnumerable<char> chars)
                {
                    var e = chars.GetEnumerator();
                    byte temp;
                    while (e.MoveNext())
                    {
                        temp = (byte)(toByte(e.Current) << 4);

                        if (e.MoveNext())
                        {
                            temp |= toByte(e.Current);
                        }
                        yield return temp;
                    }

                    static byte toByte(char c) => c switch
                    {
                        '0' => 0,
                        '1' => 1,
                        '2' => 2,
                        '3' => 3,
                        '4' => 4,
                        '5' => 5,
                        '6' => 6,
                        '7' => 7,
                        '8' => 8,
                        '9' => 9,

                        'a' => 0xa,
                        'b' => 0xb,
                        'c' => 0xc,
                        'd' => 0xd,
                        'e' => 0xe,
                        'f' => 0xf,

                        'A' => 0xa,
                        'B' => 0xb,
                        'C' => 0xc,
                        'D' => 0xd,
                        'E' => 0xe,
                        'F' => 0xf,

                        _ => 0,
                    };
                }
                return matchChain.Zip(maskChain);
            }
        }
    }
}
