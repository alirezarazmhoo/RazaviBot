namespace AtrinBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1456 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "UserName");
        }
    }
}
