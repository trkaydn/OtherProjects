using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
	public class Employee
	{
		[Key]
		public int EmployeeID { get; set; }

		[Required(ErrorMessage = "İsim boş geçilemez."), StringLength(25)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Soyisim boş geçilemez."), StringLength(25)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Telefon numarası boş geçilemez."), StringLength(25)]
		public string Phone { get; set; }

		public int? DepartmentID { get; set; }

		public virtual Department Department { get; set; }

		[ForeignKey("ReportsTo")]
		public int? ReportsToID { get; set; }

		public virtual Employee ReportsTo { get; set; }

		public virtual List<Employee> ReportsFrom { get; set; }

		public DateTime? BirthDate { get; set; }

		public virtual List<Photo> Photos { get; set; }
	}
}
