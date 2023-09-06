using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StickyNote
{
    public partial class StickyNote : Form
    {
        public double opacity = 0.6;
        public Color backColor = Color.Yellow;
        public Color fontColor = Color.Black;
        public Font fontType = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic);

        public int notAdi = 0; // Metin belgesinin adı

        // Form sürükleme
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public StickyNote()
        {
            InitializeComponent();
        }

        public void stickyNote_Load(object sender, EventArgs e)
        {
            // Formdaki tüm kontrollere (btnSettings, txtNote, ..)
            foreach (Control item in this.Controls)
            {
                // Mouse enter ve leave olaylarında Form'un mouse enter ve leave metodunu kullanmasını söyle
                item.MouseLeave += new EventHandler(stickyNote_MouseLeave);
                item.MouseEnter += new EventHandler(stickyNote_MouseEnter);
            }
            txtNote.LostFocus += new EventHandler(txtNote_LostFocus); // TxtNote'dan fare çıktığında

            // Tıklanabilir buton efektleri
            btnSettings.MouseUp += new MouseEventHandler(btn_MouseUp);
            btnClose.MouseUp += new MouseEventHandler(btn_MouseUp);
            btnSettings.MouseDown += new MouseEventHandler(btn_MouseDown);
            btnClose.MouseDown += new MouseEventHandler(btn_MouseDown);

            // Ayarları oku uygula
            this.Opacity = opacity;
            this.BackColor = backColor;
            txtNote.BackColor = backColor;
            txtNote.Font = fontType;
            txtNote.ForeColor = fontColor;

        }

        private void stickyNote_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1d; // Maks opak
            btnSettings.Visible = true;
            btnClose.Visible = true;
        }

        private void stickyNote_MouseLeave(object sender, EventArgs e)
        {
            if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                return;

            this.Opacity = opacity;
            btnSettings.Visible = false;
            btnClose.Visible = false;
            this.ActiveControl = btnSettings; // txtNote'un imlecini gizle
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            ((Control)sender).Size = new Size(26, 26);
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).Size = new Size(28, 28);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var ayar = new settingsform();
            ayar.Owner = this;
            ayar.ShowDialog();
        }

        // Not alanı her focus'unu kaybedince
        public void txtNote_LostFocus(object sender, EventArgs e)
        {
            var mainSahip = (Main)this.Owner;

            if (mainSahip == null)
                return;

            var konum = mainSahip.kayitKlasoru;
            // Henüz bir metin belgem yok, belgeye isim oluştur
            if (notAdi == 0)
            {
                mainSahip.sonNotAdi += 1;
                notAdi = mainSahip.sonNotAdi;
                mainSahip.liste.Items.Add("Not " + notAdi);
                mainSahip.notKonumlari.Add(konum + "/" + notAdi + ".txt");
            }

            using (var writer = new StreamWriter(konum + "/" + notAdi + ".txt"))
            {
                writer.WriteLine(opacity);
                writer.WriteLine(backColor.R + "," + backColor.G + "," + backColor.B);
                writer.WriteLine(fontColor.R + "," + fontColor.G + "," + fontColor.B);

                // Font tipini metin hale getir
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                string fontAdi = converter.ConvertToString(fontType);
                writer.WriteLine(fontAdi);

                writer.WriteLine(txtNote.Text);
            }
        }

        private void stickyNote_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stickyNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtNote_LostFocus(sender, e);
            var mainSahip = (Main)this.Owner;

            for (int i = 0; i < mainSahip.notPencereleri.Count; i++)
            {
                var pencere = mainSahip.notPencereleri[i];

                if (pencere.notAdi == notAdi)
                {
                    mainSahip.notPencereleri.RemoveAt(i);
                    mainSahip.btnGoster.Text = "Göster";
                    break;
                }
            }
        }
    }
}