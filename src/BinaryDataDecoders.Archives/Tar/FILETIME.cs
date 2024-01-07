using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Archives.Tar;

[StructLayout(LayoutKind.Sequential)]
internal struct FILETIME
{
    internal uint dwLowDateTime;
    internal uint dwHighDateTime;
};
