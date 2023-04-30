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
            DialogResult hasil = MessageBox.Show("Transaksi yang anda ingin lakukan: " +
                                                 "\nRekening Sumber : " + labelRekSumber.Text +
                                                 "\nRekening Tujuan : " + textBoxRekTujuan.Text +
                                                 "\nSaldo : Rp. " + labelSaldo.Text +
                                                 "\nNominal Transaksi : " + textBoxNominal.Text +
                                                 "\nPesan : " + textBoxRekTujuan.Text +
                                                 "\n\nApakah anda yakin ingin melakukan transaksi tersebut?",
                                                 "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hasil == DialogResult.Yes)
            {

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
