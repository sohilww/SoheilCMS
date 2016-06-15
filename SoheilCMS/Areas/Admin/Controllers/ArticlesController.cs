using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoheilCMS.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        public ArticlesController()
        {
            
        }
        // GET: Admin/Articles
        public ActionResult Index()
        {
            return View();
        }


    }
}