using System.Data.Entity;

namespace Lisa.Website
{
    public class PodcastContext : DbContext
    {
        public DbSet<Podcast> Podcasts { get; set; }
    }
}