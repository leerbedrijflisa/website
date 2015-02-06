using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lisa.Website.Controllers
{
    public class ManagementPodcastsController : BaseController
    {
        public ActionResult Index()
        {
            return View(GetPodcasts());
        }

        public ActionResult Delete(int? id)
        {
            var podcasts = _db.Podcasts.Find(id);

            if (podcasts == null)
            {
                return HttpNotFound();
            }

            return View(podcasts);
        }

        [HttpPost]
        public ActionResult Delete(int id, string confirmed)
        {
            var podcast = _db.Podcasts.Find(id);

            if (confirmed == "Verwijderen")
            {   
                _db.Podcasts.Remove(podcast);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Podcast podcast)
        {
            _db.Podcasts.Add(new Podcast
            {
                Title = podcast.Title,
                Image = podcast.Image,
                Content = podcast.Content,
                Author = podcast.Author,
                References = podcast.References,
                File = podcast.File,
                Date = DateTime.Now
            });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            var podcast = _db.Podcasts.Find(id);
            return View(podcast);
        }

        [HttpPost]
        public ActionResult Edit(int id, Podcast NewPodcast)
        {
            NewPodcast.Id = id;
            _db.Entry(NewPodcast).State = EntityState.Modified;
            _db.SaveChanges(); 
            return RedirectToAction("Index");
        }

        private IEnumerable<Podcast> GetPodcasts()
        {
            return _db.Podcasts.AsEnumerable();
        }

        private WebsiteContext _db = new WebsiteContext();
    }
}