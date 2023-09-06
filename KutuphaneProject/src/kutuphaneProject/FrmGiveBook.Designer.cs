namespace kutuphaneProject
{
	partial class FrmGiveBook
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
			this.cmbPerson = new System.Windows.Forms.ComboBox();
			this.cmbBook = new System.Windows.Forms.ComboBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dateReturn = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmbPerson
			// 
			this.cmbPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPerson.FormattingEnabled = true;
			this.cmbPerson.Location = new System.Drawing.Point(152, 34);
			this.cmbPerson.Name = "cmbPerson";
			this.cmbPerson.Size = new System.Drawing.Size(232, 32);
			this.cmbPerson.TabIndex = 0;
			// 
			// cmbBook
			// 
			this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBook.FormattingEnabled = true;
			this.cmbBook.Location = new System.Drawing.Point(152, 101);
			this.cmbBook.Name = "cmbBook";
			this.cmbBook.Size = new System.Drawing.Size(232, 32);
			this.cmbBook.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnSave.Location = new System.Drawing.Point(0, 226);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(410, 48);
			this.btnSave.TabIndex = 14;
			this.btnSave.Text = "Teslim Et";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Location = new System.Drawing.Point(0, 274);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(410, 52);
			this.btnClose.TabIndex = 13;
			this.btnClose.Text = "İptal";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 25);
			this.label2.TabIndex = 16;
			this.label2.Text = "Kitap Adı:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 25);
			this.label1.TabIndex = 15;
			this.label1.Text = "Tesim Alan:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// dateReturn
			// 
			this.dateReturn.Location = new System.Drawing.Point(152, 162);
			this.dateReturn.Name = "dateReturn";
			this.dateReturn.Size = new System.Drawing.Size(232, 29);
			this.dateReturn.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 166);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 25);
			this.label3.TabIndex = 18;
			this.label3.Text = "İade Tarihi:";
			// 
			// FrmGiveBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 326);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dateReturn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.cmbBook);
			this.Controls.Add(this.cmbPerson);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmGiveBook";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmGiveBook";
			this.Load += new System.EventHandler(this.FrmGiveBook_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbPerson;
		private System.Windows.Forms.ComboBox cmbBook;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateReturn;
		private System.Windows.Forms.Label label3;
	}
}