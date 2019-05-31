namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stations", "Station_Id", "dbo.Stations");
            DropIndex("dbo.Stations", new[] { "Station_Id" });
            DropColumn("dbo.Stations", "Station_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stations", "Station_Id", c => c.Int());
            CreateIndex("dbo.Stations", "Station_Id");
            AddForeignKey("dbo.Stations", "Station_Id", "dbo.Stations", "Id");
        }
    }
}
