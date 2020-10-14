namespace AtrinBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial145 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CooperationType = c.Int(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Volunteers");
        }
    }
}
