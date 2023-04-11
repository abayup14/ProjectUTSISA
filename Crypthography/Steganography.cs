using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Crypthography
{
    public class Steganography
    {
        public static Bitmap HideStringsInImage(string imagePath, List<string> hiddenStrings)
        {
            Bitmap originalImage = new Bitmap(imagePath);
            Bitmap modifiedImage = new Bitmap(originalImage.Width, originalImage.Height);

            int stringIndex = 0;
            int charIndex = 0;

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int alpha = pixelColor.A;
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;

                    if (stringIndex < hiddenStrings.Count)
                    {
                        char hiddenChar = hiddenStrings[stringIndex][charIndex];

                        alpha = (alpha & 254) | ((hiddenChar >> 7) & 1);
                        red = (red & 254) | ((hiddenChar >> 6) & 1);
                        green = (green & 254) | ((hiddenChar >> 5) & 1);
                        blue = (blue & 254) | ((hiddenChar >> 4) & 1);

                        charIndex++;

                        if (charIndex >= hiddenStrings[stringIndex].Length)
                        {
                            stringIndex++;
                            charIndex = 0;
                        }
                    }

                    Color modifiedColor = Color.FromArgb(alpha, red, green, blue);
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }

        public static List<string> RevealStringsFromImage(string imagePath)
        {
            List<string> hiddenStrings = new List<string>();
            string currentString = "";

            Bitmap originalImage = new Bitmap(imagePath);

            int stringIndex = 0;
            int charIndex = 0;

            while (true)
            {
                Color pixelColor = originalImage.GetPixel(charIndex, stringIndex);

                int alpha = pixelColor.A;
                int red = pixelColor.R;
                int green = pixelColor.G;
                int blue = pixelColor.B;

                byte hiddenChar = 0;

                hiddenChar |= (byte)((alpha & 1) << 7);
                hiddenChar |= (byte)((red & 1) << 6);
                hiddenChar |= (byte)((green & 1) << 5);
                hiddenChar |= (byte)((blue & 1) << 4);

                currentString += (char)hiddenChar;

                charIndex++;

                if (charIndex >= originalImage.Width)
                {
                    hiddenStrings.Add(currentString);
                    currentString = "";
                    stringIndex++;
                    charIndex = 0;
                }

                if (stringIndex >= originalImage.Height)
                {
                    break;
                }
            }

            return hiddenStrings;
        }
    }
}
