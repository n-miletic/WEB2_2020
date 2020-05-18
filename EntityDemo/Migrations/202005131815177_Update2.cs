namespace EntityDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminAvios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminRents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Aviokompanijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adresa_Drzava = c.String(),
                        Adresa_Grad = c.String(),
                        Adresa_Ulica = c.String(),
                        Adresa_Broj = c.Int(nullable: false),
                        Adresa_Postanski_Broj = c.Int(nullable: false),
                        Promo_opis = c.String(),
                        Prosecna_ocena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Korisnicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Uloga = c.Int(nullable: false),
                        UlogaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentACars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adresa_Drzava = c.String(),
                        Adresa_Grad = c.String(),
                        Adresa_Ulica = c.String(),
                        Adresa_Broj = c.Int(nullable: false),
                        Adresa_Postanski_Broj = c.Int(nullable: false),
                        Promo_opis = c.String(),
                        Prosecna_ocena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voziloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adresa_Drzava = c.String(),
                        Adresa_Grad = c.String(),
                        Adresa_Ulica = c.String(),
                        Adresa_Broj = c.Int(nullable: false),
                        Adresa_Postanski_Broj = c.Int(nullable: false),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Voziloes");
            DropTable("dbo.RentACars");
            DropTable("dbo.Korisnicis");
            DropTable("dbo.Aviokompanijas");
            DropTable("dbo.Admins");
            DropTable("dbo.AdminRents");
            DropTable("dbo.AdminAvios");
        }
    }
}
