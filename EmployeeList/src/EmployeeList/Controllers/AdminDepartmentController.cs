using BusinessLayer.ValidationRules;
using EmployeeListDAL.Context;
using EntityLayer;
using FluentValidation.Results;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeList.Controllers
{
	[Authorize]
	public class AdminDepartmentController : Controller
	{
		Context _context = new Context();
		DepartmentValidator _validator = new DepartmentValidator();


		public ActionResult Index()
		{
			var values = _context.Departments.ToList();
			return View(values);
		}

		public ActionResult Remove(int id)
		{
			var department = _context.Departments.FirstOrDefault(x => x.DepartmentID == id);
			if (department.Employees.Count > 0)
			{
				TempData["departmentMessage"] = "Bu departmanda çalışan personeller bulunduğu için silinemez.";
				return RedirectToAction("Index");
			}

			_context.Departments.Remove(department);
			_context.SaveChanges();

			TempData["departmentMessage"] = "Departman başarıyla silindi.";
			return RedirectToAction("Index");
		}

		public ActionResult Edit(int id)
		{
			var values = _context.Departments.FirstOrDefault(x => x.DepartmentID == id);
			return View(values);
		}

		[HttpPost]
		public ActionResult Edit(Department p)
		{
			ValidationResult results = _validator.Validate(p);

			if (!results.IsValid)
			{
				foreach (var error in results.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					return View(p);
				}
			}

			var department = _context.Departments.FirstOrDefault(x => x.DepartmentID == p.DepartmentID);
			department.DepartmentName = p.DepartmentName;
			_context.SaveChanges();

			TempData["departmentMessage"] = "Departman başarıyla güncellendi.";
			return RedirectToAction("Index");
		}

		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(Department p)
		{
			ValidationResult results = _validator.Validate(p);

			if (!results.IsValid)
			{
				foreach (var error in results.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					return View(p);
				}
			}

			_context.Departments.Add(p);
			_context.SaveChanges();

			TempData["departmentMessage"] = "Departman başarıyla eklendi.";
			return RedirectToAction("Index");

		}

	}
}