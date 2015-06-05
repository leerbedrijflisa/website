using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Mvc;

namespace Lisa.Website
{
    public abstract class BaseController : Controller
    {
        //Makes Usermanager accesable in every controller that links to the BaseController.

        public readonly UserManager<User> userManager;

        public BaseController(): this(Startup.UserManagerFactory.Invoke())
        {
        }

        public BaseController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        //Makes the currently logged in user id accesable in every controller linked to the BaseController.

        public UserPrincipal CurrentUser
        {
            get
            {
                return new UserPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }
}