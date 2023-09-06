using EntityLayer;
using System.Data.Entity;

namespace EmployeeListDAL.Context
{
	public class Context : DbContext
	{
		public DbSet<Admin> Admins { get; set; }

		public DbSet<Department> Departments { get; set; }

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Photo> Photos { get; set; }
	}
}
