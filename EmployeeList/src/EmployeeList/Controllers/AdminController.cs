using EmployeeListDAL.Context;
using System.Web.Mvc;
using System.Linq;
using EmployeeListUI.CustomAttributes;
using EmployeeList.Models;
using BusinessLayer.PasswordHasher;
using BusinessLayer.ValidationRules;
using FluentValidation;
using FluentValidation.Results;

namespace EmployeeListUI.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		Context _context = new Context();

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost, ChildAndAjaxOnly]
		public JsonResult ChangePassword(ChangePasswordVM p)
		{
			if (string.IsNullOrEmpty(p.NewPassword) ||string.IsNullOrEmpty(p.NewPassword))
				return Json(0);

			string adminMail = Session["admin"].ToString();
			var admin = _context.Admins.FirstOrDefault(x => x.MailAddress == adminMail);

			string oldPassword = MD5Hasher.Hash(p.OldPassword);
			if (oldPassword != admin.Password)
				return Json(2);

			AdminValidator validator = new AdminValidator();
			admin.Password = p.NewPassword;
			ValidationResult result = validator.Validate(admin, opt => opt.IncludeProperties(x => x.Password));

			if (!result.IsValid)
				return Json(3);

			admin.Password = MD5Hasher.Hash(p.NewPassword);
			_context.SaveChanges();
			return Json(1);
		}
	}
}