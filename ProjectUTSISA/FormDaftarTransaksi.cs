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
    public partial class FormDaftarTransaksi : Form
    {
        public FormDaftarTransaksi()
        {
            InitializeComponent();
        }
        List<Transaksi> listTransaksi = new List<Transaksi>();
        private void FormDaftarTransaksi_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listTransaksi = Transaksi.BacaData("", "");
            TampilDataGrid();
        }
        private void FormatDataGrid()
        {
            dataGridViewPengguna.Columns.Clear();

            dataGridViewPengguna.Columns.Add("rek_sumber", "Rekening Sumber");
            dataGridViewPengguna.Columns.Add("rek_tujuan", "Rekening Tujuan");
            dataGridViewPengguna.Columns.Add("waktu_transaksi", "Waktu Transaksi");
            dataGridViewPengguna.Columns.Add("nominal", "Nominal");
            dataGridViewPengguna.Columns.Add("pesan", "Pesan");
            dataGridViewPengguna.Columns.Add("jenis_transaksi", "Jenis Transaksi");

            dataGridViewPengguna.Columns["rek_sumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["rek_tujuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["waktu_transaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["pesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengguna.Columns["jenis_transaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewPengguna.AllowUserToAddRows = false;
            dataGridViewPengguna.ReadOnly = true;
        }
        private void TampilDataGrid()
        {
            dataGridViewPengguna.Rows.Clear(); //kosongi datagridview
            if (listTransaksi.Count > 0)
            {
                foreach (Transaksi t in listTransaksi)
                {
                    dataGridViewPengguna.Rows.Add(t.RekeningSumber,t.RekeningTujuan,t.WaktuTransaksi,t.Nominal,t.Pesan,t.JenisTransaksi);
                }
            }
            else
            {
                dataGridViewPengguna.DataSource = null;
            }
        }
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
