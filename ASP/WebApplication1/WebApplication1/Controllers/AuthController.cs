using Lisa.Website.ViewModels;
using System.Security.Claims;
using System.Web.Mvc;

//User gets redirected to this controller when the user is not logged in. This needs to be accesible by anonymous/not logged in users so [AllowAnonymous] is required.

namespace Lisa.Website
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
    }
}