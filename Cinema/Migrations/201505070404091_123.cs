namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "TicketId", "dbo.Tickets");
            DropIndex("dbo.Rooms", new[] { "TicketId" });
            AddColumn("dbo.Tickets", "Room_RoomId", c => c.Int());
            CreateIndex("dbo.Tickets", "Room_RoomId");
            AddForeignKey("dbo.Tickets", "Room_RoomId", "dbo.Rooms", "RoomId");
            DropColumn("dbo.Rooms", "TicketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "TicketId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.Tickets", new[] { "Room_RoomId" });
            DropColumn("dbo.Tickets", "Room_RoomId");
            CreateIndex("dbo.Rooms", "TicketId");
            AddForeignKey("dbo.Rooms", "TicketId", "dbo.Tickets", "TicketId", cascadeDelete: true);
        }
    }
}
