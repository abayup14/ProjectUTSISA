using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crypthography
{
    public class RandomKeyAndIV
    {
        private byte[] key;
        private byte[] iv;

        public RandomKeyAndIV()
        {
            this.Key = key;
            this.Iv = iv;
        }

        public byte[] Key { get => key; private set => key = value; }
        public byte[] Iv { get => iv; private set => iv = value; }

        public static byte[] GenerateRandomKeyInDES()
        {
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.GenerateKey();
                return tdes.Key;
            }
        }

        public static byte[] GenerateRandomIVInDES()
        {
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                tdes.GenerateIV();
                return tdes.IV;
            }
        }

        public static byte[] GenerateRandomKeyInAES()
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey();
                return aes.Key;
            }
        }

        public static byte[] GenerateRandomIVInAES()
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
