namespace Estates2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        EstateId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Estates", t => t.EstateId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.EmployeeId)
                .Index(t => t.EstateId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Estates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adress = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Furniture = c.Boolean(nullable: false),
                        Balcony = c.Boolean(nullable: false),
                        RoomsNumber = c.Int(nullable: false),
                        Description = c.String(),
                        Bedrooms = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adress = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        PhoneNumber = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "EstateId", "dbo.Estates");
            DropForeignKey("dbo.Estates", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Meetings", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Meetings", "ClientId", "dbo.Clients");
            DropIndex("dbo.Estates", new[] { "OwnerId" });
            DropIndex("dbo.Meetings", new[] { "EstateId" });
            DropIndex("dbo.Meetings", new[] { "EmployeeId" });
            DropIndex("dbo.Meetings", new[] { "ClientId" });
            DropTable("dbo.Owners");
            DropTable("dbo.Estates");
            DropTable("dbo.Employees");
            DropTable("dbo.Meetings");
            DropTable("dbo.Clients");
        }
    }
}
