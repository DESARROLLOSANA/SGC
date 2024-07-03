namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Permisos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        Id_per = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        Id_perfil = c.Int(nullable: false),
                        cre = c.Int(nullable: false),
                        rea = c.Int(nullable: false),
                        del = c.Int(nullable: false),
                        upd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_per);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Permisos");
        }
    }
}
