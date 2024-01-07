using System.Text.RegularExpressions;

namespace BinaryDataDecoders.Net;

public static partial class MacAddressEx
{
    public static bool IsValid(string macAddress) =>MacAddressRegex().IsMatch(macAddress);

    public static byte[] Parse(string macAddress)
    {
        InvalidMacAddressException.Check(macAddress);
        var macBuffer = ConvertEx.FromHexString(macAddress.Replace("-", "").Replace(":", ""));
        return macBuffer;
    }

    public static bool TryParse(string macAddress, out byte[] macBuffer)
    {
        if (IsValid(macAddress))
        {
            macBuffer = [];
            return false;
        }
        else
        {
            macBuffer = ConvertEx.FromHexString(macAddress.Replace("-", "").Replace(":", ""));
            return true;
        }
    }

    [GeneratedRegex("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$", RegexOptions.Compiled)]
    private static partial Regex MacAddressRegex();
}
