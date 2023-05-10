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
            listTransaksi = Transaksi.BacaData("rek_sumber", frmTransaksi.rekening.NoRekening);
            TampilDataGrid(); //tampilkan semua isi
        }
        private void TampilDataGrid()
        {
            dataGridViewRiwayat.Rows.Clear(); //kosongi datagridview
            if (listTransaksi.Count > 0)
            {
                string kodeJenis = "";
                foreach (Transaksi t in listTransaksi)
                {
                    if (t.JenisTransaksi.KodeJenis == "KRM")
                    {
                        kodeJenis = "Kirim";
                    }
                    else if (t.JenisTransaksi.KodeJenis == "TRM")
                    {
                        kodeJenis = "Terima";
                    }
                    dataGridViewRiwayat.Rows.Add(t.RekeningSumber,t.RekeningTujuan,t.WaktuTransaksi.ToString("dd-MM-yyyy HH:mm:ss"),t.Nominal,
                        t.Pesan,kodeJenis, t.NomorTransaksi);
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

            dataGridViewRiwayat.Columns.Add("rek_Sumber", "Rekening Sumber");
            dataGridViewRiwayat.Columns.Add("rek_Tujuan", "Rekening Tujuan");
            dataGridViewRiwayat.Columns.Add("waktu_transaksi", "Waktu");
            dataGridViewRiwayat.Columns.Add("nominal", "Nominal");
            dataGridViewRiwayat.Columns.Add("pesan", "Pesan");
            dataGridViewRiwayat.Columns.Add("jenis_transaksi_id", "Jenis Transaksi");
            dataGridViewRiwayat.Columns.Add("nomor_transaksi", "Nomor Transaksi");

            dataGridViewRiwayat.Columns["rek_Sumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["rek_tujuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["waktu_transaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["pesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["jenis_transaksi_id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
                Transaksi.PrintTransaksi("nomor_transaksi", dataGridViewRiwayat.Rows[e.RowIndex].Cells["nomor_transaksi"].Value.ToString(), "transaksi.txt", new Font("Courier New", 12));
                MessageBox.Show(this, "Transaksi berhasil dicetak", "Informasi");
            }
        }
    }
}
