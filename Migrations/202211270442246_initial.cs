namespace Book.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeNews", "DepartmentNew_Id", "dbo.DepartmentNews");
            DropIndex("dbo.EmployeeNews", new[] { "DepartmentNew_Id" });
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            DropTable("dbo.DepartmentNews");
            DropTable("dbo.EmployeeNews");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartmentNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameNew = c.String(),
                        LocationNew = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.BookModels", "AuthorId", "dbo.Authors");
            DropIndex("dbo.BookModels", new[] { "AuthorId" });
            DropTable("dbo.BookModels");
            DropTable("dbo.Authors");
            CreateIndex("dbo.EmployeeNews", "DepartmentNew_Id");
            AddForeignKey("dbo.EmployeeNews", "DepartmentNew_Id", "dbo.DepartmentNews", "Id");
        }
    }
}
