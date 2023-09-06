using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
	public class Photo
	{
		[Key]
		public int PhotoID { get; set; }

		[Required]
		public int EmployeeID { get; set; }

		[Required]
		public string FilePath { get; set; }

		public virtual Employee Emplooyee { get; set; }
	}
}
