namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lines", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Stufs", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stufs", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Lines", "Type");
        }
    }
}
