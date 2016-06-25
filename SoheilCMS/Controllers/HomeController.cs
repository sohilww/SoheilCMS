using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PluginBase;
using SoheilCMS.Models;

namespace SoheilCMS.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {

            IndexViewModel model = new IndexViewModel();
            model.SeoModel = new SeoModel();
            model.SeoModel.Description = "Test";
            model.SeoModel.KeyWords = "Test";
            model.SeoModel.Title = "Test";
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult Menu()
        {
            return PartialView();
        }
        public ActionResult Footer()
        {
            return PartialView();
        }

    }
}