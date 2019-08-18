namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_Update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stufs", "LineType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stufs", "LineType");
        }
    }
}
