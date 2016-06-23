using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkSamplesPlugin.Areas.WorkSamples.Controllers
{
    public class WorkSampleController : Controller
    {
     
        public WorkSampleController()
        {
            
        }
        // GET: WorkSamples/WorkSample
        public ActionResult Index()
        {
            return View();
        }
    }
}