namespace AtrinBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4543545 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "AlreadyRegistered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "AlreadyRegistered");
        }
    }
}
