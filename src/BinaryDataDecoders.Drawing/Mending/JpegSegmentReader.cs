using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryDataDecoders.Drawing.Mending;

public class JpegSegmentReader
{
    public static void Entry(string filepath, string outFileFormatter)
    {
        //var filepath = @"C:\Users\mwhited\Desktop\photos\DSC_6213.JPG";
        //var outFile = "Part_{0}_{1}.dat";

        var reader = new JpegSegmentReader();
        var segments = reader.GetSegments(filepath);
        foreach (var segment in segments)
        {
            Console.WriteLine("{0:x2} - {1}", segment.Type, segment.Length);
            File.WriteAllBytes(string.Format(outFileFormatter, segment.Index.ToString("00000"), segment.Type), segment.Data ?? new byte[0]);
        }
    }

    public IEnumerable<JpegSegment> GetSegments(string filename)
    {
        using var reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
        var x = 0;
        while (reader.CanRead)
        {
            var prefix = reader.ReadByte();
            if (prefix != 0xff)
                throw new InvalidOperationException("Invalid Prefix");


            var segmentType = reader.ReadByte();

            var lengthBuffer = new byte[2];
            ushort segmentLength;
            byte[]? segmentBuffer;

            if (2 == reader.Read(lengthBuffer, 0, 2))
            {
                segmentLength = BitConverter.ToUInt16(lengthBuffer, 0);
                segmentBuffer = new byte[segmentLength];
                var result = reader.Read(segmentBuffer, 0, segmentLength);
                if (result != segmentLength)
                    throw new InvalidOperationException("Invalid Length");
            }
            else
            {
                segmentLength = 0;
                segmentBuffer = null;
                //NOTE: No Data Captured
            }

            if (segmentBuffer != null)
                yield return new JpegSegment
                {
                    Index = x,
                    Prefix = (byte)prefix,
                    Type = (byte)segmentType,
                    Length = segmentLength,
                    Data = segmentBuffer,
                };

            x++;
        }
    }
}
