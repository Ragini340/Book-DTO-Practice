namespace Book.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameNew = c.String(),
                        LocationNew = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstNameNew = c.String(),
                        LastNameNew = c.String(),
                        GenderNew = c.String(),
                        SalaryNew = c.Int(nullable: false),
                        DepartmentNew_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentNews", t => t.DepartmentNew_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeNews", "DepartmentNew_Id", "dbo.DepartmentNews");
            DropTable("dbo.EmployeeNews");
            DropTable("dbo.DepartmentNews");
        }
    }
}
