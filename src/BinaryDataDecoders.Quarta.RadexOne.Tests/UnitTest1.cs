using BinaryDataDecoders.IO.Abstractions.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
                        //
                        //var methods = from m in typeof(MemoryMarshal).GetMethods(BindingFlags.Static | BindingFlags.Public)
                        //              where m.Name == nameof(MemoryMarshal.Cast)
                        //              select m.MakeGenericMethod(typeof(byte), pattern.type);
                        //var method = methods.First(m => m.GetParameters()[0].ParameterType == typeof(ReadOnlySpan<byte>));
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
                        //  Marshal.PtrToStructure<>

                        //var requestBuffer = new byte[Marshal.SizeOf(requestObject)];
                        //IntPtr ptr = Marshal.AllocHGlobal(requestBuffer.Length);
                        //Marshal.StructureToPtr(requestObject, ptr, true);
                        //Marshal.Copy(ptr, requestBuffer, 0, requestBuffer.Length);
                        //Marshal.FreeHGlobal(ptr);

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

        [TestMethod]
        public void ChecksumCalculator()
        {
            //// read data request
            //>: 7BFF 2000 0600 1800 ____ 4600 0008 0C00 F3F7
            //<: 7AFF 2080 1600 1800 ____ 3680 0008 ____ 0C00 ____ 1200 ____ 1200 ____ 1500 ____ BAF7

            ////read serial number request (SN: 180620-0840-008344 v1.8)
            //>: 7BFF 2000 0600 9B0D ____ C2F2 0100 0C00 F2FF
            //<: 7AFF 2080 1E00 9B0D ____ AB72 0100 ____ 1400 ____ 11A4 ____ 9820 ____ 1400 0612 0108 4803 0800 ____ D61D

            ////Write request... repeat three times
            //>: 7BFF 2000 1000 FA05 ____ 59FA 0208 0E00 0500 ____ 020A ____ ____ E8ED
            //<: 7AFF 2080 0600 FA05 ____ 647A 0208 ____ FDF7

            ////Read settings request
            //>: 7BFF 2000 0600 FD05 ____ 60FA 0108 _C00 F2F7
            //<: 7AFF 2080 1000 FD05 ____ 577A 0108 ____ 0500 ____ 020A ____ ____ F7ED

            ////reset accumulated	
            //>: 7bff 2000 0600 4e01 0000 0fff 0308 0100 fbf7
            //<: 7aff 2080 0600 4e01 0000 107f 0308 0000 fcf7

            Span<byte> bytes = new byte[] {
                0x7B, 0xFF, //prefix
                0x20, 0x00, // request
                0x06, 0x00, // extended length
                0x4e, 0x01, 0x00, 0x00, //packet number                
                0x00, 0x00, //checksum 0

                0x03, 0x08, // request type
                0x00, 0x00, // request type 2
                0x00, 0x00, // checksum1
            };

            var shorts = MemoryMarshal.Cast<byte, ushort>(bytes);

            applyChecksum(shorts.Slice(0, 6));
            applyChecksum(shorts.Slice(6, 3));

            void applyChecksum(Span<ushort> input)
            {
                input[input.Length - 1] = getCheckSum(input);
                ushort getCheckSum(ReadOnlySpan<ushort> buffer)
                {
                    int sum = 0;
                    foreach (var v in buffer)
                        sum += v;
                    return (ushort)(0xffff - (sum % 0xffff));
                }
            }
        }
    }
}
