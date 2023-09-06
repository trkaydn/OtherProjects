using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNote
{
    public partial class settingsform : Form
    {
        public settingsform()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            StickyNote sahip = (StickyNote)this.Owner;

            trackBar1.Value = (int)(sahip.opacity * 100);
            colorDialog1.Color = sahip.backColor;
            fontDialog1.Font = sahip.fontType;
            fontDialog1.Color = sahip.fontColor;
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            ((Control)sender).Size = new Size(18, 18);
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).Size = new Size(20, 20);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            StickyNote sahip = (StickyNote)this.Owner;

            sahip.opacity = (double)trackBar1.Value / 100;
            sahip.Opacity = sahip.opacity;
        }

        private void renksec_Click(object sender, EventArgs e)
        {
            StickyNote sahip = (StickyNote)this.Owner;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                sahip.backColor = colorDialog1.Color;
                sahip.BackColor = sahip.backColor;
                sahip.txtNote.BackColor = sahip.backColor;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                StickyNote sahip = (StickyNote)this.Owner;
                sahip.fontColor = fontDialog1.Color;
                sahip.fontType = fontDialog1.Font;

                sahip.txtNote.Font = sahip.fontType;
                sahip.txtNote.ForeColor = sahip.fontColor;
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsform_FormClosing(object sender, FormClosingEventArgs e)
        {
            StickyNote sahip = (StickyNote)this.Owner;
            sahip.txtNote_LostFocus(sender, e);
        }
    }
}
