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

        private WebsiteContext _db = new WebsiteContext();
         
    }
}