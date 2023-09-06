using BusinessLayer.PasswordHasher;
using BusinessLayer.ValidationRules;
using EmployeeListDAL.Context;
using EntityLayer;
using FluentValidation.Results;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeListUI.Controllers
{
	public class LoginController : Controller
	{
		Context _context = new Context();

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(Admin admin)
		{
			LoginValidator validator = new LoginValidator();
			ValidationResult results = validator.Validate(admin);

			if (!results.IsValid)
			{
				foreach (var error in results.Errors)
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

				return View(admin);
			}

			admin.Password = MD5Hasher.Hash(admin.Password);
			var values = _context.Admins.FirstOrDefault(x => x.MailAddress == admin.MailAddress && x.Password == admin.Password);

			if (values == null)
			{
				ViewBag.Message = "E-Posta veya şifre hatalı.";
				return View(admin);

			}

			Session["admin"] = admin.MailAddress;
			FormsAuthentication.SetAuthCookie(admin.MailAddress, false);
			return RedirectToAction("Index", "Admin");
		}

		[Authorize]
		public ActionResult Logout()
		{
			Session.Abandon();
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}

	}
}