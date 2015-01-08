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
                    Contents = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras sodales tincidunt tellus, a mollis leo lacinia eget. Ut tempus ultrices lacinia. Nam feugiat, neque eget aliquam suscipit, leo dolor molestie diam, a pulvinar risus velit ut mauris. Nullam scelerisque, turpis ac efficitur dapibus, metus diam bibendum tortor, quis rutrum nisl nunc vitae purus. Aliquam sodales neque eleifend sapien suscipit blandit. Morbi vitae semper ligula. Pellentesque nulla mi, porta eget condimentum vel, elementum ullamcorper neque. Donec consequat lectus vitae dapibus malesuada. Maecenas efficitur sapien a congue facilisis. In eros erat, aliquam in ex ac, euismod tincidunt nibh. Maecenas eget imperdiet sem. Ut eleifend eu nunc ac scelerisque. Fusce lobortis lectus sit amet augue rhoncus, et tempor erat volutpat.Quisque suscipit sollicitudin ex, ut semper risus volutpat non. Duis felis diam, porta quis nibh nec, volutpat hendrerit mauris. Donec iaculis varius eleifend. Vestibulum condimentum hendrerit vestibulum. Suspendisse felis mi, congue eget interdum ac, mattis sit amet massa. Praesent sem sapien, semper venenatis nisi quis, gravida fermentum neque. Pellentesque quis accumsan turpis. Phasellus quis vestibulum turpis.",
                    Image = "Raven.png"
                }
            };
        }
    }
}