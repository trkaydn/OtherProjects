using InvoiceData.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceData
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=TARIK-PC;database=InvoiceDb;integrated security=true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Invoice>().HasMany(t => t.Products)
			.WithOne(g => g.Invoice)
			.HasForeignKey(g => g.InvoiceID)
			.OnDelete(DeleteBehavior.Cascade);
		}

		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
