namespace EntityDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Letovis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        datum_vreme_poletanja = c.DateTime(nullable: false),
                        datum_vreme_sletanja = c.DateTime(nullable: false),
                        duzina_putovanja_metri = c.String(),
                        duzina_putovanja_milje = c.String(),
                        cena_karte_cena = c.Double(nullable: false),
                        cena_karte_valuta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Letovis");
        }
    }
}
