using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoheilCMS.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Name(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}