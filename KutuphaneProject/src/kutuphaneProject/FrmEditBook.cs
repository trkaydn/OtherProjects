using System;
using System.Windows.Forms;

namespace kutuphaneProject
{
	public partial class FrmEditBook : Form
	{
		SqlClass _sqlClass = new SqlClass();
		public bool control = false;
		public FrmEditBook()
		{
			InitializeComponent();
		}

		private void FrmEditBook_Load(object sender, EventArgs e)
		{
			this.Text = "Kitap Düzenleme";
			var book = _sqlClass.kitap_getir(Otomasyon._UpdatingItemId);
			txtkitapadi.Text = book.KitapAdi;
			txtSayfa.Value = book.Sayfa;
			txttur.Text = book.Tur;
			txtyazar.Text = book.Yazar;
			checkUygunluk.Checked = book.Uygunluk;
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

			control = _sqlClass.kitap_guncelle(new Book
			{
				ID = Otomasyon._UpdatingItemId,
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
