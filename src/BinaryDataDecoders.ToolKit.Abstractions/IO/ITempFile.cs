using System;

namespace BinaryDataDecoders.ToolKit.IO
{
    public interface ITempFile : IDisposable
    {
        string FilePath { get; }
    }
}
