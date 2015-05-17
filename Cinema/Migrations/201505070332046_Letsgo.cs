namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Letsgo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        StreetId = c.Int(nullable: false),
                        Family = c.String(),
                        Name = c.String(),
                        SecName = c.String(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Streets", t => t.StreetId, cascadeDelete: true)
                .Index(t => t.StreetId);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        StreetID = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                    })
                .PrimaryKey(t => t.StreetID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        SectorId = c.Int(nullable: false),
                        NColumn = c.Int(nullable: false),
                        NSpot = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Session_SessionID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Sectors", t => t.SectorId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.Session_SessionID)
                .Index(t => t.ClientId)
                .Index(t => t.SectorId)
                .Index(t => t.Session_SessionID);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        SectorId = c.Int(nullable: false, identity: true),
                        SectorName = c.String(),
                    })
                .PrimaryKey(t => t.SectorId);
            
            CreateTable(
                "dbo.ECRBs",
                c => new
                    {
                        ECRBId = c.Int(nullable: false, identity: true),
                        ECRBName = c.String(),
                    })
                .PrimaryKey(t => t.ECRBId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        FilmName = c.String(),
                        AllAbout = c.String(storeType: "ntext"),
                        GenreId = c.Int(nullable: false),
                        ECRBId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId)
                .ForeignKey("dbo.ECRBs", t => t.ECRBId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.ECRBId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DateSession = c.DateTime(nullable: false),
                        TimeSession = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        RoomName = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "Session_SessionID", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Sessions", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Reviews", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Films", "ECRBId", "dbo.ECRBs");
            DropForeignKey("dbo.Tickets", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Tickets", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Rooms", new[] { "TicketId" });
            DropIndex("dbo.Sessions", new[] { "RoomId" });
            DropIndex("dbo.Sessions", new[] { "FilmId" });
            DropIndex("dbo.Reviews", new[] { "FilmId" });
            DropIndex("dbo.Films", new[] { "ECRBId" });
            DropIndex("dbo.Films", new[] { "GenreId" });
            DropIndex("dbo.Tickets", new[] { "Session_SessionID" });
            DropIndex("dbo.Tickets", new[] { "SectorId" });
            DropIndex("dbo.Tickets", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "StreetId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Rooms");
            DropTable("dbo.Sessions");
            DropTable("dbo.Reviews");
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
            DropTable("dbo.ECRBs");
            DropTable("dbo.Sectors");
            DropTable("dbo.Tickets");
            DropTable("dbo.Streets");
            DropTable("dbo.Clients");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
