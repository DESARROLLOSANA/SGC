namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreq : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Requerimientoes",
            //    c => new
            //        {
            //            Id_Requerimiento = c.Int(nullable: false, identity: true),
            //            Id_Solicitud = c.Int(),
            //            Descripcion = c.String(maxLength: 500),
            //            Id_Estado = c.Int(nullable: false),
            //            Id_Proveedor = c.Int(nullable: false),
            //            Id_Calendario = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id_Requerimiento);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requerimientoes");
        }
    }
}
