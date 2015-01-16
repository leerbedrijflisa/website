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
                    Content = "Stoeptegels (ook wel trottoirtegels genoemd) zijn in Nederland het meest voorkomende plaveisel op het trottoir en worden soms ook toegepast als bestrating van terrassen bij woningen. Een standaard stoeptegel is 30 x 30 x 4,5 cm groot en is vervaardigd van grijs beton. Het gewicht van één tegel is 9,5 kilogram. Bij zwaar belaste trottoirs en fietspaden worden tegels van 6 cm dik gebruikt (12,5 kilogram/stuk). Trottoirtegels worden meestal in dezelfde richting als de trottoirband gelegd in een ruitpatroon of per rij versprongen (halfsteensverband). Voor het vergemakkelijken van het leggen van een versprongen patroon worden halve tegels vervaardigd. De vijfkantige stenen die worden gebruikt bij het leggen van trottoirtegels onder een hoek van 45 graden ten opzichte van de trottoirband worden bisschopsmutsen genoemd.",
                    Author = "Joost Ronkes Agerbeek, Wilco van Duinkerken",
                    References = "hier komt een linkje",
                },

                new Podcast
                {
                    Id = 2,
                    Title = "Alles wat je wilt weten over regendruppels",
                    File = "Lisa Developers Podcast 2014-08-31.mp3",
                    Image = "Raven.png",
                    Date = "2014-08-31",
                    Content = "Voor de vorming van neerslag zijn in de eerste plaats wolken nodig, die bestaan uit al dan niet onderkoelde druppeltjes of ijskristallen die ontstaan zijn door condensatie of sublimatie. Deze elementen worden wolkenelementen genoemd en hebben een doorsnede van enkele μm (1 μm = 0,001 mm). Om daadwerkelijk tot neerslag te komen moeten de afmetingen van de onderkoelde druppeltjes in een wolk toenemen, zodat deze overgaan in neerslagelementen welke een doorsnede hebben van ten minste 100 à 200 μm. Het ontstaan van wolken gaat gepaard met verticale bewegingen die in snelheid kunnen variëren van enkele cm/sec tot meerdere meters/sec. Aangezien wolkenelementen valsnelheden hebben van slechts ongeveer 1 cm/sec, is het noodzakelijk dat deze aanzienlijk aangroeien zodat zij door een wolk kunnen vallen, verdamping in de niet-gecondenseerde lucht beneden de wolkenbasis kunnen overleven en de grond als motregen, regen, enzovoorts kunnen bereiken. De vorming van relatief kleine neerslagdruppels uit enorme hoeveelheden uiterst kleine wolkendruppeltjes wordt door een tweetal processen gerealiseerd: het coalescentie-proces en het Wegener-Bergeron-Findeisen-proces.",
                    Author = "Joost Ronkes Agerbeek, Wilco van Duinkerken",
                    References = "hier komt een linkje"
                },

                new Podcast
                {
                    Id = 3,
                    Title = "De grote geheimen van de dropfabriek",
                    File = "Lisa Developers Podcast 2014-09-28.mp3",
                    Image = "Raven.png",
                    Date = "2014-08-31",
                    Content = "Drop is een snoepgoed dat wordt gemaakt van het wortelsap van de zoethoutplant Glycyrrhiza glabra (vlinderbloemfamilie). De zuivere vorm heet blokdrop. De blokdrop wordt dan gebruikt als ingrediënt voor de snoepjes. Voor de zoetheid wordt suiker (in percentages variërend tussen 30 en 60%) of een andere zoetstof toegevoegd. Vroeger bond men de drop met Arabische gom, tegenwoordig doet men dit meestal met zetmeel of gelatine. Toch wordt Arabische gom soms nog steeds gebruikt. Andere bestanddelen zijn salmiak (ammoniumchloride), soms zout, evenals geur- en smaakstoffen, al dan niet synthetisch (eucalyptus, honing, anijs). Van nature bruinige en ietwat doorzichtige dropsoorten worden met koolstof of karamel donkerder gekleurd.[1] Vooral in Nederland is drop populair, maar daarnaast ook in de Scandinavische landen en Noord-Duitsland. De industriële verwerking van de zoethoutwortel tot drop werd mogelijk toen de Italiaan Giorgio Amarelli er in 1731 in slaagde om het sap uit de zoethoutwortel (Glycyrrhiza glabra), tot drop te verwerken.[2]",
                    Author = "Joost Ronkes Agerbeek, Wilco van Duinkerken",
                    References = "hier komt een linkje"
                }
            };
        }
    }
}