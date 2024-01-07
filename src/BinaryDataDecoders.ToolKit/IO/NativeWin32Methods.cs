using System;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.ToolKit.IO;

internal partial class NativeWin32Methods
{
    // https://stackoverflow.com/questions/6077869/movefile-function-in-c-sharp-delete-file-after-reboot
    // https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-movefileexa?redirectedfrom=MSDN

    [LibraryImport("kernel32.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool MoveFileEx(
        string lpExistingFileName,
        string? lpNewFileName,
        MoveFileFlags dwFlags);

    [Flags]
    internal enum MoveFileFlags
    {
        None = 0,
        ReplaceExisting = 1,
        CopyAllowed = 2,
        DelayUntilReboot = 4,
        WriteThrough = 8,
        CreateHardlink = 16,
        FailIfNotTrackable = 32,
    }
}
