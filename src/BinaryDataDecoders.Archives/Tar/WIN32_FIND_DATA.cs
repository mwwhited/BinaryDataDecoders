using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Archives.Tar;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct WIN32_FIND_DATA
{
    internal EFileAttributes dwFileAttributes;
    internal FILETIME ftCreationTime;
    internal FILETIME ftLastAccessTime;
    internal FILETIME ftLastWriteTime;
    internal int nFileSizeHigh;
    internal int nFileSizeLow;
    internal int dwReserved0;
    internal int dwReserved1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = IOUtilities.MAX_PATH)]
    internal string cFileName;
    // not using this
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
    internal string cAlternate;
}
