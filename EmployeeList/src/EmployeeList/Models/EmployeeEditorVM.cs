using EntityLayer;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace EmployeeListUI.Models
{
	public class EmployeeEditorVM
	{
		public Employee Employee { get; set; }

		public IEnumerable<SelectListItem> Departments { get; set; }

		public IEnumerable<SelectListItem> Employees { get; set; }

		public List<HttpPostedFileBase> Photos { get; set; }
	}
}