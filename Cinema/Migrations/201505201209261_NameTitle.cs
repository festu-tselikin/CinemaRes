namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "NameTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "NameTitle");
        }
    }
}
