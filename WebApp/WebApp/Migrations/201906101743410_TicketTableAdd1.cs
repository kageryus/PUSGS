namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketTableAdd1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        BuyTime = c.DateTime(nullable: false),
                        PassengerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
