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

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            pengguna=
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
