namespace kutuphaneProject
{
	partial class FrmEditBook
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
			this.txtSayfa = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSaveEdit = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.checkUygunluk = new System.Windows.Forms.CheckBox();
			this.txttur = new System.Windows.Forms.TextBox();
			this.txtyazar = new System.Windows.Forms.TextBox();
			this.txtkitapadi = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txtSayfa)).BeginInit();
			this.SuspendLayout();
			// 
			// txtSayfa
			// 
			this.txtSayfa.Location = new System.Drawing.Point(165, 228);
			this.txtSayfa.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
			this.txtSayfa.Name = "txtSayfa";
			this.txtSayfa.Size = new System.Drawing.Size(120, 29);
			this.txtSayfa.TabIndex = 24;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(38, 230);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 25);
			this.label5.TabIndex = 23;
			this.label5.Text = "Sayfa";
			// 
			// btnSaveEdit
			// 
			this.btnSaveEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnSaveEdit.Location = new System.Drawing.Point(0, 327);
			this.btnSaveEdit.Name = "btnSaveEdit";
			this.btnSaveEdit.Size = new System.Drawing.Size(451, 48);
			this.btnSaveEdit.TabIndex = 22;
			this.btnSaveEdit.Text = "Kaydet";
			this.btnSaveEdit.UseVisualStyleBackColor = true;
			this.btnSaveEdit.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Location = new System.Drawing.Point(0, 375);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(451, 52);
			this.btnClose.TabIndex = 21;
			this.btnClose.Text = "İptal";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// checkUygunluk
			// 
			this.checkUygunluk.AutoSize = true;
			this.checkUygunluk.Location = new System.Drawing.Point(165, 279);
			this.checkUygunluk.Name = "checkUygunluk";
			this.checkUygunluk.Size = new System.Drawing.Size(272, 29);
			this.checkUygunluk.TabIndex = 20;
			this.checkUygunluk.Text = "Kitap müsait ise işaretleyin.";
			this.checkUygunluk.UseVisualStyleBackColor = true;
			// 
			// txttur
			// 
			this.txttur.Location = new System.Drawing.Point(165, 171);
			this.txttur.Name = "txttur";
			this.txttur.Size = new System.Drawing.Size(215, 29);
			this.txttur.TabIndex = 19;
			// 
			// txtyazar
			// 
			this.txtyazar.Location = new System.Drawing.Point(165, 94);
			this.txtyazar.Name = "txtyazar";
			this.txtyazar.Size = new System.Drawing.Size(215, 29);
			this.txtyazar.TabIndex = 18;
			// 
			// txtkitapadi
			// 
			this.txtkitapadi.Location = new System.Drawing.Point(165, 21);
			this.txtkitapadi.Name = "txtkitapadi";
			this.txtkitapadi.Size = new System.Drawing.Size(215, 29);
			this.txtkitapadi.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(38, 279);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 25);
			this.label4.TabIndex = 16;
			this.label4.Text = "Uygunluk:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(38, 174);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 25);
			this.label3.TabIndex = 15;
			this.label3.Text = "Tür:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(38, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 25);
			this.label2.TabIndex = 14;
			this.label2.Text = "Yazar:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(38, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 25);
			this.label1.TabIndex = 13;
			this.label1.Text = "Kitap Adı:";
			// 
			// FrmEditBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(451, 427);
			this.Controls.Add(this.txtSayfa);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSaveEdit);
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
			this.Name = "FrmEditBook";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmEditBook";
			this.Load += new System.EventHandler(this.FrmEditBook_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtSayfa)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown txtSayfa;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnSaveEdit;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox checkUygunluk;
		private System.Windows.Forms.TextBox txttur;
		private System.Windows.Forms.TextBox txtyazar;
		private System.Windows.Forms.TextBox txtkitapadi;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}