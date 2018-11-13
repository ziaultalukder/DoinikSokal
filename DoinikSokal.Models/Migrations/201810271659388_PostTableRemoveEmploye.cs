namespace DoinikSokal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTableRemoveEmploye : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Posts", new[] { "EmployeeId" });
            DropColumn("dbo.Posts", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "EmployeeId");
            AddForeignKey("dbo.Posts", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
