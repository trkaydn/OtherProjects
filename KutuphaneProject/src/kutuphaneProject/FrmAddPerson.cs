using System;
using System.Windows.Forms;

namespace kutuphaneProject
{
	public partial class FrmAddPerson : Form
	{
		SqlClass _sqlClass = new SqlClass();
		public bool control = false;

		public FrmAddPerson()
		{
			InitializeComponent();
		}

		private void FrmAddStudent_Load(object sender, EventArgs e)
		{
			this.Text = "Üye Ekleme";

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (txtAd.Text == "" || txtSoyad.Text == "" || txtSoyad.Text == "")
			{
				MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			control = _sqlClass.uye_ekle(new Person
			{
				Ad = txtAd.Text,
				Soyad = txtSoyad.Text,
				Meslek = txtMeslek.Text,
			});

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
