namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneTablEmpReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Login", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Login", c => c.String());
        }
    }
}
