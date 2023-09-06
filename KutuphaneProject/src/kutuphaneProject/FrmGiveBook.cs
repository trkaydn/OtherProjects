using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace kutuphaneProject
{
	public partial class FrmGiveBook : Form
	{
		SqlClass _sqlClass = new SqlClass();
		public bool control = false;
		Dictionary<int, string> bookList = new Dictionary<int, string>();
		Dictionary<int, string> personList = new Dictionary<int, string>();
		public FrmGiveBook()
		{
			InitializeComponent();
		}

		private void FrmGiveBook_Load(object sender, EventArgs e)
		{
			this.Text = "Kitap Teslim Et";
			dateReturn.Format = DateTimePickerFormat.Custom;
			dateReturn.MinDate = DateTime.Now;
			dateReturn.CustomFormat = "dd.MM.yyyy";

			var books = _sqlClass.veri_listele("tblKitaplar", "Uygunluk = 1");
			for (int i = 0; i < books.Rows.Count; i++)
			{
				bookList.Add((int)books.Rows[i].ItemArray[0], books.Rows[i].ItemArray[1].ToString());
				cmbBook.Items.Add(books.Rows[i].ItemArray[1]);
			}

			var persons = _sqlClass.veri_listele("tblUyeler", null);
			for (int i = 0; i < persons.Rows.Count; i++)
			{
				personList.Add((int)persons.Rows[i].ItemArray[0], persons.Rows[i].ItemArray[1] + " " + persons.Rows[i].ItemArray[2]);
				cmbPerson.Items.Add(persons.Rows[i].ItemArray[1] + " " + persons.Rows[i].ItemArray[2]);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cmbBook.Text) || string.IsNullOrEmpty(cmbPerson.Text))
			{
				MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			int kitapId = bookList.FirstOrDefault(x => x.Value == cmbBook.Text).Key;
			int personId = personList.FirstOrDefault(x => x.Value == cmbPerson.Text).Key;

			var uye = _sqlClass.uye_getir(personId);
			if(uye.CezaPuani >= 50)
			{
				MessageBox.Show("Bu üyenin ceza puanı 50 ve üzeri (" + uye.CezaPuani + ") olduğu için teslim edilemez.");
				return;
			}

			control  = _sqlClass.teslim_et(kitapId, personId,dateReturn.Value.ToString());

			if (control)
			{
				this.Close();
				this.Dispose();
			}

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}


	}
}
