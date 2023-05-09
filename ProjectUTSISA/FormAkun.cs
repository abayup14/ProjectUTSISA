using Crypthography;
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
            frmUtama = (FormUtama)this.MdiParent;
            //tampilin data pengguna
            pengguna = frmUtama.pengguna;
            rekening = frmUtama.rekening;

            Bitmap foto = new Bitmap(pengguna.FotoDiri);
            pictureBoxFoto.Image = foto;
            pictureBoxFoto.MaximumSize = new Size(150, 200); // ukuran maksimum 400x400 piksel
            pictureBoxFoto.Height = Math.Min(pictureBoxFoto.Image.Height, pictureBoxFoto.MaximumSize.Height);
            pictureBoxFoto.Width = Math.Min(pictureBoxFoto.Image.Width, pictureBoxFoto.MaximumSize.Width);
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.Zoom;

            string dataPengguna = Steganography.Munculkan(foto);
            List<string> listDataPengguna = dataPengguna.Split(' ').ToList();

            string nik = listDataPengguna[0];
            (string key, string iv) = Pengguna.AmbilKunci(nik);
            labelNIK.Text = AES.Decrypt(nik, key, iv);
            labelNamaPengguna.Text = AES.Decrypt(listDataPengguna[1], key, iv);
            labelNoRek.Text = rekening.NoRekening;
            labelSaldo.Text = "Rp. " + rekening.Saldo.ToString("N0");
            labelEmail.Text = AES.Decrypt(listDataPengguna[3], key, iv);
            labelNoTelp.Text = AES.Decrypt(listDataPengguna[4], key, iv);
            labelAlamat.Text = AES.Decrypt(listDataPengguna[2], key, iv);
            //labelNIK.Text = pengguna.Nik;
            //labelNamaPengguna.Text = pengguna.NamaLengkap;
            //labelNoRek.Text = rekening.NoRekening;
            //labelSaldo.Text = rekening.Saldo.ToString();
            //labelEmail.Text = pengguna.Email;
            //labelNoTelp.Text = pengguna.NoTelepon;
            //labelAlamat.Text = pengguna.Alamat;
            //pictureBoxFoto.Image = new Bitmap(pengguna.FotoDiri);//berpotensi error
        }
    }
}
