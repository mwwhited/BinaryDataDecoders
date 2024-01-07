using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace BinaryDataDecoders.FileSystems.Iso9660;

public static class Tools
{
    public static string ToHexString(this byte[] buffer)
    {
        var sb = new StringBuilder(buffer.Length * 3);
        foreach (var item in buffer)
            sb.AppendFormat("{0:X2} ", item);
        return sb.ToString();
    }

    public static string GetString(this byte[] buffer, 
                                    ref int offset, 
                                        int length,
                                        Encoding encoding)
    {
        var ret = encoding.GetString(buffer, offset, length)
                          .Trim(' ', '\0', '\t'); //, '\x01'
        offset += length;
        return ret;
    }

    public static uint GetUInt32(this byte[] buffer, 
                                  ref int offset, 
                                      int length)
    {
        var ret = BitConverter.ToUInt32(buffer, offset);
        offset += length;
        return ret;
    }

    public static ushort GetUInt16(this byte[] buffer, 
                                    ref int offset, 
                                        int length)
    {
        var ret = BitConverter.ToUInt16(buffer, offset);
        offset += length;
        return ret;
    }

    public static DateTime GetDateTime(this byte[] buffer, 
                                        ref int offset, 
                                            int length)
    {
        var temp = Encoding.ASCII.GetString(buffer, offset, 16).Trim();
        var timeOffset = (sbyte)buffer[offset + 16] * 15;
        DateTime ret;
        if (DateTime.TryParseExact(temp,
                                   "yyyyMMddHHmmssff",
                                   Thread.CurrentThread.CurrentCulture,
                                   DateTimeStyles.AdjustToUniversal,
                                   out ret))
            ret = ret.AddMinutes(timeOffset);
        offset += length;
        return ret;
    }
}
