using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crypthography
{
    public class RSA
    {
        private UnicodeEncoding encoding = new UnicodeEncoding();

        public string Encrypt(string plainText, RSAParameters publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                byte[] getByteFromPlainText = encoding.GetBytes(plainText);
                byte[] cipherTextInBytes = rsa.Encrypt(getByteFromPlainText, true);
                return Convert.ToBase64String(cipherTextInBytes);
            }
        }

        public string Decrypt(string cipherText, RSAParameters privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                byte[] getByteFromCipherText = Convert.FromBase64String(cipherText);
                byte[] plainTextInBytes = rsa.Decrypt(getByteFromCipherText, true);
                return encoding.GetString(plainTextInBytes);
            }
        }
    }
}
