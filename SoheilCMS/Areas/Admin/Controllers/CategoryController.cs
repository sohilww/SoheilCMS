using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Articles.Application.BussinessService;
using SoheilCMS.Areas.Admin.Models;

namespace SoheilCMS.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService rep;

        public CategoryController(ICategoryService _rep)
        {
            if (_rep == null) throw new ArgumentNullException(nameof(_rep));
            rep = _rep;
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var model = new CategoryShowAndListViewModel()
            {
                Model = new CategoryViewModel(),

            };
            model.Lists = rep.Select().Select(a => new CategoryViewModel()
            {
                Id = a.Id,
                IsParent = a.IsParent,
                LineAge = a.LineAge,
                Name = a.Name,
                PostCount = a.PostCount,
                Slug = a.Slug

            }).ToList();


            return View(model);
        }
    }
}