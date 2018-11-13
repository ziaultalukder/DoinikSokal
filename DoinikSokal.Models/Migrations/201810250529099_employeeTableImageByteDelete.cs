namespace DoinikSokal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeTableImageByteDelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Image", c => c.Binary());
        }
    }
}
