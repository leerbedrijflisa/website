using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lisa.Website.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.css = "";
            ViewBag.cssResponsive = "";
            return View();
        }

        public ActionResult AddArticle()
        {
            ViewBag.css = "";
            ViewBag.cssResponsive = "";
            return View();
        }

        [HttpPost]
        public FileStreamResult AddArticle(Article)
        {
            //NOG AFMAKEN!
        }
    }
}