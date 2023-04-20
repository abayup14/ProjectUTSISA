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

        }
    }
}
