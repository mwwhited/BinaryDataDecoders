using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDataDecoders.Archives.Zip
{
    public struct LocalFileHeader
    {
        /*
                local file header signature     4 bytes  (0x04034b50)
                version needed to extract       2 bytes
                general purpose bit flag        2 bytes
                compression method              2 bytes
                last mod file time              2 bytes
                last mod file date              2 bytes
                crc-32                          4 bytes
                compressed size                 4 bytes
                uncompressed size               4 bytes
                file name length                2 bytes
                extra field length              2 bytes

                file name (variable size)
                extra field (variable size)
        */
        public int Signature;
        public short Version;
        public short BitFlags;
        public CompressionMethodType CompressionMethod;
        public short LastModifyTime;
        public short LastModifyDate;
        public int CRC32;
        public int CompressedSize;
        public int UncompressedSize;
        public short FileNameLength;
        public short ExtraFieldLength;

        public string FileName;
        public string ExtraField;

        public int HeaderSize { get { return 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2 + 2 + FileNameLength + ExtraFieldLength; } }

        public static implicit operator byte[](LocalFileHeader localFileHeader)
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(localFileHeader.Signature));
            data.AddRange(BitConverter.GetBytes(localFileHeader.Version));
            data.AddRange(BitConverter.GetBytes(localFileHeader.BitFlags));
            data.AddRange(BitConverter.GetBytes((short)localFileHeader.CompressionMethod));
            data.AddRange(BitConverter.GetBytes(localFileHeader.LastModifyTime));
            data.AddRange(BitConverter.GetBytes(localFileHeader.LastModifyDate));
            data.AddRange(BitConverter.GetBytes(localFileHeader.CRC32));
            data.AddRange(BitConverter.GetBytes(localFileHeader.CompressedSize));
            data.AddRange(BitConverter.GetBytes(localFileHeader.UncompressedSize));

            byte[] fileName = Encoding.ASCII.GetBytes(localFileHeader.FileName);
            byte[] extraField = Encoding.ASCII.GetBytes(localFileHeader.ExtraField);

            data.AddRange(BitConverter.GetBytes(fileName.Length));
            data.AddRange(BitConverter.GetBytes(extraField.Length));

            data.AddRange(fileName);
            data.AddRange(extraField);

            return data.ToArray();
        }

        public static implicit operator LocalFileHeader(byte[] rawFileheader)
        {
            LocalFileHeader localFileHeader = new LocalFileHeader()
            {
                Signature = BitConverter.ToInt32(rawFileheader, 0),
                Version = BitConverter.ToInt16(rawFileheader, 4),
                BitFlags = BitConverter.ToInt16(rawFileheader, 4 + 2),
                CompressionMethod = (CompressionMethodType)BitConverter.ToInt16(rawFileheader, 4 + 2 + 2),
                LastModifyTime = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2),
                LastModifyDate = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2),
                CRC32 = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2),
                CompressedSize = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4),
                UncompressedSize = BitConverter.ToInt32(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4),
                FileNameLength = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4),
                ExtraFieldLength = BitConverter.ToInt16(rawFileheader, 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2),
            };
            int lastPosition = 4 + 2 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 2 + 2;
            localFileHeader.FileName = Encoding.ASCII.GetString(rawFileheader, lastPosition, localFileHeader.FileNameLength);
            lastPosition += localFileHeader.FileNameLength;
            localFileHeader.ExtraField = Encoding.ASCII.GetString(rawFileheader, lastPosition, localFileHeader.ExtraFieldLength);
            lastPosition += localFileHeader.ExtraFieldLength;
            return localFileHeader;
        }
    }
}
