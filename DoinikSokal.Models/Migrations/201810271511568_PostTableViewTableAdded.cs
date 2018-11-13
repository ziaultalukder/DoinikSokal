namespace DoinikSokal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTableViewTableAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Views", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Views");
        }
    }
}
