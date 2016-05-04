namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cruises",
                c => new
                    {
                        CruiseId = c.Int(nullable: false, identity: true),
                        CruiseName = c.String(),
                        PersonId = c.Int(nullable: false),
                        Person_PersonId = c.Int(),
                        Person_PersonId1 = c.Int(),
                    })
                .PrimaryKey(t => t.CruiseId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .ForeignKey("dbo.People", t => t.Person_PersonId1)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Person_PersonId1);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Project_ProjectId = c.Int(),
                        Cruise_CruiseId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .ForeignKey("dbo.Cruises", t => t.Cruise_CruiseId)
                .Index(t => t.Project_ProjectId)
                .Index(t => t.Cruise_CruiseId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        PersonId = c.Int(nullable: false),
                        Person_PersonId = c.Int(),
                        Person_PersonId1 = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .ForeignKey("dbo.People", t => t.Person_PersonId1)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Person_PersonId1);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationId = c.Int(nullable: false, identity: true),
                        StationName = c.String(),
                        StatLon = c.Single(nullable: false),
                        StatLat = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.StationId);
            
            CreateTable(
                "dbo.StationCruises",
                c => new
                    {
                        Station_StationId = c.Int(nullable: false),
                        Cruise_CruiseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Station_StationId, t.Cruise_CruiseId })
                .ForeignKey("dbo.Stations", t => t.Station_StationId, cascadeDelete: true)
                .ForeignKey("dbo.Cruises", t => t.Cruise_CruiseId, cascadeDelete: true)
                .Index(t => t.Station_StationId)
                .Index(t => t.Cruise_CruiseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StationCruises", "Cruise_CruiseId", "dbo.Cruises");
            DropForeignKey("dbo.StationCruises", "Station_StationId", "dbo.Stations");
            DropForeignKey("dbo.People", "Cruise_CruiseId", "dbo.Cruises");
            DropForeignKey("dbo.Cruises", "Person_PersonId1", "dbo.People");
            DropForeignKey("dbo.Projects", "Person_PersonId1", "dbo.People");
            DropForeignKey("dbo.People", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Cruises", "Person_PersonId", "dbo.People");
            DropIndex("dbo.StationCruises", new[] { "Cruise_CruiseId" });
            DropIndex("dbo.StationCruises", new[] { "Station_StationId" });
            DropIndex("dbo.Projects", new[] { "Person_PersonId1" });
            DropIndex("dbo.Projects", new[] { "Person_PersonId" });
            DropIndex("dbo.People", new[] { "Cruise_CruiseId" });
            DropIndex("dbo.People", new[] { "Project_ProjectId" });
            DropIndex("dbo.Cruises", new[] { "Person_PersonId1" });
            DropIndex("dbo.Cruises", new[] { "Person_PersonId" });
            DropTable("dbo.StationCruises");
            DropTable("dbo.Stations");
            DropTable("dbo.Projects");
            DropTable("dbo.People");
            DropTable("dbo.Cruises");
        }
    }
}
