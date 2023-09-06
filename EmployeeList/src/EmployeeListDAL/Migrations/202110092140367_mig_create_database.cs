namespace EmployeeListDAL.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class mig_create_database : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Admins",
				c => new
				{
					AdminID = c.Int(nullable: false, identity: true),
					FirstName = c.String(nullable: false, maxLength: 25),
					LastName = c.String(nullable: false, maxLength: 25),
					MailAddress = c.String(nullable: false, maxLength: 25),
					Password = c.String(nullable: false, maxLength: 25),
				})
				.PrimaryKey(t => t.AdminID);

			CreateTable(
				"dbo.Departments",
				c => new
				{
					DepartmentID = c.Int(nullable: false, identity: true),
					DepartmentName = c.String(nullable: false, maxLength: 25),
				})
				.PrimaryKey(t => t.DepartmentID);

			CreateTable(
				"dbo.Employees",
				c => new
				{
					EmployeeID = c.Int(nullable: false, identity: true),
					FirstName = c.String(nullable: false, maxLength: 25),
					LastName = c.String(nullable: false, maxLength: 25),
					Phone = c.String(nullable: false, maxLength: 25),
					DepartmentID = c.Int(),
					BirthDate = c.DateTime(),
					ReportsTo_EmployeeID = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.EmployeeID)
				.ForeignKey("dbo.Departments", t => t.DepartmentID)
				.ForeignKey("dbo.Employees", t => t.ReportsTo_EmployeeID)
				.Index(t => t.DepartmentID)
				.Index(t => t.ReportsTo_EmployeeID);

			CreateTable(
				"dbo.Photos",
				c => new
				{
					PhotoID = c.Int(nullable: false, identity: true),
					EmployeeID = c.Int(nullable: false),
					FilePath = c.String(nullable: false),
				})
				.PrimaryKey(t => t.PhotoID)
				.ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
				.Index(t => t.EmployeeID);

		}

		public override void Down()
		{
			DropForeignKey("dbo.Photos", "EmployeeID", "dbo.Employees");
			DropForeignKey("dbo.Employees", "ReportsTo_EmployeeID", "dbo.Employees");
			DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
			DropIndex("dbo.Photos", new[] { "EmployeeID" });
			DropIndex("dbo.Employees", new[] { "ReportsTo_EmployeeID" });
			DropIndex("dbo.Employees", new[] { "DepartmentID" });
			DropTable("dbo.Photos");
			DropTable("dbo.Employees");
			DropTable("dbo.Departments");
			DropTable("dbo.Admins");
		}
	}
}
