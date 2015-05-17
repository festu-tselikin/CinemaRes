namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ClientId", "dbo.Clients");
            DropIndex("dbo.Tickets", new[] { "ClientId" });
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecName", c => c.String());
            AlterColumn("dbo.Tickets", "ClientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "ClientId");
            AddForeignKey("dbo.Tickets", "ClientId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ClientId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "ClientId" });
            AlterColumn("dbo.Tickets", "ClientId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "SecName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            CreateIndex("dbo.Tickets", "ClientId");
            AddForeignKey("dbo.Tickets", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
    }
}
