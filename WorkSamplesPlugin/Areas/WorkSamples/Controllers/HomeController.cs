using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkSamplesPlugin.Areas.WorkSamples.Controllers
{
    public class HomeController : Controller
    {
        // GET: WorkSamples/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}