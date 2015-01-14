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
            ViewBag.css = "Index/index.css";
            ViewBag.cssResponsive = "Index/indexResponsive.css";
            return View();
        }
    }
}