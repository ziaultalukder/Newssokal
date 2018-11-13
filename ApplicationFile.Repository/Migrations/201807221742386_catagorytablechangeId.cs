namespace ApplicationFile.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catagorytablechangeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catagories", "CatagoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Catagories", "CatagoryId");
        }
    }
}
