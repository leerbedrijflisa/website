using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Lisa.Website.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
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