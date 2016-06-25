using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoheilCMS.Controllers
{
    public class UserCategoryController : Controller
    {
        // GET: UserCategory
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