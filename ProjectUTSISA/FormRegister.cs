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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            //simpen data pengguna
            this.Close();//kembali ke form login
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNIK_Enter(object sender, EventArgs e)
        {
            if (textBoxNIK.Text == "(16 digit angka Nomor Induk Kewarganegaraan)")
            {
                textBoxNIK.Text = "";
                textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Regular);
                textBoxNIK.ForeColor = Color.Black;
            }
        }

        private void textBoxNIK_Leave(object sender, EventArgs e)
        {
            if (textBoxNIK.Text == "")
            {
                textBoxNIK.Text = "(16 digit angka Nomor Induk Kewarganegaraan)";
                textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Italic);
                textBoxNIK.ForeColor = Color.Gray;
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;

            textBoxNIK.Text = "(16 digit angka Nomor Induk Kewarganegaraan)";
            textBoxNIK.Font = new Font(textBoxNIK.Font, FontStyle.Italic);
            textBoxNIK.ForeColor = Color.Gray;
        }
    }
}
