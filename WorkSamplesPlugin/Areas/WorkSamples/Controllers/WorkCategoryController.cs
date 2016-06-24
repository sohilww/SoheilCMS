using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrameWork.Application;
using PluginBase;
using WorkSample.Application.BussinessService;
using WorkSamplesPlugin.Areas.WorkSamples.Models;

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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index([Bind(Exclude ="Id")] WorkCategoryViewModel current)
        {
            if (ModelState.IsValid)
            {
                if (current.ParentId == 1)
                    current.ParentId = null;
                var workcategorymodel = current.ToWrkCategoryModel();
                EntityAction result = service.Create(workcategorymodel);
                if (result == EntityAction.Added)
                {
                    current.Message = ApplicationMessages.InsertSuccess;
                    current.State = ActionState.Success;
                }
                else
                {
                    current.Message = ApplicationMessages.ErrorHasBeen;
                    current.State = ActionState.Error;
                }
            }
            else
            {
                current.Message = ApplicationMessages.ErrorHasBeen;
                current.State = ActionState.Error;
            }
            return View(current);
        }

        public ActionResult Edit(int id)
        {
            var categoryviewModel = service.Get(id);
            if (categoryviewModel == null)
            {
                return new HttpNotFoundResult();
            }
            var current = new WorkCategoryViewModel(categoryviewModel);
            return View("Index",current);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(WorkCategoryViewModel current)
        {
            if (ModelState.IsValid)
            {
                if (current.ParentId == 1)
                    current.ParentId = null;
                if (current.ParentId == current.Id)
                {
                    current.Message = ApplicationMessages.ParentIdAndIdCannotBeEquals;
                    current.State = ActionState.Error;
                }
                else
                {
                    var workcategorymodel = current.ToWrkCategoryModel();
                    EntityAction result = service.Update(workcategorymodel);
                    if (result == EntityAction.Updated)
                    {
                        current.Message = ApplicationMessages.UpdateSuccess;
                        current.State = ActionState.Success;
                    }
                    else
                    {
                        current.Message = ApplicationMessages.ErrorHasBeen;
                        current.State = ActionState.Error;
                    }
                }
            }
            else
            {
                current.Message = ApplicationMessages.ErrorHasBeen;
                current.State = ActionState.Error;
            }
            return View("Index",current);
        }
        public ActionResult List()
        {
            var model = service.Select().Select(a => new WorkCategoryViewModel()
            {
                CategoryImage = a.CategoryImage,
                Description = a.Description,
                Id = a.Id,
                KeyWord = a.KeyWord,
                ParentId = a.ParentId,
                Slug = a.Slug,
                Title = a.Title,
                ParentName = a.ParentName
            });

            return PartialView(model);
        }

        public JsonResult CategorySelect()
        {
            var model = service.SelectIdAndName();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var result = service.Delete(id);
            WorkCategoryViewModel model = new WorkCategoryViewModel();
            if (result == EntityAction.Deleted)
            {
                model.Message = ApplicationMessages.DeleteSuccess;
                model.State = ActionState.Success;

            }
            else
            {
                model.Message = ApplicationMessages.ErrorHasBeen;
                model.State = ActionState.Error;
            }
            return View("Index", model);
        }
    }
}