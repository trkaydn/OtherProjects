using CreateExam.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CreateExam.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			using (Context context = new Context())
			{
				var data = context.Exams.OrderByDescending(x => x.CreateDate).ToList();
				return View(data);
			}
		}

		public IActionResult DeleteExam(int id)
		{
			using (Context context = new Context())
			{
				var examValue = context.Exams.FirstOrDefault(x => x.ExamID == id);
				context.Exams.Remove(examValue);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
