using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lisa.Website.Controllers
{
    public class ManagementIndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}