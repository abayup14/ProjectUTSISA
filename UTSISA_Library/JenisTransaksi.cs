using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class JenisTransaksi
    {
        private string kodeJenis;
        private string nama;

        public JenisTransaksi(string kodeJenis, string nama)
        {
            this.KodeJenis = kodeJenis;
            this.Nama = nama;
        }
        public JenisTransaksi(string kodeJenis)
        {
            this.KodeJenis = kodeJenis;
        }

        public string KodeJenis { get => kodeJenis; set => kodeJenis = value; }
        public string Nama { get => nama; set => nama = value; }
    }
}
