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
        private void buttonTambah_Click(object sender, EventArgs e)
        {
            //FormTambahPegawai frmTambahPegawai = new FormTambahPegawai();
            //frmTambahPegawai.Owner = this;
            //frmTambahPegawai.Show();
        }

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

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            //if (dataGridViewPengguna.CurrentRow != null)
            //{
            //    FormUbahTransaksi frmUbah = new FormUbahTransaksi();
            //    frmUbah.Owner = this;

            //    string idUbah = dataGridViewPengguna.CurrentRow.Cells["transaksi_id"].Value.ToString();
            //    frmUbah.transaksiUbah = Transaksi.AmbilDataByKode(idUbah);
            //    frmUbah.Show();
            //}
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            //if (dataGridViewPengguna.CurrentRow != null)
            //{
            //    string noRekSumber_Hapus = dataGridViewPengguna.CurrentRow.Cells["rekening_sumber"].Value.ToString();
            //    string noRekTujuan_Hapus = dataGridViewPengguna.CurrentRow.Cells["rekening_tujuan"].Value.ToString();
            //    Tabungan tabunganHapus = Tabungan.AmbilDataByKode(noRekSumber_Hapus);
            //    string idHapus = dataGridViewPengguna.CurrentRow.Cells["transaksi_id"].Value.ToString();
            //    DialogResult hasil = MessageBox.Show(this, $"Apakah anda yakin akan menghapus transaksi {noRekSumber_Hapus}-{noRekTujuan_Hapus}?", "HAPUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    //jika yes
            //    if (hasil == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            Transaksi t = Transaksi.AmbilDataByKode(idHapus);
            //            Boolean hapus = Transaksi.HapusData(t);
            //            if (hapus == true)
            //            {
            //                MessageBox.Show("Penghapusan data berhasil", "Information");

            //                //refresh form
            //                FormDaftarTransaksi_Load(buttonKeluar, e);
            //            }
            //            else
            //                MessageBox.Show("Penghapusan data gagal", "Information");
            //        }
            //        catch (Exception a)
            //        {
            //            MessageBox.Show($"Terdapat Error\n Pesan Eror: {a.Message}", "Information");
            //        }
            //    }
            //}
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "Rekening Sumber")
                kriteria = "rek_sumber";
            else if (comboBoxCari.Text == "Rekening Tujuan")
                kriteria = "rek_tujuan";
            else if (comboBoxCari.Text == "Waktu Transaksi")
                kriteria = "waktu_transaksi";
            else if (comboBoxCari.Text == "Nominal")
                kriteria = "nominal";
            else if (comboBoxCari.Text == "Pesan")
                kriteria = "pesan";
            else if (comboBoxCari.Text == "Jenis Transaksi")
                kriteria = "jenis_transaksi"; // berpotensi eror
            //listPengguna = Pengguna.BacaData(kriteria, textBoxCari.Text);
        }
    }
}
