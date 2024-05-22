using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Archives.Tar;

[StructLayout(LayoutKind.Sequential)]
public struct SECURITY_ATTRIBUTES
{
    public int nLength;
    public IntPtr lpSecurityDescriptor;
    public int bInheritHandle;
}
