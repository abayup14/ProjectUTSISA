using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crypthography
{
    public class AES
    {
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            byte[] getByteFromPlainText = Encoding.UTF8.GetBytes(plainText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] cipherTextInBytes = encryptor.TransformFinalBlock(getByteFromPlainText, 0, getByteFromPlainText.Length);

                    return Convert.ToBase64String(cipherTextInBytes);
                }
            }
        }

        public static string Decrypt(string cipherText, string key, string iv)
        {
            byte[] getByteFromCipherText = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] plainTextInBytes = decryptor.TransformFinalBlock(getByteFromCipherText, 0, getByteFromCipherText.Length);

                    return Encoding.UTF8.GetString(plainTextInBytes);
                }
            }
        }

        public static byte[] GenerateRandomKey()
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey();
                return aes.Key;
            }
        }

        public static byte[] GenerateRandomIV()
        {
            using (var aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.GenerateIV();
                return aes.IV;
            }
        }
    }
}
