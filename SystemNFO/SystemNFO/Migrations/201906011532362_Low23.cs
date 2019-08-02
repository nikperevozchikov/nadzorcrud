namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Employees", new[] { "Event_EventId" });
            AddColumn("dbo.Employees", "Organization_OrganizationId", c => c.Int());
            CreateIndex("dbo.Employees", "Organization_OrganizationId");
            AddForeignKey("dbo.Employees", "Organization_OrganizationId", "dbo.Organizations", "OrganizationId");
            DropColumn("dbo.Employees", "Event_EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Event_EventId", c => c.Int());
            DropForeignKey("dbo.Employees", "Organization_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Employees", new[] { "Organization_OrganizationId" });
            DropColumn("dbo.Employees", "Organization_OrganizationId");
            CreateIndex("dbo.Employees", "Event_EventId");
            AddForeignKey("dbo.Employees", "Event_EventId", "dbo.Events", "EventId");
        }
    }
}
