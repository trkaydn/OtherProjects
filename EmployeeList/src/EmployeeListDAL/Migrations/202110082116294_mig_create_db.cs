namespace EmployeeListDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_create_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MailAddress = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        ReportsTo = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Photos", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropTable("dbo.Photos");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Admins");
        }
    }
}
