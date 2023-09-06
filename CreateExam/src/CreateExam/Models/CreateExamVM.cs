using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CreateExam.Models
{
	public class CreateExamVM
	{
		public List<SelectListItem> TitleValues { get; set; }
		public string Text { get; set; }
		public string Title { get; set; }
		public string TitleUrl { get; set; }
		public List<string> Questions { get; set; }
		public List<string> Answers { get; set; }
		public List<string> CorrectAnswers { get; set; }

	}
}
