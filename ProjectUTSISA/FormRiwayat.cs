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
            listTransaksi = Transaksi.BacaData("rekeningSumber or rekeningTujuan", frmTransaksi.rekening.NoRekening);
            TampilDataGrid(); //tampilkan semua isi
        }
        private void TampilDataGrid()
        {
            dataGridViewRiwayat.Rows.Clear(); //kosongi datagridview
            if (listTransaksi.Count > 0)
            {
                foreach (Transaksi t in listTransaksi)
                {
                    dataGridViewRiwayat.Rows.Add(em.Id, em.Nama_depan, em.Nama_keluarga, em.Posisi.Nama, em.Nik, em.Email,
                        em.Tgl_buat.ToShortDateString(), em.Tgl_perubahan.ToShortDateString());
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
            dataGridViewRiwayat.Columns.Add("jenisTransaksi", "jenisTransaksi");

            dataGridViewRiwayat.Columns["rekeningSumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["rekeningTujuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["waktuTransaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["pesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["jenisTransaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewButtonColumn bcolCetak = new DataGridViewButtonColumn();
            bcolCetak.HeaderText = "Cetak Transaksi";
            bcolCetak.Text = "Cetak";
            bcolCetak.Name = "btnCetak";
            bcolCetak.UseColumnTextForButtonValue = true;
            dataGridViewRiwayat.Columns.Add(bcolCetak);

            dataGridViewRiwayat.AllowUserToAddRows = false;
            dataGridViewRiwayat.ReadOnly = true;
        }
    }
}
