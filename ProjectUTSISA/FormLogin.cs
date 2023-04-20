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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void labelRegistrasi_Click(object sender, EventArgs e)
        {
            FormRegister frm = new FormRegister();
            frm.Owner = this;
            frm.Show();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Koneksi koneksi = new Koneksi();
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
            //}
            //catch (Exception a)
            //{
            //    MessageBox.Show("Gagal login, pesan error :" + a.Message);
            //}
            MessageBox.Show("Login berhasil, Selamat menggunakan Aplikasi Bank Masbro, " + textBoxUsername.Text + "!", "Informasi");
            this.DialogResult = DialogResult.OK;
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
    }
}
