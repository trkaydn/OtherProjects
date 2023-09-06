using CreateExam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreateExam.Data.Context
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data source=CreateExam.db");

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Question>()
				.HasOne(x => x.Exam)
				.WithMany(y => y.Questions)
				.HasForeignKey(z => z.ExamID)
				.OnDelete(DeleteBehavior.Cascade);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Exam> Exams { get; set; }
	}
}
