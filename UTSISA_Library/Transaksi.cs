using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class Transaksi
    {
        private Rekening rekeningSumber;
        private Rekening rekeningTujuan;
        private DateTime waktuTransaksi;
        private double nominal;
        private string pesan;
        private JenisTransaksi jenisTransaksi;

        public Transaksi(Rekening rekeningSumber, Rekening rekeningTujuan, DateTime waktuTransaksi, double nominal, string pesan, JenisTransaksi jenisTransaksi)
        {
            this.RekeningSumber = rekeningSumber;
            this.RekeningTujuan = rekeningTujuan;
            this.WaktuTransaksi = waktuTransaksi;
            this.Nominal = nominal;
            this.Pesan = pesan;
            this.JenisTransaksi = jenisTransaksi;
        }

        public Rekening RekeningSumber { get => rekeningSumber; set => rekeningSumber = value; }
        public Rekening RekeningTujuan { get => rekeningTujuan; set => rekeningTujuan = value; }
        public DateTime WaktuTransaksi { get => waktuTransaksi; set => waktuTransaksi = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public JenisTransaksi JenisTransaksi { get => jenisTransaksi; set => jenisTransaksi = value; }
    }
}
