namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuperModes", "Ogrn", c => c.Long(nullable: false));
            AddColumn("dbo.SuperModes", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.SuperModes", "Document", c => c.String());
            AddColumn("dbo.SuperModes", "Vid", c => c.String());
            AddColumn("dbo.SuperModes", "Category", c => c.String());
            AddColumn("dbo.SuperModes", "Mode", c => c.Int(nullable: false));
            AlterColumn("dbo.Organizations", "Ogrn", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "Ogrn", c => c.Int(nullable: false));
            DropColumn("dbo.SuperModes", "Mode");
            DropColumn("dbo.SuperModes", "Category");
            DropColumn("dbo.SuperModes", "Vid");
            DropColumn("dbo.SuperModes", "Document");
            DropColumn("dbo.SuperModes", "Date");
            DropColumn("dbo.SuperModes", "Ogrn");
        }
    }
}
