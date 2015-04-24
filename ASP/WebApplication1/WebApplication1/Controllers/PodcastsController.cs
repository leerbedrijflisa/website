using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace Lisa.Website.Controllers
{
    public class PodcastsController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(GetPodcast());
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var podcast = _db.Podcasts.Find(id);
            return View(podcast);
        }

        [AllowAnonymous]
        public ActionResult RSS()
        {
            return View(GetPodcast());
        }

        public ActionResult Admin()
        {
            return View(GetPodcast());
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

            return RedirectToAction("Admin");
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
            return RedirectToAction("Admin");
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
            return RedirectToAction("Admin");
        }

        private IEnumerable<Podcast> GetPodcast()
        {
            return _db.Podcasts.AsEnumerable();
        }

        private WebsiteContext _db = new WebsiteContext();
    }
}