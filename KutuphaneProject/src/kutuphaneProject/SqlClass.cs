using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace kutuphaneProject
{
	public class SqlClass
	{
		public static string _conString = "Data Source=TARIK-PC;Initial Catalog = kutuphane; Integrated Security = True";
		SqlConnection connection = new SqlConnection(_conString);
		public DataTable veri_listele(string tablename, string where)
		{
			try
			{
				connection.Open();
				SqlDataAdapter veri_listele = new SqlDataAdapter("select * from " + tablename + (!string.IsNullOrEmpty(where) ? " where " + where : "" ) + " order by ID asc", connection);
				DataTable dshafiza = new DataTable();
				veri_listele.Fill(dshafiza);
				connection.Close();
				return dshafiza;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return null;
			}

		}
		public DataTable takip_listele()
		{
			try
			{
				connection.Open();
				SqlDataAdapter takip_listele = new SqlDataAdapter("select t.ID as 'Takip No', (u.Ad + ' ' + u.Soyad) as 'ÜyeAdi', k.KitapAdi, convert(varchar, t.AlimTarihi, 104) as 'AlimTarihi', convert(varchar, t.TeslimTarihi, 104) as TeslimTarihi, case when t.GeldigiTarih is null then 'Henüz Teslim Edilmedi' else convert(varchar, t.GeldigiTarih, 104)  end as 'GeldigiTarih' from tblTakip t inner join tblUyeler u on u.ID = t.UyeID inner join tblKitaplar k on k.ID = t.KitapID order by t.GeldigiTarih asc", connection);
				DataTable dshafiza = new DataTable();
				takip_listele.Fill(dshafiza);
				connection.Close();

				return dshafiza;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return null;
			}

		}
		public bool teslim_al(int id)
		{
			try
			{
				connection.Open();
				SqlCommand updateCmd = new SqlCommand("update tblTakip set GeldigiTarih = '" + DateTime.Now + "' where ID =" + id, connection);
				updateCmd.ExecuteNonQuery();
				connection.Close();

				return true;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return false;
			}

		}
		public bool teslim_et(int bookId, int personId, string date)
		{
			try
			{
				connection.Open();
				SqlCommand addCmd = new SqlCommand("insert into tblTakip (UyeID,KitapID,TeslimTarihi,AlimTarihi) values (@p1,@p2,@p3,GETDATE())", connection);
				addCmd.Parameters.AddWithValue("@p1", personId);
				addCmd.Parameters.AddWithValue("@p2", bookId);
				addCmd.Parameters.AddWithValue("@p3", date);
				addCmd.ExecuteNonQuery();

				SqlCommand uygunDegilYap = new SqlCommand("update tblKitaplar set Uygunluk = 0 where ID =" + bookId, connection);
				uygunDegilYap.ExecuteNonQuery();

				connection.Close();
				return true;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return false;
			}

		}

		public int ceza_puani_ekle(int id)
		{
			try
			{
				connection.Open();
				SqlCommand tarihkontrol = new SqlCommand("select t.UyeID, t.TeslimTarihi, t.KitapID from tblTakip t where t.ID=" + id, connection);
				SqlDataReader reader = tarihkontrol.ExecuteReader();
				int uyeid = 0, kitapid = 0;
				DateTime teslimtarihi = DateTime.Now;
				while (reader.Read())
				{
					uyeid = Convert.ToInt32(reader[0]);
					teslimtarihi = Convert.ToDateTime(reader[1]);
					kitapid = Convert.ToInt32(reader[2]);
				}
				reader.Close();

				SqlCommand uygunYap = new SqlCommand("update tblKitaplar set Uygunluk = 1 where ID =" + kitapid, connection);
				uygunYap.ExecuteNonQuery();

				int result = 1;

				if (teslimtarihi.Date < DateTime.Now.Date)
				{
					SqlCommand cezaEkle = new SqlCommand("update tblUyeler set CezaPuani += 10 where ID =" + uyeid, connection);
					cezaEkle.ExecuteNonQuery();
					result = 2;
				}

				connection.Close();
				return result;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return 0;
			}
		}
		public bool veri_sil(string tablename, int id)
		{
			try
			{
				connection.Open();
				SqlCommand deleteCmd = new SqlCommand("delete from " + tablename + " where ID=" + id, connection);
				deleteCmd.ExecuteNonQuery();
				connection.Close();
				return true;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return false;
			}
		}
		public bool kitap_ekle(Book book)
		{
			try
			{
				connection.Open();
				SqlCommand insertCmd = new SqlCommand("insert into tblKitaplar(KitapAdi,Yazar,Tur,Sayfa,Uygunluk) values (@p1,@p2,@p3,@p4,@p5)", connection);
				insertCmd.Parameters.AddWithValue("@p1", book.KitapAdi);
				insertCmd.Parameters.AddWithValue("@p2", book.Yazar);
				insertCmd.Parameters.AddWithValue("@p3", book.Tur);
				insertCmd.Parameters.AddWithValue("@p4", book.Sayfa);
				insertCmd.Parameters.AddWithValue("@p5", book.Uygunluk);
				insertCmd.ExecuteNonQuery();
				connection.Close();
				return true;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return false;
			}
		}
		public bool uye_ekle(Person person)
		{
			try
			{
				connection.Open();
				SqlCommand insertCmd = new SqlCommand("insert into tblUyeler(Ad,Soyad,Meslek,CezaPuani) values (@p1,@p2,@p3,@p4)", connection);
				insertCmd.Parameters.AddWithValue("@p1", person.Ad);
				insertCmd.Parameters.AddWithValue("@p2", person.Soyad);
				insertCmd.Parameters.AddWithValue("@p3", person.Meslek);
				insertCmd.Parameters.AddWithValue("@p4", 0);
				insertCmd.ExecuteNonQuery();
				connection.Close();
				return true;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return false;
			}
		}
		public bool kitap_guncelle(Book book)
		{
			try
			{
				connection.Open();
				SqlCommand updateCmd = new SqlCommand("update tblKitaplar set KitapAdi = @p1, Yazar = @p2,Tur = @p3,Sayfa = @p4 ,Uygunluk = @p5 where ID = @p6", connection);
				updateCmd.Parameters.AddWithValue("@p1", book.KitapAdi);
				updateCmd.Parameters.AddWithValue("@p2", book.Yazar);
				updateCmd.Parameters.AddWithValue("@p3", book.Tur);
				updateCmd.Parameters.AddWithValue("@p4", book.Sayfa);
				updateCmd.Parameters.AddWithValue("@p5", book.Uygunluk);
				updateCmd.Parameters.AddWithValue("@p6", book.ID);
				updateCmd.ExecuteNonQuery();
				connection.Close();
				return true;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return false;
			}
		}
		public bool uye_guncelle(Person person)
		{
			try
			{
				connection.Open();
				SqlCommand updateCmd = new SqlCommand("update tblUyeler set Ad = @p1, Soyad = @p2,Meslek = @p3,Cezapuani = @p4 where ID = @p5", connection);
				updateCmd.Parameters.AddWithValue("@p1", person.Ad);
				updateCmd.Parameters.AddWithValue("@p2", person.Soyad);
				updateCmd.Parameters.AddWithValue("@p3", person.Meslek);
				updateCmd.Parameters.AddWithValue("@p4", person.CezaPuani);
				updateCmd.Parameters.AddWithValue("@p5", person.ID);
				updateCmd.ExecuteNonQuery();
				connection.Close();
				return true;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return false;
			}
		}
		public Book kitap_getir(int id)
		{
			try
			{
				connection.Open();
				SqlCommand bookdetail = new SqlCommand("select * from  tblKitaplar where id=" + id, connection);
				SqlDataReader reader = bookdetail.ExecuteReader();
				Book book = new Book();
				while (reader.Read())
				{
					book.ID = (int)reader[0];
					book.KitapAdi = reader[1].ToString();
					book.Yazar = reader[2].ToString();
					book.Tur = reader[3].ToString();
					book.Sayfa = (int)reader[4];
					book.Uygunluk = Convert.ToBoolean(reader[5]);

				}
				reader.Close();
				connection.Close();
				return book;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return null;
			}
		}
		public Person uye_getir(int id)
		{
			try
			{
				connection.Open();
				SqlCommand bookdetail = new SqlCommand("select * from  tblUyeler where id=" + id, connection);
				SqlDataReader reader = bookdetail.ExecuteReader();
				Person person = new Person();
				while (reader.Read())
				{
					person.ID = (int)reader[0];
					person.Ad = reader[1].ToString();
					person.Soyad = reader[2].ToString();
					person.Meslek = reader[3].ToString();
					person.CezaPuani = (int)reader[4];

				}
				reader.Close();
				connection.Close();
				return person;
			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message, "Kütüphane Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connection.Close();
				return null;
			}
		}

	}
}
