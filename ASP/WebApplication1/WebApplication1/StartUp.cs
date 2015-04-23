using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using System;
using Microsoft.AspNet.Identity.EntityFramework;

//Tells the solution on startup that owin is used and that a authenticationCookie is used.
[assembly: OwinStartup(typeof(Lisa.Website.Startup))]

namespace Lisa.Website
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });

            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<User>(new UserStore<User>(new WebsiteContext()));

                usermanager.UserValidator = new UserValidator<User>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return usermanager;
            };
        }

        public static Func<UserManager<User>> UserManagerFactory { get; private set; }

    }
}