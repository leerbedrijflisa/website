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
            //var user = new User
            //{
            //    UserName = "administrator@leerbedrijflisa.nl"
            //};

            //public Configuration(UserManager<User> userManager)
            //{
            //    this.userManager = userManager;
            //}

            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            // Add a test administrator account (name=admin pass=iets)
			var user = new IdentityUser("administrator@leerbedrijflisa.nl");
            userManager.CreateAsync(user, "j%Dvlz4&keI!iPGebOtWeV4G");

            //NOTE: Zorg at de code een default user aanmaakt door middel van de bestaande usermanager.
            //(De andere methode werkte niet omdat je niet kan nagaan aan welke eisen je user moet voldoen en deze er niet aan voldeed).

            //var DefaultAdministrator = new User
            //{
            //    UserName = "administrator",
            //    PasswordHash = "AJKAyuBOWURPHBb5vFcL/+aQZjQdCtm0Tx+Fs0oAQ+TT2zqLdNIHhEo0aMUhcl6xJQ==",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //Password for administrator: j%Dvlz4&keI!iPGebOtWeV4G

            //context.Users.Add(DefaultAdministrator);
            //context.SaveChanges();

        }
    }
}
