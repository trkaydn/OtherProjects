using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;  //tanımladık
using System.Text.RegularExpressions; //tanımladık (REGEX)
using System.IO; //tanımladık

namespace FormProjectPersonal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }
        //Veritabanı dosya yolu ve provider belirlenmesi
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=personel.accdb");
        int resimsecme = 0;
        int resimsecme1 = 0;
        private void kullanicilari_goster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter kullanicilari_listele = new OleDbDataAdapter("select tcno AS[TC KİMLİK NO],ad AS[ADI],soyad AS[SOYADI],yetki AS[YETKİ],kullaniciadi AS[KULLANICI ADI],parola AS[PAROLA] from kullanicilar Order By ad ASC", baglanti);
                DataSet dshafiza = new DataSet();
                kullanicilari_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "TA Personal Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }

        }
        private void personelleri_goster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter personelleri_listele = new OleDbDataAdapter("select tcno AS[TC NO],ad AS[ADI],soyad AS[SOYADI],cinsiyet AS[CİNSİYET],mezuniyet AS[EĞİTİM BİLGİSİ],dogumtarihi AS[DOĞUM TARİHİ],gorevi AS[GÖREVİ],gorevyeri AS[GÖREV YERİ],maasi AS[MAAŞ (₺)] from personeller Order By ad ASC", baglanti);
                DataSet dshafiza = new DataSet();
                personelleri_listele.Fill(dshafiza);
                dataGridView2.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "TA Personal Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }

        }
        private void Form2_Load(object sender, EventArgs e)
        {

            this.contextMenuStrip1.Opening += this.contextMenuStrip1_Opening;
            this.contextMenuStrip2.Opening += this.contextMenuStrip2_Opening;
            label26.Text = DateTime.Now.ToString("dd MMMM yyyy ddd");
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg");
            pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg");

            //Form2 Ayarları
            timer1.Enabled = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                if (File.Exists(Application.StartupPath + "\\girisresimler\\" + Form1.tcno + ".jpg"))
                    File.Delete(Application.StartupPath + "\\girisresimler\\" + Form1.tcno + ".jpg");
                
                File.Copy(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg", Application.StartupPath + "\\girisresimler\\" + Form1.tcno + ".jpg");
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\girisresimler\\" + Form1.tcno + ".jpg");

            }
            catch (Exception)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg");
            }
            //Kullanıcı işlemleri sekmesi
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            label12.ForeColor = Color.DarkRed;
            label12.Text = Form1.adi + " " + Form1.soyadi;
            toolTip1.SetToolTip(this.textBox1, "TC Kimlik No 11 Karakter Olmalıdır!");
            radioButton1.Checked = true;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            kullanicilari_goster();

            //Personel işlemleri sekmesi
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            maskedTextBox1.Mask = "00000000000";
            maskedTextBox2.Mask = "LL??????????????????";
            maskedTextBox3.Mask = "LL??????????????????";
            maskedTextBox4.Mask = "$99999";
            maskedTextBox2.Text.ToUpper();
            maskedTextBox3.Text.ToUpper();
            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));
            dateTimePicker1.MinDate = new DateTime(1960, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(yil - 18, ay, gun);
            radioButton3.Checked = true;
            maskedTextBox1.ResetOnSpace = false;
            maskedTextBox3.ResetOnSpace = false;
            maskedTextBox4.ResetOnSpace = false;
            personelleri_goster();
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 11)
            {
                errorProvider1.SetError(textBox1, "TC Kimlik No 11 Karakter Olmalıdır!");
                if (textBox1.Text == "")
                    label1.ForeColor = Color.Black;
                errorProvider1.Clear();
            }
            else
                errorProvider1.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length < 3)
            {
                errorProvider1.SetError(textBox4, "Kullanıcı adı en az 3, en fazla 12 karakter olmalıdır.");
                if (textBox4.Text == "")
                    errorProvider1.Clear();
            }
            else
                errorProvider1.Clear();
        }

        int parola_skoru = 0;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                label1.ForeColor = Color.Black;

            string parola_seviyesi = "";
            int kucuk_harf_skoru = 0, buyuk_harf_skoru = 0, rakam_skoru = 0, sembol_skoru = 0;
            string sifre = textBox5.Text;
            //Regex kütüphanesi ingilizce karakterleri baz aldığından şifredeki türkçe karakterleri ingilizceye dönüştürmek gerekiyor.
            string duzeltilmis_sifre = "";
            duzeltilmis_sifre = sifre;
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('İ', 'I');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ı', 'i');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ç', 'C');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ç', 'c');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ş', 'S');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ş', 's');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ğ', 'G');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ğ', 'g');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ü', 'U');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ü', 'u');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('Ö', 'O');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ö', 'o');
            if (sifre != duzeltilmis_sifre)
            {
                sifre = duzeltilmis_sifre;
                textBox5.Text = sifre;
                MessageBox.Show("Paroladaki Türkçe karakterler İngilizceye Dönüştürülmüştür.");
            }
            //1 küçük harf 10 puan, 2 ve üzeri 20 puan
            int az_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
            kucuk_harf_skoru = Math.Min(2, az_karakter_sayisi) * 10;

            //1 büyük harf 10 puan, 2 ve üzeri 20 puan
            int AZ_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
            buyuk_harf_skoru = Math.Min(2, AZ_karakter_sayisi) * 10;

            //1 rakam 10 puan, 2 ve üzeri 20 puan
            int rakam_sayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
            rakam_skoru = Math.Min(2, rakam_sayisi) * 10;

            //1 sembol 10 puan, 2 ve üzeri 20 puan
            int sembol_sayisi = sifre.Length - az_karakter_sayisi - AZ_karakter_sayisi - rakam_sayisi;
            sembol_skoru = Math.Min(2, sembol_sayisi) * 10;

            parola_skoru = kucuk_harf_skoru + buyuk_harf_skoru + rakam_skoru + sembol_skoru;
            if (sifre.Length > 7)
                parola_skoru += 10;
            if (sifre.Length > 9)
                parola_skoru += 20;

            if (kucuk_harf_skoru == 0 || buyuk_harf_skoru == 0 || rakam_skoru == 0 || sembol_skoru == 0)
            {
                label22.Text = "Şifreniz en az 1 büyük harf, 1 küçük harf, 1 rakam ve 1 sembol içermelidir.";
                if (textBox5.Text == "")

                    label22.Text = "";


            }
            else if (kucuk_harf_skoru != 0 || buyuk_harf_skoru != 0 || rakam_skoru != 0 || sembol_skoru != 0)
                label22.Text = "";

            if (parola_skoru < 60)
                parola_seviyesi = "Kabul Edilemez!";
            else if (parola_skoru == 60)
                parola_seviyesi = "İdare Eder.";
            else if (parola_skoru == 70 || parola_skoru == 80)
                parola_seviyesi = "Güçlü.";
            else if (parola_skoru == 90 || parola_skoru == 100)
                parola_seviyesi = "Çok Güçlü.";

            label9.Text = "%" + Convert.ToString(parola_skoru);
            label10.Text = parola_seviyesi;
            if (textBox5.Text == "")

                label10.Text = "";

            progressBar1.Value = parola_skoru;

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                label1.ForeColor = Color.Black;

            if (textBox6.Text != textBox5.Text)
            {
                errorProvider1.SetError(textBox6, "Girdiğiniz şifreler aynı değil.");
                if (textBox6.Text == "")
                    errorProvider1.Clear();
            }
            else
                errorProvider1.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Devam etmek istediğinize emin misiniz?", "Oturum Sonlandırılacak", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer == DialogResult.Yes)
            {
                baglanti.Close();
                this.Hide();
                Form1 yenigiris = new Form1();
                yenigiris.Show();
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Devam etmek istediğinize emin misiniz?", "Program Kapatılacak", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer == DialogResult.Yes)
            {
                baglanti.Close();
                timer1.Enabled = false;
                Environment.Exit(0);
            }

        }
        int saniye = 00, dakika = 00, saat = 00;

        private void tabpage1_temizle()
        {
            label1.ForeColor = Color.Black; label2.ForeColor = Color.Black; label3.ForeColor = Color.Black; label5.ForeColor = Color.Black; label6.ForeColor = Color.Black; label7.ForeColor = Color.Black;
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg");

        }

        private void tabpage2_temizle()
        {
            maskedTextBox1.Enabled = true;
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg");
            maskedTextBox1.Clear(); maskedTextBox2.Clear(); maskedTextBox3.Clear(); maskedTextBox4.Clear();
            label13.ForeColor = Color.Black; label14.ForeColor = Color.Black; label15.ForeColor = Color.Black; label16.ForeColor = Color.Black; label17.ForeColor = Color.Black; label18.ForeColor = Color.Black; label19.ForeColor = Color.Black; label20.ForeColor = Color.Black; label21.ForeColor = Color.Black;
            comboBox1.SelectedIndex = -1; comboBox2.SelectedIndex = -1; comboBox3.SelectedIndex = -1;
            maskedTextBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yetki = "";
            bool kayitkontrol = false;
            bool kayitkontrol2 = false;
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + textBox1.Text + "'", baglanti);
            OleDbCommand selectsorgu2 = new OleDbCommand("select * from kullanicilar where kullaniciadi='" + textBox4.Text + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            OleDbDataReader kayitokuma1 = selectsorgu2.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                label1.ForeColor = Color.Red;

                MessageBox.Show("Girilen TC zaten kayıtlı.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
                return;
            }
            while (kayitokuma1.Read())
            {
                kayitkontrol2 = true;
                label5.ForeColor = Color.Red;

                MessageBox.Show("Girilen kullanıcı adı zaten kayıtlı.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
                return;
            }
            baglanti.Close();
            if (kayitkontrol == false && kayitkontrol2 == false)
            {
                //TC No kontrolü
                if (textBox1.Text.Length < 11 || textBox1.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                //İsim veri kontrolü
                if (textBox2.Text.Length < 2 || textBox2.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                //Soyisim veri kontrolü
                if (textBox3.Text.Length < 2 || textBox3.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                //Kullanıcı adı veri kontrolü
                if (textBox4.Text.Length < 3 || textBox4.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                //Parola veri kontrolü
                if (textBox5.Text == "" || parola_skoru < 60)
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;

                //Parola tekrarı veri kontrolü
                if (textBox6.Text == "" || textBox5.Text != textBox6.Text)
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                if (textBox1.Text.Length == 11 && textBox2.Text.Length > 1 && textBox3.Text.Length > 1 && textBox4.Text.Length > 2 && textBox5.Text.Length > 0 && textBox6.Text.Length > 0 && textBox5.Text == textBox6.Text && parola_skoru > 50)
                {
                    if (radioButton1.Checked == true)
                        yetki = "Yönetici";
                    else if (radioButton2.Checked == true)
                        yetki = "Kullanıcı";

                    try
                    {
                        baglanti.Open();
                        OleDbCommand eklekomutu = new OleDbCommand("insert into kullanicilar values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + yetki + "','" + textBox4.Text + "','" + textBox6.Text + "')", baglanti);
                        eklekomutu.ExecuteNonQuery();
                        if (!Directory.Exists(Application.StartupPath + "\\kullaniciresimler"))
                            Directory.CreateDirectory(Application.StartupPath + "\\kullaniciresimler");

                        pictureBox3.Image.Save(Application.StartupPath + "\\kullaniciresimler\\" + textBox1.Text + ".jpg");
                        baglanti.Close();
                        MessageBox.Show("Yeni kullanıcı kaydı oluşturuldu.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabpage1_temizle();

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message, "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen kırmızı alanları yeniden gözden geçirin.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
                kullanicilari_goster();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                label1.ForeColor = Color.Black;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                label1.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool kayit_arama = false;
            if (textBox1.Text.Length == 11)
            {
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + textBox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama = true;
                    textBox2.Text = kayitokuma.GetValue(1).ToString();
                    textBox3.Text = kayitokuma.GetValue(2).ToString();
                    if (kayitokuma.GetValue(3).ToString() == "Yönetici")
                        radioButton2.Checked = true;
                    else if (kayitokuma.GetValue(3).ToString() == "Kullanıcı")
                        radioButton1.Checked = true;
                    textBox4.Text = kayitokuma.GetValue(4).ToString();
                    textBox5.Text = kayitokuma.GetValue(5).ToString();
                    textBox6.Text = kayitokuma.GetValue(5).ToString();
                    textBox1.Enabled = false;
                    break;
                }
                if (kayit_arama == false)
                {
                    MessageBox.Show("Aranan kayıt bulunamadı.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                myfile = pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + textBox1.Text + ".jpg");
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Aranacak TC Kimlik No 11 karakter olmalıdır.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string yetki = "";

            //TC No kontrolü
            if (textBox1.Text.Length < 11 || textBox1.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            //İsim veri kontrolü
            if (textBox2.Text.Length < 2 || textBox2.Text == "")
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = Color.Black;

            //Soyisim veri kontrolü
            if (textBox3.Text.Length < 2 || textBox3.Text == "")
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = Color.Black;

            //Kullanıcı adı veri kontrolü
            if (textBox4.Text.Length < 3 || textBox4.Text == "")
                label5.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;

            //Parola veri kontrolü
            if (textBox5.Text == "" || parola_skoru < 60)
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;

            //Parola tekrarı veri kontrolü
            if (textBox6.Text == "" || textBox5.Text != textBox6.Text)
                label7.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.Black;

            if (textBox1.Text.Length == 11 && textBox2.Text.Length > 1 && textBox3.Text.Length > 1 && textBox4.Text.Length > 2 && textBox5.Text.Length > 0 && textBox6.Text.Length > 0 && textBox5.Text == textBox6.Text && parola_skoru > 50)
            {
                if (radioButton2.Checked == true)
                    yetki = "Yönetici";
                else if (radioButton1.Checked == true)
                    yetki = "Kullanıcı";

                try
                {
                    baglanti.Open();
                    OleDbCommand guncellekomutu = new OleDbCommand("update kullanicilar set ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',yetki='" + yetki + "',kullaniciadi='" + textBox4.Text + "',parola='" + textBox5.Text + "' where tcno='" + textBox1.Text + "'", baglanti);
                    guncellekomutu.ExecuteNonQuery();
                    if (!Directory.Exists(Application.StartupPath + "\\kullaniciresimler"))
                        Directory.CreateDirectory(Application.StartupPath + "\\kullaniciresimler");
                    if (resimsecme == 1)
                    {


                        myfile.Dispose();
                        File.Delete(Application.StartupPath + "\\kullaniciresimler\\" + textBox1.Text + ".jpg");

                        pictureBox3.Image.Save(Application.StartupPath + "\\kullaniciresimler\\" + textBox1.Text + ".jpg");
                        resimsecme = 0;
                    }
                    else if (resimsecme == 0)
                        myfile.Dispose();

                    baglanti.Close();
                    MessageBox.Show("Kullanıcı bilgileri güncellendi.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kullanicilari_goster();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }

            }
            else
            {
                MessageBox.Show("Lütfen kırmızı alanları yeniden gözden geçirin.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 11)
            {
                bool kayit_arama = false;
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + textBox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama = true;
                    OleDbCommand deletesorgu = new OleDbCommand("delete from kullanicilar where tcno='" + textBox1.Text + "'", baglanti);
                    deletesorgu.ExecuteNonQuery();
                    myfile.Dispose();
                    File.Delete(Application.StartupPath + "\\kullaniciresimler\\" + textBox1.Text + ".jpg");
                    MessageBox.Show("Kullanıcı kaydı silindi.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();
                    tabpage1_temizle();
                    kullanicilari_goster();
                    break;
                }
                if (kayit_arama == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
            }
            else
                MessageBox.Show("Girilen TC Kimlik No 11 karakter olmalıdır.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            tabpage1_temizle();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog resimsec = new OpenFileDialog();
            resimsec.Title = "Personel Resmi Seçiniz";
            resimsec.Filter = "JPG Dosyaları (*.jpg) | *.jpg";

            if (resimsec.ShowDialog() == DialogResult.OK)
            {

                this.pictureBox2.Image = new Bitmap(resimsec.OpenFile());
                resimsecme1 = 1;
                myfile1.Dispose();
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = this.dataGridView1.SelectedRows.Count <= 0;

        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int satir = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    dataGridView1.Rows[satir].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[satir].Cells[0];
                }
                else if (dataGridView1.SelectedRows.Count > 0)
                    dataGridView1.ClearSelection();
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    dataGridView1.ClearSelection();
            }
        }

        private void contextMenuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            dataGridView1.ClearSelection();

        }

        Image myfile;
        Image myfile1;
        private void bilgileriKGetirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Enabled = false;
            tabpage1_temizle();
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                textBox1.Text = kayitokuma.GetValue(0).ToString();
                textBox2.Text = kayitokuma.GetValue(1).ToString();
                textBox3.Text = kayitokuma.GetValue(2).ToString();
                if (kayitokuma.GetValue(3).ToString() == "Yönetici")
                    radioButton2.Checked = true;
                else if (kayitokuma.GetValue(3).ToString() == "Kullanıcı")
                    radioButton1.Checked = true;
                textBox4.Text = kayitokuma.GetValue(4).ToString();
                textBox5.Text = kayitokuma.GetValue(5).ToString();
                textBox6.Text = kayitokuma.GetValue(5).ToString();
            }

            myfile = pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + ".jpg");
            baglanti.Close();

        }

        private void kaydiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {

                OleDbCommand deletesorgu = new OleDbCommand("delete from kullanicilar where tcno='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'", baglanti);
                deletesorgu.ExecuteNonQuery();
                File.Delete(Application.StartupPath + "\\kullaniciresimler\\" + textBox1.Text + ".jpg");
                MessageBox.Show("Kullanıcı kaydı silindi.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;
            }
            baglanti.Close();
            kullanicilari_goster();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;
            }
            baglanti.Close();

            if (kayitkontrol == false)
            {

                if (maskedTextBox1.MaskCompleted == false)
                    label16.ForeColor = Color.Red;
                else
                    label16.ForeColor = Color.Black;
                if (maskedTextBox2.MaskCompleted == false)
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.Black;
                if (maskedTextBox3.MaskCompleted == false)
                    label14.ForeColor = Color.Red;
                else
                    label14.ForeColor = Color.Black;
                if (maskedTextBox4.Text.Length < 3)
                    label21.ForeColor = Color.Red;
                else
                    label21.ForeColor = Color.Black;
                if (comboBox1.Text == "")
                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.Black;
                if (comboBox2.Text == "")
                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;
                if (comboBox3.Text == "")
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;

                if (maskedTextBox1.MaskCompleted == true && maskedTextBox2.MaskCompleted == true && maskedTextBox3.MaskCompleted == true && maskedTextBox4.Text.Length > 2 && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    if (radioButton3.Checked == true)
                        cinsiyet = "Erkek";
                    else if (radioButton4.Checked == true)
                        cinsiyet = "Kadın";
                    try
                    {
                        baglanti.Open();
                        OleDbCommand eklekomutu = new OleDbCommand("insert into personeller values('" + maskedTextBox1.Text + "','" + maskedTextBox2.Text.ToUpper() + "','" + maskedTextBox3.Text.ToUpper() + "','" + cinsiyet + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + maskedTextBox4.Text + "')", baglanti);
                        eklekomutu.ExecuteNonQuery();
                        baglanti.Close();
                        if (!Directory.Exists(Application.StartupPath + "\\personelresimler"))
                            Directory.CreateDirectory(Application.StartupPath + "\\personelresimler");

                        pictureBox2.Image.Save(Application.StartupPath + "\\personelresimler\\" + maskedTextBox1.Text + ".jpg");
                        MessageBox.Show("Yeni personel kaydı oluşturuldu.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        personelleri_goster();
                        tabpage2_temizle();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message, "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }

                }
                else
                    MessageBox.Show("Lütfen kırmızı alanları yeniden gözden geçirin.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Girilen TC zaten kayıtlı.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabpage2_temizle();
        }


        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog resimsec = new OpenFileDialog();
            resimsec.Title = "Kullanıcı Resmi Seçiniz";
            resimsec.Filter = "JPG Dosyaları (*.jpg) | *.jpg";
            if (resimsec.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox3.Image = new Bitmap(resimsec.OpenFile());
                resimsecme = 1;
                myfile.Dispose();

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                bilgileriGetirToolStripMenuItem.PerformClick();
            else
                button5.PerformClick();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (maskedTextBox1.Text.Length == 11)
            {
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    try
                    {
                        myfile1 = pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personelresimler\\" + kayitokuma.GetValue(0).ToString() + ".jpg");
                    }
                    catch (Exception)
                    {
                        myfile1 = pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + "resimyok.jpg");
                    }
                    maskedTextBox1.Enabled = false;
                    maskedTextBox2.Text = kayitokuma.GetValue(1).ToString();
                    maskedTextBox3.Text = kayitokuma.GetValue(2).ToString();
                    if (kayitokuma.GetValue(3).ToString() == "Erkek")
                        radioButton3.Checked = true;
                    else if (kayitokuma.GetValue(3).ToString() == "Kadın")
                        radioButton4.Checked = true;
                    comboBox1.Text = kayitokuma.GetValue(4).ToString();
                    dateTimePicker1.Text = kayitokuma.GetValue(5).ToString();
                    comboBox2.Text = kayitokuma.GetValue(6).ToString();
                    comboBox3.Text = kayitokuma.GetValue(7).ToString();
                    maskedTextBox4.Text = kayitokuma.GetValue(8).ToString();
                    break;
                }
                if (kayit_arama_durumu == false)
                    MessageBox.Show("Aranan kayıt bulunamadı.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Aranacak TC Kimlik No 11 karakter olmalıdır.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";

            if (maskedTextBox1.MaskCompleted == false)
                label16.ForeColor = Color.Red;
            else
                label16.ForeColor = Color.Black;
            if (maskedTextBox2.MaskCompleted == false)
                label15.ForeColor = Color.Red;
            else
                label15.ForeColor = Color.Black;
            if (maskedTextBox3.MaskCompleted == false)
                label14.ForeColor = Color.Red;
            else
                label14.ForeColor = Color.Black;
            if (maskedTextBox4.Text.Length < 3)
                label21.ForeColor = Color.Red;
            else
                label21.ForeColor = Color.Black;
            if (comboBox1.Text == "")
                label17.ForeColor = Color.Red;
            else
                label17.ForeColor = Color.Black;
            if (comboBox2.Text == "")
                label19.ForeColor = Color.Red;
            else
                label19.ForeColor = Color.Black;
            if (comboBox3.Text == "")
                label20.ForeColor = Color.Red;
            else
                label20.ForeColor = Color.Black;

            if (maskedTextBox1.MaskCompleted == true && maskedTextBox2.MaskCompleted == true && maskedTextBox3.MaskCompleted == true && maskedTextBox4.Text.Length > 2 && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                if (radioButton3.Checked == true)
                    cinsiyet = "Erkek";
                else if (radioButton4.Checked == true)
                    cinsiyet = "Kadın";
                try
                {
                    baglanti.Open();
                    OleDbCommand guncellekomutu = new OleDbCommand("update personeller set ad='" + maskedTextBox2.Text.ToUpper() + "',soyad='" + maskedTextBox3.Text.ToUpper() + "',cinsiyet='" + cinsiyet + "',mezuniyet='" + comboBox1.Text + "',dogumtarihi='" + dateTimePicker1.Text + "',gorevi='" + comboBox2.Text + "',gorevyeri='" + comboBox3.Text + "',maasi='" + maskedTextBox4.Text + "' where tcno='" + maskedTextBox1.Text + "'", baglanti);
                    guncellekomutu.ExecuteNonQuery();
                    baglanti.Close();
                    if (!Directory.Exists(Application.StartupPath + "\\personelresimler"))
                        Directory.CreateDirectory(Application.StartupPath + "\\personelresimler");
                    if (resimsecme1 == 1)
                    {

                        myfile1.Dispose();

                        File.Delete(Application.StartupPath + "\\personelresimler\\" + maskedTextBox1.Text + ".jpg");

                        pictureBox2.Image.Save(Application.StartupPath + "\\personelresimler\\" + maskedTextBox1.Text + ".jpg");
                        resimsecme1 = 0;
                    }
                    else if (resimsecme1 == 0)
                        myfile1.Dispose();
                    MessageBox.Show("Personel bilgileri Güncellendi.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    personelleri_goster();

                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }

            }
            else
                MessageBox.Show("Lütfen kırmızı alanları yeniden gözden geçirin.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted == true)
            {
                bool kayit_arama_durumu = false;
                baglanti.Open();
                OleDbCommand arama_sorgusu = new OleDbCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = arama_sorgusu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    OleDbCommand deletesorgu = new OleDbCommand("delete from personeller where tcno='" + maskedTextBox1.Text + "'", baglanti);
                    deletesorgu.ExecuteNonQuery();
                    myfile1.Dispose();
                    File.Delete(Application.StartupPath + "\\personelresimler\\" + maskedTextBox1.Text + ".jpg");
                    MessageBox.Show("Personel kaydı silindi.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabpage2_temizle();

                    break;

                }
                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Girilen TC Kimlik No 11 karakter olmalıdır.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
            baglanti.Close();
            personelleri_goster();

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
            dataGridView2.ClearSelection();

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = this.dataGridView2.SelectedRows.Count <= 0;

        }

        private void contextMenuStrip2_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                int satir = dataGridView2.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    dataGridView2.Rows[satir].Selected = true;
                    dataGridView2.CurrentCell = dataGridView2.Rows[satir].Cells[0];
                }
                else if (dataGridView2.SelectedRows.Count > 0)
                    dataGridView2.ClearSelection();
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (dataGridView2.SelectedRows.Count > 0)
                    dataGridView2.ClearSelection();
            }
        }

        private void contextMenuStrip2_MouseUp(object sender, MouseEventArgs e)
        {
            dataGridView2.ClearSelection();

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                bilgileriGetirToolStripMenuItem1.PerformClick();
            }
            else
                button10.PerformClick();
        }

        private void bilgileriPGetirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Enabled = false;
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                try
                {
                    myfile1 = pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\personelresimler\\" + kayitokuma.GetValue(0).ToString() + ".jpg");
                }
                catch (Exception)
                {
                    myfile1 = pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + "resimyok.jpg");
                }
                maskedTextBox1.Enabled = false;
                maskedTextBox1.Text = kayitokuma.GetValue(0).ToString();
                maskedTextBox2.Text = kayitokuma.GetValue(1).ToString();
                maskedTextBox3.Text = kayitokuma.GetValue(2).ToString();
                if (kayitokuma.GetValue(3).ToString() == "Erkek")
                    radioButton3.Checked = true;
                else if (kayitokuma.GetValue(3).ToString() == "Kadın")
                    radioButton4.Checked = true;
                comboBox1.Text = kayitokuma.GetValue(4).ToString();
                dateTimePicker1.Text = kayitokuma.GetValue(5).ToString();
                comboBox2.Text = kayitokuma.GetValue(6).ToString();
                comboBox3.Text = kayitokuma.GetValue(7).ToString();
                maskedTextBox4.Text = kayitokuma.GetValue(8).ToString();
                break;
            }
            baglanti.Close();
        }


        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "'", baglanti);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {

                OleDbCommand deletesorgu = new OleDbCommand("delete from personeller where tcno='" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "'", baglanti);
                deletesorgu.ExecuteNonQuery();
                File.Delete(Application.StartupPath + "\\personelresimler\\" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + ".jpg");
                MessageBox.Show("Personel kaydı silindi.", "T.A Personel Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;
            }
            baglanti.Close();
            personelleri_goster();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            button13.PerformClick();
            e.Cancel = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            label25.Text = ((Convert.ToString(saat) + ":") + (Convert.ToString(dakika) + ":") + Convert.ToString(saniye));
            if ((saniye == 59))
            {
                saniye = 0;
                dakika++;
                if (dakika == 60)
                {
                    saniye = 0;
                    dakika = 0;
                    saat++;
                }
            }
        }
    }
}

