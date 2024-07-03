namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mopes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.modulos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Em_Cve_Empresa = c.Int(nullable: false),
                        modulo = c.String(maxLength: 50),
                        user_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mopes",
                c => new
                    {
                        Id_mope = c.Int(nullable: false),
                        modulo_ID = c.Int(nullable: false),
                        permisos_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_mope);
            
            AddColumn("dbo.cat_sistemas", "modulos_Id", c => c.Int());
            CreateIndex("dbo.cat_sistemas", "modulos_Id");
            AddForeignKey("dbo.cat_sistemas", "modulos_Id", "dbo.modulos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cat_sistemas", "modulos_Id", "dbo.modulos");
            DropIndex("dbo.cat_sistemas", new[] { "modulos_Id" });
            DropColumn("dbo.cat_sistemas", "modulos_Id");
            DropTable("dbo.Mopes");
            DropTable("dbo.modulos");
        }
    }
}
