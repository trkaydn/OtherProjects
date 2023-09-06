namespace kutuphaneProject
{
	partial class FrmEditPerson
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
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.txtMeslek = new System.Windows.Forms.TextBox();
			this.txtSoyad = new System.Windows.Forms.TextBox();
			this.txtAd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPuan = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.txtPuan)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnSave.Location = new System.Drawing.Point(0, 266);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(354, 48);
			this.btnSave.TabIndex = 20;
			this.btnSave.Text = "Kaydet";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Location = new System.Drawing.Point(0, 314);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(354, 52);
			this.btnClose.TabIndex = 19;
			this.btnClose.Text = "İptal";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// txtMeslek
			// 
			this.txtMeslek.Location = new System.Drawing.Point(115, 150);
			this.txtMeslek.Name = "txtMeslek";
			this.txtMeslek.Size = new System.Drawing.Size(215, 29);
			this.txtMeslek.TabIndex = 18;
			// 
			// txtSoyad
			// 
			this.txtSoyad.Location = new System.Drawing.Point(117, 83);
			this.txtSoyad.Name = "txtSoyad";
			this.txtSoyad.Size = new System.Drawing.Size(215, 29);
			this.txtSoyad.TabIndex = 17;
			// 
			// txtAd
			// 
			this.txtAd.Location = new System.Drawing.Point(117, 22);
			this.txtAd.Name = "txtAd";
			this.txtAd.Size = new System.Drawing.Size(215, 29);
			this.txtAd.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 154);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 25);
			this.label3.TabIndex = 15;
			this.label3.Text = "Meslek:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 25);
			this.label2.TabIndex = 14;
			this.label2.Text = "Soyadı:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 25);
			this.label1.TabIndex = 13;
			this.label1.Text = "Adı:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 220);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 25);
			this.label4.TabIndex = 21;
			this.label4.Text = "Ceza Puanı:";
			// 
			// txtPuan
			// 
			this.txtPuan.Location = new System.Drawing.Point(138, 216);
			this.txtPuan.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
			this.txtPuan.Name = "txtPuan";
			this.txtPuan.Size = new System.Drawing.Size(192, 29);
			this.txtPuan.TabIndex = 22;
			// 
			// FrmEditPerson
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 366);
			this.Controls.Add(this.txtPuan);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtMeslek);
			this.Controls.Add(this.txtSoyad);
			this.Controls.Add(this.txtAd);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmEditPerson";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmEditPerson";
			this.Load += new System.EventHandler(this.FrmEditPerson_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtPuan)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txtMeslek;
		private System.Windows.Forms.TextBox txtSoyad;
		private System.Windows.Forms.TextBox txtAd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown txtPuan;
	}
}