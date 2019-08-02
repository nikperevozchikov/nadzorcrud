namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrganizationCurators",
                c => new
                    {
                        OrganizationCuratorId = c.Int(nullable: false, identity: true),
                        Ogrn = c.Long(nullable: false),
                        Socrnameorg = c.String(nullable: false),
                        FIO = c.String(),
                    })
                .PrimaryKey(t => t.OrganizationCuratorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrganizationCurators");
        }
    }
}
