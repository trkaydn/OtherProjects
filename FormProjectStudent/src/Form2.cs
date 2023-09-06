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

namespace FormProject4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        DialogResult iptal;
        public void kayitiptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcyaz_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void adyaz_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void soyadyaz_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void ogrencinoyaz_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        DialogResult basari = new DialogResult();
        public void kayitonay_Click(object sender, EventArgs e)
        {
            try
            {
                string cins = "bilinmiyor";
                if (erkek.Checked == true)
                    cins = erkek.Text;
                else if (kadin.Checked == true)
                    cins = kadin.Text;

                string sinif = "";
                if (sinif9.Checked == true)
                    sinif = "9";
                else if (sinif10.Checked == true)
                    sinif = "10";
                else if (sinif11.Checked == true)
                    sinif = "11";
                else if (sinif12.Checked == true)
                    sinif = "12";

                string sube = "";
                if (subea.Checked == true)
                    sube = "A";
                else if (subeb.Checked == true)
                    sube = "B";
                else if (subec.Checked == true)
                    sube = "C";
                else if (subed.Checked == true)
                    sube = "D";
                else if (subee.Checked == true)
                    sube = "E";
                else if (subef.Checked == true)
                    sube = "F";

                if (tcyaz.Text == "" || adyaz.Text == "" || soyad.Text == "" || cins == "" || ogrencinoyaz.Text == "" || sinif == "" || sube == "" || tcyaz.Text.Length < 11 || adyaz.Text.Length < 3 || soyad.Text.Length < 2)
                    MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else

                {
                    using (StreamReader reader = new StreamReader(Form1.gonder))
                    {


                        string[] bilgiler = new string[5];
                        while (reader.Peek() != -1)
                        {
                            char ayrac = ',';
                            bilgiler = reader.ReadLine().Split(ayrac);


                            if (bilgiler[0].Contains(tcyaz.Text) == true)
                            {
                                MessageBox.Show("Girilen TC numarası sistemde zaten kayıtlı.", "Kayıt Bulundu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (bilgiler[4].Contains(ogrencinoyaz.Text) == true)
                            {
                                MessageBox.Show("Girilen öğrenci numarası sistemde zaten kayıtlı.", "Kayıt Bulundu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                    }

                    using (StreamWriter yaz = new StreamWriter(Form1.gonder, true))
                    {
                        yaz.WriteLine(tcyaz.Text + "," + adyaz.Text + "," + soyadyaz.Text + "," + cins + "," + ogrencinoyaz.Text + "," + sinif + "-" + sube);

                        basari = MessageBox.Show("Kayıt İşlemi Başarıyla Tamamlandı.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }

        }

  
        public void Form2_FormClosing(object sender, CancelEventArgs e)
        {

            if (iptal == DialogResult.Yes)
                e.Cancel = false;
            else if (basari == DialogResult.OK)
                e.Cancel = false;
            else
            {
                DialogResult iptal2 = MessageBox.Show("Kayıt işlemini iptal etmek istediğinizden emin misiniz?", "İşlem İptal Edilmek Üzere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (iptal2 == DialogResult.Yes)
                    e.Cancel = false;
                else if (iptal2 == DialogResult.No)
                    e.Cancel = true;
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            tcyaz.ShortcutsEnabled = false;
            adyaz.ShortcutsEnabled = false;
            soyadyaz.ShortcutsEnabled = false;
            ogrencinoyaz.ShortcutsEnabled = false;

        }


        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
             this.Close(); 
        }

     
    }


}

