namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Curs",
                c => new
                    {
                        CurId = c.Int(nullable: false, identity: true),
                        Ogrn = c.Long(nullable: false),
                        Socrnameorg = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CurId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Curs");
        }
    }
}
