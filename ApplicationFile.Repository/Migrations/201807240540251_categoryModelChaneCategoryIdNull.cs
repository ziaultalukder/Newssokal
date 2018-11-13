namespace ApplicationFile.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryModelChaneCategoryIdNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Catagories", new[] { "CategoryId" });
            AlterColumn("dbo.Catagories", "CategoryId", c => c.Int());
            CreateIndex("dbo.Catagories", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Catagories", new[] { "CategoryId" });
            AlterColumn("dbo.Catagories", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Catagories", "CategoryId");
        }
    }
}
