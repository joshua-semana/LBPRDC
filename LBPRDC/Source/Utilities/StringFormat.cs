using System.Globalization;

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

    }
}
