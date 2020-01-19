using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryDataDecoders.ToolKit
{
    public static class MemoryEx
    {
        public static IEnumerable<Memory<byte>> Distinct(this IEnumerable<Memory<byte>> segments)
        {
            return segments.Distinct(new MemoryCompare());
        }

        public static Memory<byte> MemoryFromHexString(this Memory<char> input)
        {
            byte charToNibble(char input)
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


        public static IEnumerable<Memory<byte>> Split(this Memory<byte> memory, byte delimiter, DelimiterOptions option = DelimiterOptions.Exclude)
        {
            switch (option)
            {
                default:
                case DelimiterOptions.Exclude:
                    return SplitWithExclude(memory, delimiter);
                case DelimiterOptions.Return:
                    return SplitWithReturn(memory, delimiter);
                case DelimiterOptions.Carry:
                    return SplitWithCarry(memory, delimiter);
            }

            throw new NotSupportedException();
        }
        private static IEnumerable<Memory<byte>> SplitWithExclude(this Memory<byte> memory, byte delimiter)
        {
            var pointer = 0;
            while (memory.Length > pointer)
            {
                var segment = memory.Span.Slice(pointer);
                var next = segment.IndexOf(delimiter) + 1;

                if (next <= 0)
                {
                    yield return memory.Slice(pointer);
                    yield break;
                }
                else
                {
                    yield return memory.Slice(pointer, next - 1);
                    pointer += next;
                }
            }
        }

        private static IEnumerable<Memory<byte>> SplitWithReturn(this Memory<byte> memory, byte delimiter)
        {
            var pointer = 0;
            while (memory.Length > pointer)
            {
                var segment = memory.Span.Slice(pointer);
                var next = segment.IndexOf(delimiter) + 1;

                if (next <= 0)
                {
                    yield return memory.Slice(pointer);
                    yield break;
                }
                else
                {
                    yield return memory.Slice(pointer, next);
                    pointer += next;
                }
            }
        }

        private static IEnumerable<Memory<byte>> SplitWithCarry(this Memory<byte> memory, byte delimiter)
        {
            var pointer = 0;
            while (memory.Length > pointer)
            {
                var bump = memory.Span[pointer] == delimiter;
                var segmentPointer = bump ? pointer + 1 : pointer;
                var segment = memory.Span.Slice(segmentPointer);
                var next = segment.IndexOf(delimiter) + (bump ? 1 : 0);

                if (next <= 0)
                {
                    yield return memory.Slice(pointer);
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
}
