namespace Lisa.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Podcasts", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Podcasts", "Date", c => c.String());
        }
    }
}
