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

        private IEnumerable<Podcast> GetPodcast()
        {
            return new Podcast[]
            { 
                new Podcast
                {
                    Id = 1,
                    Title = "De wonderbaarlijke wereld van stoeptegels",
                    File = "Lisa Developers Podcast 2014-08-10.mp3",
                    Image = "Penguin.png",
                    Date = "2014-08-10",
                    Content = "iets van inhoud",
                    Author = "Joost Ronkes Agerbeek, Wilco",
                    References = "hier komt een linkje",
                },

                new Podcast
                {
                    Id = 2,
                    Title = "Alles wat je wilt weten over regendruppels",
                    File = "Lisa Developers Podcast 2014-08-31.mp3",
                    Image = "Raven.png",
                    Date = "2014-08-31",
                    Content = "Developers podcast van leerwerkbedrijf Lisa.",
                    Author = "Joost Ronkes Agerbeek, Wilco",
                    References = "hier komt een linkje"
                },

                new Podcast
                {
                    Id = 3,
                    Title = "De grote geheimen van de dropfabriek",
                    File = "Lisa Developers Podcast 2014-09-28.mp3",
                    Image = "Raven.png",
                    Date = "2014-08-31",
                    Content = "Developers podcast van leerwerkbedrijf Lisa.",
                    Author = "Joost Ronkes Agerbeek, Wilco",
                    References = "hier komt een linkje"
                }
            };
        }
    }
}