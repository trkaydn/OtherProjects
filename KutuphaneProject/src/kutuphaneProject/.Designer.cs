namespace kutuphaneProject
{
	partial class Otomasyon
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnDeleteBook = new System.Windows.Forms.Button();
			this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
			this.btnEditBook = new System.Windows.Forms.Button();
			this.btnAddBook = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnDeletePerson = new System.Windows.Forms.Button();
			this.btnEditPerson = new System.Windows.Forms.Button();
			this.btnAddPerson = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnExit2 = new System.Windows.Forms.Button();
			this.dataGridViewPersons = new System.Windows.Forms.DataGridView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnDeleteTakip = new System.Windows.Forms.Button();
			this.btnTeslimEt = new System.Windows.Forms.Button();
			this.btnTeslimAl = new System.Windows.Forms.Button();
			this.btnExit3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.dataGridTakip = new System.Windows.Forms.DataGridView();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridTakip)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(12, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1447, 791);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.btnExit);
			this.tabPage1.Controls.Add(this.btnDeleteBook);
			this.tabPage1.Controls.Add(this.dataGridViewBooks);
			this.tabPage1.Controls.Add(this.btnEditBook);
			this.tabPage1.Controls.Add(this.btnAddBook);
			this.tabPage1.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.tabPage1.Location = new System.Drawing.Point(4, 33);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1439, 754);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Kitap Listesi";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 6.142858F);
			this.label1.Location = new System.Drawing.Point(1232, 703);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(201, 48);
			this.label1.TabIndex = 29;
			this.label1.Text = "Copyright © Tarık Aydın, 2022";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Location = new System.Drawing.Point(1261, 648);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(150, 43);
			this.btnExit.TabIndex = 28;
			this.btnExit.Text = "Çıkış";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnDeleteBook
			// 
			this.btnDeleteBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteBook.AutoSize = true;
			this.btnDeleteBook.Location = new System.Drawing.Point(1264, 169);
			this.btnDeleteBook.Name = "btnDeleteBook";
			this.btnDeleteBook.Size = new System.Drawing.Size(150, 43);
			this.btnDeleteBook.TabIndex = 27;
			this.btnDeleteBook.Text = "Sil";
			this.btnDeleteBook.UseVisualStyleBackColor = true;
			this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
			// 
			// dataGridViewBooks
			// 
			this.dataGridViewBooks.AllowUserToAddRows = false;
			this.dataGridViewBooks.AllowUserToDeleteRows = false;
			this.dataGridViewBooks.AllowUserToResizeRows = false;
			this.dataGridViewBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewBooks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewBooks.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dataGridViewBooks.Location = new System.Drawing.Point(6, 6);
			this.dataGridViewBooks.MultiSelect = false;
			this.dataGridViewBooks.Name = "dataGridViewBooks";
			this.dataGridViewBooks.ReadOnly = true;
			this.dataGridViewBooks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridViewBooks.RowHeadersVisible = false;
			this.dataGridViewBooks.RowHeadersWidth = 72;
			this.dataGridViewBooks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewBooks.Size = new System.Drawing.Size(1220, 742);
			this.dataGridViewBooks.TabIndex = 26;
			// 
			// btnEditBook
			// 
			this.btnEditBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditBook.AutoSize = true;
			this.btnEditBook.Location = new System.Drawing.Point(1264, 102);
			this.btnEditBook.Name = "btnEditBook";
			this.btnEditBook.Size = new System.Drawing.Size(150, 43);
			this.btnEditBook.TabIndex = 2;
			this.btnEditBook.Text = "Düzenle";
			this.btnEditBook.UseVisualStyleBackColor = true;
			this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
			// 
			// btnAddBook
			// 
			this.btnAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddBook.AutoSize = true;
			this.btnAddBook.Location = new System.Drawing.Point(1264, 32);
			this.btnAddBook.Name = "btnAddBook";
			this.btnAddBook.Size = new System.Drawing.Size(150, 43);
			this.btnAddBook.TabIndex = 1;
			this.btnAddBook.Text = "Kitap Ekle";
			this.btnAddBook.UseVisualStyleBackColor = true;
			this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnDeletePerson);
			this.tabPage2.Controls.Add(this.btnEditPerson);
			this.tabPage2.Controls.Add(this.btnAddPerson);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.btnExit2);
			this.tabPage2.Controls.Add(this.dataGridViewPersons);
			this.tabPage2.Location = new System.Drawing.Point(4, 33);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1439, 754);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Üye Listesi";
			// 
			// btnDeletePerson
			// 
			this.btnDeletePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeletePerson.AutoSize = true;
			this.btnDeletePerson.Location = new System.Drawing.Point(1259, 176);
			this.btnDeletePerson.Name = "btnDeletePerson";
			this.btnDeletePerson.Size = new System.Drawing.Size(150, 43);
			this.btnDeletePerson.TabIndex = 33;
			this.btnDeletePerson.Text = "Sil";
			this.btnDeletePerson.UseVisualStyleBackColor = true;
			this.btnDeletePerson.Click += new System.EventHandler(this.btnDeleteStudent_Click);
			// 
			// btnEditPerson
			// 
			this.btnEditPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditPerson.AutoSize = true;
			this.btnEditPerson.Location = new System.Drawing.Point(1259, 109);
			this.btnEditPerson.Name = "btnEditPerson";
			this.btnEditPerson.Size = new System.Drawing.Size(150, 43);
			this.btnEditPerson.TabIndex = 32;
			this.btnEditPerson.Text = "Düzenle";
			this.btnEditPerson.UseVisualStyleBackColor = true;
			this.btnEditPerson.Click += new System.EventHandler(this.btnEditPerson_Click);
			// 
			// btnAddPerson
			// 
			this.btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddPerson.AutoSize = true;
			this.btnAddPerson.Location = new System.Drawing.Point(1259, 39);
			this.btnAddPerson.Name = "btnAddPerson";
			this.btnAddPerson.Size = new System.Drawing.Size(150, 43);
			this.btnAddPerson.TabIndex = 31;
			this.btnAddPerson.Text = "Üye Ekle";
			this.btnAddPerson.UseVisualStyleBackColor = true;
			this.btnAddPerson.Click += new System.EventHandler(this.btnAddStudent_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 6.142858F);
			this.label2.Location = new System.Drawing.Point(1232, 702);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(201, 48);
			this.label2.TabIndex = 30;
			this.label2.Text = "Copyright © Tarık Aydın, 2022";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnExit2
			// 
			this.btnExit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit2.Location = new System.Drawing.Point(1259, 644);
			this.btnExit2.Name = "btnExit2";
			this.btnExit2.Size = new System.Drawing.Size(150, 43);
			this.btnExit2.TabIndex = 29;
			this.btnExit2.Text = "Çıkış";
			this.btnExit2.UseVisualStyleBackColor = true;
			this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// dataGridViewPersons
			// 
			this.dataGridViewPersons.AllowUserToAddRows = false;
			this.dataGridViewPersons.AllowUserToDeleteRows = false;
			this.dataGridViewPersons.AllowUserToResizeRows = false;
			this.dataGridViewPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewPersons.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridViewPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPersons.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dataGridViewPersons.Location = new System.Drawing.Point(6, 6);
			this.dataGridViewPersons.MultiSelect = false;
			this.dataGridViewPersons.Name = "dataGridViewPersons";
			this.dataGridViewPersons.ReadOnly = true;
			this.dataGridViewPersons.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridViewPersons.RowHeadersVisible = false;
			this.dataGridViewPersons.RowHeadersWidth = 72;
			this.dataGridViewPersons.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridViewPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewPersons.Size = new System.Drawing.Size(1220, 737);
			this.dataGridViewPersons.TabIndex = 27;
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage3.Controls.Add(this.btnDeleteTakip);
			this.tabPage3.Controls.Add(this.btnTeslimEt);
			this.tabPage3.Controls.Add(this.btnTeslimAl);
			this.tabPage3.Controls.Add(this.btnExit3);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.dataGridTakip);
			this.tabPage3.Location = new System.Drawing.Point(4, 33);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(1439, 754);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Takip İşlemleri";
			// 
			// btnDeleteTakip
			// 
			this.btnDeleteTakip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteTakip.AutoSize = true;
			this.btnDeleteTakip.Location = new System.Drawing.Point(1257, 160);
			this.btnDeleteTakip.Name = "btnDeleteTakip";
			this.btnDeleteTakip.Size = new System.Drawing.Size(153, 43);
			this.btnDeleteTakip.TabIndex = 35;
			this.btnDeleteTakip.Text = "Kaydı Sil";
			this.btnDeleteTakip.UseVisualStyleBackColor = true;
			this.btnDeleteTakip.Click += new System.EventHandler(this.btnDeleteTakip_Click);
			// 
			// btnTeslimEt
			// 
			this.btnTeslimEt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTeslimEt.AutoSize = true;
			this.btnTeslimEt.Location = new System.Drawing.Point(1257, 96);
			this.btnTeslimEt.Name = "btnTeslimEt";
			this.btnTeslimEt.Size = new System.Drawing.Size(153, 43);
			this.btnTeslimEt.TabIndex = 34;
			this.btnTeslimEt.Text = "Kitap Teslim Et";
			this.btnTeslimEt.UseVisualStyleBackColor = true;
			this.btnTeslimEt.Click += new System.EventHandler(this.btnTeslimEt_Click);
			// 
			// btnTeslimAl
			// 
			this.btnTeslimAl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTeslimAl.AutoSize = true;
			this.btnTeslimAl.Location = new System.Drawing.Point(1257, 34);
			this.btnTeslimAl.Name = "btnTeslimAl";
			this.btnTeslimAl.Size = new System.Drawing.Size(153, 43);
			this.btnTeslimAl.TabIndex = 33;
			this.btnTeslimAl.Text = "Teslim Al";
			this.btnTeslimAl.UseVisualStyleBackColor = true;
			this.btnTeslimAl.Click += new System.EventHandler(this.btnTeslimAl_Click);
			// 
			// btnExit3
			// 
			this.btnExit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit3.Location = new System.Drawing.Point(1260, 633);
			this.btnExit3.Name = "btnExit3";
			this.btnExit3.Size = new System.Drawing.Size(150, 43);
			this.btnExit3.TabIndex = 32;
			this.btnExit3.Text = "Çıkış";
			this.btnExit3.UseVisualStyleBackColor = true;
			this.btnExit3.Click += new System.EventHandler(this.btnExit3_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 6.142858F);
			this.label3.Location = new System.Drawing.Point(1235, 692);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(201, 48);
			this.label3.TabIndex = 31;
			this.label3.Text = "Copyright © Tarık Aydın, 2022";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGridTakip
			// 
			this.dataGridTakip.AllowUserToAddRows = false;
			this.dataGridTakip.AllowUserToDeleteRows = false;
			this.dataGridTakip.AllowUserToResizeRows = false;
			this.dataGridTakip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridTakip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridTakip.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridTakip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridTakip.GridColor = System.Drawing.SystemColors.ActiveBorder;
			this.dataGridTakip.Location = new System.Drawing.Point(3, 3);
			this.dataGridTakip.MultiSelect = false;
			this.dataGridTakip.Name = "dataGridTakip";
			this.dataGridTakip.ReadOnly = true;
			this.dataGridTakip.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridTakip.RowHeadersVisible = false;
			this.dataGridTakip.RowHeadersWidth = 72;
			this.dataGridTakip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridTakip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridTakip.Size = new System.Drawing.Size(1220, 737);
			this.dataGridTakip.TabIndex = 28;
			// 
			// Otomasyon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1471, 796);
			this.Controls.Add(this.tabControl1);
			this.Name = "Otomasyon";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridTakip)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnEditBook;
		private System.Windows.Forms.Button btnAddBook;
		private System.Windows.Forms.DataGridView dataGridViewBooks;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnDeleteBook;
		private System.Windows.Forms.DataGridView dataGridViewPersons;
		private System.Windows.Forms.Button btnExit2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnDeletePerson;
		private System.Windows.Forms.Button btnEditPerson;
		private System.Windows.Forms.Button btnAddPerson;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.DataGridView dataGridTakip;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnExit3;
		private System.Windows.Forms.Button btnTeslimEt;
		private System.Windows.Forms.Button btnTeslimAl;
		private System.Windows.Forms.Button btnDeleteTakip;
	}
}

