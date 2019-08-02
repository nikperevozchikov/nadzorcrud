namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Nameevent = c.String(),
                        Comment = c.String(nullable: false),
                        Status = c.String(),
                        Nadzorfact = c.String(),
                        Result = c.String(),
                        Mode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.SuperModes",
                c => new
                    {
                        SuperModeId = c.Int(nullable: false, identity: true),
                        Namemode = c.String(),
                    })
                .PrimaryKey(t => t.SuperModeId);
            
            AlterColumn("dbo.Employees", "Position", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Position", c => c.String());
            DropTable("dbo.SuperModes");
            DropTable("dbo.Events");
        }
    }
}
