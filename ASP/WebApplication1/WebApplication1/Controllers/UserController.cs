
using Lisa.Website.ViewModels;
using Microsoft.AspNet.Identity;
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
            var currentUser = await userManager.FindByIdAsync(Id);

            var user = new User
            {
                Email = model.Email,
                EmailConfirmed = currentUser.EmailConfirmed,
                PasswordHash = currentUser.PasswordHash,
                SecurityStamp = currentUser.SecurityStamp,
                PhoneNumber = currentUser.PhoneNumber,
                PhoneNumberConfirmed = currentUser.PhoneNumberConfirmed,
                TwoFactorEnabled = currentUser.TwoFactorEnabled,
                LockoutEndDateUtc = currentUser.LockoutEndDateUtc,
                LockoutEnabled = currentUser.LockoutEnabled,
                AccessFailedCount = currentUser.AccessFailedCount,
                UserName = model.Email
            };

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