namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false, identity: true),
                        Ogrn = c.Int(nullable: false),
                        Nameorg = c.String(),
                        Socrnameorg = c.String(nullable: false),
                        Status = c.String(),
                        Vidorg = c.String(),
                        Category = c.String(),
                        Risc = c.String(),
                        Mode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Organizations");
        }
    }
}
