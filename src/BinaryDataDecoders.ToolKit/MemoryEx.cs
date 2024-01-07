﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ToolKit;

/// <summary>
/// Extension methods for System.Memory&lt;&gt;
/// </summary>
public static class MemoryEx
{
    public static Memory<char> AsMemory(this IEnumerable<char> input) =>
        new(input.ToArray());

    public static IEnumerable<Memory<T>> Distinct<T>(this IEnumerable<Memory<T>> segments) where T : IEquatable<T> =>
        segments.Distinct(new MemoryCompare<T>());

    public static Memory<byte> BytesFromHexString(this Memory<char> input)
    {
        static byte charToNibble(char input)
        {
            unchecked
            {
                if (input >= '0' && input <= '9') return (byte)(input - '0');
                else if (input >= 'A' && input <= 'F') return (byte)(input - 'A' + 10);
                else if (input >= 'a' && input <= 'f') return (byte)(input - 'a' + 10);
                else throw new InvalidOperationException();
            }
        }

        var memory = new Memory<byte>(new byte[input.Length / 2]);
        for (var i = 0; i < input.Length; i += 2)
        {
            var highNibble = charToNibble(input.Span[i]);
            var lowNibble = charToNibble(input.Span[i + 1]);

            var memoryIndex = i >> 1;
            var newValue = (byte)(highNibble << 4 | lowNibble);

            memory.Span[memoryIndex] = newValue;
        }
        return memory;
    }

    public static IEnumerable<Memory<byte>> Split(this Memory<byte> memory, byte delimiter, DelimiterOptions option = DelimiterOptions.Exclude) =>
        memory.Split<byte>(delimiter, option);

    public static IEnumerable<Memory<char>> Split(this Memory<char> memory, char delimiter, DelimiterOptions option = DelimiterOptions.Exclude) =>
        memory.Split<char>(delimiter, option);

    public static IEnumerable<Memory<T>> Split<T>(this Memory<T> memory, T delimiter, DelimiterOptions option = DelimiterOptions.Exclude) where T : IEquatable<T> =>
        option switch
        {
            DelimiterOptions.Return => SplitWithReturn(memory, delimiter),
            DelimiterOptions.Carry => SplitWithCarry(memory, delimiter),
            _ => SplitWithExclude(memory, delimiter),
        };

    private static IEnumerable<Memory<T>> SplitWithExclude<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
    {
        var pointer = 0;
        while (memory.Length > pointer)
        {
            var segment = memory.Span[pointer..];
            var next = segment.IndexOf(delimiter) + 1;

            if (next <= 0)
            {
                yield return memory[pointer..];
                yield break;
            }
            else
            {
                yield return memory.Slice(pointer, next - 1);
                pointer += next;
            }
        }
    }

    private static IEnumerable<Memory<T>> SplitWithReturn<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
    {
        var pointer = 0;
        while (memory.Length > pointer)
        {
            var segment = memory.Span[pointer..];
            var next = segment.IndexOf(delimiter) + 1;

            if (next <= 0)
            {
                yield return memory[pointer..];
                yield break;
            }
            else
            {
                yield return memory.Slice(pointer, next);
                pointer += next;
            }
        }
    }

    private static IEnumerable<Memory<T>> SplitWithCarry<T>(this Memory<T> memory, T delimiter) where T : IEquatable<T>
    {
        var pointer = 0;
        while (memory.Length > pointer)
        {
            var bump = delimiter.Equals(memory.Span[pointer]);
            var segmentPointer = bump ? pointer + 1 : pointer;
            var segment = memory.Span[segmentPointer..];
            var next = segment.IndexOf(delimiter) + (bump ? 1 : 0);

            if (next <= 0)
            {
                yield return memory[pointer..];
                yield break;
            }
            else
            {
                yield return memory.Slice(pointer, next);
                pointer += next;
            }
        }
    }
}
