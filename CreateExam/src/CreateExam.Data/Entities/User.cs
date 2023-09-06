using System.ComponentModel.DataAnnotations;

namespace CreateExam.Data.Entities
{
	public class User
	{
		[Key]
		public int UserID { get; set; }

		[StringLength(30)]
		public string UserName { get; set; }

		[StringLength(30)]
		public string Password { get; set; }
	}
}
