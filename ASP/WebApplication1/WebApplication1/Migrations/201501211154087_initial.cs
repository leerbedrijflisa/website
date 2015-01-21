namespace Lisa.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Podcasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        File = c.String(),
                        Content = c.String(),
                        Image = c.String(),
                        Date = c.String(),
                        Author = c.String(),
                        References = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Podcasts");
        }
    }
}
