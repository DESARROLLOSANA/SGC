namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNewColums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cat_sistemas", "empresa_ID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.cat_sistemas", "empresa_ID");
        }
    }
}
