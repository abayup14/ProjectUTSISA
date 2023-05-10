using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTSISA_Library;
using Crypthography;
using System.IO;

namespace ProjectUTSISA
{
    public partial class FormTambahPengguna : Form
    {
        public FormTambahPengguna()
        {
            InitializeComponent();
        }
        OpenFileDialog open;
        
        private void FormTambahPengguna_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;

            textBoxNIK.Text = "(16 digit angka Nomor Induk Kewarganegaraan)";
            textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Italic);
            textBoxNIK.ForeColor = Color.Gray;

            textBoxNamaLengkap.Text = "Nama Lengkap";
            textBoxNamaLengkap.Font = new Font(textBoxNamaLengkap.Font, FontStyle.Italic);
            textBoxNamaLengkap.ForeColor = Color.Gray;

            textBoxAlamat.Text = "Alamat";
            textBoxAlamat.Font = new Font(textBoxAlamat.Font, FontStyle.Italic);
            textBoxAlamat.ForeColor = Color.Gray;

            textBoxEmail.Text = "example@email.com";
            textBoxEmail.Font = new Font(textBoxAlamat.Font, FontStyle.Italic);
            textBoxEmail.ForeColor = Color.Gray;

            textBoxNoTelp.Text = "0818xxxxxxx";
            textBoxNoTelp.Font = new Font(textBoxAlamat.Font, FontStyle.Italic);
            textBoxNoTelp.ForeColor = Color.Gray;

            textBoxPassword.Text = "Password";
            textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
            textBoxPassword.ForeColor = Color.Gray;
            textBoxPassword.UseSystemPasswordChar = false;

