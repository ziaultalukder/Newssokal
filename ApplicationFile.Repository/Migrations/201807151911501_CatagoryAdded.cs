namespace ApplicationFile.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatagoryAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Catagories");
        }
    }
}
