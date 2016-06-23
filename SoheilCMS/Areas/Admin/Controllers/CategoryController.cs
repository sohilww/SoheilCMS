using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Articles.Application.BussinessService;
using FrameWork.Application;
using PluginBase;
using SoheilCMS.Areas.Admin.Models;
using SoheilCMS.Models;

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
            var model = new CategoryViewModel();
           
           return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ParentId == 1)
                    model.IsParent = true;
                var current = model.ToCategoryModel();

                var result = rep.Create(current);
                model.State = ActionState.Success;
                model.Message = ApplicationMessages.InsertSuccess;
            }
            else
            {
                model.State = ActionState.Error;
                model.Message = ApplicationMessages.ErrorHasBeen;
            }
            return View(model);
            
            
        }

        public PartialViewResult CategoryList()
        {
            var model=rep.Select().Select(a => new CategoryViewModel()
            {
                Id = a.Id,
                IsParent = a.IsParent,
                LineAge = a.LineAge,
                Name = a.Name,
                PostCount = a.PostCount,
                Slug = a.Slug

            }).ToList();

            return PartialView(model);
        }

        public JsonResult CategorySelect()
        {
            var model = rep.SelectList();

            return Json(model,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var model = rep.Get(id);
            if (model == null)
                return HttpNotFound();

            CategoryViewModel tmp = new CategoryViewModel(model);

           return View("index",tmp);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {

            if (ModelState.IsValid)
            {
                var current = model.ToCategoryModel();
                EntityAction result = rep.Update(current);
                model.State = ActionState.Success;
                model.Message = ApplicationMessages.UpdateSuccess;


            }
            else
            {
                model.State = ActionState.Error;
                model.Message = ApplicationMessages.ErrorHasBeen;
            }
            return View("index",model);
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
                return new HttpNotFoundResult();
            EntityAction result=rep.Delete(id);
            CategoryViewModel model = new CategoryViewModel();
            if (result == EntityAction.Deleted)
            {
                model.State = ActionState.Success;
                model.Message = ApplicationMessages.DeleteSuccess;
            }
            else
            {
                model.State = ActionState.Error;
                model.Message = ApplicationMessages.ErrorHasBeen;
            }
            return View("index", model);
        }

        public PartialViewResult CategoryRadioButton()
        {
            var model = rep.SelectList();
            return PartialView(model);
        }
    }
}