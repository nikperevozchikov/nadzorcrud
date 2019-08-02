namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Databegin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Dataend", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Dataend", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Databegin", c => c.DateTime(nullable: false));
        }
    }
}
