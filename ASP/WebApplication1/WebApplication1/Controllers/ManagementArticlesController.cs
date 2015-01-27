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
            SetCSS("Index");
            var db = new WebsiteContext();
            var deletedItem = (from a in GetArticles()
                           where a.Id == Id
                           select a).SingleOrDefault();

            Article deleteArticle = (Article)db.Articles.Where(selectedArticle => selectedArticle.Id == Id).First();
            db.Articles.Remove(deleteArticle);
            db.SaveChanges();

            ViewBag.Saved = "Delete";
            ViewBag.Changed = deletedItem.Title;
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
            ViewBag.Saved = "Add";

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

            var db = new WebsiteContext(); //Nieuwe Database Connectie
            db.Articles.Attach(articles); //?
            db.Entry(articles).State = EntityState.Modified; //?
            db.SaveChanges(); //Sla wijzigenen op.
  
            ViewBag.Saved = "Edit";
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