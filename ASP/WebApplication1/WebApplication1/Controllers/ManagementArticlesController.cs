using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lisa.Website.Controllers
{
    public class ManagementArticlesController : Controller
    {
        public ActionResult Index()
        {
            SetCSS("Index");
            return View(GetArticles());
        }

        [HttpPost]
        public ActionResult Index(int Id)
        {
            var db = new WebsiteContext();
            var article = (from a in GetArticles()
                           where a.Id == Id
                           select a).SingleOrDefault();
            db.Articles.Remove(article);
            db.SaveChanges();
            return View(GetArticles());
        }

        public ActionResult Add()
        {
            SetCSS("Add");
            return View();
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

            return View("Index", GetArticles());
        }

        public ActionResult Edit(int id)
        {
            SetCSS("Edit");
            var db = new WebsiteContext();
            var article = (from a in GetArticles()
                           where a.Id == id
                           select a).SingleOrDefault();
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article articles)
        {
            SetCSS("Edit");

            var db = new WebsiteContext();
            db.Articles.Attach(articles);
            var entry = db.Entry(articles);
            entry.State = EntityState.Modified;
            db.SaveChanges(); 
  
            ViewBag.Saved = true;
            return View("Index");
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