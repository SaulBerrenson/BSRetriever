using System.Globalization;

namespace BSRetriever.Extantions
{
    internal static class StringExtantions
    {
        public static string DoubleWithDot(this double data)
        {
            return data.ToString(CultureInfo.InvariantCulture);
        }
    }
}