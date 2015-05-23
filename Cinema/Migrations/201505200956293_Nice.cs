namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "AllAbout", c => c.String(storeType: "ntext"));
            DropColumn("dbo.Reviews", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Title", c => c.String());
            DropColumn("dbo.Reviews", "AllAbout");
        }
    }
}
