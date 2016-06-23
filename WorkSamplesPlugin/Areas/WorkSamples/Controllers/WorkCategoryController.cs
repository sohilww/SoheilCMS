using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkSample.Application.BussinessService;

namespace WorkSamplesPlugin.Areas.WorkSamples.Controllers
{
    public class WorkCategoryController : Controller
    {
        IWorkCategoryService service;

        public WorkCategoryController(IWorkCategoryService ser)
        {
            service = ser;
        }
        // GET: WorkSamples/WorkCategory
        public ActionResult Index()
        {
            return View();
        }
    }
}