namespace SystemNFO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneTablEmp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        Login = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
