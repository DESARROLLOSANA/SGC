namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Day : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cat_indicadores", "dia", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.cat_indicadores", "dia");
        }
    }
}
