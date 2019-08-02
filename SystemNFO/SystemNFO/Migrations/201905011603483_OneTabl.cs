namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneTabl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Fio");
        }
    }
}
