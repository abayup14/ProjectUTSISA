using MySql.Data.MySqlClient;
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

        public static void TambahData(Transaksi transaksi, Koneksi k)
        {
            string sql = $"INSERT into transaksis (rek_sumber, rek_tujuan, waktu_transaksi, nominal, pesan, jenis_transaksi_id) " +
                         $"values ('{transaksi.RekeningSumber.NoRekening}', '{transaksi.RekeningTujuan.NoRekening}', '{transaksi.WaktuTransaksi.ToString("yyyy-MM-dd HH:mm:ss")}', '{transaksi.Nominal}', '{transaksi.Pesan}', '{transaksi.JenisTransaksi.KodeJenis}')";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        
        public static List<Transaksi> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql;

            if (kriteria == "")
            {
                sql = "SELECT * from transaksis";
            }
            else
            {
                sql = $"SELECT * from transaksis where {kriteria} LIKE '%{nilaiKriteria}%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Transaksi> listTransaksi = new List<Transaksi>();

            while (hasil.Read() == true)
            {
                Rekening rekeningSumber = new Rekening(hasil.GetValue(0).ToString());
                Rekening rekeningTujuan = new Rekening(hasil.GetValue(1).ToString());
                JenisTransaksi jt = new JenisTransaksi(hasil.GetValue(5).ToString());
                Transaksi tr = new Transaksi(rekeningSumber, 
                                             rekeningTujuan, 
                                             DateTime.Parse(hasil.GetValue(2).ToString()), 
                                             double.Parse(hasil.GetValue(3).ToString()), 
                                             hasil.GetValue(4).ToString(), 
                                             jt);

                listTransaksi.Add(tr);
            }

            return listTransaksi;
        }
    }
}
