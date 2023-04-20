
namespace ProjectUTSISA
{
    partial class FormUtama
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.akunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNamaPegawai = new System.Windows.Forms.Label();
            this.labelKodePegawai = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.riwayatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.keluarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(593, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.akunToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.riwayatToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // akunToolStripMenuItem
            // 
            this.akunToolStripMenuItem.Name = "akunToolStripMenuItem";
            this.akunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.akunToolStripMenuItem.Text = "Akun";
            this.akunToolStripMenuItem.Click += new System.EventHandler(this.akunToolStripMenuItem_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            this.transaksiToolStripMenuItem.Click += new System.EventHandler(this.transaksiToolStripMenuItem_Click);
            // 
            // keluarToolStripMenuItem
            // 
            this.keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            this.keluarToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.keluarToolStripMenuItem.Text = "Keluar";
            this.keluarToolStripMenuItem.Click += new System.EventHandler(this.keluarToolStripMenuItem_Click);
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelSubtitle.Location = new System.Drawing.Point(182, 75);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(263, 19);
            this.labelSubtitle.TabIndex = 17;
            this.labelSubtitle.Text = "Your Application for Digital Banking";
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(167, 41);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(293, 33);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.Text = "Welcome to Masbro!";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Menu;
            this.label3.Location = new System.Drawing.Point(490, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "-";
            // 
            // labelNamaPegawai
            // 
            this.labelNamaPegawai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNamaPegawai.AutoSize = true;
            this.labelNamaPegawai.BackColor = System.Drawing.SystemColors.Menu;
            this.labelNamaPegawai.Location = new System.Drawing.Point(504, 6);
            this.labelNamaPegawai.Name = "labelNamaPegawai";
            this.labelNamaPegawai.Size = new System.Drawing.Size(79, 13);
            this.labelNamaPegawai.TabIndex = 14;
            this.labelNamaPegawai.Text = "Nama Pegawai";
            // 
            // labelKodePegawai
            // 
            this.labelKodePegawai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKodePegawai.AutoSize = true;
            this.labelKodePegawai.BackColor = System.Drawing.SystemColors.Menu;
            this.labelKodePegawai.Location = new System.Drawing.Point(456, 6);
            this.labelKodePegawai.Name = "labelKodePegawai";
            this.labelKodePegawai.Size = new System.Drawing.Size(32, 13);
            this.labelKodePegawai.TabIndex = 13;
            this.labelKodePegawai.Text = "Kode";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(347, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Anda login sebagai:";
            // 
            // riwayatToolStripMenuItem
            // 
            this.riwayatToolStripMenuItem.Name = "riwayatToolStripMenuItem";
            this.riwayatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.riwayatToolStripMenuItem.Text = "Riwayat";
            this.riwayatToolStripMenuItem.Click += new System.EventHandler(this.riwayatToolStripMenuItem_Click);
            // 
            // FormUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(593, 401);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelNamaPegawai);
            this.Controls.Add(this.labelKodePegawai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormUtama";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormUtama_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem akunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNamaPegawai;
        private System.Windows.Forms.Label labelKodePegawai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem riwayatToolStripMenuItem;
    }
}