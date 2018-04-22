namespace Utilities
{
    using System;
    using System.Linq;

    public static class StringExtensions
    {
        public static byte[] ConvertHexStringToByteArray(string hex)
        {
            hex = hex.RemoveWhitespace();
            if (hex.Length % 2 != 0)
            {
                Console.WriteLine("Input string must be even number of characters.");
                return new byte[0];
            }

            byte[] bytes = new byte[hex.Length >> 1];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
        }
    }
}
