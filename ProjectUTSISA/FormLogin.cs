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

namespace ProjectUTSISA
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        public string email;
        public string password;
        public FormUtama formUtama;
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;

            textBoxEmail.Text = "Masukkan username anda";
            textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Italic);
            textBoxEmail.ForeColor = Color.Gray;

            textBoxPassword.Text = "Masukkan password anda";
            textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
            textBoxPassword.ForeColor = Color.Gray;
            textBoxPassword.UseSystemPasswordChar = false;
        }

        private void labelRegistrasi_Click(object sender, EventArgs e)
        {
            FormRegister frm = new FormRegister();
            frm.Owner = this;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                textBoxEmail.Text = email;
                textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Regular);
                textBoxEmail.ForeColor = Color.Black;

                textBoxPassword.Text = password;
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Regular);
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();
                email = textBoxEmail.Text;
                password = textBoxPassword.Text;
                Pengguna p = Pengguna.CekLogin(email, password);
                if (p != null)
                {
                    Rekening rek = Rekening.AmbilData(p);
                    formUtama = (FormUtama)this.Owner;
                    formUtama.pengguna = p;
                    formUtama.rekening = rek;

                    MessageBox.Show("Login berhasil, Selamat menggunakan Aplikasi Bank Masbro, " + textBoxEmail.Text + "!", "Informasi");
                    this.DialogResult = DialogResult.OK;
                }
                //    string apakahEmployee = textBoxUsername.Text.Substring(textBoxUsername.Text.Length - 3);
                //    if (apakahEmployee.ToUpper() == "EMP")
                //    {
                //        string email = textBoxUsername.Text.Remove(textBoxUsername.Text.Length - 3);
                //        string password = textBoxPassword.Text;
                //        Employee em = Employee.CekLogin(email, password);
                //        if (!(em is null))
                //        {
                //            FormUtama frmUtama = (FormUtama)this.Owner;
                //            frmUtama.employeeAktif = em;

                //            MessageBox.Show("Koneksi berhasil, Selamat menggunakan aplikasi, " + em.Nama_depan + "!", "Informasi");
                //            this.DialogResult = DialogResult.OK;
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Username atau password salah!");
                //        }
                //    }
                //    else
                //    {
                //        string username = textBoxUsername.Text;
                //        string password = textBoxPassword.Text;
                //        Pengguna p = Pengguna.CekLogin(username, password, jenisLogin);
                //        if (!(p is null))
                //        {
                //            FormUtama frmUtama = (FormUtama)this.Owner;
                //            frmUtama.penggunaAktif = p;

                //            MessageBox.Show("Login berhasil, Selamat menggunakan DiBa, " + p.Nama_depan + "!", "Informasi");
                //            this.DialogResult = DialogResult.OK;
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Username atau password salah!");
                //        }
                //    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Gagal login, pesan error :" + a.Message, "Kesalahan");
                }
            this.Close();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Anda yakin ingin keluar?", "Informasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Masukkan username anda")
            {
                textBoxEmail.Text = "";
                textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Regular);
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "Masukkan username anda";
                textBoxEmail.Font = new Font(textBoxEmail.Font, FontStyle.Italic);
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Masukkan password anda")
            {
                textBoxPassword.Text = "";
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Regular);
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Masukkan password anda";
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Italic);
                textBoxPassword.ForeColor = Color.Gray;
                textBoxPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
