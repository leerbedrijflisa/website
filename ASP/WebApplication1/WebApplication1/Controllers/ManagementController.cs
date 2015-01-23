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
            SetCSS("Index");
            return View();
        }

        public ActionResult Add()
        {
            SetCSS("Add");
            return View(GetArticles());
        }

        [HttpPost]
        public ActionResult Add(Article articles)
        {
            SetCSS("Add");

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

            return View(GetArticles());
        }

        private IEnumerable<Article> GetArticles()
        {
            var db = new WebsiteContext();
            return db.Articles.AsEnumerable();
        }

        private void SetCSS(string pageName)
        {
            ViewBag.css = "Articles/article" + pageName + ".css";
            ViewBag.cssResponsive = "Articles/article" + pageName + "Responsive.css";
        }
    }
}