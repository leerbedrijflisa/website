using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lisa.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Make sure the database is updated to the latest version. This effectively runs Update-Database, even when running in Azure.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebsiteContext, Migrations.Configuration>());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
