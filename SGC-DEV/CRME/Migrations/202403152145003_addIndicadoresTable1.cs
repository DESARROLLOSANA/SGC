namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIndicadoresTable1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.cat_indicadores");
            AlterColumn("dbo.cat_indicadores", "indicadores_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.cat_indicadores", "indicadores_ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.cat_indicadores");
            AlterColumn("dbo.cat_indicadores", "indicadores_ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.cat_indicadores", "indicadores_ID");
        }
    }
}
