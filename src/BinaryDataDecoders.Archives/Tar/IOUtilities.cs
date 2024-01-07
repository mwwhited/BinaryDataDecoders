using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Archives.Tar;

public static class IOUtilities
{
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern SafeFileHandle CreateFile(
        string lpFileName,
        EFileAccess dwDesiredAccess,
        EFileShare dwShareMode,
        IntPtr lpSecurityAttributes,
        ECreationDisposition dwCreationDisposition,
        EFileAttributes dwFlagsAndAttributes,
        IntPtr hTemplateFile);

    internal static IntPtr INVALID_HANDLE_VALUE = new(-1);
    internal static int FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
    internal const int MAX_PATH = 260;

    public static FileStream OpenFileStream(string fileName, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
    {
        if (fileName.Length <= 260)
            return new FileStream(fileName, fileMode, fileAccess);

        var handle = CreateFile(
            @"\\?\" + fileName,
            fileAccess.Convert(),
            fileShare.Convert(),
            IntPtr.Zero,
            fileMode.Convert(),
            0, IntPtr.Zero);
        var stream = new FileStream(handle, fileAccess);
        if (fileMode == FileMode.Append)
            stream.Seek(0, SeekOrigin.End);

        return stream;
    }

    internal static EFileAccess Convert(this FileAccess fileAccess) => fileAccess switch
    {
        FileAccess.Read => EFileAccess.GenericRead,
        FileAccess.ReadWrite => EFileAccess.GenericRead | EFileAccess.GenericRead,
        FileAccess.Write => EFileAccess.GenericWrite,
        _ => throw new NotSupportedException(),
    };

    internal static EFileShare Convert(this FileShare fileShare) => fileShare switch
    {
        FileShare.Delete => EFileShare.Delete,
        FileShare.Read => EFileShare.Read,
        FileShare.ReadWrite => EFileShare.Write | EFileShare.Read,
        FileShare.Write => EFileShare.Write,
        FileShare.None => EFileShare.None,
        _ => throw new NotSupportedException(),
    };

    internal static ECreationDisposition Convert(this FileMode fileMode) => fileMode switch
    {
        FileMode.Append => ECreationDisposition.OpenAlways,
        FileMode.Create => ECreationDisposition.CreateAlways,
        FileMode.CreateNew => ECreationDisposition.New,
        FileMode.Open => ECreationDisposition.OpenExisting,
        FileMode.OpenOrCreate => ECreationDisposition.OpenAlways,
        FileMode.Truncate => ECreationDisposition.TruncateExisting,
        _ => throw new NotSupportedException(),
    };
}
