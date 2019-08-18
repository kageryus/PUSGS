namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "Line_Id", "dbo.Lines");
            DropForeignKey("dbo.Stations", "Line_Id", "dbo.Lines");
            DropForeignKey("dbo.Lines", "TimetableId", "dbo.Timetables");
            DropForeignKey("dbo.Stufs", "Pricelist_Id", "dbo.Pricelists");
            DropIndex("dbo.Lines", new[] { "TimetableId" });
            DropIndex("dbo.Locations", new[] { "Line_Id" });
            DropIndex("dbo.Stations", new[] { "Line_Id" });
            DropIndex("dbo.Stufs", new[] { "Pricelist_Id" });
            CreateTable(
                "dbo.TicketPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        PriceListId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pricelists", t => t.PriceListId, cascadeDelete: true)
                .Index(t => t.PriceListId);
            
            CreateTable(
                "dbo.Departures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hour = c.Int(nullable: false),
                        TimeTableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Timetables", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.TimeTableId);
            
            CreateTable(
                "dbo.StationLines",
                c => new
                    {
                        Station_Id = c.Int(nullable: false),
                        Line_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Station_Id, t.Line_Id })
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lines", t => t.Line_Id, cascadeDelete: true)
                .Index(t => t.Station_Id)
                .Index(t => t.Line_Id);
            
            AddColumn("dbo.Timetables", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Timetables", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "RemainingTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Tickets", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Tickets", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pricelists", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Pricelists", "EndDate", c => c.DateTime());
            CreateIndex("dbo.Tickets", "User_Id");
            CreateIndex("dbo.Timetables", "LineId");
            AddForeignKey("dbo.Tickets", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Timetables", "LineId", "dbo.Lines", "Id", cascadeDelete: true);
            DropColumn("dbo.Lines", "TimetableId");
            DropColumn("dbo.Locations", "Line_Id");
            DropColumn("dbo.Stations", "Line_Id");
            DropColumn("dbo.Timetables", "WorkDay");
            DropColumn("dbo.Timetables", "Saturday");
            DropColumn("dbo.Timetables", "Sunday");
            DropColumn("dbo.Pricelists", "Active");
            DropColumn("dbo.Tickets", "PassengerId");
            DropTable("dbo.Stufs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stufs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        LineType = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Pricelist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "PassengerId", c => c.Int(nullable: false));
            AddColumn("dbo.Pricelists", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Timetables", "Sunday", c => c.String());
            AddColumn("dbo.Timetables", "Saturday", c => c.String());
            AddColumn("dbo.Timetables", "WorkDay", c => c.String());
            AddColumn("dbo.Stations", "Line_Id", c => c.Int());
            AddColumn("dbo.Locations", "Line_Id", c => c.Int());
            AddColumn("dbo.Lines", "TimetableId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Timetables", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Departures", "TimeTableId", "dbo.Timetables");
            DropForeignKey("dbo.Tickets", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketPrices", "PriceListId", "dbo.Pricelists");
            DropForeignKey("dbo.StationLines", "Line_Id", "dbo.Lines");
            DropForeignKey("dbo.StationLines", "Station_Id", "dbo.Stations");
            DropIndex("dbo.StationLines", new[] { "Line_Id" });
            DropIndex("dbo.StationLines", new[] { "Station_Id" });
            DropIndex("dbo.Departures", new[] { "TimeTableId" });
            DropIndex("dbo.Timetables", new[] { "LineId" });
            DropIndex("dbo.Tickets", new[] { "User_Id" });
            DropIndex("dbo.TicketPrices", new[] { "PriceListId" });
            AlterColumn("dbo.Pricelists", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pricelists", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tickets", "User_Id");
            DropColumn("dbo.Tickets", "Price");
            DropColumn("dbo.Tickets", "UserId");
            DropColumn("dbo.Tickets", "RemainingTime");
            DropColumn("dbo.Timetables", "LineId");
            DropColumn("dbo.Timetables", "Day");
            DropTable("dbo.StationLines");
            DropTable("dbo.Departures");
            DropTable("dbo.TicketPrices");
            CreateIndex("dbo.Stufs", "Pricelist_Id");
            CreateIndex("dbo.Stations", "Line_Id");
            CreateIndex("dbo.Locations", "Line_Id");
            CreateIndex("dbo.Lines", "TimetableId");
            AddForeignKey("dbo.Stufs", "Pricelist_Id", "dbo.Pricelists", "Id");
            AddForeignKey("dbo.Lines", "TimetableId", "dbo.Timetables", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Stations", "Line_Id", "dbo.Lines", "Id");
            AddForeignKey("dbo.Locations", "Line_Id", "dbo.Lines", "Id");
        }
    }
}
