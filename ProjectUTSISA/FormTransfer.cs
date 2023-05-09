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
    public partial class FormTransfer : Form
    {
        public FormTransfer()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin ingin membatalkan transaksi?","Info",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            Koneksi k = new Koneksi();
            DialogResult hasil = MessageBox.Show("Transaksi yang anda ingin lakukan: " +
                                                 "\nRekening Sumber : " + labelRekSumber.Text +
                                                 "\nRekening Tujuan : " + textBoxRekTujuan.Text +
                                                 /*"\nSaldo : Rp. " + labelSaldo.Text +*/
                                                 "\nNominal Transaksi : " + textBoxNominal.Text +
                                                 "\nPesan : " + textBoxRekTujuan.Text +
                                                 "\n\nApakah anda yakin ingin melakukan transaksi tersebut?",
                                                 "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hasil == DialogResult.Yes)
            {
                string noTransaksi = Transaksi.GenerateNomorTransaksi();
                JenisTransaksi jtKirim = new JenisTransaksi("Kirim");
                JenisTransaksi jtTerima = new JenisTransaksi("Terima");
                Rekening rekeningSumber = new Rekening(labelRekSumber.Text);
                Rekening rekeningTujuan = new Rekening(textBoxRekTujuan.Text);
                Transaksi tr = new Transaksi(rekeningSumber, rekeningTujuan, DateTime.Now, double.Parse(textBoxNominal.Text), textBoxPesan.Text, jtKirim, noTransaksi);
                string noTransaksiTujuan = Transaksi.GenerateNomorTransaksi();
                Transaksi.TambahData(tr, k);
                Transaksi trTujuan = new Transaksi(rekeningTujuan, rekeningSumber, DateTime.Now, double.Parse(textBoxNominal.Text), textBoxPesan.Text, jtTerima, noTransaksiTujuan);
                Transaksi.TambahData(tr, k);
                MessageBox.Show("Transaksi berhasil dilakukan", "Informasi");
            }
        }

        private void FormTransfer_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;

            textBoxRekTujuan.Text = "Masukkan nomor rekening tujuan";
            textBoxRekTujuan.Font = new Font(textBoxRekTujuan.Font, FontStyle.Italic);
            textBoxRekTujuan.ForeColor = Color.Gray;
        }

        private void textBoxRekTujuan_Enter(object sender, EventArgs e)
        {
            if (textBoxRekTujuan.Text == "Masukkan nomor rekening tujuan")
            {
                textBoxRekTujuan.Text = "";
                textBoxRekTujuan.Font = new Font(textBoxRekTujuan.Font, FontStyle.Regular);
                textBoxRekTujuan.ForeColor = Color.Black;
            }
        }

        private void textBoxRekTujuan_Leave(object sender, EventArgs e)
        {
            if (textBoxRekTujuan.Text == "")
            {
                textBoxRekTujuan.Text = "Masukkan nomor rekening tujuan";
                textBoxRekTujuan.Font = new Font(textBoxRekTujuan.Font, FontStyle.Italic);
                textBoxRekTujuan.ForeColor = Color.Gray;
            }
        }
    }
}
