using System.Globalization;
using System.Text.RegularExpressions;

namespace LBPRDC.Source.Utilities
{
    internal class StringFormat
    {
        public static string ToSentenceCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static string CamelCaseToSpaced(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, "([a-z])([A-Z])", "$1 $2");
        }

    }
}
