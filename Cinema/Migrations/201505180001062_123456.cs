namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123456 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "House", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Apartment", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "StreetId", c => c.Int(nullable: true));
            CreateIndex("dbo.AspNetUsers", "StreetId");
            AddForeignKey("dbo.AspNetUsers", "StreetId", "dbo.Streets", "StreetID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "StreetId", "dbo.Streets");
            DropIndex("dbo.AspNetUsers", new[] { "StreetId" });
            DropColumn("dbo.AspNetUsers", "StreetId");
            DropColumn("dbo.AspNetUsers", "Apartment");
            DropColumn("dbo.AspNetUsers", "House");
        }
    }
}