            textBoxPIN.Text = "PIN anda";
            textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Italic);
            textBoxPIN.ForeColor = Color.Gray;
            textBoxPIN.UseSystemPasswordChar = false;
        }

        private void buttonFoto_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Image Files",
                Filter = "Image Files(*.jpg; *.jpeg)|*.jpg; *.jpeg",
                DefaultExt = "jpg",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxPhoto.Image = new Bitmap(open.FileName);
                    pictureBoxPhoto.MaximumSize = new Size(150, 200); // ukuran maksimum 400x400 piksel
                    pictureBoxPhoto.Height = Math.Min(pictureBoxPhoto.Image.Height, pictureBoxPhoto.MaximumSize.Height);
                    pictureBoxPhoto.Width = Math.Min(pictureBoxPhoto.Image.Width, pictureBoxPhoto.MaximumSize.Width);
                    pictureBoxPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi k = new Koneksi();

                //simpen data pengguna
                string nik = textBoxNIK.Text;
                string nama = textBoxNamaLengkap.Text;
                string alamat = textBoxAlamat.Text;
                string email = textBoxEmail.Text;
                string noTelepon = textBoxNoTelp.Text;
                string password = textBoxPassword.Text;
                string fotoDiri = open.FileName;
                JenisPengguna jp =null;
                if (fotoDiri == "")
                {
                    MessageBox.Show("Masukkan foto anda.");
                }
                else
                {
                    if (textBoxPassword.Text == "" || textBoxPIN.Text == "")
                    {
                        MessageBox.Show("PIN atau password belum diisi. Tolong diisi terlebih dahulu");
                    }
                    else
                    {
                        byte[] key = AES.GenerateRandomKey();
                        byte[] iv = AES.GenerateRandomIV();

                        string encrypt_nik = AES.Encrypt(nik, key, iv);
                        string encrypt_namaLengkap = AES.Encrypt(nama, key, iv);
                        string encrypt_alamat = AES.Encrypt(alamat, key, iv);
                        string encrypt_email = AES.Encrypt(email, key, iv);
                        string encrypt_noTelepon = AES.Encrypt(noTelepon, key, iv);
                        string encrypt_password = AES.Encrypt(password, key, iv);

                        List<string> listDataPengguna = new List<string>() { encrypt_nik, encrypt_namaLengkap, encrypt_alamat, encrypt_email, encrypt_noTelepon, encrypt_password };
                        string dataPenggunaDigabung = string.Join(" ", listDataPengguna);
                        string workPath = Directory.GetCurrentDirectory();
                        string parentpath = Directory.GetParent(workPath).Parent.Parent.FullName;
                        string lokasiSimpan ="";
                        if (radioButtonEmp.Checked)
                        {
                            jp = new JenisPengguna("EMP");
                            lokasiSimpan = parentpath + $"\\foto_stegano\\{nik}_emp.png";
                            Bitmap hideDataToImage = Steganography.Sembunyikan(dataPenggunaDigabung, fotoDiri);
                            hideDataToImage.Save(lokasiSimpan, System.Drawing.Imaging.ImageFormat.Png);

                            Pengguna p = new Pengguna(encrypt_nik,
                                                      encrypt_namaLengkap,
                                                      encrypt_alamat,
                                                      encrypt_email,
                                                      encrypt_noTelepon,
                                                      encrypt_password,
                                                      lokasiSimpan.Replace("\\", "\\\\"),
                                                      jp);

                            Pengguna.TambahData(p, k);
                            Pengguna.TambahKunci(encrypt_nik, key, iv, k);                           
                        }
                        else if (radioButtonNsb.Checked)
                        {
                            jp = new JenisPengguna("NSB");
                            string noRekening = Rekening.GenerateNomorRekening();
                            lokasiSimpan = parentpath + $"\\foto_stegano\\{nik}_{noRekening}.png";
                            Bitmap hideDataToImage = Steganography.Sembunyikan(dataPenggunaDigabung, fotoDiri);
                            hideDataToImage.Save(lokasiSimpan, System.Drawing.Imaging.ImageFormat.Png);

                            Pengguna p = new Pengguna(encrypt_nik,
                                                      encrypt_namaLengkap,
                                                      encrypt_alamat,
                                                      encrypt_email,
                                                      encrypt_noTelepon,
                                                      encrypt_password,
                                                      lokasiSimpan.Replace("\\", "\\\\"),
                                                      jp);

                            Pengguna.TambahData(p, k);
                            Pengguna.TambahKunci(encrypt_nik, key, iv, k);

                            string pin = textBoxPIN.Text;
                            string encrypt_pin = AES.Encrypt(pin, key, iv);
                            Rekening rek = new Rekening(noRekening, 0, encrypt_pin, p);
                            Rekening.TambahData(rek, k);

                            MessageBox.Show($"Rekening anda sudah dibuat dengan nomor rekening {noRekening}", "Informasi");
                        }
                        MessageBox.Show("Selamat, data anda sudah tersimpan." +
                                           "\nSilahkan login dengan email dan password yang anda daftarkan", "Informasi");

                    }
                }
                this.Close();//kembali ke form login
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxNIK_Enter(object sender, EventArgs e)
        {
            if (textBoxNIK.Text == "(16 digit angka Nomor Induk Kewarganegaraan)")
            {
                textBoxNIK.Text = "";
                textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Regular);
                textBoxNIK.ForeColor = Color.Black;
            }
        }

        private void textBoxNIK_Leave(object sender, EventArgs e)
        {
            if (textBoxNIK.Text == "")
            {
                textBoxNIK.Text = "(16 digit angka Nomor Induk Kewarganegaraan)";
                textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Italic);
                textBoxNIK.ForeColor = Color.Gray;
            }
        }
        private void textBoxNamaLengkap_Enter(object sender, EventArgs e)
        {
            if (textBoxNamaLengkap.Text == "Nama Lengkap")
            {
                textBoxNamaLengkap.Text = "";
                textBoxNamaLengkap.Font = new Font(textBoxNamaLengkap.Font, FontStyle.Regular);
                textBoxNamaLengkap.ForeColor = Color.Black;
            }
        }

        private void textBoxNamaLengkap_Leave(object sender, EventArgs e)
        {
            if (textBoxNamaLengkap.Text == "")
            {
                textBoxNamaLengkap.Text = "Nama Lengkap";
                textBoxNamaLengkap.Font = new Font(textBoxNamaLengkap.Font, FontStyle.Italic);
                textBoxNamaLengkap.ForeColor = Color.Gray;
            }
        }

        private void textBoxAlamat_Enter(object sender, EventArgs e)
        {
            if (textBoxAlamat.Text == "Alamat")
            {
                textBoxAlamat.Text = "";
                textBoxAlamat.Font = new Font(textBoxAlamat.Font, FontStyle.Regular);
                textBoxAlamat.ForeColor = Color.Black;
            }
        }

        private void textBoxAlamat_Leave(object sender, EventArgs e)
        {
            if (textBoxAlamat.Text == "")
            {
                textBoxAlamat.Text = "Alamat";
                textBoxAlamat.Font = new Font(textBoxAlamat.Font, FontStyle.Italic);
                textBoxAlamat.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "example@email.com")
            {
                textBoxEmail.Text = "";
                textBoxEmail.Font = new Font(textBoxAlamat.Font, FontStyle.Regular);
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "example@email.com";
                textBoxEmail.Font = new Font(textBoxAlamat.Font, FontStyle.Italic);
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void textBoxNoTelp_Leave(object sender, EventArgs e)
        {
            if (textBoxNoTelp.Text == "")
            {
                textBoxNoTelp.Text = "0818xxxxxxx";
                textBoxNoTelp.Font = new Font(textBoxAlamat.Font, FontStyle.Italic);
                textBoxNoTelp.ForeColor = Color.Gray;
            }
        }

        private void textBoxNoTelp_Enter(object sender, EventArgs e)
        {
            if (textBoxNoTelp.Text == "0818xxxxxxx")
            {
                textBoxNoTelp.Text = "";
                textBoxNoTelp.Font = new Font(textBoxNoTelp.Font, FontStyle.Regular);
                textBoxNoTelp.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
                textBoxPassword.ForeColor = Color.Gray;
                if (buttonBukaPass.Text == "Buka" || buttonBukaPass.Text == "Tutup")
                {
                    textBoxPassword.UseSystemPasswordChar = false;
                }

            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Text = "";
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Regular);
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNIK.Text = "";
            textBoxNamaLengkap.Text = "";
            textBoxAlamat.Text = "";
            textBoxEmail.Text = "";
            textBoxNoTelp.Text = "";
            textBoxPassword.Text = "";
            open.FileName = "";
            pictureBoxPhoto.Image = null;
        }

        private void buttonBukaPass_Click(object sender, EventArgs e)
        {
            if (buttonBukaPass.Text == "Buka")
            {
                buttonBukaPass.Text = "Tutup";
                if (textBoxPassword.Text == "Password")
                {
                    textBoxPassword.Text = "Password";
                }
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else if (buttonBukaPass.Text == "Tutup")
            {
                buttonBukaPass.Text = "Buka";
                if (textBoxPassword.Text == "Password")
                {
                    textBoxPassword.Text = "Password";
                    textBoxPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    textBoxPassword.UseSystemPasswordChar = true;
                }
            }
        }

        private void textBoxPIN_Enter(object sender, EventArgs e)
        {
            if (textBoxPIN.Text == "PIN anda")
            {
                textBoxPIN.Text = "";
                textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Regular);
                textBoxPIN.ForeColor = Color.Black;
                textBoxPIN.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPIN_Leave(object sender, EventArgs e)
        {
            if (textBoxPIN.Text == "")
            {
                textBoxPIN.Text = "PIN anda";
                textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Italic);
                textBoxPIN.ForeColor = Color.Gray;
                if (buttonBukaPIN.Text == "Buka" || buttonBukaPIN.Text == "Tutup")
                {
                    textBoxPIN.UseSystemPasswordChar = false;
                }

            }
        }

        private void buttonBukaPIN_Click(object sender, EventArgs e)
        {
            if (buttonBukaPIN.Text == "Buka")
            {
                buttonBukaPIN.Text = "Tutup";
                if (textBoxPIN.Text == "Password")
                {
                    textBoxPIN.Text = "Password";
                }
                textBoxPIN.UseSystemPasswordChar = false;
            }
            else if (buttonBukaPIN.Text == "Tutup")
            {
                buttonBukaPIN.Text = "Buka";
                if (textBoxPIN.Text == "Password")
                {
                    textBoxPIN.Text = "Password";
                    textBoxPIN.UseSystemPasswordChar = false;
                }
                else
                {
                    textBoxPIN.UseSystemPasswordChar = true;
                }
            }
        }

        private void radioButtonNsb_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNsb.Checked)
            {
                labelPIN.Enabled = true;
                textBoxPIN.Enabled = true;
                buttonBukaPIN.Enabled = true;
            }
            else
            {
                labelPIN.Enabled = textBoxPIN.Enabled = buttonBukaPIN.Enabled = false;
            }
        }

        private void buttonKosongi_Click_1(object sender, EventArgs e)
        {

        }
    }
}
