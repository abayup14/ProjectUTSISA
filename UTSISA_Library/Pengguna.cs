using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypthography;

namespace UTSISA_Library
{
    public class Pengguna
    {
        #region Data Members
        private string nik;
        private string namaLengkap;
        private string alamat;
        private string email;
        private string noTelepon;
        private string password;
        private string fotoDiri;
        private JenisPengguna jenisPengguna;
        #endregion

        #region Constructors
        public Pengguna(string nik, string namaLengkap, string alamat, string email, string noTelepon, string password, string fotoDiri, JenisPengguna jenisPengguna)
        {
            this.Nik = nik;
            this.NamaLengkap = namaLengkap;
            this.Alamat = alamat;
            this.Email = email;
            this.NoTelepon = noTelepon;
            this.Password = password;
            this.FotoDiri = fotoDiri;
            this.JenisPengguna = jenisPengguna;
        }
        public Pengguna(string nik)
        {
            this.Nik = nik;
        }
        #endregion

        #region Properties
        public string Nik { get => nik; set => nik = value; }
        public string NamaLengkap { get => namaLengkap; set => namaLengkap = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Email { get => email; set => email = value; }
        public string NoTelepon { get => noTelepon; set => noTelepon = value; }
        public string Password { get => password; set => password = value; }
        public string FotoDiri { get => fotoDiri; set => fotoDiri = value; }
        public JenisPengguna JenisPengguna { get => jenisPengguna; set => jenisPengguna = value; }
        #endregion

        #region Methods
        public static void TambahData(Pengguna pengguna, Koneksi k)
        {
            byte[] key = AES.GenerateRandomKey();
            byte[] iv = AES.GenerateRandomIV();

            string nik = AES.Encrypt(pengguna.Nik, key, iv);
            string namaLengkap = AES.Encrypt(pengguna.NamaLengkap, key, iv);
            string alamat = AES.Encrypt(pengguna.Alamat, key, iv);
            string email = AES.Encrypt(pengguna.Email, key, iv);
            string noTelepon = AES.Encrypt(pengguna.NoTelepon, key, iv);
            string password = AES.Encrypt(pengguna.Password, key, iv);

            string sql = $"INSERT into penggunas (nik, nama_lengkap, alamat, email, nomor_telepon, password, foto_diri, jenis_pengguna_id) " +
                         $"values ('{nik}', '{namaLengkap}', '{alamat}', '{email}', '{noTelepon}', '{password}', '{pengguna.FotoDiri}', '{pengguna.JenisPengguna.KodeJenis}')";

            Koneksi.JalankanPerintahDML(sql, k);

            string sql1 = $"INSERT INTO public_keys(key, iv, penggunas_nik) " +
                          $"values ('{Encoding.UTF8.GetString(key)}', '{Encoding.UTF8.GetString(iv)}', '{nik}')";

            Koneksi.JalankanPerintahDML(sql1, k);
        }

        public static void UpdateData(Pengguna pengguna, Koneksi k)
        {
            string sql = $"UPDATE penggunas set nik='{pengguna.Nik}', nama_lengkap='{pengguna.NamaLengkap}', alamat='{pengguna.Alamat}', email='{pengguna.Email}', nomor_telepon='{pengguna.NoTelepon}', password='{pengguna.Password}', foto_diri='{pengguna.FotoDiri}', jenis_pengguna_id='{pengguna.JenisPengguna.KodeJenis}'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(Pengguna pengguna, Koneksi k)
        {
            string sql = $"DELETE from penggunas where nik='{pengguna.Nik}'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static List<Pengguna> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = $"SELECT * from key k inner join penggunas p on k.pengguna_nik = p.nik";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                string key = hasil.GetValue(0).ToString();
                string iv = hasil.GetValue(1).ToString();
                string decrypt_email = AES.Decrypt(hasil.GetValue(6).ToString(), key, iv);
                string decrypt_pass = AES.Decrypt(hasil.GetValue(8).ToString(), key, iv);

                string sql1;

                if (kriteria == "")
                {
                    sql1 = "SELECT * from penggunas";
                }
                else
                {
                    sql1 = $"SELECT * from penggunas where {kriteria} LIKE '%{nilaiKriteria}%'";
                }

                MySqlDataReader hasil1 = Koneksi.JalankanPerintahQuery(sql1);

                List<Pengguna> listPengguna = new List<Pengguna>();

                while (hasil1.Read() == true)
                {
                    JenisPengguna jp = new JenisPengguna(hasil.GetValue(7).ToString());

                    string nik = AES.Decrypt(hasil1.GetValue(0).ToString(), key, iv);
                    string namaLengkap = AES.Decrypt(hasil1.GetValue(1).ToString(), key, iv);
                    string alamat = AES.Decrypt(hasil1.GetValue(2).ToString(), key, iv);
                    string noTelepon = AES.Decrypt(hasil1.GetValue(4).ToString(), key, iv);
                    string fotoDiri = hasil1.GetValue(6).ToString();

                    Pengguna pengguna = new Pengguna(nik, namaLengkap, alamat, decrypt_email, noTelepon, decrypt_pass, fotoDiri, jp);

                    listPengguna.Add(pengguna);
                }

                return listPengguna;
            }

            return null;
        }

        public static Pengguna CekLogin(string email, string password)
        {
            string sql = $"SELECT * from public_key k inner join penggunas p on k.pengguna_nik = p.nik";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                string key = hasil.GetValue(0).ToString();
                string iv = hasil.GetValue(1).ToString();
                string decrypt_email = AES.Decrypt(hasil.GetValue(6).ToString(), key, iv);
                string decrypt_pass = AES.Decrypt(hasil.GetValue(8).ToString(), key, iv);

                if (email == decrypt_email && password == decrypt_pass)
                {
                    string new_email = hasil.GetValue(6).ToString();
                    string new_pass = hasil.GetValue(8).ToString();
                    string sql1 = $"SELECT * from penggunas where email='{new_email}' AND password='{new_pass}'";

                    MySqlDataReader hasil1 = Koneksi.JalankanPerintahQuery(sql1);

                    if (hasil1.Read() == true)
                    {
                        JenisPengguna jp = new JenisPengguna(hasil.GetValue(7).ToString());

                        string nik = AES.Decrypt(hasil1.GetValue(0).ToString(), key, iv);
                        string namaLengkap = AES.Decrypt(hasil1.GetValue(1).ToString(), key, iv);
                        string alamat = AES.Decrypt(hasil1.GetValue(2).ToString(), key, iv);
                        string noTelepon = AES.Decrypt(hasil1.GetValue(4).ToString(), key, iv);
                        string fotoDiri = hasil1.GetValue(6).ToString();

                        Pengguna p = new Pengguna(nik, namaLengkap, alamat, decrypt_email, noTelepon, decrypt_pass, fotoDiri, jp);

                        return p;
                    }
                }
            }
            
            return null;
        }

        #endregion
    }
}
