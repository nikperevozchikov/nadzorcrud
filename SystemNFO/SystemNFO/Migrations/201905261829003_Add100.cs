namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add100 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Organizationcurs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Organizationcurs",
                c => new
                    {
                        OrganizationcurId = c.Int(nullable: false, identity: true),
                        Ogrn = c.Long(nullable: false),
                        Socrnameorg = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrganizationcurId);
            
        }
    }
}
