namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actualizaciones : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.cat_sistemas", "De_Cve_Departamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.cat_sistemas", "De_Cve_Departamento", c => c.Int(nullable: false));
        }
    }
}
