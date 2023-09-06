namespace StickyNote
{
    partial class StickyNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StickyNote));
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Image = global::StickyNote.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(262, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 28);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSettings.Image = global::StickyNote.Properties.Resources.gear;
            this.btnSettings.Location = new System.Drawing.Point(6, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(28, 28);
            this.btnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSettings.TabIndex = 1;
            this.btnSettings.TabStop = false;
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.Yellow;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.Location = new System.Drawing.Point(6, 44);
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(288, 200);
            this.txtNote.TabIndex = 4;
            this.txtNote.TabStop = false;
            this.txtNote.Text = "";
            // 
            // stickyNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "stickyNote";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StickyNote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.stickyNote_FormClosing);
            this.Load += new System.EventHandler(this.stickyNote_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stickyNote_MouseDown);
            this.MouseEnter += new System.EventHandler(this.stickyNote_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.stickyNote_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnSettings;
        private System.Windows.Forms.PictureBox btnClose;
        public System.Windows.Forms.RichTextBox txtNote;
    }
}

