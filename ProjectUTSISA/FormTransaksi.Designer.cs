
namespace ProjectUTSISA
{
    partial class FormTransaksi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelnm = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxTmpilkanSaldo = new System.Windows.Forms.CheckBox();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.labelsld = new System.Windows.Forms.Label();
            this.labelNoRek = new System.Windows.Forms.Label();
            this.labelNamaPengguna = new System.Windows.Forms.Label();
            this.labelnrk = new System.Windows.Forms.Label();
            this.btnKembali = new System.Windows.Forms.Button();
            this.btnRiwayat = new System.Windows.Forms.Button();
            this.btnTranfer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelnm
            // 
            this.labelnm.AutoSize = true;
            this.labelnm.Location = new System.Drawing.Point(15, 10);
            this.labelnm.Name = "labelnm";
            this.labelnm.Size = new System.Drawing.Size(115, 16);
            this.labelnm.TabIndex = 0;
            this.labelnm.Text = "Nama Pengguna: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxTmpilkanSaldo);
            this.panel1.Controls.Add(this.labelSaldo);
            this.panel1.Controls.Add(this.labelsld);
            this.panel1.Controls.Add(this.labelNoRek);
            this.panel1.Controls.Add(this.labelNamaPengguna);
            this.panel1.Controls.Add(this.labelnrk);
            this.panel1.Controls.Add(this.labelnm);
            this.panel1.Location = new System.Drawing.Point(11, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 98);
            this.panel1.TabIndex = 5;
            // 
            // checkBoxTmpilkanSaldo
            // 
            this.checkBoxTmpilkanSaldo.AutoSize = true;
            this.checkBoxTmpilkanSaldo.Location = new System.Drawing.Point(305, 70);
            this.checkBoxTmpilkanSaldo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxTmpilkanSaldo.Name = "checkBoxTmpilkanSaldo";
            this.checkBoxTmpilkanSaldo.Size = new System.Drawing.Size(132, 20);
            this.checkBoxTmpilkanSaldo.TabIndex = 6;
            this.checkBoxTmpilkanSaldo.Text = "Tampilkan Saldo";
            this.checkBoxTmpilkanSaldo.UseVisualStyleBackColor = true;
            this.checkBoxTmpilkanSaldo.CheckedChanged += new System.EventHandler(this.checkBoxTmpilkanSaldo_CheckedChanged);
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Location = new System.Drawing.Point(147, 71);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(71, 16);
            this.labelSaldo.TabIndex = 5;
            this.labelSaldo.Text = "Rp. ********";
            // 
            // labelsld
            // 
            this.labelsld.AutoSize = true;
            this.labelsld.Location = new System.Drawing.Point(21, 71);
            this.labelsld.Name = "labelsld";
            this.labelsld.Size = new System.Drawing.Size(110, 16);
            this.labelsld.TabIndex = 4;
            this.labelsld.Text = "Saldo Rekening: ";
            // 
            // labelNoRek
            // 
            this.labelNoRek.AutoSize = true;
            this.labelNoRek.Location = new System.Drawing.Point(147, 39);
            this.labelNoRek.Name = "labelNoRek";
            this.labelNoRek.Size = new System.Drawing.Size(48, 16);
            this.labelNoRek.TabIndex = 3;
            this.labelNoRek.Text = "Nomor";
            // 
            // labelNamaPengguna
            // 
            this.labelNamaPengguna.AutoSize = true;
            this.labelNamaPengguna.Location = new System.Drawing.Point(147, 10);
            this.labelNamaPengguna.Name = "labelNamaPengguna";
            this.labelNamaPengguna.Size = new System.Drawing.Size(44, 16);
            this.labelNamaPengguna.TabIndex = 2;
            this.labelNamaPengguna.Text = "Nama";
            // 
            // labelnrk
            // 
            this.labelnrk.AutoSize = true;
            this.labelnrk.Location = new System.Drawing.Point(15, 39);
            this.labelnrk.Name = "labelnrk";
            this.labelnrk.Size = new System.Drawing.Size(112, 16);
            this.labelnrk.TabIndex = 1;
            this.labelnrk.Text = "Nomor Rekening:";
            // 
            // btnKembali
            // 
            this.btnKembali.BackColor = System.Drawing.Color.Red;
            this.btnKembali.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKembali.Location = new System.Drawing.Point(350, 124);
            this.btnKembali.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(101, 36);
            this.btnKembali.TabIndex = 8;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = false;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // btnRiwayat
            // 
            this.btnRiwayat.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRiwayat.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRiwayat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRiwayat.Location = new System.Drawing.Point(161, 124);
            this.btnRiwayat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRiwayat.Name = "btnRiwayat";
            this.btnRiwayat.Size = new System.Drawing.Size(101, 36);
            this.btnRiwayat.TabIndex = 7;
            this.btnRiwayat.Text = "Riwayat";
            this.btnRiwayat.UseVisualStyleBackColor = false;
            this.btnRiwayat.Click += new System.EventHandler(this.btnRiwayat_Click);
            // 
            // btnTranfer
            // 
            this.btnTranfer.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTranfer.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranfer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTranfer.Location = new System.Drawing.Point(29, 124);
            this.btnTranfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTranfer.Name = "btnTranfer";
            this.btnTranfer.Size = new System.Drawing.Size(101, 36);
            this.btnTranfer.TabIndex = 6;
            this.btnTranfer.Text = "Transfer";
            this.btnTranfer.UseVisualStyleBackColor = false;
            this.btnTranfer.Click += new System.EventHandler(this.btnTranfer_Click);
            // 
            // FormTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 180);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.btnRiwayat);
            this.Controls.Add(this.btnTranfer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTransaksi";
            this.Text = "Transaksi";
            this.Load += new System.EventHandler(this.FormTransaksi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelnm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNoRek;
        private System.Windows.Forms.Label labelNamaPengguna;
        private System.Windows.Forms.Label labelnrk;
        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Button btnRiwayat;
        private System.Windows.Forms.Button btnTranfer;
        private System.Windows.Forms.CheckBox checkBoxTmpilkanSaldo;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label labelsld;
    }
}