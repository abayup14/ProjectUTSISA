using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class Pengguna
    {
        private string nik;
        private string namaLengkap;
        private string alamat;
        private string email;
        private string noTelepon;
        private string password;
        private string photoPath;
        private JenisPengguna jenisPengguna;

        public Pengguna(string nik, string namaLengkap, string alamat, string email, string noTelepon, string password, string photoPath, JenisPengguna jenisPengguna)
        {
            this.Nik = nik;
            this.NamaLengkap = namaLengkap;
            this.Alamat = alamat;
            this.Email = email;
            this.NoTelepon = noTelepon;
            this.Password = password;
            this.PhotoPath = photoPath;
            this.JenisPengguna = jenisPengguna;
        }

        public string Nik { get => nik; set => nik = value; }
        public string NamaLengkap { get => namaLengkap; set => namaLengkap = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Email { get => email; set => email = value; }
        public string NoTelepon { get => noTelepon; set => noTelepon = value; }
        public string Password { get => password; set => password = value; }
        public string PhotoPath { get => photoPath; set => photoPath = value; }
        public JenisPengguna JenisPengguna { get => jenisPengguna; set => jenisPengguna = value; }
        

        public static void TambahData(Pengguna pengguna, Koneksi k)
        {
            string sql = $"INSERT into penggunas (nik, nama_lengkap, alamat, email, nomor_telepon, password, foto_diri, jenis_pengguna_id) " +
                         $"values ('{pengguna.Nik}', '{pengguna.NamaLengkap}', '{pengguna.Alamat}', '{pengguna.Email}', '{pengguna.NoTelepon}', '{pengguna.Password}', '{pengguna.PhotoPath}', '{pengguna.JenisPengguna.KodeJenis}')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void UpdateData(Pengguna pengguna, Koneksi k)
        {
            string sql = $"UPDATE penggunas set nik='{pengguna.Nik}', nama_lengkap='{pengguna.NamaLengkap}', alamat='{pengguna.Alamat}', email='{pengguna.Email}', nomor_telepon='{pengguna.NoTelepon}', password='{pengguna.Password}', foto_diri='{pengguna.PhotoPath}', jenis_pengguna_id='{pengguna.JenisPengguna.KodeJenis}'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(Pengguna pengguna, Koneksi k)
        {
            string sql = $"DELETE from penggunas where nik='{pengguna.Nik}'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static List<Pengguna> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql;

            if (kriteria == "")
            {
                sql = "SELECT * from penggunas";
            }
            else
            {
                sql = $"SELECT * from penggunas where {kriteria} LIKE '%{nilaiKriteria}%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Pengguna> listPengguna = new List<Pengguna>();

            while (hasil.Read() == true)
            {
                JenisPengguna jp = new JenisPengguna(hasil.GetValue(7).ToString());

                Pengguna pengguna = new Pengguna(hasil.GetValue(0).ToString(),
                                                 hasil.GetValue(1).ToString(),
                                                 hasil.GetValue(2).ToString(),
                                                 hasil.GetValue(3).ToString(),
                                                 hasil.GetValue(4).ToString(),
                                                 hasil.GetValue(5).ToString(),
                                                 hasil.GetValue(6).ToString(),
                                                 jp);

                listPengguna.Add(pengguna);
            }

            return listPengguna;
        }

        public static Pengguna CekLogin(string email, string password)
        {
            string sql = $"SELECT * from penggunas where email='{email}' AND password='{password}'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                JenisPengguna jp = new JenisPengguna(hasil.GetValue(7).ToString());

                Pengguna p = new Pengguna(hasil.GetString(0), 
                                          hasil.GetString(1), 
                                          hasil.GetString(2), 
                                          hasil.GetString(3), 
                                          hasil.GetString(4),
                                          hasil.GetString(5), 
                                          hasil.GetString(6), 
                                          jp);

                return p;
            }

            return null;
        }
    }
}
