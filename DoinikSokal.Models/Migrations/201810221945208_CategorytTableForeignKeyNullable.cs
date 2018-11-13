namespace DoinikSokal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategorytTableForeignKeyNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "SubCatId" });
            AlterColumn("dbo.Categories", "SubCatId", c => c.Int());
            CreateIndex("dbo.Categories", "SubCatId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "SubCatId" });
            AlterColumn("dbo.Categories", "SubCatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "SubCatId");
        }
    }
}
