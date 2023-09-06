using BusinessLayer.PasswordHasher;
using BusinessLayer.ValidationRules;
using EmployeeListDAL.Context;
using EntityLayer;
using FluentValidation.Results;
using System.Web.Mvc;

namespace EmployeeList.Controllers
{
	public class RegisterController : Controller
	{
		Context _context = new Context();

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(Admin admin)
		{
			AdminValidator validator = new AdminValidator();
			ValidationResult results = validator.Validate(admin);

			if (results.IsValid)
			{
				admin.Password = MD5Hasher.Hash(admin.Password);
				_context.Admins.Add(admin);
				_context.SaveChanges();
				TempData["message"] = "Başarıyla kayıt olundu. Lütfen giriş yapın.";
				return RedirectToAction("Index", "Login");
			}

			foreach (var error in results.Errors)
			{
				ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
			return View(admin);
		}
	}
}