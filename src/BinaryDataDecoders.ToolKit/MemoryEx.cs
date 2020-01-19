using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit
{
    public static class MemoryEx
    {
        public static IEnumerable<Memory<byte>> Split(this Memory<byte> memory, byte delimiter, DelimiterOptions option = DelimiterOptions.Exclude)
        {
            if (option != DelimiterOptions.Carry)
            {
                //Haven't finished support for the other operations yet.
                throw new NotSupportedException();
            }

            var chunks = new List<Memory<byte>>();
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
