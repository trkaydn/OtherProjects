namespace EmployeeListDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ReportsToID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ReportsToID");
        }
    }
}
