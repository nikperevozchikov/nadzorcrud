namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrgCurs",
                c => new
                    {
                        OrgCurId = c.Int(nullable: false, identity: true),
                        Ogrn = c.Long(nullable: false),
                        Socrnameorg = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrgCurId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrgCurs");
        }
    }
}
