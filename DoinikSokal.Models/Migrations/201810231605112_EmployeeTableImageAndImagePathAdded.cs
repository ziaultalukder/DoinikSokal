namespace DoinikSokal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTableImageAndImagePathAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Image", c => c.Binary());
            AddColumn("dbo.Employees", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "FilePath");
            DropColumn("dbo.Employees", "Image");
        }
    }
}
