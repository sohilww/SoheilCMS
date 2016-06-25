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
        List<IPluginBase> plugins;
        public HomeController(List<IPluginBase> plugins)
        {
            this.plugins = plugins;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
            
            return PartialView(plugins);
        }

        public ActionResult Footer()
        {
            return PartialView();
        }
    }

 
}