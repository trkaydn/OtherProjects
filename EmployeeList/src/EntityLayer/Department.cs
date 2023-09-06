using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
	public class Department
	{
		[Key]
		public int DepartmentID { get; set; }

		[Required(ErrorMessage ="Departman adı zorunludur."), StringLength(25)]
		public string DepartmentName { get; set; }

		public virtual List<Employee> Employees { get; set; }
	}
}
