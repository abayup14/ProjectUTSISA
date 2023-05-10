using Crypthography;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
            string sql = $"INSERT into transaksis (rek_sumber, rek_tujuan, waktu_transaksi, nominal, pesan, jenis_transaksis_id, nomor_transaksi) " +
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
                Rekening rekeningSumber = Rekening.AmbilData(hasil.GetValue(0).ToString());
                Rekening rekeningTujuan = Rekening.AmbilData(hasil.GetValue(1).ToString());
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
        public static bool CekPIN(string pin, Rekening rek)
        {
            string sql = "SELECT * from public_keys k inner join penggunas p on k.penggunas_nik = p.nik inner join rekenings r on p.nik = r.pengguna_id";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                string rekening = hasil.GetValue(11).ToString();

                if (rekening == rek.NoRekening)
                {
                    string key = hasil.GetValue(0).ToString();
                    string iv = hasil.GetValue(1).ToString();
                    string decrypt_pin = AES.Decrypt(hasil.GetValue(13).ToString(), key, iv);

                    if (pin == decrypt_pin)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static string GenerateNomorTransaksi()
        {
            string sql = "SELECT max(nomor_transaksi) FROM transaksis";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            string hasilGenerate = "";

            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    string hasilKode = (int.Parse(hasil.GetValue(0).ToString()) + 1).ToString();

                    if (hasilKode.Length == 10)
                    {
                        hasilGenerate = hasilKode;
                    }
                    else if (hasilKode.Length < 10)
                    {
                        hasilGenerate = hasilKode.PadLeft(11 - hasilKode.Length, '0');
                    }
                }
                else
                {
                    hasilGenerate = 1.ToString().PadLeft(10, '0');
                }
            }

            return hasilGenerate;
        }

        public static void PrintTransaksi(string printKriteria, string nilaiKriteria, string fileName, Font font)
        {
            List<Transaksi> listTransaksi = Transaksi.BacaData(printKriteria, nilaiKriteria);

            StreamWriter tempFile = new StreamWriter(fileName);

            foreach (Transaksi tr in listTransaksi)
            {
                tempFile.WriteLine("");
                tempFile.WriteLine("===== Bank MasBro =====");
                tempFile.WriteLine("");
                tempFile.WriteLine("Tanggal Transaksi: " + tr.WaktuTransaksi.ToShortDateString());
                tempFile.WriteLine("Waktu Transaksi: " + tr.WaktuTransaksi.ToLongTimeString());
                tempFile.WriteLine("");
                tempFile.WriteLine("");
                tempFile.WriteLine("Nomor Transaksi: " + tr.NomorTransaksi);
                if (tr.JenisTransaksi.KodeJenis == "KRM")
                {
                    tempFile.WriteLine("*** KIRIM ***");
                }
                else if (tr.JenisTransaksi.KodeJenis == "TRM")
                {
                    tempFile.WriteLine("*** TERIMA ***");
                }
                tempFile.WriteLine("Rekeining Sumber: " + tr.RekeningSumber.NoRekening);
                tempFile.WriteLine("Rekening Tujuan: " + tr.RekeningTujuan.NoRekening);
                tempFile.WriteLine("Nominal Transaksi: Rp. " + tr.Nominal.ToString("N0"));
                tempFile.WriteLine("Saldo: Rp. " + tr.RekeningSumber.Saldo.ToString("N0"));
                if (tr.Pesan == "")
                {
                    tempFile.WriteLine("");
                }
                else
                {
                    tempFile.WriteLine("Pesan Tambahan: " + tr.Pesan);
                }
                
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
