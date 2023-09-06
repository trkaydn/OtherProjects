using EmployeeListDAL.Context;
using EmployeeListUI.CustomAttributes;
using EntityLayer;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeListUI.Controllers
{
	public class HomeController : Controller
	{
		Context _context = new Context();

		public ActionResult Index()
		{
			var values = _context.Employees.ToList();
			return View(values);
		}

		[ChildAndAjaxOnly]
		public PartialViewResult EmployeeDetail(int? id)
		{
			Employee employee = null;

			if (id != null)
				employee = _context.Employees.FirstOrDefault(x => x.EmployeeID == id);

			return PartialView(employee);
		}

		public ActionResult About()
		{
			return View();
		}
	}
}