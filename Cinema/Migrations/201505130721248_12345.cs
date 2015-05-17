namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12345 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "StreetId" });
            DropColumn("dbo.AspNetUsers", "StreetId");
            DropColumn("dbo.AspNetUsers", "House");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "House", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "StreetId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "StreetId");
        }
    }
}
