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
            var article = db.Articles.Find(Id);

            db.Articles.Remove(article);
            db.SaveChanges();

            ViewBag.Saved = "Delete";
            ViewBag.Changed = article.Title;
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            SetCSS("Add");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Article articles)
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
            ViewBag.Saved = "Add";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            SetCSS("Edit");
            var db = new WebsiteContext();
            var article = db.Articles.Find(Id);
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(int id, Article NewArticle)
        {
            var db = new WebsiteContext(); //Nieuwe Database Connectie
            NewArticle.Id = id;
            db.Entry(NewArticle).State = EntityState.Modified; 
            db.SaveChanges(); //Sla wijzigenen op.
  
            ViewBag.Saved = "Edit";
            return RedirectToAction("Index");
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