using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lisa.Website.Controllers
{
    public class ManagementPodcastsController : Controller
    {
        public ActionResult Index()
        {
            SetCSS("Index");
            return View(GetPodcasts());
        }

        [HttpPost]
        public ActionResult Index(int Id)
        {
            SetCSS("Index");
            var db = new WebsiteContext();
            var podcast = db.Podcasts.Find(Id);

            db.Podcasts.Remove(podcast);
            db.SaveChanges();

            ViewBag.Saved = "Delete";
            ViewBag.Changed = podcast.Title;
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
        /*
        public ActionResult Edit(int id)
        {
            SetCSS("Edit");
            var db = new WebsiteContext();
            var article = (from a in GetPodcasts()
                           where a.Id == id
                           select a).SingleOrDefault();
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(int id, Article NewArticle)
        {
            SetCSS("Index");

            var db = new WebsiteContext(); //Nieuwe Database Connectie
            NewArticle.Id = id;
            db.Entry(NewArticle).State = EntityState.Modified;
            db.SaveChanges(); //Sla wijzigenen op.

            ViewBag.Saved = "Edit";
            return RedirectToAction("Index");
        }
        */

        private IEnumerable<Podcast> GetPodcasts()
        {
            var db = new WebsiteContext();
            return db.Podcasts.AsEnumerable();
        }

        private void SetCSS(string pageName)
        {
            ViewBag.css = "Podcasts/podcast" + pageName + ".css";
            ViewBag.cssResponsive = "Podcasts/podcast" + pageName + "Responsive.css";
        }
    }
}