using System.IO;

namespace BinaryDataDecoders.IO;

public interface IDeviceAdapter
{
    string Type { get; }
    string Path { get; }

    bool TryOpen(out Stream? stream);
    Stream Stream { get; }
    //void Open();
}
