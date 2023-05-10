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
        FormTransaksi formTransaksi;
        public Pengguna pengguna;
        public Rekening rekening;
        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin ingin membatalkan transaksi?","Info",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                formTransaksi.FormTransaksi_Load(btnBatal, e);
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
                                                 "\nPesan : " + textBoxPesan.Text +
                                                 "\n\nApakah anda yakin ingin melakukan transaksi tersebut?",
                                                 "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hasil == DialogResult.Yes)
            {
                string noTransaksi = Transaksi.GenerateNomorTransaksi();
                JenisTransaksi jtKirim = new JenisTransaksi("KRM");
                JenisTransaksi jtTerima = new JenisTransaksi("TRM");
                Rekening rekeningTujuan = Rekening.AmbilData(textBoxRekTujuan.Text);
                string pin = textBoxPIN.Text;
                if (Transaksi.CekPIN(pin, rekening) == true)
                {

                    double nominal = double.Parse(textBoxNominal.Text);
                    Transaksi tr = new Transaksi(rekening, rekeningTujuan, DateTime.Now, nominal, textBoxPesan.Text, jtKirim, noTransaksi);
                    Transaksi.TambahData(tr, k);
                    rekening.Saldo += nominal;
                    Rekening.UpdateSaldo(rekening, k);
                    string noTransaksiTujuan = Transaksi.GenerateNomorTransaksi();
                    Transaksi trTujuan = new Transaksi(rekeningTujuan, rekening, DateTime.Now, nominal, textBoxPesan.Text, jtTerima, noTransaksiTujuan);
                    rekeningTujuan.Saldo -= nominal;
                    Rekening.UpdateSaldo(rekeningTujuan, k);
                    Transaksi.TambahData(trTujuan, k);
                    
                    MessageBox.Show("Transaksi berhasil dilakukan", "Informasi");

                    formTransaksi.FormTransaksi_Load(btnKirim, e);
                }
                else
                {
                    MessageBox.Show("PIN yang anda masukkan salah. Silahkan coba lagi.", "Informasi");
                }
            }
        }

        private void FormTransfer_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;

            formTransaksi = (FormTransaksi)this.Owner;
            pengguna = formTransaksi.pengguna;
            rekening = formTransaksi.rekening;
            labelRekSumber.Text = rekening.NoRekening;

            textBoxRekTujuan.Text = "Masukkan nomor rekening tujuan";
            textBoxRekTujuan.Font = new Font(textBoxRekTujuan.Font, FontStyle.Italic);
            textBoxRekTujuan.ForeColor = Color.Gray;

            textBoxPIN.Text = "PIN anda";
            textBoxPIN.Font = new Font(textBoxPIN.Font, FontStyle.Italic);
            textBoxPIN.ForeColor = Color.Gray;
            textBoxPIN.UseSystemPasswordChar = false;
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
    }
}
