using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lisa.Website.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.css = "~/Content/CSS/index.css";
            ViewBag.cssResponsive = "~/Content/CSS/indexResponsive.css";
            return View();
        }
    }
}