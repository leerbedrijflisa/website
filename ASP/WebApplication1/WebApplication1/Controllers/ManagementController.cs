using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lisa.Website.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.css = "";
            ViewBag.cssResponsive = "";
            return View();
        }

        public ActionResult AddArticle()
        {
            ViewBag.css = "";
            ViewBag.cssResponsive = "";
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(Article articles)
        {
            var db = new WebsiteContext();
            db.Articles.Add(new Article
            {
                Title = articles.Title,
                Image = articles.Image,
                Content = articles.Content,
                Date = DateTime.Now
            });
            db.SaveChanges();

            ViewBag.Saved = true;

            return View();
        }
    }
}