using System.Security.Claims;
using System.Web.Mvc;

namespace Lisa.Website
{
    public abstract class BaseController : Controller
    {
        public UserPrincipal CurrentUser
        {
            get
            {
                return new UserPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }
}