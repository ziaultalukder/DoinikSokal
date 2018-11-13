namespace DoinikSokal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTableAddedSomeFeaturesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Status", c => c.String());
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropColumn("dbo.Posts", "Status");
            DropColumn("dbo.Posts", "CategoryId");
        }
    }
}
