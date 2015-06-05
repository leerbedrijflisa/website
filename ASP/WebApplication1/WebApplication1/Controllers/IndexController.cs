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
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [PasswordCheck]
        public ActionResult Admin()
        {
            var Id = this.User.Identity.GetUserId();
            var user = userManager.FindById(Id);
            return View(user);
        }

        private WebsiteContext _db = new WebsiteContext();
    }
}