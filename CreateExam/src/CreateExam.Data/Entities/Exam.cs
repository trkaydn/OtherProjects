using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreateExam.Data.Entities
{
	public class Exam
	{
		[Key]
		public int ExamID { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime CreateDate { get; set; }
		public virtual ICollection<Question> Questions { get; set; }
	}
}
