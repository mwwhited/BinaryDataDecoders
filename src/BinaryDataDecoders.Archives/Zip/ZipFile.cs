using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace BinaryDataDecoders.Archives.Zip;

class ZipFile
{
    static void Entry(string[] args)
    {
        string fileName = new DirectoryInfo(".\\").GetFiles("*.zip").Select(f => f.FullName).FirstOrDefault();
        if (string.IsNullOrEmpty(fileName))
            return;

        byte[] zipFileContents = File.ReadAllBytes(fileName);
        int offset = 0;
        while (true)
        {
            LocalFileHeader localFileHeader = zipFileContents;
            if (localFileHeader.Signature != 0x04034b50)
                break;

            offset += localFileHeader.HeaderSize;
            if (localFileHeader.CompressionMethod == CompressionMethodType.Deflate)
            {
                byte[] fileContent = new byte[localFileHeader.CompressedSize];
                Array.Copy(zipFileContents, offset, fileContent, 0, fileContent.Length);
                File.WriteAllBytes(localFileHeader.FileName, Decompress(fileContent));
                offset += fileContent.Length;
            }


            byte[] newBuffer = new byte[zipFileContents.Length - offset];
            Array.Copy(zipFileContents, offset, newBuffer, 0, newBuffer.Length);
            zipFileContents = newBuffer;
            offset = 0;
        }
    }

    public static byte[] Decompress(byte[] input)
    {
        if (input == null || input.Length < 1)
            return null;

        using MemoryStream compressedData = new(input);
        using MemoryStream decompressedData = new();
        using DeflateStream deflateDecompress = new(compressedData, CompressionMode.Decompress, true);
        byte[] buffer = new byte[1024];
        int bufferLen;
        do
        {
            bufferLen = deflateDecompress.Read(buffer, 0, buffer.Length);
            if (bufferLen > 0)
                decompressedData.Write(buffer, 0, bufferLen);
        } while (bufferLen > 0);
        return decompressedData.ToArray();
    }

    public static byte[] Compress(byte[] input)
    {
        if (input == null || input.Length < 1)
            return null;

        using MemoryStream rawDataStreamIn = new(input);
        using MemoryStream compressedDataStreamOut = new();
        using DeflateStream deflateCompress = new(compressedDataStreamOut, CompressionMode.Compress, true);
        byte[] buffer = new byte[1024];
        int bufferLen;
        do
        {
            bufferLen = rawDataStreamIn.Read(buffer, 0, buffer.Length);
            if (bufferLen > 0)
                deflateCompress.Write(buffer, 0, bufferLen);
        } while (bufferLen > 0);
        return compressedDataStreamOut.ToArray();
    }
}
