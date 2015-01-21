using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lisa.Website
{
    public class ArticlesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.css = "Articles/articleIndex.css";
            ViewBag.cssResponsive = "Articles/articleIndexResponsive.css";
            ViewBag.localScript = "~/Scripts/article.js";
            var articles = GetArticles();
            return View(articles);
        }

        public ActionResult Details(int id)
        {
            ViewBag.css = "Articles/articleDetail.css";
            ViewBag.cssResponsive = "Articles/articleDetailResponsive.css";

            var article = (from a in GetArticles()
                           where a.Id == id
                           select a).SingleOrDefault();

            return View(article);
        }
        
        private IEnumerable<Article> GetArticles()
        {
            //var db = new WebsiteContext();
            //return db.Article.AsEnumerable();
           
            //BUGFIX MUST RETURN SOMETHING
        }
         
    }
}