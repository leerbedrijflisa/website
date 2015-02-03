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

        public ActionResult Delete(int? id)
        {
            var article = _db.Articles.Find(id);

            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }

        [HttpPost]
        public ActionResult Delete(int? id, string confirmed)
        {
            var article = _db.Articles.Find(id);

            if (article == null)
            {
                return HttpNotFound();
            }

            if(confirmed == "Verwijderen")
            {
                _db.Articles.Remove(article);
                _db.SaveChanges();
            }

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
            _db.Articles.Add(new Article
            {
                Title = articles.Title,
                Image = articles.Image,
                Content = articles.Content,
                Date = DateTime.Now
            });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            SetCSS("Edit");
            var article = _db.Articles.Find(Id);
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(int id, Article NewArticle)
        {
            NewArticle.Id = id;
            _db.Entry(NewArticle).State = EntityState.Modified; 
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private IEnumerable<Article> GetArticles()
        {
            return _db.Articles.AsEnumerable();
        }

        private void SetCSS(string pageName)
        {
            ViewBag.css = "Articles/article" + pageName + ".css";
            ViewBag.cssResponsive = "Articles/article" + pageName + "Responsive.css";
        }

        private WebsiteContext _db = new WebsiteContext();
    }
}