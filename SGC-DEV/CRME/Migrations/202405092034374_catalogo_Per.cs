namespace CRME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catalogo_Per : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cat_perm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cat_perm");
        }
    }
}
