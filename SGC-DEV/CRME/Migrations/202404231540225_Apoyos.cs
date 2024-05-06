namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Apoyos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doc_apoyo",
                c => new
                    {
                        Id_doc = c.Int(nullable: false, identity: true),
                        Nombre_doc = c.String(),
                        Ruta_doc = c.String(),
                    })
                .PrimaryKey(t => t.Id_doc);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doc_apoyo");
        }
    }
}
