using System;
using System.Windows.Forms;

namespace kutuphaneProject
{
	public partial class FrmAddBook : Form
	{
		SqlClass _sqlClass = new SqlClass();
		public bool control = false;
		public FrmAddBook()
		{
			InitializeComponent();
		}

		private void FrmAddBook_Load(object sender, EventArgs e)
		{
			this.Text = "Kitap Ekleme";
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (txtkitapadi.Text == "" || txtSayfa.Value == 0 || txtyazar.Text == "" || txttur.Text == "")
			{
				MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			control = _sqlClass.kitap_ekle(new Book
			{
				KitapAdi = txtkitapadi.Text,
				Yazar = txtyazar.Text,
				Tur = txttur.Text,
				Sayfa = (int)txtSayfa.Value,
				Uygunluk = checkUygunluk.Checked
			});

			if (control)
			{
				this.Close();
				this.Dispose();
			}
		}
	}
}
