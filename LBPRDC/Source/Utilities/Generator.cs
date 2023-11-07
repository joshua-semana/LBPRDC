using System.Text;

namespace LBPRDC.Source.Utilities
{
    internal class Generator
    {
        private static readonly Random random = new();
        private const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GeneratePassword(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Password length must be greater than zero.");
            }

            StringBuilder password = new(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(allowedChars.Length);
                password.Append(allowedChars[index]);
            }

            return password.ToString();
        }
    }
}
