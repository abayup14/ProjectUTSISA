using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crypthography
{
    public class TripleDES
    {
        public string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            byte[] getByteFromPlainText = Encoding.UTF8.GetBytes(plainText);

            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = key;
                tdes.IV = iv;

                using (ICryptoTransform encryptor = tdes.CreateEncryptor())
                {
                    byte[] cipherTextInBytes = encryptor.TransformFinalBlock(getByteFromPlainText, 0, getByteFromPlainText.Length);

                    return Convert.ToBase64String(cipherTextInBytes);
                }
            }
        }

        public string Decrypt(string cipherText, string key, string iv)
        {
            byte[] getByteFromCipherText = Convert.FromBase64String(cipherText);

            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.Key = Convert.FromBase64String(key);
                tdes.IV = Convert.FromBase64String(iv);

                using (ICryptoTransform decryptor = tdes.CreateDecryptor())
                {
                    byte[] plainTextInBytes = decryptor.TransformFinalBlock(getByteFromCipherText, 0, getByteFromCipherText.Length);

                    return Encoding.UTF8.GetString(plainTextInBytes);
                }
            }
        }
    }
}
