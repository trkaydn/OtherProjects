using System;
using System.Windows.Forms;

namespace kutuphaneProject
{
	public partial class FrmEditPerson : Form
	{
		SqlClass _sqlClass = new SqlClass();
		public bool control = false;

		public FrmEditPerson()
		{
			InitializeComponent();
		}

		private void FrmEditPerson_Load(object sender, EventArgs e)
		{
			this.Text = "Üye Güncelleme";
			var person = _sqlClass.uye_getir(Otomasyon._UpdatingItemId);
			txtAd.Text = person.Ad;
			txtSoyad.Text = person.Soyad;
			txtMeslek.Text = person.Meslek;
			txtPuan.Value = person.CezaPuani;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (txtAd.Text == "" || txtSoyad.Text == "" || txtMeslek.Text == "")
			{
				MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			control = _sqlClass.uye_guncelle(new Person
			{
				ID = Otomasyon._UpdatingItemId,
				Ad = txtAd.Text,
				Soyad = txtSoyad.Text,
				Meslek = txtMeslek.Text,
				CezaPuani = (int)txtPuan.Value,
			});

			if (control)
			{
				this.Close();
				this.Dispose();
			}
		}
	}
}
