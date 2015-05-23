namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ticket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Session_SessionID", "dbo.Sessions");
            DropIndex("dbo.Tickets", new[] { "Session_SessionID" });
            RenameColumn(table: "dbo.Tickets", name: "Session_SessionID", newName: "SessionId");
            AlterColumn("dbo.Tickets", "SessionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "SessionId");
            AddForeignKey("dbo.Tickets", "SessionId", "dbo.Sessions", "SessionID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "SessionId", "dbo.Sessions");
            DropIndex("dbo.Tickets", new[] { "SessionId" });
            AlterColumn("dbo.Tickets", "SessionId", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "SessionId", newName: "Session_SessionID");
            CreateIndex("dbo.Tickets", "Session_SessionID");
            AddForeignKey("dbo.Tickets", "Session_SessionID", "dbo.Sessions", "SessionID");
        }
    }
}
