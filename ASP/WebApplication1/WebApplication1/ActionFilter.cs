using System;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.Routing;

namespace Lisa.Website
{
    public class PasswordCheckAttribute : ActionFilterAttribute
    {
        public readonly UserManager<User> userManager;

        public PasswordCheckAttribute(): this(Startup.UserManagerFactory.Invoke())
        {
        }

        public PasswordCheckAttribute(UserManager<User> userManager)
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

        public override void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            var authUser = filterContext.Controller.ControllerContext.RequestContext.HttpContext.User;

            if (authUser != null && authUser.Identity.IsAuthenticated == true)
            {
                var Id = authUser.Identity.GetUserId();
                var user = userManager.FindById(Id);

                if (user.ChangePassword == true)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary 
                    {
                        { "controller", "User" }, 
                        { "action", "ChangePass" } 
                    });
                }

                
            }
        }

        public ClaimsPrincipal User { get; set; }
    }
}