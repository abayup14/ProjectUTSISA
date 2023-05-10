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
    public partial class FormDaftarPengguna : Form
    {
        public FormDaftarPengguna()
        {
            InitializeComponent();
        }
        List<Pengguna> listPengguna = new List<Pengguna>();
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormPengguna_Load(object sender, EventArgs e)
        {
            FormatDataGrid(); 
            listPengguna = Pengguna.BacaData("", "");
            TampilDataGrid(); 
        }
        private void FormatDataGrid()
        {
            dataGridViewPengguna.Columns.Clear();

            dataGridViewPengguna.Columns.Add("nik", "NIK");
            dataGridViewPengguna.Columns.Add("nama_lengkap", "Nama Lengkap");
            dataGridViewPengguna.Columns.Add("alamat", "Alamat");
            dataGridViewPengguna.Columns.Add("email", "Email");
            dataGridViewPengguna.Columns.Add("no_telp", "Nomor Telepon");
            dataGridViewPengguna.Columns.Add("jenis_pengguna", "Jenis Pengguna");

            dataGridViewPengguna.Columns["nik"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["nama_lengkap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["no_telp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["jenis_pengguna"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 

            dataGridViewPengguna.AllowUserToAddRows = false;
            dataGridViewPengguna.ReadOnly = true;
        }
        private void TampilDataGrid()
        {
            dataGridViewPengguna.Rows.Clear(); //kosongi datagridview
            if (listPengguna.Count > 0)
            {
                foreach (Pengguna p in listPengguna)
                {
                    dataGridViewPengguna.Rows.Add(p.Nik,p.NamaLengkap,p.Alamat,p.Email,p.NoTelepon,p.JenisPengguna);
                }
            }
            else
            {
                dataGridViewPengguna.DataSource = null;
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPengguna frmTambah = new FormTambahPengguna();
            frmTambah.Owner = this;
            frmTambah.Show();
        }
    }
}
