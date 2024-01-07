namespace BinaryDataDecoders.ToolKit;

public static class NumberEx
{
    public static float? ToFloat(this string input) =>
        float.TryParse(input, out var ret) ? (float?)ret : null;

    public static int? ToInteger(this string input) =>
        int.TryParse(input, out var ret) ? (int?)ret : null;

    public static decimal? ToDecimal(this string input) =>
        decimal.TryParse(input, out var ret) ? (decimal?)ret : null;

    public static double? ToDouble(this string input)
    {
        if (double.TryParse(input, out var ret))
            return ret;
        else if (input?.Trim().StartsWith("1/") ?? false)
            if (double.TryParse(input.Trim().Substring(2), out ret))
                return 1d / ret;

        return null;
    }
}
