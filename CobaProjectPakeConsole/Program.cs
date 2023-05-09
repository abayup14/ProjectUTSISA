using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypthography;
using static System.Console;

namespace CobaProjectPakeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] key, iv;
            //key = TripleDES.GenerateRandomKey();
            //iv = TripleDES.GenerateRandomIV();

            key = AES.GenerateRandomKey();
            iv = AES.GenerateRandomIV();

            //RSACryptoServiceProvider rsaCrypt = new RSACryptoServiceProvider();
            //RSAParameters publicKey = rsaCrypt.ExportParameters(false);

            //(RSAParameters pubKey, RSAParameters privKey) = RSA.GetPublicAndPrivateKey();

            while (true)
            {
                Console.Write("Masukkan kata-kata: ");
                string plainText = Console.ReadLine();
                if (plainText != "-1")
                {
                    string cipherText, decryptText;
                    //TripleDES
                    //cipherText = TripleDES.Encrypt(plainText, key, iv);
                    //Console.WriteLine("");
                    //Console.WriteLine(plainText + " encrypted become " + cipherText);
                    //Console.WriteLine("");
                    //decryptText = TripleDES.Decrypt(cipherText, Convert.ToBase64String(key), Convert.ToBase64String(iv));
                    //Console.WriteLine(cipherText + " decrypted become " + decryptText);
                    //Console.WriteLine("");
                    //AES
                    cipherText = AES.Encrypt(plainText, key, iv);
                    WriteLine("");
                    WriteLine(plainText + " encrypted become " + cipherText);
                    WriteLine("");
                    WriteLine(cipherText + " decrypted become " + AES.Decrypt(cipherText, Convert.ToBase64String(key), Convert.ToBase64String(iv)));
                    WriteLine("");
                    //RSA
                    //        cipherText = RSA.Encrypt(plainText, publicKey);
                    //cipherText = RSA.Encrypt(plainText, pubKey);
                    //WriteLine("");
                    //WriteLine(plainText + " encrypted become " + cipherText);
                    //RSAParameters privateKey = rsaCrypt.ExportParameters(true);
                    //WriteLine("");
                    //WriteLine(cipherText + " decrypted become " + RSA.Decrypt(cipherText, privateKey));
                    //string decryptedText = RSA.Decrypt(cipherText, privKey);
                    //WriteLine(cipherText + " decrypted become " + decryptedText);
                    //WriteLine("");
                }
                else
                {
                    Console.ReadLine();
                }
            }
            //Contoh Steganography 
            //List<string> list1 = new List<string>() { "01", "Bayu", "bayu@gmail.com", "081234123123", "Kediri" };
            //string newList = string.Join(" ", list1);

            //string workPath = Directory.GetCurrentDirectory();
            //string parentpath = Directory.GetParent(workPath).Parent.Parent.FullName;
            //string filePath = parentpath + @"\foto.jpg";
            //string lokasi = parentpath + @"\foto_modif.png";

            //Bitmap hasil = Steganography.Sembunyikan(newList, filePath);

            //hasil.Save(lokasi, System.Drawing.Imaging.ImageFormat.Png);

            //string hasilAkhir = Steganography.Munculkan(new Bitmap(Image.FromFile(lokasi)));

            //List<string> list2 = hasilAkhir.Split(' ').ToList();

            //foreach (string item in list2)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadLine();
        }
    }
}
