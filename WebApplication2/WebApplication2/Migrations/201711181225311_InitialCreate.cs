namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZadanieDBs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Towar = c.String(),
                        DataWprow = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZadanieDBs");
        }
    }
}
