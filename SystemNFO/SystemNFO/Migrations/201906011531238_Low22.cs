namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Event_EventId", c => c.Int());
            CreateIndex("dbo.Employees", "Event_EventId");
            AddForeignKey("dbo.Employees", "Event_EventId", "dbo.Events", "EventId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Employees", new[] { "Event_EventId" });
            DropColumn("dbo.Employees", "Event_EventId");
        }
    }
}
