namespace FormProject4
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.ad = new System.Windows.Forms.Label();
            this.soyad = new System.Windows.Forms.Label();
            this.kimlik = new System.Windows.Forms.GroupBox();
            this.cinsiyetpanel = new System.Windows.Forms.Panel();
            this.kadin = new System.Windows.Forms.RadioButton();
            this.erkek = new System.Windows.Forms.RadioButton();
            this.soyadyaz = new System.Windows.Forms.TextBox();
            this.adyaz = new System.Windows.Forms.TextBox();
            this.tcyaz = new System.Windows.Forms.TextBox();
            this.cinsiyet = new System.Windows.Forms.Label();
            this.kayitbilgi = new System.Windows.Forms.GroupBox();
            this.subepanel = new System.Windows.Forms.GroupBox();
            this.subef = new System.Windows.Forms.RadioButton();
            this.subec = new System.Windows.Forms.RadioButton();
            this.subee = new System.Windows.Forms.RadioButton();
            this.subeb = new System.Windows.Forms.RadioButton();
            this.subed = new System.Windows.Forms.RadioButton();
            this.subea = new System.Windows.Forms.RadioButton();
            this.ogrencinoyaz = new System.Windows.Forms.TextBox();
            this.sinifpanel = new System.Windows.Forms.GroupBox();
            this.sinif11 = new System.Windows.Forms.RadioButton();
            this.sinif12 = new System.Windows.Forms.RadioButton();
            this.sinif10 = new System.Windows.Forms.RadioButton();
            this.sinif9 = new System.Windows.Forms.RadioButton();
            this.ogrencino = new System.Windows.Forms.Label();
            this.kayitiptal = new System.Windows.Forms.Button();
            this.kayitonay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.kimlik.SuspendLayout();
            this.cinsiyetpanel.SuspendLayout();
            this.kayitbilgi.SuspendLayout();
            this.subepanel.SuspendLayout();
            this.sinifpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ad
            // 
            resources.ApplyResources(this.ad, "ad");
            this.ad.Name = "ad";
            // 
            // soyad
            // 
            resources.ApplyResources(this.soyad, "soyad");
            this.soyad.Name = "soyad";
            // 
            // kimlik
            // 
            this.kimlik.Controls.Add(this.cinsiyetpanel);
            this.kimlik.Controls.Add(this.soyadyaz);
            this.kimlik.Controls.Add(this.adyaz);
            this.kimlik.Controls.Add(this.tcyaz);
            this.kimlik.Controls.Add(this.cinsiyet);
            this.kimlik.Controls.Add(this.ad);
            this.kimlik.Controls.Add(this.soyad);
            this.kimlik.Controls.Add(this.label1);
            resources.ApplyResources(this.kimlik, "kimlik");
            this.kimlik.Name = "kimlik";
            this.kimlik.TabStop = false;
            // 
            // cinsiyetpanel
            // 
            this.cinsiyetpanel.Controls.Add(this.kadin);
            this.cinsiyetpanel.Controls.Add(this.erkek);
            resources.ApplyResources(this.cinsiyetpanel, "cinsiyetpanel");
            this.cinsiyetpanel.Name = "cinsiyetpanel";
            // 
            // kadin
            // 
            resources.ApplyResources(this.kadin, "kadin");
            this.kadin.Name = "kadin";
            this.kadin.TabStop = true;
            this.kadin.UseVisualStyleBackColor = true;
            // 
            // erkek
            // 
            resources.ApplyResources(this.erkek, "erkek");
            this.erkek.Name = "erkek";
            this.erkek.TabStop = true;
            this.erkek.UseVisualStyleBackColor = true;
            // 
            // soyadyaz
            // 
            resources.ApplyResources(this.soyadyaz, "soyadyaz");
            this.soyadyaz.Name = "soyadyaz";
            this.soyadyaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soyadyaz_KeyPress);
            // 
            // adyaz
            // 
            resources.ApplyResources(this.adyaz, "adyaz");
            this.adyaz.Name = "adyaz";
            this.adyaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.adyaz_KeyPress);
            // 
            // tcyaz
            // 
            resources.ApplyResources(this.tcyaz, "tcyaz");
            this.tcyaz.Name = "tcyaz";
            this.tcyaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcyaz_KeyPress);
            // 
            // cinsiyet
            // 
            resources.ApplyResources(this.cinsiyet, "cinsiyet");
            this.cinsiyet.Name = "cinsiyet";
            // 
            // kayitbilgi
            // 
            resources.ApplyResources(this.kayitbilgi, "kayitbilgi");
            this.kayitbilgi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.kayitbilgi.Controls.Add(this.subepanel);
            this.kayitbilgi.Controls.Add(this.ogrencinoyaz);
            this.kayitbilgi.Controls.Add(this.sinifpanel);
            this.kayitbilgi.Controls.Add(this.ogrencino);
            this.kayitbilgi.Name = "kayitbilgi";
            this.kayitbilgi.TabStop = false;
            // 
            // subepanel
            // 
            this.subepanel.Controls.Add(this.subef);
            this.subepanel.Controls.Add(this.subec);
            this.subepanel.Controls.Add(this.subee);
            this.subepanel.Controls.Add(this.subeb);
            this.subepanel.Controls.Add(this.subed);
            this.subepanel.Controls.Add(this.subea);
            resources.ApplyResources(this.subepanel, "subepanel");
            this.subepanel.Name = "subepanel";
            this.subepanel.TabStop = false;
            // 
            // subef
            // 
            resources.ApplyResources(this.subef, "subef");
            this.subef.Name = "subef";
            this.subef.TabStop = true;
            this.subef.UseVisualStyleBackColor = true;
            // 
            // subec
            // 
            resources.ApplyResources(this.subec, "subec");
            this.subec.Name = "subec";
            this.subec.TabStop = true;
            this.subec.UseVisualStyleBackColor = true;
            // 
            // subee
            // 
            resources.ApplyResources(this.subee, "subee");
            this.subee.Name = "subee";
            this.subee.TabStop = true;
            this.subee.UseVisualStyleBackColor = true;
            // 
            // subeb
            // 
            resources.ApplyResources(this.subeb, "subeb");
            this.subeb.Name = "subeb";
            this.subeb.TabStop = true;
            this.subeb.UseVisualStyleBackColor = true;
            // 
            // subed
            // 
            resources.ApplyResources(this.subed, "subed");
            this.subed.Name = "subed";
            this.subed.TabStop = true;
            this.subed.UseVisualStyleBackColor = true;
            // 
            // subea
            // 
            resources.ApplyResources(this.subea, "subea");
            this.subea.Name = "subea";
            this.subea.TabStop = true;
            this.subea.UseVisualStyleBackColor = true;
            // 
            // ogrencinoyaz
            // 
            resources.ApplyResources(this.ogrencinoyaz, "ogrencinoyaz");
            this.ogrencinoyaz.Name = "ogrencinoyaz";
            this.ogrencinoyaz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ogrencinoyaz_KeyPress);
            // 
            // sinifpanel
            // 
            this.sinifpanel.Controls.Add(this.sinif11);
            this.sinifpanel.Controls.Add(this.sinif12);
            this.sinifpanel.Controls.Add(this.sinif10);
            this.sinifpanel.Controls.Add(this.sinif9);
            resources.ApplyResources(this.sinifpanel, "sinifpanel");
            this.sinifpanel.Name = "sinifpanel";
            this.sinifpanel.TabStop = false;
            // 
            // sinif11
            // 
            resources.ApplyResources(this.sinif11, "sinif11");
            this.sinif11.Name = "sinif11";
            this.sinif11.TabStop = true;
            this.sinif11.UseVisualStyleBackColor = true;
            // 
            // sinif12
            // 
            resources.ApplyResources(this.sinif12, "sinif12");
            this.sinif12.Name = "sinif12";
            this.sinif12.TabStop = true;
            this.sinif12.UseVisualStyleBackColor = true;
            // 
            // sinif10
            // 
            resources.ApplyResources(this.sinif10, "sinif10");
            this.sinif10.Name = "sinif10";
            this.sinif10.TabStop = true;
            this.sinif10.UseVisualStyleBackColor = true;
            // 
            // sinif9
            // 
            resources.ApplyResources(this.sinif9, "sinif9");
            this.sinif9.Name = "sinif9";
            this.sinif9.TabStop = true;
            this.sinif9.UseVisualStyleBackColor = true;
            // 
            // ogrencino
            // 
            resources.ApplyResources(this.ogrencino, "ogrencino");
            this.ogrencino.Name = "ogrencino";
            // 
            // kayitiptal
            // 
            resources.ApplyResources(this.kayitiptal, "kayitiptal");
            this.kayitiptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kayitiptal.Name = "kayitiptal";
            this.kayitiptal.UseVisualStyleBackColor = true;
            this.kayitiptal.Click += new System.EventHandler(this.kayitiptal_Click);
            // 
            // kayitonay
            // 
            resources.ApplyResources(this.kayitonay, "kayitonay");
            this.kayitonay.Name = "kayitonay";
            this.kayitonay.TabStop = false;
            this.kayitonay.UseVisualStyleBackColor = true;
            this.kayitonay.Click += new System.EventHandler(this.kayitonay_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Name = "label2";
            // 
            // Form2
            // 
            this.AcceptButton = this.kayitonay;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CausesValidation = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kayitonay);
            this.Controls.Add(this.kayitiptal);
            this.Controls.Add(this.kayitbilgi);
            this.Controls.Add(this.kimlik);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form2_KeyPress);
            this.kimlik.ResumeLayout(false);
            this.kimlik.PerformLayout();
            this.cinsiyetpanel.ResumeLayout(false);
            this.cinsiyetpanel.PerformLayout();
            this.kayitbilgi.ResumeLayout(false);
            this.kayitbilgi.PerformLayout();
            this.subepanel.ResumeLayout(false);
            this.subepanel.PerformLayout();
            this.sinifpanel.ResumeLayout(false);
            this.sinifpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ad;
        private System.Windows.Forms.Label soyad;
        private System.Windows.Forms.GroupBox kimlik;
        private System.Windows.Forms.Panel cinsiyetpanel;
        private System.Windows.Forms.TextBox soyadyaz;
        private System.Windows.Forms.TextBox adyaz;
        private System.Windows.Forms.TextBox tcyaz;
        private System.Windows.Forms.Label cinsiyet;
        private System.Windows.Forms.RadioButton kadin;
        private System.Windows.Forms.RadioButton erkek;
        private System.Windows.Forms.GroupBox kayitbilgi;
        private System.Windows.Forms.TextBox ogrencinoyaz;
        private System.Windows.Forms.Label ogrencino;
        private System.Windows.Forms.GroupBox sinifpanel;
        private System.Windows.Forms.GroupBox subepanel;
        private System.Windows.Forms.RadioButton subef;
        private System.Windows.Forms.RadioButton subec;
        private System.Windows.Forms.RadioButton subee;
        private System.Windows.Forms.RadioButton subeb;
        private System.Windows.Forms.RadioButton subed;
        private System.Windows.Forms.RadioButton subea;
        private System.Windows.Forms.RadioButton sinif11;
        private System.Windows.Forms.RadioButton sinif12;
        private System.Windows.Forms.RadioButton sinif10;
        private System.Windows.Forms.RadioButton sinif9;
        private System.Windows.Forms.Button kayitiptal;
        private System.Windows.Forms.Button kayitonay;
        private System.Windows.Forms.Label label2;
    }
}