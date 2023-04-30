using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class Rekening
    {
        private string noRekening;
        private double saldo;
        private string pin;
        private Pengguna pengguna;

        public Rekening(string noRekening, double saldo, string pin, Pengguna pengguna)
        {
            this.NoRekening = noRekening;
            this.Saldo = saldo;
            this.Pin = pin;
            this.Pengguna = pengguna;
        }

        public string NoRekening { get => noRekening; set => noRekening = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Pin { get => pin; set => pin = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }

        public static void TambahData(Rekening rk, Koneksi k)
        {
            string sql = $"";

            Koneksi.JalankanPerintahDML(sql, k);
        }
    }
}
