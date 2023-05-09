using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class Transaksi
    {
        #region Data Members
        private Rekening rekeningSumber;
        private Rekening rekeningTujuan;
        private DateTime waktuTransaksi;
        private double nominal;
        private string pesan;
        private JenisTransaksi jenisTransaksi;
        private string nomorTransaksi;
        #endregion

        #region Constructors
        public Transaksi(Rekening rekeningSumber, Rekening rekeningTujuan, DateTime waktuTransaksi, double nominal, string pesan, JenisTransaksi jenisTransaksi, string nomorTransaksi)
        {
            this.RekeningSumber = rekeningSumber;
            this.RekeningTujuan = rekeningTujuan;
            this.WaktuTransaksi = waktuTransaksi;
            this.Nominal = nominal;
            this.Pesan = pesan;
            this.JenisTransaksi = jenisTransaksi;
            this.NomorTransaksi = nomorTransaksi;
        }
        #endregion

        #region Properties
        public Rekening RekeningSumber { get => rekeningSumber; set => rekeningSumber = value; }
        public Rekening RekeningTujuan { get => rekeningTujuan; set => rekeningTujuan = value; }
        public DateTime WaktuTransaksi { get => waktuTransaksi; set => waktuTransaksi = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public JenisTransaksi JenisTransaksi { get => jenisTransaksi; set => jenisTransaksi = value; }
        public string NomorTransaksi { get => nomorTransaksi; set => nomorTransaksi = value; }
        #endregion

        #region Methods
        public static void TambahData(Transaksi transaksi, Koneksi k)
        {
            string sql = $"INSERT into transaksis (rek_sumber, rek_tujuan, waktu_transaksi, nominal, pesan, jenis_transaksi_id, nomor_transaksi) " +
                         $"values ('{transaksi.RekeningSumber.NoRekening}', '{transaksi.RekeningTujuan.NoRekening}', '{transaksi.WaktuTransaksi.ToString("yyyy-MM-dd HH:mm:ss")}', '{transaksi.Nominal}', '{transaksi.Pesan}', '{transaksi.JenisTransaksi.KodeJenis}', '{transaksi.NomorTransaksi}')";

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
                                             jt, 
                                             hasil.GetValue(6).ToString());

                listTransaksi.Add(tr);
            }

            return listTransaksi;
        }

        public static void PrintTransaksi(string printKriteria, string nilaiKriteria, string fileName, Font font)
        {
            List<Transaksi> listTransaksi = new List<Transaksi>();

            listTransaksi = Transaksi.BacaData(printKriteria, nilaiKriteria);

            StreamWriter tempFile = new StreamWriter(fileName);

            foreach (Transaksi tr in listTransaksi)
            {
                tempFile.WriteLine("");
                tempFile.WriteLine("===== Bank MasBro =====");
                tempFile.WriteLine("");
                tempFile.WriteLine("Tanggal Transaksi: " + tr.WaktuTransaksi.ToShortDateString());
                tempFile.WriteLine("Waktu Transaksi: " + tr.WaktuTransaksi.ToShortTimeString());
                tempFile.WriteLine("");
                tempFile.WriteLine("");
                tempFile.WriteLine("Nomor Transaksi: " + tr.NomorTransaksi);
                if (tr.JenisTransaksi.KodeJenis == "")
                {
                    tempFile.WriteLine("KIRIM");
                }
                else
                {
                    tempFile.WriteLine("TERIMA");
                }
                tempFile.WriteLine("Rekeining Sumber: " + tr.RekeningSumber.NoRekening);
                tempFile.WriteLine("Rekening Tujuan: " + tr.RekeningTujuan.NoRekening);
                tempFile.WriteLine("Nominal Transaksi: Rp. " + tr.Nominal.ToString());
                tempFile.WriteLine("Saldo: Rp. " + tr.RekeningSumber.Saldo.ToString());
                tempFile.WriteLine("Pesan Tambahan: " + tr.Pesan);
                tempFile.WriteLine("");
                tempFile.WriteLine("");
                tempFile.WriteLine("===== TERIMA KASIH =====");
                tempFile.Close();

                Cetak cetak = new Cetak(font, fileName, 20, 10, 10, 10);

                cetak.SentToPrinter();
            }
        }
        #endregion
    }
}
