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
            return View(GetPodcasts());
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var db = new WebsiteContext();
            var podcast = db.Podcasts.Find(id);
            db.Podcasts.Remove(podcast);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Add()
        {
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
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            var db = new WebsiteContext();
            var podcast = db.Podcasts.Find(id);
            return View(podcast);
        }

        [HttpPost]
        public ActionResult Edit(int id, Podcast NewPodcast)
        {
            var db = new WebsiteContext(); 
            NewPodcast.Id = id;
            db.Entry(NewPodcast).State = EntityState.Modified;
            db.SaveChanges(); 
            return RedirectToAction("Index");
        }

        private IEnumerable<Podcast> GetPodcasts()
        {
            var db = new WebsiteContext();
            return db.Podcasts.AsEnumerable();
        }
    }
}