using CreateExam.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreateExam.Controllers
{
	[Authorize]
	public class TakeExamController : Controller
	{
		public IActionResult Index(int id)
		{
			using (Context context = new Context())
			{
				var examValue = context.Exams.Include(x => x.Questions).FirstOrDefault(y => y.ExamID == id);

				if (examValue == null)
					return NotFound();

				return View(examValue);
			}
		}

		[HttpPost]
		public JsonResult GetResult(string[] answers)
		{
			using (Context context = new Context())
			{
				var examValue = context.Exams.Include(x => x.Questions).FirstOrDefault(x => x.ExamID == Convert.ToInt32(answers[0]));
				List<string> correctAnswers = new List<string>();
				
				foreach (var item in examValue.Questions)
				{
					correctAnswers.Add(item.CorrectAnswer);
				}
				return Json(correctAnswers);
			}
		}
	}
}
