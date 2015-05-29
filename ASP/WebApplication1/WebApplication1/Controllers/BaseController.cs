using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Mvc;

namespace Lisa.Website
{
    public abstract class BaseController : Controller
    {
        public readonly UserManager<User> userManager;

        public BaseController(): this(Startup.UserManagerFactory.Invoke())
        {
        }

        public BaseController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public UserPrincipal CurrentUser
        {
            get
            {
                return new UserPrincipal(this.User as ClaimsPrincipal);
            }
        }

        public void checkPassChange()
        {
            
        }
    }
}