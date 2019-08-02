namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Databegin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Dataend", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Dataperenos", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Dataplan", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "Datacontrol", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Datacontrol");
            DropColumn("dbo.Events", "Dataplan");
            DropColumn("dbo.Events", "Dataperenos");
            DropColumn("dbo.Events", "Dataend");
            DropColumn("dbo.Events", "Databegin");
        }
    }
}
