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
    public partial class FormTransaksi : Form
    {
        public FormTransaksi()
        {
            InitializeComponent();
        }
        public Pengguna pengguna;
        public Rekening rekening;
        FormUtama formUtama;
        private void btnTranfer_Click(object sender, EventArgs e)
        {
            FormTransfer frm = new FormTransfer();
            frm.Owner = this;
            frm.Show();
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            FormRiwayat frm = new FormRiwayat();
            frm.Owner = this;
            frm.Show();
        }

        public void FormTransaksi_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;
            pengguna = formUtama.pengguna;
            rekening = formUtama.rekening;
            labelNamaPengguna.Text = pengguna.NamaLengkap;
            labelNoRek.Text = rekening.NoRekening;
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxTmpilkanSaldo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTmpilkanSaldo.Checked)
            {
                labelSaldo.Text = $"Rp. {rekening.Saldo.ToString("N0")}";
            }
            else
            {
                labelSaldo.Text = "Rp. ********";
            }
        }
    }
}
