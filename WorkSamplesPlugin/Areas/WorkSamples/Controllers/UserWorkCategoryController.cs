using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkSample.Application.BussinessService;

namespace WorkSamplesPlugin.Areas.WorkSamples.Controllers
{
    public class UserWorkCategoryController : Controller
    {
        // GET: WorkSamples/UserWorkCategory

        IWorkCategoryService service;
        public UserWorkCategoryController(IWorkCategoryService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetBaseCategory(int take)
        {
            var model = service.GetBaseCategory(take);
            return PartialView(model);
        }
    }
}