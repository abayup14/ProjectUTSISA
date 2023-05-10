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
            string sql = $"INSERT into penggunas (nik, nama_lengkap, alamat, email, nomor_telepon, password, foto_diri, jenis_pengguna_id) " +
                         $"values ('{pengguna.Nik}', '{pengguna.NamaLengkap}', '{pengguna.Alamat}', '{pengguna.Email}', '{pengguna.NoTelepon}', '{pengguna.Password}', '{pengguna.FotoDiri}', '{pengguna.JenisPengguna.KodeJenis}')";

            Koneksi.JalankanPerintahDML(sql, k);
        }
        
        public static void TambahKunci(string nik, byte[] key, byte[] iv, Koneksi k)
        {
            string sql = $"INSERT INTO public_keys (public_key, iv, penggunas_nik) " +
                          $"values ('{Convert.ToBase64String(key)}', '{Convert.ToBase64String(iv)}', '{nik}')";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static void HapusData(Pengguna pengguna, Koneksi k)
        {
            string sql = $"DELETE from penggunas where nik='{pengguna.Nik}'";

            Koneksi.JalankanPerintahDML(sql, k);
        }

        public static (string, string) AmbilKunci(string nik)
        {
            string key = "";
            string iv = "";
            
            string sql = $"SELECT * from public_keys k inner join penggunas p on k.penggunas_nik = p.nik";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                string getNik = hasil.GetValue(3).ToString();

                if (nik == getNik)
                {
                    key = hasil.GetValue(0).ToString();
                    iv = hasil.GetValue(1).ToString();
                }
            }

            return (key, iv);
        }

        public static List<Pengguna> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql;
            if (kriteria == "")
            {
                sql = $"SELECT * from public_keys k right join penggunas p on k.penggunas_nik = p.nik";
            }
            else
            {
                sql = $"SELECT * from public_keys k right join penggunas p on k.penggunas_nik = p.nik where {kriteria} LIKE '%{nilaiKriteria}%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Pengguna> listPengguna = new List<Pengguna>();

            while (hasil.Read() == true)
            {
                if (hasil.GetValue(3).ToString() == "1")
                {
                    continue;
                }
                else
                {
                    string key = hasil.GetValue(0).ToString();
                    string iv = hasil.GetValue(1).ToString();
                    string decrypt_email = AES.Decrypt(hasil.GetValue(6).ToString(), key, iv);
                    string decrypt_pass = AES.Decrypt(hasil.GetValue(8).ToString(), key, iv);

                    JenisPengguna jp = new JenisPengguna(hasil.GetValue(10).ToString());

                    string nik = AES.Decrypt(hasil.GetValue(3).ToString(), key, iv);
                    string namaLengkap = AES.Decrypt(hasil.GetValue(4).ToString(), key, iv);
                    string alamat = AES.Decrypt(hasil.GetValue(5).ToString(), key, iv);
                    string noTelepon = AES.Decrypt(hasil.GetValue(7).ToString(), key, iv);
                    string fotoDiri = hasil.GetValue(9).ToString();

                    Pengguna pengguna = new Pengguna(nik, namaLengkap, alamat, decrypt_email, noTelepon, decrypt_pass, fotoDiri, jp);

                    listPengguna.Add(pengguna);
                }
            }

            return listPengguna;
        }

        public static Pengguna CekLogin(string email, string password)
        {
            string sql = $"SELECT * from public_keys k right join penggunas p on k.penggunas_nik = p.nik";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                string new_email = hasil.GetValue(6).ToString();
                string new_pass = hasil.GetValue(8).ToString();
                if (email == new_email && password == new_pass)
                {
                    JenisPengguna jp = new JenisPengguna(hasil.GetValue(10).ToString());

                    string nik = hasil.GetValue(3).ToString();
                    string namaLengkap = hasil.GetValue(4).ToString();
                    string alamat = hasil.GetValue(5).ToString();
                    string noTelepon = hasil.GetValue(7).ToString();
                    string fotoDiri = hasil.GetValue(9).ToString();

                    Pengguna p = new Pengguna(nik, namaLengkap, alamat, new_email, noTelepon, new_pass, fotoDiri, jp);

                    return p;
                }
                else
                {
                    string key = hasil.GetValue(0).ToString();
                    string iv = hasil.GetValue(1).ToString();
                    string decrypt_email = AES.Decrypt(hasil.GetValue(6).ToString(), key, iv);
                    string decrypt_pass = AES.Decrypt(hasil.GetValue(8).ToString(), key, iv);

                    if (email == decrypt_email && password == decrypt_pass)
                    {
                        JenisPengguna jp = new JenisPengguna(hasil.GetValue(10).ToString());

                        string nik = AES.Decrypt(hasil.GetValue(3).ToString(), key, iv);
                        string namaLengkap = AES.Decrypt(hasil.GetValue(4).ToString(), key, iv);
                        string alamat = AES.Decrypt(hasil.GetValue(5).ToString(), key, iv);
                        string noTelepon = AES.Decrypt(hasil.GetValue(7).ToString(), key, iv);
                        string fotoDiri = hasil.GetValue(9).ToString();

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
