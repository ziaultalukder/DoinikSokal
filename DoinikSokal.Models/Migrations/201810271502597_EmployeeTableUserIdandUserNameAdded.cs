namespace DoinikSokal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTableUserIdandUserNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "UserName");
            DropColumn("dbo.Employees", "UserId");
        }
    }
}
