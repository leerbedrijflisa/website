using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Lisa.Website
{
    public class WebsiteContext : IdentityDbContext<User>
    {
        public WebsiteContext() : base("WebsiteContext")
        {

        }

        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}