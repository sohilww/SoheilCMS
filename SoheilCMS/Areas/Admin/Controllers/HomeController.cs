using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PluginBase;

namespace SoheilCMS.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
            List<IPluginBase> plugins = new List<IPluginBase>();
            return PartialView(plugins);
        }
    }

 
}