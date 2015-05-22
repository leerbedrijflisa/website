using Lisa.Website.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Lisa.Website
{
    public class UserManagementController : BaseController
    {
        private readonly UserManager<User> userManager;

        public UserManagementController(): this(Startup.UserManagerFactory.Invoke())
        {
        }

        public UserManagementController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult Admin()
        {
            return View(_db.Users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new User
            {
                UserName = model.Email,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return RedirectToAction("admin", "index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = _db.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User EditUser)
        {
            var user = _db.Users.Find(EditUser.Id);

            EditUser.PasswordHash = user.PasswordHash;
            EditUser.UserName = EditUser.Email;
            EditUser.Email = null;

            var result = userManager.Update(EditUser);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return RedirectToAction("Admin");
        }

        private WebsiteContext _db = new WebsiteContext();
        
    }
}