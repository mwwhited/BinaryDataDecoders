namespace BinaryDataDecoders.ToolKit
{
    public static class NumberEx
    {
        public static float? ToFloat(this string input)
        {
            float ret;
            if (float.TryParse(input, out ret))
                return ret;
            return null;
        }
        public static int? ToInteger(this string input)
        {
            int ret;
            if (int.TryParse(input, out ret))
                return ret;
            return null;
        }
        public static decimal? ToDecimal(this string input)
        {
            decimal ret;
            if (decimal.TryParse(input, out ret))
                return ret;
            return null;
        }
        public static double? ToDouble(this string input)
        {
            double ret;
            if (double.TryParse(input, out ret))
                return ret;
            else if (input?.Trim().StartsWith("1/") ?? false)
                if (double.TryParse(input.Trim().Substring(2), out ret))
                    return 1d / ret;

            return null;
        }
    }
}
