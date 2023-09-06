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
using System.Diagnostics;

namespace FormProject4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.sagtik.Opening += this.contextMenuStrip1_Opening;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = this.tablo.SelectedRows.Count <= 0;
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;

        }

        public static string gonder;


        private void kayitolustur_Click(object sender, EventArgs e)
        {
            if (tablo.Rows.Count < 1)
            {
                MessageBox.Show("Lütfen bir database seçiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            gonder = dosyakonum.Text;
            Form2 goster = new Form2();
            goster.ShowDialog();

        }

        private void cikis_Click(object sender, EventArgs e)
        {
            cikisonay = MessageBox.Show("Uygulamadan Çıkmak İstediğinize Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cikisonay == DialogResult.Yes)
                Environment.Exit(0);
        }


        public static int silmesayisi = 0;
        public void kayitsil_Click(object sender, EventArgs e)
        {
            try
            {
                if (tablo.SelectedRows.Count > 0)
                {
                    silmesayisi = 1;
                    DialogResult sil = MessageBox.Show("Seçili kayıt silinecektir. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                    if (sil == DialogResult.Yes)
                    {

                        tablo.Rows.RemoveAt(tablo.SelectedRows[0].Index);


                        string filePath = textopen.FileName;
                        dosyakonum.Text = filePath;


                        using (StreamWriter yaz = new StreamWriter(filePath, false))
                        {

                            for (int i = 0; i < tablo.Rows.Count; i++)
                            {
                                for (int j = 0; j < tablo.Columns.Count; j++)
                                {
                                    yaz.Write(tablo.Rows[i].Cells[j].Value.ToString() + ",");
                                }
                                yaz.WriteLine("");
                            }
                        }
                    }

                }
                else
                    MessageBox.Show("Lütfen bir kayıt seçin.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception hata)
            { MessageBox.Show(hata.Message); }
            ogrsayisi.Text = tablo.Rows.Count.ToString();

        }


        public DialogResult cikisonay = new DialogResult();
        private void Form1_FormClosing(object sender, CancelEventArgs e)
        {
            if (cikisonay == DialogResult.Yes)
                e.Cancel = false;
            else
            {

                cikisonay = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cikisonay == DialogResult.Yes)
                    Environment.Exit(0);
                else
                    e.Cancel = true;
            }


        }
        public static int dosyaac = 0;
        public void acbutton_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (textopen.ShowDialog() == DialogResult.Cancel)
                    return;

                tablo.Rows.Clear();
                string filePath = textopen.FileName;
                dosyakonum.Text = filePath;
                if (File.Exists(filePath) == false)
                {
                    DialogResult hatacevap = MessageBox.Show("Dosya dizini hatalı. Yeni dosya seçiniz.", "Dosya Bulunamadı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (hatacevap == DialogResult.Retry)
                    {
                        textopen.ShowDialog();
                        filePath = textopen.FileName;
                        dosyakonum.Text = filePath;

                    }
                    else if (hatacevap == DialogResult.Cancel)
                        this.Close();


                }
                int error1 = 0;

                if (File.Exists(filePath) == true)
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (reader.Peek() != -1)
                        {
                            char ayrac = ',';
                            string[] bilgiler = reader.ReadLine().Split(ayrac);

                            if (bilgiler.Length < 6)
                            {
                                continue;
                                // break: döngüden komple çık
                                // return: metoddan komple çık
                                //continue: sonraki döngüye atla (skip geç bu adımı)
                            }
                            try
                            {
                                tablo.Rows.Add(bilgiler[0], bilgiler[1], bilgiler[2], bilgiler[3], bilgiler[4], bilgiler[5]);
                                tablo.Text += "\r\n";
                            }
                            catch (Exception hata)
                            { error1 = 1; }

                        }
                    }
                }
                if (error1 == 1)
                {
                    int error;
                    do
                    {
                        try
                        {
                            error1 = 0;
                            error = 0;
                            dosyaac = 1;
                            MessageBox.Show("Seçtiğin dosyanın içeriği programa uygun değil. Lütfen başka bir dosya seç.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult text = textopen.ShowDialog();
                            if (text == DialogResult.Cancel)
                            {
                                var cevap = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (cevap == DialogResult.Yes)
                                    Environment.Exit(0);
                                else
                                    textopen.ShowDialog();
                            }


                            filePath = textopen.FileName;
                            dosyakonum.Text = filePath;
                            using (StreamReader reader = new StreamReader(filePath))
                            {
                                while (reader.Peek() != -1)
                                {
                                    char ayrac = ',';
                                    string[] bilgiler = reader.ReadLine().Split(ayrac);


                                    tablo.Rows.Add(bilgiler[0], bilgiler[1], bilgiler[2], bilgiler[3], bilgiler[4], bilgiler[5]);
                                    tablo.Text += "\r\n";
                                }
                            }
                        }
                        catch (Exception hata)
                        { error = 1; }
                    }

                    while (error == 1);
                }
            }
            catch (Exception hata)
            { MessageBox.Show(hata.Message); }

            tablo.ClearSelection();
            ogrsayisi.Text = tablo.Rows.Count.ToString();


        }

        private void Form1_Activated(object sender, EventArgs e)
        {

            this.sagtik.Opening += this.contextMenuStrip1_Opening;

            if (silmesayisi == 1)
            {
                silmesayisi = 0;
                return;
            }

            try
            {
                if (dosyakonum.Text != "")
                {
                    tablo.Rows.Clear();
                    string filePath = dosyakonum.Text;
                    if (File.Exists(filePath) == false)
                    {
                        DialogResult hatacevap = MessageBox.Show("Dosya dizini hatalı. Yeni dosya seçiniz.", "Dosya Bulunamadı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (hatacevap == DialogResult.Retry)
                        {
                            textopen.ShowDialog();
                            filePath = textopen.FileName;
                            dosyakonum.Text = filePath;
                        }
                        else if (hatacevap == DialogResult.Cancel)
                            this.Close();

                    }


                    if (File.Exists(filePath) == true)
                    {

                        using (StreamReader reader = new StreamReader(filePath))
                        {

                            while (reader.Peek() != -1)
                            {
                                char ayrac = ',';
                                string[] bilgiler = reader.ReadLine().Split(ayrac);


                                tablo.Rows.Add(bilgiler[0], bilgiler[1], bilgiler[2], bilgiler[3], bilgiler[4], bilgiler[5]);
                                tablo.Text += "\r\n";

                            }
                        }
                    }
                    ogrsayisi.Text = tablo.Rows.Count.ToString();
                }
            }
            catch (Exception)
            {
                if (dosyaac == 0)
                {
                    MessageBox.Show("Seçtiğin dosyanın içeriği programa uygun değil. Lütfen başka bir dosya seç.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult sec = textopen.ShowDialog();
                    if (sec == DialogResult.Cancel)
                        this.Close();

                    string filePath = textopen.FileName;
                    dosyakonum.Text = filePath;
                    dosyaac = 1;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (reader.Peek() != -1)
                        {
                            char ayrac = ',';
                            string[] bilgiler = reader.ReadLine().Split(ayrac);

                            try
                            {
                                tablo.Rows.Add(bilgiler[0], bilgiler[1], bilgiler[2], bilgiler[3], bilgiler[4], bilgiler[5]);
                                tablo.Text += "\r\n";
                            }
                            catch (Exception hata)
                            { break; }
                        }
                    }
                }
            }
            ogrsayisi.Text = tablo.Rows.Count.ToString();
        }

        public void tumunusil_Click(object sender, EventArgs e)
        {
            if (tablo.SelectedRows.Count < 1)
            {
                MessageBox.Show("Lütfen bir databese seçiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            try
            {
                DialogResult cevap = MessageBox.Show("Tüm kayıtları silmek üzeresiniz. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    tablo.Rows.Clear();

                    using (StreamWriter sil = new StreamWriter(dosyakonum.Text))
                    {
                        sil.Write("");
                    }

                }
                ogrsayisi.Text = tablo.Rows.Count.ToString();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }


        private void kayitguncelle_Click(object sender, EventArgs e)
        {
            if (tablo.SelectedRows.Count < 1)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            frmDuzenle goster = new frmDuzenle();

            goster.tcyaz.Text = tablo.SelectedRows[0].Cells[0].Value.ToString();
            goster.adyaz.Text = tablo.SelectedRows[0].Cells[1].Value.ToString();
            goster.soyadyaz.Text = tablo.SelectedRows[0].Cells[2].Value.ToString();
            goster.ogrencinoyaz.Text = tablo.SelectedRows[0].Cells[4].Value.ToString();


            if (tablo.SelectedRows[0].Cells[3].Value.ToString() == goster.erkek.Text.ToString())
                goster.erkek.Checked = true;
            else if (tablo.SelectedRows[0].Cells[3].Value.ToString() == goster.kadin.Text.ToString())
                goster.kadin.Checked = true;

            string sinif = tablo.SelectedRows[0].Cells[5].Value.ToString();
            string[] a = sinif.Split('-');

            if (a[0] == "9")
                goster.sinif9.Checked = true;
            else if (a[0] == "10")
                goster.sinif10.Checked = true;
            else if (a[0] == "11")
                goster.sinif11.Checked = true;
            else
                goster.sinif12.Checked = true;

            switch (a[1])
            {
                case "A":
                    goster.subea.Checked = true;
                    break;
                case "B":
                    goster.subeb.Checked = true;
                    break;
                case "C":
                    goster.subec.Checked = true;
                    break;
                case "D":
                    goster.subed.Checked = true;
                    break;
                case "E":
                    goster.subee.Checked = true;
                    break;
                case "F":
                    goster.subef.Checked = true;
                    break;
            }

            goster.Owner = this;
            ogrsayisi.Text = tablo.Rows.Count.ToString();
            goster.ShowDialog();
            if (goster.Visible == true)
                goster.Hide();

        }

        private void tablo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                kayitsil_Click(sender, e);
                //kayitsil.PerformClick();
            }
        }



        private void tablo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int satir = tablo.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    tablo.Rows[satir].Selected = true;
                    tablo.CurrentCell = tablo.Rows[satir].Cells[0];
                }
                else if (tablo.SelectedRows.Count > 0)
                    tablo.ClearSelection();
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (tablo.SelectedRows.Count > 0)
                    tablo.ClearSelection();
            }
        }

        private void sagtik_MouseUp(object sender, MouseEventArgs e)
        {
            tablo.ClearSelection();
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                kayitguncelle.PerformClick();

            else if (e.KeyCode == Keys.Delete)
                kayitsil.PerformClick();
            else if (e.KeyCode == Keys.Escape)
                cikis.PerformClick();


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tarih.Text = DateTime.Now.ToString();
        }

        private void tablo_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                tablo.Rows.Clear();
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = files[0];
                textopen.FileName = filePath;
                dosyakonum.Text = filePath;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (reader.Peek() != -1)
                    {
                        char ayrac = ',';
                        string[] bilgiler = reader.ReadLine().Split(ayrac);

                        try
                        {
                            tablo.Rows.Add(bilgiler[0], bilgiler[1], bilgiler[2], bilgiler[3], bilgiler[4], bilgiler[5]);
                            tablo.Text += "\r\n";
                        }
                        catch (Exception hata)
                        { break; }
                    }
                }
                ogrsayisi.Text = tablo.Rows.Count.ToString();

            }
        }




        private void tablo_DragEnter(object sender, DragEventArgs e)
        {
           
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (Path.GetExtension(files[0]) != ".txt")
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Copy;
         
        }
    }
}






