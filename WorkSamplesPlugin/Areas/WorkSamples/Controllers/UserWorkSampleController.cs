using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkSamplesPlugin.Areas.WorkSamples.Controllers
{
    public class UserWorkSampleController : Controller
    {
        // GET: WorkSamples/UserWorkSample
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAll()
        {
            throw new NotImplementedException();
        }

        public ActionResult Show(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}