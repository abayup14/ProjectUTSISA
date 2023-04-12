using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Crypthography
{
    public class Steganography
    {
        enum Kondisi
        {
            Sembunyikan,
            Isi_Dengan_Nol
        }

        private static Bitmap BuatGambarDulu(Image image)
        {
            Bitmap gambarBaru = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(gambarBaru))
            {
                gfx.DrawImage(image, 0, 0);
            }

            return gambarBaru;
        }

        public static Bitmap Sembunyikan(string pesan, string pathGambar)
        {
            Bitmap gambarModif = BuatGambarDulu(Image.FromFile(pathGambar));

            Kondisi k = Kondisi.Sembunyikan;

            int charIndex = 0;
            int charValue = 0;
            long colorUnitIndex = 0;

            int zeros = 0;

            int R, G, B;

            for (int i = 0; i < gambarModif.Height; i++)
            {
                for (int j = 0; j < gambarModif.Width; j++)
                {
                    Color pixel = gambarModif.GetPixel(j, i);

                    pixel = Color.FromArgb(pixel.R - pixel.R % 2, pixel.G - pixel.G % 2, pixel.B - pixel.B % 2);

                    R = pixel.R; G = pixel.G; B = pixel.B;

                    for (int n = 0; n < 3; n++)
                    {
                        if (colorUnitIndex % 8 == 0)
                        {
                            if (zeros == 8)
                            {
                                if ((colorUnitIndex - 1) % 3 < 2)
                                {
                                    gambarModif.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }

                                return gambarModif;
                            }

                            if (charIndex >= pesan.Length)
                            {
                                k = Kondisi.Isi_Dengan_Nol;
                            }
                            else
                            {
                                charValue = pesan[charIndex++];
                            }
                        }

                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    if (k == Kondisi.Sembunyikan)
                                    {
                                        R += charValue % 2;

                                        charValue /= 2;
                                    }
                                }
                                break;
                            case 1:
                                {
                                    if (k == Kondisi.Sembunyikan)
                                    {
                                        G += charValue % 2;

                                        charValue /= 2;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    if (k == Kondisi.Sembunyikan)
                                    {
                                        B += charValue % 2;

                                        charValue /= 2;
                                    }

                                    gambarModif.SetPixel(j, i, Color.FromArgb(R, G, B));
                                }
                                break;
                        }

                        colorUnitIndex++;

                        if (k == Kondisi.Isi_Dengan_Nol)
                        {
                            zeros++;
                        }
                    }
                }
            }

            return gambarModif;
        }

        public static string Munculkan(Bitmap gambarModif)
        {
            int colorUnitIndex = 0;
            int charValue = 0;

            string hasilAkhir = string.Empty;

            for (int i = 0; i < gambarModif.Height; i++)
            {
                for (int j = 0; j < gambarModif.Width; j++)
                {
                    Color pixel = gambarModif.GetPixel(j, i);

                    for (int n = 0; n < 3; n++)
                    {
                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    charValue = charValue * 2 + pixel.R % 2;
                                }
                                break;
                            case 1:
                                {
                                    charValue = charValue * 2 + pixel.G % 2;
                                }
                                break;
                            case 2:
                                {
                                    charValue = charValue * 2 + pixel.B % 2;
                                }
                                break;
                        }

                        colorUnitIndex++;

                        if (colorUnitIndex % 8 == 0)
                        {
                            charValue = BalikkanBit(charValue);

                            if (charValue == 0)
                            {
                                return hasilAkhir;
                            }

                            char c = (char)charValue;

                            hasilAkhir += c.ToString();
                        }
                    }
                }
            }

            return hasilAkhir;
        }

        private static int BalikkanBit(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }
    }
}
