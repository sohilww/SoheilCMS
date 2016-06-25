using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Articles.Application.BussinessService;
using Articles.Contracts;

namespace SoheilCMS.Controllers
{
    public class BlogController : Controller
    {
        IPostService service;
        public BlogController(IPostService service)
        {
            this.service = service;
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowLastPostinHomePage()
        {
            int count = 2;
            List<PostShowHomePage> model = service.HomePagePost(count);
            return PartialView(model);
        }
    }
}