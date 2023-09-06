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
    public partial class frmDuzenle : Form
    {
        public frmDuzenle()
        {
            InitializeComponent();
        }
     

        private void frmDuzenle_Load(object sender, EventArgs e)
        {
            tcyaz.ShortcutsEnabled = false;
            adyaz.ShortcutsEnabled = false;
            soyadyaz.ShortcutsEnabled = false;
            ogrencinoyaz.ShortcutsEnabled = false;
            
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

        private void kayitonay_Click(object sender, EventArgs e)
        {
            Form1 sahip = (Form1)this.Owner;

            DialogResult cevap = MessageBox.Show("Öğrenci bilgileri güncellenecektir. Devam etmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {

                sahip.tablo.SelectedRows[0].Cells[0].Value = tcyaz.Text;
                sahip.tablo.SelectedRows[0].Cells[1].Value = adyaz.Text;
                sahip.tablo.SelectedRows[0].Cells[2].Value = soyadyaz.Text;

                if (erkek.Checked == true)
                    sahip.tablo.SelectedRows[0].Cells[3].Value = "Erkek";
                else if (kadin.Checked == true)
                    sahip.tablo.SelectedRows[0].Cells[3].Value = "Kadın";

                sahip.tablo.SelectedRows[0].Cells[4].Value = ogrencinoyaz.Text;

                string sinif = "";
                string sube = "";

                if (sinif9.Checked == true)
                    sinif = "9";
                else if (sinif10.Checked == true)
                    sinif = "10";
                else if (sinif11.Checked == true)
                    sinif = "11";
                else
                    sinif = "12";

                if (subea.Checked == true)
                    sube = "A";
                else if (subeb.Checked == true)
                    sube = "B";
                else if (subec.Checked == true)
                    sube = "C";
                if (subed.Checked == true)
                    sube = "D";
                else if (subee.Checked == true)
                    sube = "E";
                else if (subef.Checked == true)
                    sube = "F";

                if (tcyaz.Text == "" || adyaz.Text == "" || soyad.Text == "" || ogrencinoyaz.Text == "" || sinif == "" || sube == "" || tcyaz.Text.Length < 11 || adyaz.Text.Length < 3 || soyad.Text.Length < 2)
                    MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    sahip.tablo.SelectedRows[0].Cells[5].Value = sinif + "-" + sube;

                    string filePath = sahip.textopen.FileName;
                    sahip.dosyakonum.Text = filePath;


                    using (StreamWriter yaz = new StreamWriter(filePath, false))
                    {

                        for (int i = 0; i < sahip.tablo.Rows.Count; i++)
                        {
                            for (int j = 0; j < sahip.tablo.Columns.Count; j++)
                            {
                                yaz.Write(sahip.tablo.Rows[i].Cells[j].Value.ToString() + ",");
                            }
                            yaz.WriteLine("");
                        }
                    }
                    basari = MessageBox.Show("Güncelleme işlemi başarıyla başarıyla tamamlandı.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    

                }



            }
        }
        DialogResult iptal2;
        DialogResult basari;
        int abc = 0;
        private void frmDuzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (abc==1)
                return;
            else if (basari == DialogResult.OK)
                e.Cancel = false;
            else
            {
                DialogResult iptal2 = MessageBox.Show("Güncelleme işlemini iptal etmek istediğinizden emin misiniz?", "İşlem İptal Edilmek Üzere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (iptal2 == DialogResult.Yes)
                {
                    e.Cancel = false;
                    abc = 1;
                 }
                else if (iptal2 == DialogResult.No)
                    e.Cancel = true;
            }


        }

        private void kayitiptal_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void frmDuzenle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
                kayitonay.PerformClick();
        }
    }
}

