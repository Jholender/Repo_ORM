namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataModyf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ZadanieDBs", "DataModyf", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ZadanieDBs", "DataModyf");
        }
    }
}
