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
        static UnicodeEncoding encoder = new UnicodeEncoding();

        public static string Encrypt(string plainText, RSAParameters publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                byte[] getByteFromPlainText = encoder.GetBytes(plainText);
                byte[] cipherTextInBytes = rsa.Encrypt(getByteFromPlainText, true);
                return Convert.ToBase64String(cipherTextInBytes);
            }
        }

        public static string Decrypt(string cipherText, RSAParameters privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                byte[] getByteFromCipherText = Convert.FromBase64String(cipherText);
                byte[] plainTextInBytes = rsa.Decrypt(getByteFromCipherText, true);
                return encoder.GetString(plainTextInBytes);
            }
        }

        public static RSAParameters GeneratePublicKey()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                return rsa.ExportParameters(false);
            }
        }

        public static RSAParameters GeneratePrivateKey()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                return rsa.ExportParameters(true);
            }
        }
    }
}
