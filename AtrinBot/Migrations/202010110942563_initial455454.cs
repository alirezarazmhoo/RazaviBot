namespace AtrinBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial455454 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "Mobile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "Mobile");
        }
    }
}
