namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSome : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.Tickets", new[] { "Room_RoomId" });
            DropColumn("dbo.Tickets", "Room_RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Room_RoomId", c => c.Int());
            CreateIndex("dbo.Tickets", "Room_RoomId");
            AddForeignKey("dbo.Tickets", "Room_RoomId", "dbo.Rooms", "RoomId");
        }
    }
}
