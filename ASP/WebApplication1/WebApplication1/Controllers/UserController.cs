using Lisa.Website.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lisa.Website
{
    public class UserController : BaseController
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
            ViewBag.LoggedUserId = this.User.Identity.GetUserId();
            return View(_db.Users);
        }

        public ActionResult MyAccount()
        {
            var Id = this.User.Identity.GetUserId();
            var user = userManager.FindById(Id);
            return View(user);
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
                PasswordNew = null,
                PasswordConfirm = null
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
        public async Task<ActionResult> Edit(User EditUser)
        {
            var user = await userManager.FindByIdAsync(EditUser.Id);
            var errorState = false;

            if (EditUser.PasswordNew != null)
            {
                if (EditUser.PasswordNew != EditUser.PasswordConfirm)
                {
                    ModelState.AddModelError("", "Wachtwoorden zijn niet gelijk!");
                    errorState = true;
                }
                else
                {
                    userManager.RemovePassword(user.Id);
                    userManager.AddPassword(user.Id, EditUser.PasswordNew);
                }
            }

            user.UserName = EditUser.Email;
            user.PasswordNew = null;
            user.PasswordConfirm = null;
            
            var result = await userManager.UpdateAsync(user);
            
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
                errorState = true;
            }

            if (errorState == true)
            {
                EditUser.UserName = EditUser.Email;
                return View(EditUser);
            }
            else
            {
                return RedirectToAction("Admin");
            }
        }

        private WebsiteContext _db = new WebsiteContext();
        
    }
}