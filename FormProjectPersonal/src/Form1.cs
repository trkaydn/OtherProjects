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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Veritabanı dosya yolu ve provider nesnesinin belirlenmesi
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=personel.accdb");

        public static string tcno, adi, soyadi, yetki;

        int hak = 3;

        private void button2_Click(object sender, EventArgs e)
        {

            baglanti.Close();
            Environment.Exit(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && hak > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && hak > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
            Environment.Exit(0);
        }

        bool durum = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "T.A Personel - Giriş Yap";
            this.AcceptButton = button1;
            this.CancelButton = button2;
            label5.Text = Convert.ToString(hak);
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (hak != 0)
            {

                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar", baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {

                    if (kayitokuma["kullaniciadi"].ToString() == textBox1.Text && kayitokuma["parola"].ToString() == textBox2.Text)
                    {
                        if (kayitokuma["yetki"].ToString() == "Yönetici")
                        {
                            durum = true;
                            tcno = kayitokuma.GetValue(0).ToString();
                            adi = kayitokuma.GetValue(1).ToString();
                            soyadi = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(3).ToString();
                            this.Hide();
                            Form2 frm2 = new Form2();
                            frm2.Show();
                            break;
                        }
                        else
                        {
                            durum = true;
                            tcno = kayitokuma.GetValue(0).ToString();
                            adi = kayitokuma.GetValue(1).ToString();
                            soyadi = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(3).ToString();
                            this.Hide();
                            Form3 frm3 = new Form3();
                            frm3.Show();
                            break;
                        }
                    }
                }
                if (durum == false)
                {
                    hak--;
                    label5.Text = Convert.ToString(hak);

                    if (hak == 0)
                    {
                        button1.Enabled = false;
                        MessageBox.Show("Üç defa hatalı giriş yaptınız. Lütfen yöneticiye başvurun.", "Program Kilitlendi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                        return;
                    }

                    MessageBox.Show("Kullanıcı adı veya şifre Hatalı.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
            }

        }



    }
}
