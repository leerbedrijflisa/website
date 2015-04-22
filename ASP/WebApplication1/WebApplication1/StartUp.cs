using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Owin;

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
        }
    }
}