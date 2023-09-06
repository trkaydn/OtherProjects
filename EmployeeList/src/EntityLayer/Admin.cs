using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
	public class Admin
	{
		[Key]
		public int AdminID { get; set; }

		[StringLength(25)]
		public string FirstName { get; set; }

		[StringLength(25)]
		public string LastName { get; set; }

		[StringLength(25)]
		public string MailAddress { get; set; }

		public string Password { get; set; }
	}
}
