using System.Data.Entity;

namespace Lisa.Website
{
    public class WebsiteContext : DbContext
    {
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}