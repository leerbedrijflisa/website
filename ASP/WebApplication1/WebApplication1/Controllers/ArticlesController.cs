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
            ViewBag.css = "~/Content/CSS/articles.css";
            ViewBag.cssResponsive = "~/Content/CSS/articlesResponsive.css";
            ViewBag.localScript = "~/Scripts/article.js";
            var articles = GetArticles();
            return View(articles);
        }

        public ActionResult Details(int id)
        {
            ViewBag.css = "~/Content/CSS/article.css";
            ViewBag.cssResponsive = "~/Content/CSS/articleResponsive.css";

            var article = (from a in GetArticles()
                           where a.Id == id
                           select a).SingleOrDefault();

            return View(article);
        }

        private IEnumerable<Article> GetArticles()
        {
            return new Article[]
            {
                new Article
                {
                    Id = 1,
                    Title = "De wonderbaarlijke wereld van stoeptegels",
                    Description = "...",
                    Contents = "bla bla bla",
                    Image = "Penguin.png"
                },

                new Article
                {
                    Id = 2,
                    Title = "Alles wat je wilt weten over regendruppels",
                    Description = "---",
                    Contents = "dinges",
                    Image = "Raven.png"
                }
            };
        }
    }
}