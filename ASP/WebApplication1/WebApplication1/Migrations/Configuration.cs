using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Lisa.Website.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Lisa.Website.WebsiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        //private readonly UserManager<User> userManager;

        protected override void Seed(Lisa.Website.WebsiteContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));

            // Add a test administrator account (name=admin pass=something)

            var user = new User();
            user.Email = "Administrator@leerbedrijflisa.nl";
            user.Activity = true;
            user.ChangePassword = true;
            
            userManager.CreateAsync(user, "j%Dvlz4&keI!iPGebOtWeV4G");

            //NOTE: make sure the code generates a default user with the usermanager.
        }
    }
}
