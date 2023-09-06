using CreateExam.Data.Context;
using CreateExam.Data.Entities;
using CreateExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace CreateExam.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserVM user)
		{
			using (Context db = new Context())
			{
				User loggingUser = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

				if (loggingUser != null)
				{
					var claims = new List<Claim>()
					{
						new Claim(ClaimTypes.Name, loggingUser.UserName)
					};

					var useridentity = new ClaimsIdentity(claims, "user");
					ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
					await HttpContext.SignInAsync(principal);

					return RedirectToAction("Index", "Home");
				}
			}

			ViewBag.Message = "Kullanıcı adı veya şifre hatalı!";
			return View();
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}

	}
}
