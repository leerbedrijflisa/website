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
            ViewBag.css = "~/Content/CSS/podcastIndex.css";
            ViewBag.cssResponsive = "~/Content/CSS/podcastIndexResponsive.css";
            return View(GetPodcast());
        }

        public ActionResult Details(int id)
        {
            ViewBag.css = "~/Content/CSS/podcastDetail.css";
            ViewBag.cssResponsive = "~/Content/CSS/podcastDetailResponsive.css";

            var podcast = (from a in GetPodcast()
                           where a.Id == id
                           select a).SingleOrDefault();

            return View(podcast);
        }

        private IEnumerable<Podcast> GetPodcast()
        {
            return new Podcast[]
            {
                new Podcast
                {
                    Id = 1,
                    Title = "De wonderbaarlijke wereld van stoeptegels",
                    File = "",
                    Image = "Penguin.png",
                    Date = "2014-04-01",
                    Content = "iets van inhoud"
                },

                new Podcast
                {
                    Id = 2,
                    Title = "Alles wat je wilt weten over regendruppels",
                    File = "",
                    Image = "Raven.png",
                    Date = "2014-03-11",
                    Content = "Bla Bla Bla"
                }
            };
        }
    }
}