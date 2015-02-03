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
        public ActionResult Add(Podcast podcast)
        {
            var db = new WebsiteContext();
            db.Podcasts.Add(new Podcast
            {
                Title = podcast.Title,
                Image = podcast.Image,
                Content = podcast.Content,
                Author = podcast.Author,
                References = podcast.References,
                File = podcast.File,
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
            var podcast = db.Podcasts.Find(Id);
            return View(podcast);
        }

        [HttpPost]
        public ActionResult Edit(int id, Podcast NewPodcast)
        {
            SetCSS("Index");

            var db = new WebsiteContext(); 
            NewPodcast.Id = id;
            db.Entry(NewPodcast).State = EntityState.Modified;
            db.SaveChanges(); 

            ViewBag.Saved = "Edit";
            return RedirectToAction("Index");
        }

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