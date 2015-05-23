namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nudavai : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "StreetId", "dbo.Streets");
            DropIndex("dbo.AspNetUsers", new[] { "StreetId" });
            AlterColumn("dbo.AspNetUsers", "StreetId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "StreetId");
            AddForeignKey("dbo.AspNetUsers", "StreetId", "dbo.Streets", "StreetID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "StreetId", "dbo.Streets");
            DropIndex("dbo.AspNetUsers", new[] { "StreetId" });
            AlterColumn("dbo.AspNetUsers", "StreetId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "StreetId");
            AddForeignKey("dbo.AspNetUsers", "StreetId", "dbo.Streets", "StreetID", cascadeDelete: true);
        }
    }
}
