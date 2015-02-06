using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Lisa.Website
{
    public class ArticlesController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.css = "Articles/articleIndex.css";
            ViewBag.cssResponsive = "Articles/articleIndexResponsive.css";
            ViewBag.localScript = "~/Scripts/article.js";

            var articles = _db.Articles;
            return View(articles);
        }

        public ActionResult Details(int? id)
        {
            ViewBag.css = "Articles/articleDetail.css";
            ViewBag.cssResponsive = "Articles/articleDetailResponsive.css";

            var article = _db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }

        public ActionResult Admin()
        {
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

            if (confirmed == "Verwijderen")
            {
                _db.Articles.Remove(article);
                _db.SaveChanges();
            }

            return RedirectToAction("Admin");
        }

        public ActionResult Add()
        {
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
            return RedirectToAction("Admin");
        }

        public ActionResult Edit(int id)
        {
            var article = _db.Articles.Find(id);
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(int id, Article NewArticle)
        {
            NewArticle.Id = id;
            _db.Entry(NewArticle).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Admin");
        }

        private IEnumerable<Article> GetArticles()
        {
            return _db.Articles.AsEnumerable();
        }

        private WebsiteContext _db = new WebsiteContext();
         
    }
}