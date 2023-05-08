using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUTSISA
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        OpenFileDialog open;
        FormLogin frmLogin;
        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                //simpen data pengguna
                string nik = textBoxNIK.Text;
                string nama = textBoxNamaLengkap.Text;
                string alamat = textBoxAlamat.Text;
                string email = textBoxEmail.Text;
                string noTelepon = textBoxNoTelp.Text;
                string password = textBoxPassword.Text;
                string fotoDiri = open.FileName;

                frmLogin.email = email;
                frmLogin.password = password;
                //new akun
                this.DialogResult = DialogResult.OK;
                this.Close();//kembali ke form login
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
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

        private void FormRegister_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            frmLogin = (FormLogin)this.Owner;

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
        }

        private void buttonFoto_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Image Files",
                Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp",
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
        private void textBoxNamaDepan_Enter(object sender, EventArgs e)
        {
            if (textBoxNamaLengkap.Text == "Nama Lengkap")
            {
                textBoxNamaLengkap.Text = "";
                textBoxNamaLengkap.Font = new Font(textBoxNamaLengkap.Font, FontStyle.Regular);
                textBoxNamaLengkap.ForeColor = Color.Black;
            }
        }

        private void textBoxNamaDepan_Leave(object sender, EventArgs e)
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
    }
}
