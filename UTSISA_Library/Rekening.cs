using Crypthography;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class Rekening
    {
        #region Data Members
        private string noRekening;
        private double saldo;
        private string pin;
        private Pengguna pengguna;
        #endregion

        #region Constructors
        public Rekening(string noRekening, double saldo, string pin, Pengguna pengguna)
        {
            this.NoRekening = noRekening;
            this.Saldo = saldo;
            this.Pin = pin;
            this.Pengguna = pengguna;
        }
        public Rekening(string noRekening)
        {
            this.NoRekening = noRekening;
        }
        #endregion

        #region Properties
        public string NoRekening { get => noRekening; set => noRekening = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Pin { get => pin; set => pin = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        #endregion

        #region Methods
        public static void TambahData(Rekening rekening, Koneksi k)
        {
            string sql = $"INSERT into rekenings (nomor_rekening, saldo, pin, pengguna_id) " + 
                         $"values ('{rekening.NoRekening}', '{rekening.Saldo}', '{rekening.Pin}', '{rekening.Pengguna.Nik}')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UpdateData(Rekening rekening, Koneksi k)
        {
            string sql = $"UPDATE rekenings set nomor_rekening='{rekening.NoRekening}', saldo='{rekening.Saldo}', pin='{rekening.Saldo}', pengguna_id='{rekening.Pengguna.Nik}'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(Rekening rekening, Koneksi k)
        {
            string sql = $"DELETE from rekenings where nomor_rekening='{rekening.NoRekening}'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static Rekening AmbilData(Pengguna p)
        {
            string sql = $"SELECT * from public_keys k inner join penggunas p on k.penggunas_nik = p.nik";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                string key = hasil.GetValue(0).ToString();
                string iv = hasil.GetValue(1).ToString();
                string nik = AES.Decrypt(hasil.GetValue(3).ToString(), key, iv);

                if (nik == p.Nik)
                {
                    string sql1 = $"SELECT * from rekenings where pengguna_id = '{hasil.GetValue(3).ToString()}'";

                    MySqlDataReader hasil1 = Koneksi.JalankanPerintahQuery(sql1);

                    while (hasil1.Read() == true)
                    {
                        Pengguna pen = new Pengguna(nik);
                        Rekening rek = new Rekening(hasil1.GetValue(0).ToString(),
                                                    double.Parse(hasil1.GetValue(1).ToString()),
                                                    hasil1.GetValue(2).ToString(),
                                                    pen);

                        return rek;
                    }
                }
            }

            return null;
        }

        public static List<Rekening> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql;

            if (kriteria == "")
            {
                sql = "SELECT * from rekenings";
            }
            else
            {
                sql = $"SELECT * from rekenings where {kriteria} LIKE '%{nilaiKriteria}%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Rekening> listRekening = new List<Rekening>();

            while (hasil.Read() == true)
            {
                Pengguna p = new Pengguna(hasil.GetValue(3).ToString());
                Rekening rk = new Rekening(hasil.GetValue(0).ToString(), 
                                           double.Parse(hasil.GetValue(1).ToString()), 
                                           hasil.GetValue(2).ToString(), 
                                           p);

                listRekening.Add(rk);
            }

            return listRekening;
        }
        public override string ToString()
        {
            return this.NoRekening;
        }

        public static string GenerateNomorRekening()
        {
            string sql = "SELECT max(nomor_rekening) FROM rekenings";

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
        #endregion
    }
}
