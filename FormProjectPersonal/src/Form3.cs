using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FormProjectPersonal
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int saniye = 00, dakika = 00, saat = 00;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=personel.accdb");

        private void personelleri_goster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter personelleri_listele = new OleDbDataAdapter("select tcno AS[TC NO],ad AS[ADI],soyad AS[SOYADI],cinsiyet AS[CİNSİYET],mezuniyet AS[EĞİTİM BİLGİSİ],dogumtarihi AS[DOĞUM TARİHİ],gorevi AS[GÖREVİ],gorevyeri AS[GÖREV YERİ],maasi AS[MAAŞ (₺)] from personeller Order By ad ASC", baglanti);
                DataSet dshafiza = new DataSet();
                personelleri_listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "TA Personal Takip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (textBox1.Text.Length == 11)
            {
                label22.Text = "";
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + textBox1.Text + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\personelresimler\\" + kayitokuma.GetValue(0) + ".jpg");
                    }
                    catch (Exception)
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + "resimyok.jpg");

                    }
                    textBox2.Text = kayitokuma.GetValue(1).ToString();
                    textBox3.Text = kayitokuma.GetValue(2).ToString();
                    textBox4.Text = kayitokuma.GetValue(3).ToString();
                    textBox7.Text = kayitokuma.GetValue(4).ToString();
                    textBox5.Text = kayitokuma.GetValue(5).ToString();
                    textBox6.Text = kayitokuma.GetValue(6).ToString();
                    textBox8.Text = kayitokuma.GetValue(7).ToString();
                    textBox9.Text = kayitokuma.GetValue(8).ToString();
                    textBox1.Enabled = false;
                    break;
                }
                if (kayit_arama_durumu == false)
                    label22.Text = "Aranan kayıt bulunamadı.";
                baglanti.Close();
            }
            else
                label22.Text = "Aranacak TC Kimlik No 11 karakter olmalıdır.";


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label22.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label22.Text = "";
            dataGridView1.ClearSelection();
            textBox1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + "resimyok.jpg");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                label22.Text = "";
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\personelresimler\\" + kayitokuma.GetValue(0) + ".jpg");
                    }
                    catch (Exception)
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + "resimyok.jpg");

                    }
                    textBox1.Enabled = false;
                    textBox1.Text = kayitokuma.GetValue(0).ToString();
                    textBox2.Text = kayitokuma.GetValue(1).ToString();
                    textBox3.Text = kayitokuma.GetValue(2).ToString();
                    textBox4.Text = kayitokuma.GetValue(3).ToString();
                    textBox7.Text = kayitokuma.GetValue(4).ToString();
                    textBox5.Text = kayitokuma.GetValue(5).ToString();
                    textBox6.Text = kayitokuma.GetValue(6).ToString();
                    textBox8.Text = kayitokuma.GetValue(7).ToString();
                    textBox9.Text = kayitokuma.GetValue(8).ToString();
                    textBox1.Enabled = false;
                    break;
                }
                baglanti.Close();

            }

            else
            {
                dataGridView1.ClearSelection();
                button1.PerformClick();
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
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

        private void Form3_Load(object sender, EventArgs e)
        {
            label26.Text = DateTime.Now.ToString("dd MMMM yyyy ddd");
            personelleri_goster();
            label12.ForeColor = Color.DarkRed;
            label12.Text = Form1.adi + " " + Form1.soyadi;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            dataGridView1.ClearSelection();
            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg");
            }
            catch (Exception)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + "resimyok.jpg");
            }

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
