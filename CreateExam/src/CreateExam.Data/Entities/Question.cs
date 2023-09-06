using System.ComponentModel.DataAnnotations;

namespace CreateExam.Data.Entities
{
	public class Question
	{
		[Key]
		public int QuestionID { get; set; }
		public string QuestionText { get; set; }
		public string AnswerA { get; set; }
		public string AnswerB { get; set; }
		public string AnswerC { get; set; }
		public string AnswerD { get; set; }
		public string CorrectAnswer { get; set; }
		public int ExamID { get; set; }
		public Exam Exam { get; set; }

	}
}
