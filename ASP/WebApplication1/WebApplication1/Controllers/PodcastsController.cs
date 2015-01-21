using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lisa.Website.Controllers
{
    public class PodcastsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.css = "Podcasts/podcastIndex.css";
            ViewBag.cssResponsive = "Podcasts/CSS/podcastIndexResponsive.css";
            return View(GetPodcast());
        }

        public ActionResult Details(int id)
        {
            ViewBag.css = "Podcasts/podcastDetail.css";
            ViewBag.cssResponsive = "Podcasts/podcastDetailResponsive.css";

            var podcast = (from a in GetPodcast()
                           where a.Id == id
                           select a).SingleOrDefault();

            return View(podcast);
        }

        public ActionResult RSS()
        {
            return View(GetPodcast());
        }

        private IEnumerable<Podcast> GetPodcast()
        {
            var db = new WebsiteContext();
            return db.Podcasts.AsEnumerable();
        }
    }
}