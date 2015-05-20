
using Lisa.Website.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Lisa.Website
{
    public class UserController:BaseController
    {
        private readonly UserManager<User> userManager;

        public UserController(): this(Startup.UserManagerFactory.Invoke())
        {
        }

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult Admin()
        {
            return View();
        }

        public async Task<ActionResult> Edit()
        {
            string Id = this.User.Identity.GetUserId();
            var user = await userManager.FindByIdAsync(Id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CreateModel model)
        {
            string Id = this.User.Identity.GetUserId();
            var user = await userManager.FindByIdAsync(Id);

            user.Id = user.Id;
            user.Email = user.Email;
            user.EmailConfirmed = user.EmailConfirmed;
            user.PasswordHash = user.PasswordHash;
            user.SecurityStamp = user.SecurityStamp;
            user.PhoneNumber = user.PhoneNumber;
            user.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            user.TwoFactorEnabled = user.TwoFactorEnabled;
            user.LockoutEndDateUtc = user.LockoutEndDateUtc;
            user.LockoutEnabled = user.LockoutEnabled;
            user.AccessFailedCount = user.AccessFailedCount;
            user.UserName = model.Email;

            //if (!ModelState.IsValid)
            //{
            //    return View(user);
            //}

            var result = await userManager.UpdateAsync(user);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return RedirectToAction("admin", "user");
        }

        private WebsiteContext _db = new WebsiteContext();
    }
}