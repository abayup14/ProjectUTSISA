using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypthography;

namespace CobaProjectPakeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //byte[] key, iv;
            //key = TripleDES.GenerateRandomKey();
            //iv = TripleDES.GenerateRandomIV();

            //RSACryptoServiceProvider rsaCrypt = new RSACryptoServiceProvider();
            //RSAParameters publicKey = rsaCrypt.ExportParameters(false);

            //(RSAParameters pubKey, RSAParameters privKey) = RSA.GetPublicAndPrivateKey();

            //while (true)
            //{
            //    Console.Write("Masukkan kata-kata: ");
            //    string plainText = Console.ReadLine();
            //    if (plainText != "-1")
            //    {
            //        string cipherText, decryptText;
            //        cipherText = TripleDES.Encrypt(plainText, key, iv);
            //        Console.WriteLine("");
            //        Console.WriteLine(plainText + " encrypted become " + cipherText);
            //        Console.WriteLine("");
            //        decryptText = TripleDES.Decrypt(cipherText, Convert.ToBase64String(key), Convert.ToBase64String(iv));
            //        Console.WriteLine(cipherText + " decrypted become " + decryptText);
            //        Console.WriteLine("");

            //        AES aes = new AES();
            //        cipherText = aes.Encrypt(plainText, key, iv);
            //        WriteLine("");
            //        WriteLine(plainText + " encrypted become " + cipherText);
            //        WriteLine("");
            //        WriteLine(cipherText + " decrypted become " + aes.Decrypt(cipherText, Convert.ToBase64String(key), Convert.ToBase64String(iv)));
            //        WriteLine("");

            //        cipherText = RSA.Encrypt(plainText, publicKey);
            //        cipherText = RSA.Encrypt(plainText, pubKey);
            //        WriteLine("");
            //        WriteLine(plainText + " encrypted become " + cipherText);
            //        RSAParameters privateKey = rsaCrypt.ExportParameters(true);
            //        WriteLine("");
            //        WriteLine(cipherText + " decrypted become " + RSA.Decrypt(cipherText, privateKey));
            //        string decryptedText = RSA.Decrypt(cipherText, privKey);
            //        WriteLine(cipherText + " decrypted become " + decryptedText);
            //        WriteLine("");
            //    }
            //    else
            //    {
            //        Console.ReadLine();
            //    }
            //}
        }
    }
}
