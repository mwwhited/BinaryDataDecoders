using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;

namespace BinaryDataDecoders.Archives.Tar
{
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

        internal static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
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
            var stream= new FileStream(handle, fileAccess);
            if (fileMode == FileMode.Append)
                stream.Seek(0, SeekOrigin.End);

            return stream;
        }

        internal static EFileAccess Convert(this FileAccess fileAccess)
        {
            switch (fileAccess)
            {
                case FileAccess.Read:
                    return EFileAccess.GenericRead;
                case FileAccess.ReadWrite:
                    return EFileAccess.GenericRead | EFileAccess.GenericRead;
                case FileAccess.Write:
                    return EFileAccess.GenericWrite;
                default:
                    throw new NotSupportedException();
            }
        }
        internal static EFileShare Convert(this FileShare fileShare)
        {
            switch (fileShare)
            {
                case FileShare.Delete:
                    return EFileShare.Delete;

                case FileShare.Read:
                    return EFileShare.Read;
                case FileShare.ReadWrite:
                    return EFileShare.Write | EFileShare.Read;
                case FileShare.Write:
                    return EFileShare.Write;

                case FileShare.None:
                    return EFileShare.None;
                    break;

                default:
                case FileShare.Inheritable:
                    throw new NotSupportedException();
            }
        }
        internal static ECreationDisposition Convert(this FileMode fileMode)
        {
            switch (fileMode)
            {
                case FileMode.Append:
                    return ECreationDisposition.OpenAlways;

                case FileMode.Create:
                    return ECreationDisposition.CreateAlways;

                case FileMode.CreateNew:
                    return ECreationDisposition.New;

                case FileMode.Open:
                    return ECreationDisposition.OpenExisting;

                case FileMode.OpenOrCreate:
                    return ECreationDisposition.OpenAlways;

                case FileMode.Truncate:
                    return ECreationDisposition.TruncateExisting;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
