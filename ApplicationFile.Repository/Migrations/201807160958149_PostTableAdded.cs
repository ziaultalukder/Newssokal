namespace ApplicationFile.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Details = c.String(),
                        Tags = c.String(),
                        CatagoryId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.CatagoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CatagoryId", "dbo.Catagories");
            DropIndex("dbo.Posts", new[] { "CatagoryId" });
            DropTable("dbo.Posts");
        }
    }
}
