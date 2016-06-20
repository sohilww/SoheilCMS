using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Menu.Application.BussinessService;

namespace SoheilCMS.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        ISiteMenuService serivce;

        public MenuController(ISiteMenuService ser)
        {
            serivce = ser;
        }
        // GET: Admin/Menu
        public ActionResult Index()
        {
            var model = serivce.Select();
            return View(model);
        }
    }
}