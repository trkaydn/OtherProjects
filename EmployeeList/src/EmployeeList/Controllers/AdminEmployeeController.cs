using BusinessLayer.ValidationRules;
using EmployeeListUI.Models;
using EmployeeListDAL.Context;
using FluentValidation.Results;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using EntityLayer;
using System.Drawing;
using EmployeeListUI.CustomAttributes;

namespace EmployeeList.Controllers
{
	[Authorize]
	public class AdminEmployeeController : Controller
	{
		Context _context = new Context();
		EmployeeValidator _validator = new EmployeeValidator();
		EmployeeEditorVM vm = new EmployeeEditorVM();

		public AdminEmployeeController()
		{
			vm.Departments = new SelectList(
				(from s in _context.Departments
				 select new { DepartmentID = s.DepartmentID, DepartmentName = s.DepartmentName }),
				"DepartmentID", "DepartmentName");

			vm.Employees = new SelectList(
				(from s in _context.Employees
				 select new { ReportsToID = s.EmployeeID, FullName = s.FirstName + " " + s.LastName }),
				"ReportsToID", "FullName");
		}

		public ActionResult Index()
		{
			var values = _context.Employees.ToList();
			return View(values);
		}

		public ActionResult Remove(int id)
		{
			var employee = _context.Employees.FirstOrDefault(x => x.EmployeeID == id);
			var photos = employee.Photos.ToList();

			if (employee.ReportsFrom.Count > 0)
			{
				string reportsFrom = "";

				foreach (var item in employee.ReportsFrom)
				{
					reportsFrom += item.FirstName + " " + item.LastName + ", ";
				}
				reportsFrom = reportsFrom.Substring(0, reportsFrom.Length - 2);

				TempData["employeeMessage"] = "Bu personel " + reportsFrom + " isimli personelleri yönettiği için silinemez.";
				return RedirectToAction("Index");

			}

			if (photos.Count > 0)
			{
				foreach (var photo in photos)
				{
					System.IO.File.Delete(Server.MapPath(photo.FilePath));
					_context.Photos.Remove(photo);
				}
			}

			_context.Employees.Remove(employee);
			_context.SaveChanges();

			TempData["employeeMessage"] = "Personel başarıyla silindi.";
			return RedirectToAction("Index");
		}

		public ActionResult Edit(int id)
		{
			vm.Employee = _context.Employees.FirstOrDefault(x => x.EmployeeID == id);
			return View(vm);
		}

		[HttpPost]
		public ActionResult Edit(EmployeeEditorVM p)
		{
			ValidationResult results = _validator.Validate(p.Employee);

			if (!results.IsValid)
			{
				foreach (var error in results.Errors)
				{
					ModelState.AddModelError("Employee." + error.PropertyName, error.ErrorMessage);
					vm.Employee = _context.Employees.FirstOrDefault(x => x.EmployeeID == p.Employee.EmployeeID);
					return View(vm);
				}
			}

			Employee employee = _context.Employees.FirstOrDefault(x => x.EmployeeID == p.Employee.EmployeeID);
			employee.FirstName = p.Employee.FirstName;
			employee.LastName = p.Employee.LastName;
			employee.Phone = p.Employee.Phone;
			employee.BirthDate = p.Employee.BirthDate;
			employee.DepartmentID = p.Employee.DepartmentID;
			employee.ReportsToID = p.Employee.ReportsToID;

			if (p.Photos.ElementAt(0) != null)
			{
				foreach (var item in p.Photos)
				{
					if (Path.GetExtension(item.FileName.ToLower()) == ".jpg" || Path.GetExtension(item.FileName.ToLower()) == ".png" || Path.GetExtension(item.FileName.ToLower()) == ".jpeg")
					{
						string newName = Path.GetRandomFileName() + Path.GetExtension(item.FileName);
						string filePath = "/Content/images/" + newName;
						var fullPath = Server.MapPath(filePath);
						item.SaveAs(fullPath);

						Bitmap map = new Bitmap(fullPath);
						Size photoSize = new Size(250, 250);
						Bitmap editedPhoto = new Bitmap(map, photoSize);
						map.Dispose();
						editedPhoto.Save(fullPath);
						editedPhoto.Dispose();

						_context.Photos.Add(new Photo
						{
							EmployeeID = p.Employee.EmployeeID,
							FilePath = filePath
						});
					}

					else
					{
						_context.SaveChanges();
						ModelState.AddModelError("photoUpload", "Sadece .jpg, .jpeg ve .png formatları geçerlidir.");
						vm.Employee = _context.Employees.FirstOrDefault(x => x.EmployeeID == p.Employee.EmployeeID);
						return View(vm);
					}
				}
			}

			_context.SaveChanges();
			TempData["employeeMessage"] = "Personel bilgileri başarıyla güncellendi.";
			return RedirectToAction("Index");
		}

		public ActionResult Add()
		{
			return View(vm);
		}

		[HttpPost]
		public ActionResult Add(EmployeeEditorVM p)
		{
			ValidationResult results = _validator.Validate(p.Employee);
			if (!results.IsValid)
			{
				foreach (var error in results.Errors)
				{
					ModelState.AddModelError("Employee." + error.PropertyName, error.ErrorMessage);

				}
				return View(vm);
			}

			_context.Employees.Add(p.Employee);

			if (p.Photos.ElementAt(0) != null)
			{
				foreach (var item in p.Photos)
				{
					if (Path.GetExtension(item.FileName.ToLower()) == ".jpg" || Path.GetExtension(item.FileName.ToLower()) == ".png" || Path.GetExtension(item.FileName.ToLower()) == ".jpeg")
					{
						string newName = Path.GetRandomFileName() + Path.GetExtension(item.FileName);
						string filePath = "/Content/images/" + newName;
						var fullPath = Server.MapPath(filePath);
						item.SaveAs(fullPath);

						Bitmap map = new Bitmap(fullPath);
						Size photoSize = new Size(250, 250);
						Bitmap editedPhoto = new Bitmap(map, photoSize);
						map.Dispose();
						editedPhoto.Save(fullPath);
						editedPhoto.Dispose();

						_context.Photos.Add(new Photo
						{
							EmployeeID = p.Employee.EmployeeID,
							FilePath = filePath
						});
					}

					else
					{
						ModelState.AddModelError("photoUpload", "Sadece .jpg, .jpeg ve .png formatları geçerlidir.");
						return View(vm);
					}
				}
			}

			_context.SaveChanges();
			TempData["employeeMessage"] = "Personel başarıyla eklendi.";
			return RedirectToAction("Index");
		}

		[HttpPost, ChildAndAjaxOnly]
		public JsonResult RemovePhoto(int id)
		{
			var photo = _context.Photos.FirstOrDefault(x => x.PhotoID == id);
			vm.Employee = _context.Employees.FirstOrDefault(x => x.EmployeeID == photo.EmployeeID);

			System.IO.File.Delete(Server.MapPath(photo.FilePath));
			_context.Photos.Remove(photo);
			_context.SaveChanges();
			return Json(1);
		}
	}
}