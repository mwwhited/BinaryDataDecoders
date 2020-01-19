using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit
{
    public static class MemoryEx
    {
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
