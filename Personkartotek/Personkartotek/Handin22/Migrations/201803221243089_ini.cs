namespace Handin22.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdressId = c.Long(nullable: false, identity: true),
                        Street = c.String(),
                        Number = c.String(),
                        City_CityId = c.Long(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.AdressId)
                .ForeignKey("dbo.Cities", t => t.City_CityId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.City_CityId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Type = c.String(),
                        PAdress_AdressId = c.Long(),
                        Adress_AdressId = c.Long(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Adresses", t => t.PAdress_AdressId)
                .ForeignKey("dbo.Adresses", t => t.Adress_AdressId)
                .Index(t => t.PAdress_AdressId)
                .Index(t => t.Adress_AdressId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneID = c.Long(nullable: false, identity: true),
                        Number = c.String(),
                        provider = c.String(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PhoneID)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Adress_AdressId", "dbo.Adresses");
            DropForeignKey("dbo.Adresses", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Phones", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.People", "PAdress_AdressId", "dbo.Adresses");
            DropForeignKey("dbo.Adresses", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Phones", new[] { "Person_PersonId" });
            DropIndex("dbo.People", new[] { "Adress_AdressId" });
            DropIndex("dbo.People", new[] { "PAdress_AdressId" });
            DropIndex("dbo.Adresses", new[] { "Person_PersonId" });
            DropIndex("dbo.Adresses", new[] { "City_CityId" });
            DropTable("dbo.Phones");
            DropTable("dbo.People");
            DropTable("dbo.Cities");
            DropTable("dbo.Adresses");
        }
    }
}
