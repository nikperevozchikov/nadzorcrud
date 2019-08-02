namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Low8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrgCurs", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrgCurs", "EmployeeId");
            AddForeignKey("dbo.OrgCurs", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            DropColumn("dbo.Employees", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Position", c => c.String(nullable: false));
            DropForeignKey("dbo.OrgCurs", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.OrgCurs", new[] { "EmployeeId" });
            DropColumn("dbo.OrgCurs", "EmployeeId");
        }
    }
}
