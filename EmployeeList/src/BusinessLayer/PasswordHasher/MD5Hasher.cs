using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.PasswordHasher
{
	public static class MD5Hasher
	{
		public static string Hash(string hashingPassword)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

			byte[] array = Encoding.UTF8.GetBytes(hashingPassword);
			array = md5.ComputeHash(array);

			StringBuilder sb = new StringBuilder();

			foreach (byte item in array)
			{
				sb.Append(item.ToString("x2").ToLower());
			}
			return sb.ToString();
		}

	}
}

