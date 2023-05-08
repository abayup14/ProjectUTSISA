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
    public partial class FormAkun : Form
    {
        public FormAkun()
        {
            InitializeComponent();
        }
        Pengguna pengguna;
        FormUtama frmUtama;
        Rekening rekening;
        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAkun_Load(object sender, EventArgs e)
        {
            //tampilin data pengguna
            pengguna = frmUtama.pengguna;
            rekening = frmUtama.rekening;
            labelNIK.Text = pengguna.Nik;
            labelNamaPengguna.Text = pengguna.NamaLengkap;
            labelNoRek.Text = rekening.NoRekening;
            labelSaldo.Text = rekening.Saldo.ToString();
            labelEmail.Text = pengguna.Email;
            labelNoTelp.Text = pengguna.NoTelepon;
            labelAlamat.Text = pengguna.Alamat;
            pictureBoxFoto.Image = new Bitmap(pengguna.FotoDiri);//berpotensi error
        }
    }
}
