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
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }
        public Pengguna pengguna;
        public Rekening rekening;
        public void SetHakAkses()
        {
            //ganti dalem stringnya dan visiblity nya
            if (pengguna.JenisPengguna.KodeJenis == "")
            {
                masterToolStripMenuItem.Visible = true;//pegawai
            }
            else if (pengguna.JenisPengguna.KodeJenis == "")
            {
                aksiToolStripMenuItem.Visible = true;//nasbah
            }
        }
        private void FormUtama_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            masterToolStripMenuItem.Visible = false;
            aksiToolStripMenuItem.Visible = false;
            try
            {
                Koneksi koneksi = new Koneksi();
                MessageBox.Show("Koneksi berhasil dibentuk!", "Information");

                //form login
                FormLogin frmLogin = new FormLogin();
                frmLogin.Owner = this;

                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    //login sukses
                    //if (!(employeeAktif is null))
                    //{
                    //    label1.Text = "Anda login sebagai:";
                    //    label3.Text = "-";
                    //    labelKodePegawai.Text = employeeAktif.Id.ToString();
                    //    labelNamaPegawai.Text = employeeAktif.Nama_depan;
                    //}
                    //SetHakAkses(employeeAktif, penggunaAktif);
                    //List<Rekening> reks= Rekening.BacaData("NIK", pengguna.Nik); // berpotensi erorr -> untuk nasabar=h
                    //rekening = reks[0];
                }
                else
                {
                    //login gagal
                    MessageBox.Show("Gagal Login");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Koneksi gagal hiks\nPesan Eror: {ex.Message}", "Information");
            }
        }

        private void akunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormAkun"];

            if (form == null)
            {
                FormAkun frm = new FormAkun();
                frm.MdiParent = this;
                frm.Show();
                labelTitle.SendToBack();
                labelSubtitle.SendToBack();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormTransaksi"];

            if (form == null)
            {
                FormTransaksi frm = new FormTransaksi();
                frm.MdiParent = this;
                frm.Show();
                labelTitle.SendToBack();
                labelSubtitle.SendToBack();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    } 
}
