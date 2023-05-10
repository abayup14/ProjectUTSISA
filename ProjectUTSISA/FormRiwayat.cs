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
    public partial class FormRiwayat : Form
    {
        public FormRiwayat()
        {
            InitializeComponent();
        }
        List<Transaksi> listTransaksi = new List<Transaksi>();
        FormTransaksi frmTransaksi;
        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void FormRiwayat_Load(object sender, EventArgs e)
        {
            frmTransaksi = (FormTransaksi)this.Owner;
            FormatDataGrid(); //method untuk menambah kolompada datagridview
            listTransaksi = Transaksi.BacaData("rek_sumber or rek_tujuan", frmTransaksi.rekening.NoRekening);
            TampilDataGrid(); //tampilkan semua isi
        }
        private void TampilDataGrid()
        {
            dataGridViewRiwayat.Rows.Clear(); //kosongi datagridview
            if (listTransaksi.Count > 0)
            {
                foreach (Transaksi t in listTransaksi)
                {
                    dataGridViewRiwayat.Rows.Add(t.RekeningSumber,t.RekeningTujuan,t.WaktuTransaksi.ToString("dd-MM-yyyy HH:mm:ss"),t.Nominal,
                        t.Pesan,t.JenisTransaksi.KodeJenis, t.NomorTransaksi);
                }
            }
            else
            {
                dataGridViewRiwayat.DataSource = null;
            }
        }
        private void FormatDataGrid()
        {
            dataGridViewRiwayat.Columns.Clear();

            dataGridViewRiwayat.Columns.Add("rekeningSumber", "Rekening Sumber");
            dataGridViewRiwayat.Columns.Add("rekeningTujuan", "Rekening Tujuan");
            dataGridViewRiwayat.Columns.Add("waktuTransaksi", "Waktu");
            dataGridViewRiwayat.Columns.Add("nominal", "Nominal");
            dataGridViewRiwayat.Columns.Add("pesan", "Pesan");
            dataGridViewRiwayat.Columns.Add("jenisTransaksi", "Jenis Transaksi");
            dataGridViewRiwayat.Columns.Add("nomor_transaksi", "Nomor Transaksi");

            dataGridViewRiwayat.Columns["rekeningSumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["rekeningTujuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["waktuTransaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["pesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["jenisTransaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["nomor_transaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewButtonColumn bcolCetak = new DataGridViewButtonColumn();
            bcolCetak.HeaderText = "Cetak Transaksi";
            bcolCetak.Text = "Cetak";
            bcolCetak.Name = "btnCetak";
            bcolCetak.UseColumnTextForButtonValue = true;
            dataGridViewRiwayat.Columns.Add(bcolCetak);

            dataGridViewRiwayat.AllowUserToAddRows = false;
            dataGridViewRiwayat.ReadOnly = true;
        }

        private void dataGridViewRiwayat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRiwayat.Columns["btnCetak"].Index && e.RowIndex >= 0)
            {
                Transaksi.PrintTransaksi("transaksi_id", dataGridViewRiwayat.Rows[e.RowIndex].Cells["nomor_transaksi"].Value.ToString(), "transaksi.txt", new Font("Courier New", 12));
                MessageBox.Show("Transaksi telah tercetak.");
            }
        }
    }
}
