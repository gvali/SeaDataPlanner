namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxStringLength : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Projects", new[] { "Person_PersonId" });
            AlterColumn("dbo.Cruises", "CruiseName", c => c.String(maxLength: 64));
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 128));
            AlterColumn("dbo.People", "LastName", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "ProjectName", c => c.String(maxLength: 64));
            AlterColumn("dbo.Projects", "Person_PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Stations", "StationName", c => c.String(maxLength: 16));
            CreateIndex("dbo.Projects", "Person_PersonId");
            AddForeignKey("dbo.Projects", "Person_PersonId", "dbo.People", "PersonId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Projects", new[] { "Person_PersonId" });
            AlterColumn("dbo.Stations", "StationName", c => c.String());
            AlterColumn("dbo.Projects", "Person_PersonId", c => c.Int());
            AlterColumn("dbo.Projects", "ProjectName", c => c.String());
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            AlterColumn("dbo.Cruises", "CruiseName", c => c.String());
            CreateIndex("dbo.Projects", "Person_PersonId");
            AddForeignKey("dbo.Projects", "Person_PersonId", "dbo.People", "PersonId");
        }
    }
}
