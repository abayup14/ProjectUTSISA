
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
            this.labelNoRek = new System.Windows.Forms.Label();
            this.labelNamaPengguna = new System.Windows.Forms.Label();
            this.labelnrk = new System.Windows.Forms.Label();
            this.btnKembali = new System.Windows.Forms.Button();
            this.btnRiwayat = new System.Windows.Forms.Button();
            this.btnTranfer = new System.Windows.Forms.Button();
            this.btnAkun = new System.Windows.Forms.Button();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.labelsld = new System.Windows.Forms.Label();
            this.checkBoxTmpilkanSaldo = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelnm
            // 
            this.labelnm.AutoSize = true;
            this.labelnm.Location = new System.Drawing.Point(17, 13);
            this.labelnm.Name = "labelnm";
            this.labelnm.Size = new System.Drawing.Size(142, 20);
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 123);
            this.panel1.TabIndex = 5;
            // 
            // labelNoRek
            // 
            this.labelNoRek.AutoSize = true;
            this.labelNoRek.Location = new System.Drawing.Point(165, 49);
            this.labelNoRek.Name = "labelNoRek";
            this.labelNoRek.Size = new System.Drawing.Size(59, 20);
            this.labelNoRek.TabIndex = 3;
            this.labelNoRek.Text = "Nomor";
            // 
            // labelNamaPengguna
            // 
            this.labelNamaPengguna.AutoSize = true;
            this.labelNamaPengguna.Location = new System.Drawing.Point(165, 13);
            this.labelNamaPengguna.Name = "labelNamaPengguna";
            this.labelNamaPengguna.Size = new System.Drawing.Size(53, 20);
            this.labelNamaPengguna.TabIndex = 2;
            this.labelNamaPengguna.Text = "Nama";
            // 
            // labelnrk
            // 
            this.labelnrk.AutoSize = true;
            this.labelnrk.Location = new System.Drawing.Point(17, 49);
            this.labelnrk.Name = "labelnrk";
            this.labelnrk.Size = new System.Drawing.Size(138, 20);
            this.labelnrk.TabIndex = 1;
            this.labelnrk.Text = "Nomor Rekening:";
            // 
            // btnKembali
            // 
            this.btnKembali.BackColor = System.Drawing.Color.Red;
            this.btnKembali.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKembali.Location = new System.Drawing.Point(380, 380);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(114, 44);
            this.btnKembali.TabIndex = 8;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = false;
            // 
            // btnRiwayat
            // 
            this.btnRiwayat.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRiwayat.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRiwayat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRiwayat.Location = new System.Drawing.Point(208, 156);
            this.btnRiwayat.Name = "btnRiwayat";
            this.btnRiwayat.Size = new System.Drawing.Size(114, 44);
            this.btnRiwayat.TabIndex = 7;
            this.btnRiwayat.Text = "Riwayat";
            this.btnRiwayat.UseVisualStyleBackColor = false;
            // 
            // btnTranfer
            // 
            this.btnTranfer.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTranfer.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranfer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTranfer.Location = new System.Drawing.Point(33, 156);
            this.btnTranfer.Name = "btnTranfer";
            this.btnTranfer.Size = new System.Drawing.Size(114, 44);
            this.btnTranfer.TabIndex = 6;
            this.btnTranfer.Text = "Transfer";
            this.btnTranfer.UseVisualStyleBackColor = false;
            // 
            // btnAkun
            // 
            this.btnAkun.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAkun.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAkun.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAkun.Location = new System.Drawing.Point(380, 156);
            this.btnAkun.Name = "btnAkun";
            this.btnAkun.Size = new System.Drawing.Size(114, 44);
            this.btnAkun.TabIndex = 9;
            this.btnAkun.Text = "Akun";
            this.btnAkun.UseVisualStyleBackColor = false;
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Location = new System.Drawing.Point(165, 89);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(69, 20);
            this.labelSaldo.TabIndex = 5;
            this.labelSaldo.Text = "**********";
            // 
            // labelsld
            // 
            this.labelsld.AutoSize = true;
            this.labelsld.Location = new System.Drawing.Point(24, 89);
            this.labelsld.Name = "labelsld";
            this.labelsld.Size = new System.Drawing.Size(135, 20);
            this.labelsld.TabIndex = 4;
            this.labelsld.Text = "Saldo Rekening: ";
            // 
            // checkBoxTmpilkanSaldo
            // 
            this.checkBoxTmpilkanSaldo.AutoSize = true;
            this.checkBoxTmpilkanSaldo.Location = new System.Drawing.Point(343, 88);
            this.checkBoxTmpilkanSaldo.Name = "checkBoxTmpilkanSaldo";
            this.checkBoxTmpilkanSaldo.Size = new System.Drawing.Size(154, 24);
            this.checkBoxTmpilkanSaldo.TabIndex = 6;
            this.checkBoxTmpilkanSaldo.Text = "Tampilkan Saldo";
            this.checkBoxTmpilkanSaldo.UseVisualStyleBackColor = true;
            // 
            // FormTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 450);
            this.Controls.Add(this.btnAkun);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.btnRiwayat);
            this.Controls.Add(this.btnTranfer);
            this.Name = "FormTransaksi";
            this.Text = "Transaksi";
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
        private System.Windows.Forms.Button btnAkun;
        private System.Windows.Forms.CheckBox checkBoxTmpilkanSaldo;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label labelsld;
    }
}