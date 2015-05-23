namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sessions", "DateSession", c => c.DateTime());
            AlterColumn("dbo.Sessions", "TimeSession", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sessions", "TimeSession", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sessions", "DateSession", c => c.DateTime(nullable: false));
        }
    }
}
