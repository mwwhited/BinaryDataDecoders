using System;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace BinaryDataDecoders.Archives.Tar;

class Entry
{
    static void Sample(string[] args)
    {
        var file = @"XXX.tar.gz";

        if (string.IsNullOrEmpty(file))
        {
            Console.WriteLine("provide files name to decompress");
            return;
        }
        if (!File.Exists(file))
        {
            Console.WriteLine("file \"{0}\" not found", file);
            return;
        }
        var basePath = Path.GetDirectoryName(file);

        //try
        {
            var volumePath = basePath;

            Stream infile = File.OpenRead(file);
            try
            {
                var ext = Path.GetExtension(file).ToUpper();
                if (ext == ".gz" || ext == ".tgz")
                    infile = infile.Decompress();

                byte[] buffer = new byte[512];
                TarHeader header = null;
                bool getHeader = true;
                Stream newFile = null;
                int lengthWrote = 0;
                string longName = null;
                bool writingFile = false;

                int getLength = 1;

                while (getLength > 0)
                {
                    getLength = infile.Read(buffer, 0, 512);

                    if (getHeader)
                    {
                        header = buffer.ToHeader();

                        if (!string.IsNullOrEmpty(header.FileName))
                        {
                            Console.WriteLine("{0} \"{1}\" ({2})",
                                              header.FileType,
                                              header.FileName,
                                              header.FileSize);
                            getHeader = false;
                        }
                        else
                            continue;
                    }

                    switch (header.FileType)
                    {
                        case TarFileType.File:
                        case TarFileType.FileOld:
                        case TarFileType.ContiguousFile:
                        case TarFileType.SparseFile:
                        case TarFileType.LongName:
                            {
                                if (header.FileSize == 0)
                                    getHeader = true;
                                else
                                {
                                    if (!writingFile)
                                    {
                                        lengthWrote = 0;
                                        writingFile = true;

                                        var innerFile = Path.Combine(volumePath, longName ?? header.FileName);
                                        if (!File.Exists(innerFile) || new FileInfo(innerFile).Length != header.FileSize)
                                        {
                                            if (header.FileType == TarFileType.LongName)
                                                newFile = new MemoryStream();
                                            else
                                                newFile = IOUtilities.OpenFileStream(innerFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                                        }
                                    }
                                    else
                                    {
                                        if (header.FileType != TarFileType.LongName)
                                            longName = null;
                                        if (newFile != null)
                                            newFile.Write(buffer,
                                                          0,
                                                          Math.Min(buffer.Length,
                                                                   header.FileSize - lengthWrote));
                                        lengthWrote += 512;

                                        if (lengthWrote >= header.FileSize && writingFile)
                                        {
                                            if (newFile != null)
                                            {
                                                var ms = newFile as MemoryStream;
                                                if (ms != null)
                                                    longName = string.Format("{0}{1}", longName, Encoding.ASCII.GetString(ms.ToArray()).TrimEnd('\0'));
                                                newFile.Flush();
                                                newFile.Close();
                                            }
                                            writingFile = false;
                                            newFile = null;
                                            getHeader = true;
                                            lengthWrote = 0;
                                        }
                                    }
                                }

                                break;
                            }

                        default:
                        case TarFileType.HardLink:
                        case TarFileType.SymbolicLink:
                        case TarFileType.LongSymbolicLink:
                        case TarFileType.CharacterDevice:
                        case TarFileType.BlockDevice:
                        case TarFileType.NamedPipe:
                            Console.WriteLine("Windows doesn't really care about these: {0}", header.FileType);
                            break;

                        case TarFileType.Volume:
                            var cleanName = header.FileName.Replace(':', '\\');
                            volumePath = Path.Combine(basePath, cleanName);
                            break;

                        case TarFileType.Directory:
                            {
                                var tarPath = Path.Combine(volumePath, longName ?? header.FileName);
                                longName = null;
                                if (!Directory.Exists(tarPath))
                                    Directory.CreateDirectory(tarPath);
                                getHeader = true;
                                break;
                            }
                    }
                }
                Console.WriteLine("Decompress Complete");
            }
            finally
            {
                if (infile != null)
                    infile.Dispose();
            }
        }
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
        //}
    }
}
