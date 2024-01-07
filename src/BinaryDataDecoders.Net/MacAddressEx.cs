using System.Text.RegularExpressions;

namespace BinaryDataDecoders.Net;

public static class MacAddressEx
{
    public static bool IsValid(string macAddress)
    {
        var macPattern = new Regex("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$", RegexOptions.Compiled);
        return macPattern.IsMatch(macAddress);
    }

    public static byte[] Parse(string macAddress)
    {
        InvalidMacAddressException.Check(macAddress);
        var macBuffer = ConvertEx.FromHexString(macAddress.Replace("-", "").Replace(":", ""));
        return macBuffer;
    }

    public static bool TryParse(string macAddress, out byte[] macBuffer)
    {
        if (MacAddressEx.IsValid(macAddress))
        {
            macBuffer = new byte[0];
            return false;
        }
        else
        {
            macBuffer = ConvertEx.FromHexString(macAddress.Replace("-", "").Replace(":", ""));
            return true;
        }
    }
}
