namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Databegin", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Events", "Dataend", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Dataend", c => c.DateTime());
            AlterColumn("dbo.Events", "Databegin", c => c.DateTime());
        }
    }
}
