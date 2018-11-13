namespace ApplicationFile.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catagoryModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catagories", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Catagories", "CategoryId");
            AddForeignKey("dbo.Catagories", "CategoryId", "dbo.Catagories", "Id");
            DropColumn("dbo.Catagories", "CatagoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Catagories", "CatagoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Catagories", "CategoryId", "dbo.Catagories");
            DropIndex("dbo.Catagories", new[] { "CategoryId" });
            DropColumn("dbo.Catagories", "CategoryId");
        }
    }
}
