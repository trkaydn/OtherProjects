namespace StickyNote
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnEkle = new System.Windows.Forms.Button();
            this.liste = new System.Windows.Forms.ListBox();
            this.btnGoster = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTumunuSil = new System.Windows.Forms.Button();
            this.btnsirala = new System.Windows.Forms.Button();
            this.btnTumunuKapat = new System.Windows.Forms.Button();
            this.tumunuGoster = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saaticon = new System.Windows.Forms.NotifyIcon(this.components);
            this.saatmenusu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gosterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.saatmenusu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(158, 69);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(64, 34);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // liste
            // 
            this.liste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.liste.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liste.ForeColor = System.Drawing.Color.White;
            this.liste.FormattingEnabled = true;
            this.liste.Location = new System.Drawing.Point(3, 16);
            this.liste.Name = "liste";
            this.liste.Size = new System.Drawing.Size(129, 282);
            this.liste.TabIndex = 1;
            this.liste.SelectedIndexChanged += new System.EventHandler(this.liste_SelectedIndexChanged);
            this.liste.DoubleClick += new System.EventHandler(this.liste_DoubleClick);
            // 
            // btnGoster
            // 
            this.btnGoster.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGoster.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGoster.ForeColor = System.Drawing.Color.White;
            this.btnGoster.Location = new System.Drawing.Point(158, 109);
            this.btnGoster.Name = "btnGoster";
            this.btnGoster.Size = new System.Drawing.Size(64, 34);
            this.btnGoster.TabIndex = 2;
            this.btnGoster.Text = "Göster";
            this.btnGoster.UseVisualStyleBackColor = false;
            this.btnGoster.Click += new System.EventHandler(this.btnGoster_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(158, 149);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(64, 34);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTumunuSil
            // 
            this.btnTumunuSil.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTumunuSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTumunuSil.ForeColor = System.Drawing.Color.White;
            this.btnTumunuSil.Location = new System.Drawing.Point(158, 269);
            this.btnTumunuSil.Name = "btnTumunuSil";
            this.btnTumunuSil.Size = new System.Drawing.Size(64, 34);
            this.btnTumunuSil.TabIndex = 4;
            this.btnTumunuSil.Text = "Tümünü Sil";
            this.btnTumunuSil.UseVisualStyleBackColor = false;
            this.btnTumunuSil.Click += new System.EventHandler(this.btnTumunuSil_Click);
            // 
            // btnsirala
            // 
            this.btnsirala.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsirala.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsirala.ForeColor = System.Drawing.Color.White;
            this.btnsirala.Location = new System.Drawing.Point(178, 36);
            this.btnsirala.Name = "btnsirala";
            this.btnsirala.Size = new System.Drawing.Size(44, 27);
            this.btnsirala.TabIndex = 5;
            this.btnsirala.Text = "Sırala";
            this.btnsirala.UseVisualStyleBackColor = false;
            this.btnsirala.Visible = false;
            this.btnsirala.Click += new System.EventHandler(this.btnsirala_Click);
            // 
            // btnTumunuKapat
            // 
            this.btnTumunuKapat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTumunuKapat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTumunuKapat.ForeColor = System.Drawing.Color.White;
            this.btnTumunuKapat.Location = new System.Drawing.Point(158, 229);
            this.btnTumunuKapat.Name = "btnTumunuKapat";
            this.btnTumunuKapat.Size = new System.Drawing.Size(64, 34);
            this.btnTumunuKapat.TabIndex = 6;
            this.btnTumunuKapat.Text = "Tümünü Kapat";
            this.btnTumunuKapat.UseVisualStyleBackColor = false;
            this.btnTumunuKapat.Click += new System.EventHandler(this.btnTumunuKapat_Click);
            // 
            // tumunuGoster
            // 
            this.tumunuGoster.BackColor = System.Drawing.Color.SteelBlue;
            this.tumunuGoster.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tumunuGoster.ForeColor = System.Drawing.Color.White;
            this.tumunuGoster.Location = new System.Drawing.Point(158, 189);
            this.tumunuGoster.Name = "tumunuGoster";
            this.tumunuGoster.Size = new System.Drawing.Size(64, 34);
            this.tumunuGoster.TabIndex = 7;
            this.tumunuGoster.Text = "Tümünü Göster";
            this.tumunuGoster.UseVisualStyleBackColor = false;
            this.tumunuGoster.Click += new System.EventHandler(this.tumunuGoster_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.liste);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 301);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notlar";
            // 
            // saaticon
            // 
            this.saaticon.ContextMenuStrip = this.saatmenusu;
            this.saaticon.Icon = ((System.Drawing.Icon)(resources.GetObject("saaticon.Icon")));
            this.saaticon.Text = "Yapışkan Notlar";
            this.saaticon.Visible = true;
            this.saaticon.DoubleClick += new System.EventHandler(this.saaticon_DoubleClick);
            // 
            // saatmenusu
            // 
            this.saatmenusu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.saatmenusu.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.saatmenusu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gosterToolStripMenuItem,
            this.toolStripSeparator1,
            this.cikisToolStripMenuItem});
            this.saatmenusu.Name = "saatmenusu";
            this.saatmenusu.ShowImageMargin = false;
            this.saatmenusu.Size = new System.Drawing.Size(75, 54);
            // 
            // gosterToolStripMenuItem
            // 
            this.gosterToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gosterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gosterToolStripMenuItem.Name = "gosterToolStripMenuItem";
            this.gosterToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
            this.gosterToolStripMenuItem.Text = "Gizle";
            this.gosterToolStripMenuItem.Click += new System.EventHandler(this.gösterToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(71, 6);
            // 
            // cikisToolStripMenuItem
            // 
            this.cikisToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cikisToolStripMenuItem.Name = "cikisToolStripMenuItem";
            this.cikisToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
            this.cikisToolStripMenuItem.Text = "Çıkış";
            this.cikisToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gizleToolStripMenuItem,
            this.hakkındaToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(230, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gizleToolStripMenuItem
            // 
            this.gizleToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.gizleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gizleToolStripMenuItem.Name = "gizleToolStripMenuItem";
            this.gizleToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.gizleToolStripMenuItem.Text = "Gizle";
            this.gizleToolStripMenuItem.Click += new System.EventHandler(this.gizleToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.hakkındaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "Çıkış";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(230, 349);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnsirala);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tumunuGoster);
            this.Controls.Add(this.btnTumunuKapat);
            this.Controls.Add(this.btnTumunuSil);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGoster);
            this.Controls.Add(this.btnEkle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StickyNote";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.groupBox1.ResumeLayout(false);
            this.saatmenusu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTumunuSil;
        public System.Windows.Forms.ListBox liste;
        private System.Windows.Forms.Button btnsirala;
        private System.Windows.Forms.Button btnTumunuKapat;
        private System.Windows.Forms.Button tumunuGoster;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon saaticon;
        private System.Windows.Forms.ContextMenuStrip saatmenusu;
        private System.Windows.Forms.ToolStripMenuItem gosterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.Button btnGoster;
    }
}