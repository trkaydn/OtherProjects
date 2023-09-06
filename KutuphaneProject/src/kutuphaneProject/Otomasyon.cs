using System;
using System.Windows.Forms;

namespace kutuphaneProject
{
	public partial class Otomasyon : Form
	{
		SqlClass _sqlClass = new SqlClass();
		public static int _UpdatingItemId;
		public Otomasyon()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.Text = "Kütüphane Otomasyonu";
			RefreshBooks();
			RefreshPersons();
			RefreshTakip();
		}
		private void btnDeleteBook_Click(object sender, EventArgs e)
		{
			if (dataGridViewBooks.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Silmek için bir kitap seçiniz!");
				return;
			}

			int id = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);

			if (_sqlClass.veri_sil("tblKitaplar", id))
				MessageBox.Show("Kitap başarıyla silindi.");

			dataGridViewBooks.DataSource = _sqlClass.veri_listele("tblKitaplar",null);

		}

		private void btnAddBook_Click(object sender, EventArgs e)
		{
			FrmAddBook form = new FrmAddBook();
			form.ShowDialog();
			if (form.control)
				MessageBox.Show("Kitap başarıyla eklendi.");

			RefreshBooks();
		}
		private void btnEditBook_Click(object sender, EventArgs e)
		{
			if (dataGridViewBooks.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Düzenlemek için bir kitap seçiniz!");
				return;
			}

			_UpdatingItemId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value);
			FrmEditBook form = new FrmEditBook();
			form.ShowDialog();

			if (form.control)
				MessageBox.Show("Kitap başarıyla güncellendi.");

			RefreshBooks();
		}

		private void btnDeleteStudent_Click(object sender, EventArgs e)
		{
			if (dataGridViewPersons.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Silmek için bir üye seçiniz!");
				return;
			}

			int id = Convert.ToInt32(dataGridViewPersons.SelectedRows[0].Cells[0].Value);

			if (_sqlClass.veri_sil("tblUyeler", id))
				MessageBox.Show("Öğrenci başarıyla silindi.");

			dataGridViewPersons.DataSource = _sqlClass.veri_listele("tblUyeler", null);
		}

		private void btnAddStudent_Click(object sender, EventArgs e)
		{
			FrmAddPerson form = new FrmAddPerson();
			form.ShowDialog();

			if (form.control)
				MessageBox.Show("Üye başarıyla eklendi.");

			RefreshPersons();

		}

		private void btnEditPerson_Click(object sender, EventArgs e)
		{
			if (dataGridViewPersons.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Düzenlemek için bir üye seçiniz!");
				return;
			}

			_UpdatingItemId = Convert.ToInt32(dataGridViewPersons.SelectedRows[0].Cells[0].Value);
			FrmEditPerson form = new FrmEditPerson();
			form.ShowDialog();
			if (form.control)
				MessageBox.Show("Üye başarıyla güncellendi.");

			RefreshPersons();
		}
		private void btnTeslimAl_Click(object sender, EventArgs e)
		{
			if (dataGridTakip.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Teslim almak için bir kayıt seçiniz!");
				return;
			}
			if (dataGridTakip.SelectedRows[0].Cells[5].Value.ToString() != "Henüz Teslim Edilmedi")
			{
				MessageBox.Show("Bu kitap zaten teslim alınmış");
				return;
			}
				
			_UpdatingItemId = Convert.ToInt32(dataGridTakip.SelectedRows[0].Cells[0].Value);
			bool control = _sqlClass.teslim_al(_UpdatingItemId);

			if (control)
			{
				int result = _sqlClass.ceza_puani_ekle(_UpdatingItemId);
				MessageBox.Show("Kitap teslim alındı. " + (result == 2 ? "10 ceza puanı eklendi." : "Teslim zamanında yapıldı."));
			}
			RefreshTakip();
			RefreshBooks();
			RefreshPersons();
		}
		private void btnDeleteTakip_Click(object sender, EventArgs e)
		{
			if (dataGridTakip.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Teslim almak için bir kayıt seçiniz!");
				return;
			}
			bool control = _sqlClass.veri_sil("tblTakip",Convert.ToInt32(dataGridTakip.SelectedRows[0].Cells[0].Value));
			if (control)
			{
				MessageBox.Show("Kayıt Silindi.");
			}
			RefreshTakip();

		}
		private void btnTeslimEt_Click(object sender, EventArgs e)
		{
			FrmGiveBook form = new FrmGiveBook();
			form.ShowDialog();

			if (form.control)
				MessageBox.Show("Kitap teslim edildi.");

			RefreshTakip();
			RefreshBooks();
		}
		private void RefreshBooks()
		{
			dataGridViewBooks.DataSource = _sqlClass.veri_listele("tblKitaplar",null);
		}
		private void RefreshPersons()
		{
			dataGridViewPersons.DataSource = _sqlClass.veri_listele("tblUyeler",null);
		}
		private void RefreshTakip()
		{
			dataGridTakip.DataSource = _sqlClass.takip_listele();
		}
		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
		private void btnExit2_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
		private void btnExit3_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
	}
}
