namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaPeriodos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cat_periodos",
                c => new
                    {
                        periodo_ID = c.Int(nullable: true),
                        periodo_des = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.periodo_ID);
            
            AlterColumn("dbo.cat_indicadores", "frec_med", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.cat_indicadores", "frec_med", c => c.String(maxLength: 30));
            DropTable("dbo.cat_periodos");
        }
    }
}
