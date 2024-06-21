namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNewColums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cat_sistemas", "Em_Cve_Empresa", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.cat_sistemas", "Em_Cve_Empresa");
        }
    }
}
