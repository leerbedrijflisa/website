using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Lisa.Website.ViewModels;

namespace Lisa.Website.Controllers
{
    public class IndexController : BaseController
    {
        private readonly UserManager<User> userManager;

        public IndexController(): this(Startup.UserManagerFactory.Invoke())
        {
        }

        public IndexController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            var Id = this.User.Identity.GetUserId();
            var user = userManager.FindById(Id);
            return View(user);
        }

        public ActionResult Contact()
        {
            return View(_db.Contacts.Find(1));
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            contact.Id = 1;
            _db.Entry(contact).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Admin");
        }

        private WebsiteContext _db = new WebsiteContext();
    }
}