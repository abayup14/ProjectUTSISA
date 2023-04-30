using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class JenisPengguna
    {
        private string kodeJenis;
        private string nama;

        public JenisPengguna(string kodeJenis, string nama)
        {
            this.KodeJenis = kodeJenis;
            this.Nama = nama;
        }
        public JenisPengguna(string kodeJenis)
        {
            this.KodeJenis = kodeJenis;
        }


        public string KodeJenis { get => kodeJenis; set => kodeJenis = value; }
        public string Nama { get => nama; set => nama = value; }
    }
}
