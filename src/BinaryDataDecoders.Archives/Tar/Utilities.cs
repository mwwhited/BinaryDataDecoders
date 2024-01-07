using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace BinaryDataDecoders.Archives.Tar;

public static class Utilities
{
    public static TarHeader ToHeader(this byte[] input)
    {
        var header = new TarHeader();
        header.FileName = input.ToString(0, 100);
        header.FileMode = input.ToString(100, 8);
        header.OwnerId = input.ToString(108, 8);
        header.GroupId = input.ToString(116, 8);
        var fileSize = input.ToString(124, 12);
        header.FileSize = Convert.ToInt32(fileSize ?? "0", 8);
        var lastModifiedTime = input.ToString(136, 12);
        header.LastModifiedTime = Convert.ToInt32(lastModifiedTime ?? "0", 8);
        header.CheckSum = input.ToString(148, 8);
        var fileType = input[156];
        header.FileType = (TarFileType)fileType;
        header.LinkedFile = input.ToString(157, 100);
        return header;
    }

    public static string ToString(this byte[] input, int index, int length)
    {
        if (input == null || input.Length == 0)
            return null;
        else
        {
            string result = Encoding.ASCII.GetString(input, index, length)
                                          .Trim('\0', ' ');
            if (result == string.Empty)
                return null;
            else
                return result;
        }
    }

    public static byte[] Decompress(this byte[] input)
    {
        if (input == null || input.Length < 1)
            return null;

        using var compressedData = new MemoryStream(input);
        using var decompressedData = new MemoryStream();
        using (var deflateDecompress = new GZipStream(compressedData,
                                                      CompressionMode.Decompress,
                                                      true))
        {
            byte[] buffer = new byte[1024];
            int bufferLen;
            do
            {
                bufferLen = deflateDecompress.Read(buffer,
                                                   0,
                                                   buffer.Length);
                if (bufferLen > 0)
                    decompressedData.Write(buffer, 0, bufferLen);
            } while (bufferLen > 0);
        }
        return decompressedData.ToArray();
    }

    public static Stream Decompress(this Stream input)
    {
        return new GZipStream(input, CompressionMode.Decompress, false);
    }
}
