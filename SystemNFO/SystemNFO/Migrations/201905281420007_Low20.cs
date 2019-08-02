namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Dataperenos", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Events", "Dataplan", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Dataplan", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Events", "Dataperenos", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
