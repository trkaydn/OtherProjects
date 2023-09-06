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
    public partial class Main : Form
    {
        public string kayitKlasoru = "notlar";
        public int sonNotAdi = 0;
        public List<string> notKonumlari = new List<string>();
        public List<StickyNote> notPencereleri = new List<StickyNote>();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.menuStrip1.BackColor = Color.SteelBlue;

            if (!Directory.Exists(kayitKlasoru))
                Directory.CreateDirectory(kayitKlasoru);

            var tumDosyalar = Directory.GetFiles(kayitKlasoru, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (var not in tumDosyalar)
            {
                var txtAdi = Path.GetFileNameWithoutExtension(not);
                sonNotAdi = Math.Max(sonNotAdi, int.Parse(txtAdi));
                liste.Items.Add("Not " + txtAdi);
                notKonumlari.Add(not);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var not = new StickyNote();
            not.Owner = this;
            notPencereleri.Add(not); // Listeye kaydet ki açık pencereleri takip edebilelim
            not.Show();
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            if (liste.SelectedItems.Count <= 0)
                return;

            string okunanNot = notKonumlari[liste.SelectedIndex];
            var notAdi = int.Parse(Path.GetFileNameWithoutExtension(okunanNot)); // Txt Adı

            // Pencere zaten açık ise pencereyi değişkene al
            StickyNote notPenceresi = null;
            foreach (var pencere in notPencereleri)
            {
                if (pencere.notAdi == notAdi)
                {
                    notPenceresi = pencere;
                    break;
                }
            }

            if (notPenceresi != null)
            {
                notPenceresi.Close();
                btnGoster.Text = "Göster";
                return;
            }
            else
            {
                btnGoster.Text = "Kapat";
            }

            var not = new StickyNote();
            not.Owner = this;

            using (var reader = new StreamReader(okunanNot))
            {
                var opaklik = reader.ReadLine();
                not.opacity = double.Parse(opaklik);

                var arkaplan = reader.ReadLine();
                var arkaplanR = int.Parse(arkaplan.Split(',')[0]);
                var arkaplanG = int.Parse(arkaplan.Split(',')[1]);
                var arkaplanB = int.Parse(arkaplan.Split(',')[2]);
                not.backColor = Color.FromArgb(arkaplanR, arkaplanG, arkaplanB);

                var fontRenk = reader.ReadLine();
                var fontRenkR = int.Parse(fontRenk.Split(',')[0]);
                var fontRenkG = int.Parse(fontRenk.Split(',')[1]);
                var fontRenkB = int.Parse(fontRenk.Split(',')[2]);
                not.fontColor = Color.FromArgb(fontRenkR, fontRenkG, fontRenkB);

                var yaziTipi = reader.ReadLine();
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                not.fontType = (Font)converter.ConvertFromString(yaziTipi);

                var metin = reader.ReadToEnd();
                not.txtNote.Text = metin;
                not.notAdi = notAdi;
            }

            notPencereleri.Add(not);
            not.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (liste.SelectedItems.Count <= 0)
                return;

            var notKonum = notKonumlari[liste.SelectedIndex]; // TXT Konumu
            var notAdi = Path.GetFileNameWithoutExtension(notKonum); // Txt Adı



            for (int i = 0; i < notPencereleri.Count; i++)
            {
                var pencere = notPencereleri[i];

                if (pencere.notAdi == int.Parse(notAdi))
                {
                    pencere.Close();
                    break;
                }
            }
            File.Delete(notKonum); // TXT yi sil
            notKonumlari.RemoveAt(liste.SelectedIndex);
            liste.Items.RemoveAt(liste.SelectedIndex);
            btnsirala.PerformClick();

        }

        private void btnTumunuSil_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Tüm notlar silinecektir.\nDevam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
                return;

            while (liste.Items.Count > 0)
            {
                File.Delete(notKonumlari[0]);
                notKonumlari.RemoveAt(0);
                liste.Items.RemoveAt(0);
            }

            while (notPencereleri.Count > 0)
            {
                notPencereleri[0].Close();
            }

            notPencereleri.Clear();

            sonNotAdi = 0;
            btnsirala.PerformClick();
        }

        private void btnsirala_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dosyaAdlari = new Dictionary<string, string>();
            Dictionary<StickyNote, int> pencereAdlari = new Dictionary<StickyNote, int>();

            int yeniAd = 1;

            // Bütün notları dön
            foreach (var notKonum in notKonumlari)
            {
                var orjinalAd = Path.GetFileNameWithoutExtension(notKonum);

                dosyaAdlari[notKonum] = kayitKlasoru + "/" + yeniAd + ".txt";

                foreach (var pencere in notPencereleri)
                {
                    if (pencere.notAdi == int.Parse(orjinalAd))
                    {
                        pencereAdlari[pencere] = yeniAd;
                        break;
                    }
                }

                yeniAd++;
            }

            notKonumlari.Clear();
            liste.Items.Clear();

            foreach (var konumlar in dosyaAdlari)
            {
                File.Move(konumlar.Key, konumlar.Value);

                notKonumlari.Add(konumlar.Value);
                liste.Items.Add("Not " + Path.GetFileNameWithoutExtension(konumlar.Value));
            }

            foreach (var pencereSozlukElemani in pencereAdlari)
            {
                StickyNote acikPencere = pencereSozlukElemani.Key;
                acikPencere.notAdi = pencereSozlukElemani.Value;
            }

            sonNotAdi = dosyaAdlari.Count;
        }

        private void liste_DoubleClick(object sender, EventArgs e)
        {
            foreach (var pencere in notPencereleri)
            {
                int b = int.Parse(Path.GetFileNameWithoutExtension(notKonumlari[liste.SelectedIndex]));
                int a = pencere.notAdi;
                if (a == b)
                {
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    Cursor.Position = new Point(pencere.Location.X + 10, pencere.Location.Y + 10);
                    return;
                }
            }

            btnGoster.PerformClick();
        }

        private void liste_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liste.SelectedItems.Count <= 0)
                return;

            string okunanNot = notKonumlari[liste.SelectedIndex];
            var notAdi = int.Parse(Path.GetFileNameWithoutExtension(okunanNot)); // Txt Adı

            bool pencereAcikMi = false;
            foreach (var pencere in notPencereleri)
            {
                if (pencere.notAdi == notAdi)
                {
                    pencereAcikMi = true;
                    break;
                }
            }

            if (pencereAcikMi == true)
                btnGoster.Text = "Kapat";
            else
                btnGoster.Text = "Göster";
        }

        private void btnTumunuKapat_Click(object sender, EventArgs e)
        {
            if (notPencereleri.Count <= 0)
                return;

            int a = notPencereleri.Count;
            for (int i = 0; i < a; i++)
            {
                notPencereleri[0].Close();
            }
            btnGoster.Text = "Göster";
        }

        private void tumunuGoster_Click(object sender, EventArgs e)
        {
            if (liste.Items.Count < 1)
                return;

            for (int i = 0; i < liste.Items.Count; i++)
            {
                bool kontrol = false;
                liste.SelectedIndex = i;

                foreach (var pencere in notPencereleri)
                {
                    int b = int.Parse(Path.GetFileNameWithoutExtension(notKonumlari[liste.SelectedIndex]));
                    int a = pencere.notAdi;
                    if (a == b)
                        kontrol = true;

                }

                if (kontrol != true)
                    btnGoster.PerformClick();

            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                foreach (var pencere in notPencereleri)
                {
                    pencere.Show();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.PerformClick();
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                gosterToolStripMenuItem.Text = "Göster";
                this.Hide();
            }
            else
            {
                gosterToolStripMenuItem.Text = "Gizle";
                this.Show();
            }
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gizleToolStripMenuItem_Click(sender, e);
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("StickyNote v1.0\nCopyright © 2020 Tarık A, All Rights Reserved.", "StickyNote Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saaticon_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
                return;

            gizleToolStripMenuItem_Click(sender, e);

        }
    }
}