namespace kutuphaneProject
{
	partial class FrmAddBook
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtkitapadi = new System.Windows.Forms.TextBox();
			this.txtyazar = new System.Windows.Forms.TextBox();
			this.txttur = new System.Windows.Forms.TextBox();
			this.checkUygunluk = new System.Windows.Forms.CheckBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSayfa = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.txtSayfa)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(38, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Kitap Adı:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(38, 117);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Yazar:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(38, 194);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 25);
			this.label3.TabIndex = 2;
			this.label3.Text = "Tür:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(38, 299);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 25);
			this.label4.TabIndex = 3;
			this.label4.Text = "Uygunluk:";
			// 
			// txtkitapadi
			// 
			this.txtkitapadi.Location = new System.Drawing.Point(165, 41);
			this.txtkitapadi.Name = "txtkitapadi";
			this.txtkitapadi.Size = new System.Drawing.Size(215, 29);
			this.txtkitapadi.TabIndex = 4;
			// 
			// txtyazar
			// 
			this.txtyazar.Location = new System.Drawing.Point(165, 114);
			this.txtyazar.Name = "txtyazar";
			this.txtyazar.Size = new System.Drawing.Size(215, 29);
			this.txtyazar.TabIndex = 5;
			// 
			// txttur
			// 
			this.txttur.Location = new System.Drawing.Point(165, 191);
			this.txttur.Name = "txttur";
			this.txttur.Size = new System.Drawing.Size(215, 29);
			this.txttur.TabIndex = 6;
			// 
			// checkUygunluk
			// 
			this.checkUygunluk.AutoSize = true;
			this.checkUygunluk.Location = new System.Drawing.Point(165, 299);
			this.checkUygunluk.Name = "checkUygunluk";
			this.checkUygunluk.Size = new System.Drawing.Size(272, 29);
			this.checkUygunluk.TabIndex = 7;
			this.checkUygunluk.Text = "Kitap müsait ise işaretleyin.";
			this.checkUygunluk.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Location = new System.Drawing.Point(0, 399);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(455, 52);
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "İptal";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnSave.Location = new System.Drawing.Point(0, 351);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(455, 48);
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Kaydet";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(38, 250);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 25);
			this.label5.TabIndex = 11;
			this.label5.Text = "Sayfa";
			// 
			// txtSayfa
			// 
			this.txtSayfa.Location = new System.Drawing.Point(165, 248);
			this.txtSayfa.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.txtSayfa.Name = "txtSayfa";
			this.txtSayfa.Size = new System.Drawing.Size(120, 29);
			this.txtSayfa.TabIndex = 12;
			// 
			// FrmAddBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(455, 451);
			this.Controls.Add(this.txtSayfa);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.checkUygunluk);
			this.Controls.Add(this.txttur);
			this.Controls.Add(this.txtyazar);
			this.Controls.Add(this.txtkitapadi);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAddBook";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmAddBook";
			this.Load += new System.EventHandler(this.FrmAddBook_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtSayfa)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtkitapadi;
		private System.Windows.Forms.TextBox txtyazar;
		private System.Windows.Forms.TextBox txttur;
		private System.Windows.Forms.CheckBox checkUygunluk;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown txtSayfa;
	}
}