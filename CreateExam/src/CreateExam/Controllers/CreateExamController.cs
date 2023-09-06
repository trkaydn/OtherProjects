using CreateExam.Data.Context;
using CreateExam.Data.Entities;
using CreateExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CreateExam.Controllers
{
	[Authorize]
	public class CreateExamController : Controller
	{
		public IActionResult Index()
		{
			try
			{
				CreateExamVM model = new CreateExamVM();
				model.TitleValues = GetTitleFromWired();
				return View(model);
			}
			catch (Exception e)
			{
				TempData["ErrorMessage"] = e.Message;
				return RedirectToAction("Error", "Home");
			}
		}

		[HttpPost]
		public IActionResult Index(CreateExamVM model)
		{
			Exam exam = new Exam();
			exam.CreateDate = DateTime.Now;
			exam.Title = model.Title;
			exam.Text = model.Text;
			exam.Questions = new List<Question>();

			for (int i = 0; i < 4; i++)
			{
				List<string> answers = new List<string>();
				for (int j = i * 4; j < (i * 4 + 4); j++)
				{
					answers.Add(model.Answers[j]);
				}

				exam.Questions.Add(new Question()
				{
					QuestionText = model.Questions[i],
					CorrectAnswer = model.CorrectAnswers[i],
					AnswerA = answers[0],
					AnswerB = answers[1],
					AnswerC = answers[2],
					AnswerD = answers[3],
				});
			}

			using (Context context = new Context())
			{
				context.Exams.Add(exam);
				context.SaveChanges();
			}

			return RedirectToAction("Index", "Home");
		}

		public List<SelectListItem> GetTitleFromWired()
		{
			WebRequest request = HttpWebRequest.Create("https://www.wired.com/");
			WebResponse response = request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream());

			string html = reader.ReadToEnd();
			int startIndex = html.IndexOf("summary-item__content summary-item__content--no-rubric\">");
			int length = html.Substring(startIndex).IndexOf("</section>");
			html = html.Substring(startIndex, length);

			List<SelectListItem> result = new List<SelectListItem>();

			for (int i = 0; i < 5; i++)
			{
				//get the a element from html
				int start = html.IndexOf("<a");
				int linkLength = html.IndexOf("</a>");
				string linkHtml = html.Substring(start, linkLength);

				//get the a href from html
				int linkStartIndex = linkHtml.IndexOf("\"/") + 1;
				int linkEnd = linkHtml.IndexOf(" ", linkStartIndex);
				string href = "https://www.wired.com" + linkHtml.Substring(linkStartIndex, linkEnd - linkStartIndex - 1);

				//get the a title from html
				int titleStartIndex = linkHtml.IndexOf("data-recirc-pattern=\"summary-item\"") + 35;
				int titleLength = linkHtml.IndexOf("</h2>");
				string title = linkHtml.Substring(titleStartIndex, titleLength - titleStartIndex);

				//remove added link from html
				html = html.Substring(start + linkLength);
				result.Add(new SelectListItem()
				{
					Text = title,
					Value = href
				});
			}
			return result;
		}

		public JsonResult GetTextFromWired(string url)
		{
			try
			{
				WebRequest request = HttpWebRequest.Create(url);
				WebResponse response = request.GetResponse(); //sometimes wired server returns 402 Payment Required error. Please Re-open sln to fix it.
				StreamReader reader = new StreamReader(response.GetResponseStream());

				string html = reader.ReadToEnd();
				int startIndex = html.IndexOf("<div class=\"body__inner-container\">");

				if (startIndex == -1)
					startIndex = html.IndexOf("<div><p>");

				int length = html.Substring(startIndex).IndexOf("</p>");
				html = html.Substring(startIndex, length);
				return Json(html);
			}
			catch (Exception e)
			{
				string[] error = new string[2];
				error[0] = "error";
				error[1] = e.Message;
				return Json(error);
			}
		}
	}
}
