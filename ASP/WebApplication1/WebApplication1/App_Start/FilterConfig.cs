using System.Web.Mvc;

namespace Lisa.Website
{
    public class FilterConfig
    {
        //Filters applied to all classes in the solution.

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); //adds [authorize] to all classes, non authorize classes need to be defined with [allowAnonymous] now.
        }
    }
}