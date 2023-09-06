namespace FormProject4
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kayitolustur = new System.Windows.Forms.Button();
            this.tumunusil = new System.Windows.Forms.Button();
            this.cikis = new System.Windows.Forms.Button();
            this.kayitguncelle = new System.Windows.Forms.Button();
            this.kayitsil = new System.Windows.Forms.Button();
            this.tablo = new System.Windows.Forms.DataGridView();
            this.tcno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cinsiyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sinif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sagtik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baslik = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dosyakonum = new System.Windows.Forms.TextBox();
            this.acbutton = new System.Windows.Forms.Button();
            this.textopen = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ogrsayi = new System.Windows.Forms.Label();
            this.tarih = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ogrsayisi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            this.sagtik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kayitolustur
            // 
            this.kayitolustur.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kayitolustur.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kayitolustur.Location = new System.Drawing.Point(907, 111);
            this.kayitolustur.Name = "kayitolustur";
            this.kayitolustur.Size = new System.Drawing.Size(126, 64);
            this.kayitolustur.TabIndex = 2;
            this.kayitolustur.Text = "Yeni Kayıt";
            this.kayitolustur.UseVisualStyleBackColor = true;
            this.kayitolustur.Click += new System.EventHandler(this.kayitolustur_Click);
            // 
            // tumunusil
            // 
            this.tumunusil.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tumunusil.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tumunusil.Location = new System.Drawing.Point(907, 368);
            this.tumunusil.Name = "tumunusil";
            this.tumunusil.Size = new System.Drawing.Size(126, 64);
            this.tumunusil.TabIndex = 4;
            this.tumunusil.Text = "Tümünü Sil";
            this.tumunusil.UseVisualStyleBackColor = true;
            this.tumunusil.Click += new System.EventHandler(this.tumunusil_Click);
            // 
            // cikis
            // 
            this.cikis.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cikis.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cikis.Location = new System.Drawing.Point(907, 452);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(126, 64);
            this.cikis.TabIndex = 6;
            this.cikis.Text = "Çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // kayitguncelle
            // 
            this.kayitguncelle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kayitguncelle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kayitguncelle.Location = new System.Drawing.Point(907, 199);
            this.kayitguncelle.Name = "kayitguncelle";
            this.kayitguncelle.Size = new System.Drawing.Size(126, 64);
            this.kayitguncelle.TabIndex = 7;
            this.kayitguncelle.Text = "Güncelle";
            this.kayitguncelle.UseVisualStyleBackColor = true;
            this.kayitguncelle.Click += new System.EventHandler(this.kayitguncelle_Click);
            // 
            // kayitsil
            // 
            this.kayitsil.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kayitsil.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kayitsil.Location = new System.Drawing.Point(907, 283);
            this.kayitsil.Name = "kayitsil";
            this.kayitsil.Size = new System.Drawing.Size(126, 64);
            this.kayitsil.TabIndex = 3;
            this.kayitsil.Text = "Sil";
            this.kayitsil.UseVisualStyleBackColor = true;
            this.kayitsil.Click += new System.EventHandler(this.kayitsil_Click);
            // 
            // tablo
            // 
            this.tablo.AllowDrop = true;
            this.tablo.AllowUserToAddRows = false;
            this.tablo.AllowUserToDeleteRows = false;
            this.tablo.AllowUserToResizeColumns = false;
            this.tablo.AllowUserToResizeRows = false;
            this.tablo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tcno,
            this.ad,
            this.dataGridViewTextBoxColumn1,
            this.cinsiyet,
            this.numara,
            this.sinif});
            this.tablo.ContextMenuStrip = this.sagtik;
            this.tablo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablo.EnableHeadersVisualStyles = false;
            this.tablo.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.tablo.Location = new System.Drawing.Point(16, 111);
            this.tablo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tablo.MultiSelect = false;
            this.tablo.Name = "tablo";
            this.tablo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablo.ShowEditingIcon = false;
            this.tablo.Size = new System.Drawing.Size(849, 421);
            this.tablo.TabIndex = 1;
            this.tablo.DragDrop += new System.Windows.Forms.DragEventHandler(this.tablo_DragDrop);
            this.tablo.DragEnter += new System.Windows.Forms.DragEventHandler(this.tablo_DragEnter);
            this.tablo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tablo_KeyUp);
            this.tablo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tablo_MouseDown);
            // 
            // tcno
            // 
            this.tcno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tcno.HeaderText = "TC No:";
            this.tcno.MaxInputLength = 11;
            this.tcno.Name = "tcno";
            this.tcno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ad
            // 
            this.ad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ad.HeaderText = "Adı:";
            this.ad.MaxInputLength = 20;
            this.ad.Name = "ad";
            this.ad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Soyadı:";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // cinsiyet
            // 
            this.cinsiyet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cinsiyet.HeaderText = "Cinsiyet:";
            this.cinsiyet.MaxInputLength = 5;
            this.cinsiyet.Name = "cinsiyet";
            this.cinsiyet.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // numara
            // 
            this.numara.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numara.HeaderText = "Öğrenci No:";
            this.numara.MaxInputLength = 8;
            this.numara.Name = "numara";
            this.numara.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // sinif
            // 
            this.sinif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sinif.HeaderText = "Sınıf:";
            this.sinif.MaxInputLength = 4;
            this.sinif.Name = "sinif";
            this.sinif.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // sagtik
            // 
            this.sagtik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem,
            this.kaydıSilToolStripMenuItem});
            this.sagtik.Name = "contextMenuStrip1";
            this.sagtik.Size = new System.Drawing.Size(163, 48);
            this.sagtik.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tablo_MouseDown);
            this.sagtik.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sagtik_MouseUp);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.düzenleToolStripMenuItem.Text = "Bilgileri Güncelle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.kayitguncelle_Click);
            // 
            // kaydıSilToolStripMenuItem
            // 
            this.kaydıSilToolStripMenuItem.Name = "kaydıSilToolStripMenuItem";
            this.kaydıSilToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.kaydıSilToolStripMenuItem.Text = "Kaydı Sil";
            this.kaydıSilToolStripMenuItem.Click += new System.EventHandler(this.kayitsil_Click);
            // 
            // baslik
            // 
            this.baslik.AutoSize = true;
            this.baslik.Font = new System.Drawing.Font("Snap ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baslik.ForeColor = System.Drawing.SystemColors.ControlText;
            this.baslik.Location = new System.Drawing.Point(10, 18);
            this.baslik.Name = "baslik";
            this.baslik.Size = new System.Drawing.Size(583, 25);
            this.baslik.TabIndex = 5;
            this.baslik.Text = "İSTANBUL/KARTAL Yakacık Lisesi Öğrenci Listesi";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(12, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Copyright ©  2020 Tarık A, All Rights Reserved.";
            // 
            // dosyakonum
            // 
            this.dosyakonum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dosyakonum.BackColor = System.Drawing.Color.LightGray;
            this.dosyakonum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dosyakonum.Location = new System.Drawing.Point(109, 56);
            this.dosyakonum.Name = "dosyakonum";
            this.dosyakonum.ReadOnly = true;
            this.dosyakonum.Size = new System.Drawing.Size(756, 23);
            this.dosyakonum.TabIndex = 10;
            // 
            // acbutton
            // 
            this.acbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.acbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.acbutton.Location = new System.Drawing.Point(16, 54);
            this.acbutton.Name = "acbutton";
            this.acbutton.Size = new System.Drawing.Size(87, 26);
            this.acbutton.TabIndex = 11;
            this.acbutton.Text = "Dosya Seç";
            this.acbutton.UseVisualStyleBackColor = true;
            this.acbutton.Click += new System.EventHandler(this.acbutton_Click_1);
            // 
            // textopen
            // 
            this.textopen.DefaultExt = "*.txt";
            this.textopen.Filter = "Metin Belgeleri|*.txt";
            this.textopen.ReadOnlyChecked = true;
            this.textopen.Title = "Dosya Aç";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(921, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // ogrsayi
            // 
            this.ogrsayi.AutoSize = true;
            this.ogrsayi.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ogrsayi.Location = new System.Drawing.Point(12, 82);
            this.ogrsayi.Name = "ogrsayi";
            this.ogrsayi.Size = new System.Drawing.Size(196, 28);
            this.ogrsayi.TabIndex = 13;
            this.ogrsayi.Text = "Toplam Öğrenci Sayısı:";
            // 
            // tarih
            // 
            this.tarih.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tarih.AutoSize = true;
            this.tarih.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tarih.Location = new System.Drawing.Point(685, 83);
            this.tarih.Name = "tarih";
            this.tarih.Size = new System.Drawing.Size(34, 26);
            this.tarih.TabIndex = 14;
            this.tarih.Text = "00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ogrsayisi
            // 
            this.ogrsayisi.AutoSize = true;
            this.ogrsayisi.Font = new System.Drawing.Font("Segoe Print", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ogrsayisi.Location = new System.Drawing.Point(202, 82);
            this.ogrsayisi.Name = "ogrsayisi";
            this.ogrsayisi.Size = new System.Drawing.Size(24, 28);
            this.ogrsayisi.TabIndex = 15;
            this.ogrsayisi.Text = "0";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.CancelButton = this.cikis;
            this.ClientSize = new System.Drawing.Size(1060, 562);
            this.Controls.Add(this.ogrsayisi);
            this.Controls.Add(this.tarih);
            this.Controls.Add(this.ogrsayi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.acbutton);
            this.Controls.Add(this.dosyakonum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablo);
            this.Controls.Add(this.kayitguncelle);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.baslik);
            this.Controls.Add(this.tumunusil);
            this.Controls.Add(this.kayitsil);
            this.Controls.Add(this.kayitolustur);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1049, 570);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğrenci Kayıt Programı";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            this.sagtik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label baslik;
        public System.Windows.Forms.DataGridView tablo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acbutton;
        public System.Windows.Forms.TextBox dosyakonum;
        public System.Windows.Forms.OpenFileDialog textopen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cinsiyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn numara;
        private System.Windows.Forms.DataGridViewTextBoxColumn sinif;
        private System.Windows.Forms.Button kayitsil;
        private System.Windows.Forms.Button kayitolustur;
        private System.Windows.Forms.Button tumunusil;
        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.Button kayitguncelle;
        private System.Windows.Forms.ContextMenuStrip sagtik;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydıSilToolStripMenuItem;
        private System.Windows.Forms.Label ogrsayi;
        private System.Windows.Forms.Label tarih;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ogrsayisi;
    }
}

