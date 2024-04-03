namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIndicadoresTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cat_indicadores",
                c => new
                    {
                        indicadores_ID = c.Int(nullable: false, identity: true),
                        empresa_ID = c.Int(nullable: false),
                        proceso = c.String(maxLength: 50),
                        indicador = c.String(maxLength: 30),
                        form_cal = c.String(maxLength: 30),
                        res_esp = c.Single(nullable: false),
                        resp_med = c.Int(nullable: false),
                        frec_med = c.String(maxLength: 30),
                        resp_mej = c.Int(nullable: false),
                        ene = c.Int(nullable: false),
                        feb = c.Int(nullable: false),
                        mar = c.Int(nullable: false),
                        abr = c.Int(nullable: false),
                        may = c.Int(nullable: false),
                        jun = c.Int(nullable: false),
                        jul = c.Int(nullable: false),
                        ago = c.Int(nullable: false),
                        sep = c.Int(nullable: false),
                        oct = c.Int(nullable: false),
                        nov = c.Int(nullable: false),
                        dec = c.Int(nullable: false),
                        por_cum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.indicadores_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cat_indicadores");
        }
    }
}
