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
            //FormTambahPegawai frmTambahPegawai = new FormTambahPegawai();
            //frmTambahPegawai.Owner = this;
            //frmTambahPegawai.Show();
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

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "NIK")
                kriteria = "p.id";
            else if (comboBoxCari.Text == "Nama Lengkap")
                kriteria = "p.nama_depan";
            else if (comboBoxCari.Text == "Alamat")
                kriteria = "p.nama_keluarga";
            else if (comboBoxCari.Text == "Email")
                kriteria = "p.posisi";
            else if (comboBoxCari.Text == "Nomor Telepon")
                kriteria = "p.nik";
            else if (comboBoxCari.Text == "Jenis Pengguna")
                kriteria = "j.email";
            //listPengguna = Pengguna.BacaData(kriteria, textBoxCari.Text);
        }
    }
}
