using System;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography;

namespace USC.GISResearchLab.Common.Utils.Colors
{
    public class ColorUtils
    {
        static char[] hexDigits = {
         '0', '1', '2', '3', '4', '5', '6', '7',
         '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};


        public static string HexToRgbString(string hex)
        {

            int r, g, b;
            int num = (int)long.Parse(hex, NumberStyles.HexNumber);
            r = (num & 0xFF0000) >> 16;
            g = (num & 0xFF00) >> 8;
            b = num & 0xFF;
            return string.Format("{0}, {1}, {2}", r, g, b);
        }


        public static Color RandomColor()
        {
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

            byte[] randomNumber = new byte[1];

            rngCsp.GetBytes(randomNumber);
            int seed = (int)randomNumber[0];

            return RandomColor(seed);
        }

        public static Color RandomColor(int seed)
        {

            Random rand1 = new Random(seed);
            int r1 = rand1.Next(256);

            Random rand2 = new Random(r1);
            int r2 = rand2.Next(256);

            Random rand3 = new Random(r2);
            int r3 = rand3.Next(256);

            return Color.FromArgb(r1, r2, r3);
        }

        public static Color HexToColor(string hex)
        {
            int r, g, b;
            int num = (int)long.Parse(hex, NumberStyles.HexNumber);
            r = (num & 0xFF0000) >> 16;
            g = (num & 0xFF00) >> 8;
            b = num & 0xFF;
            return Color.FromArgb(r, g, b);
        }

        public static Color NameToColor(string name)
        {
            return Color.FromName(name);
        }

        public static string ColorToHexString(Color color)
        {
            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }



    }
}
