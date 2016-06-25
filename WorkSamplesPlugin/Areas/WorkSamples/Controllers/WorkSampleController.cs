using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseMVC;
using FrameWork.Application;
using PluginBase;
using WorkSample.Application.BussinessService;
using WorkSample.Contracts;
using WorkSamplesPlugin.Areas.WorkSamples.Models;

namespace WorkSamplesPlugin.Areas.WorkSamples.Controllers
{
    public class WorkSampleController : Controller
    {
        IWorkSampleService service;
        public WorkSampleController(IWorkSampleService service)
        {
            this.service = service;
        }

        // GET: WorkSamples/WorkSample
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowUploadSafeFiles]
        public ActionResult Index([Bind(Exclude = "Id")]SampleWorkViewModel current, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image == null)
                {
                    current.Message = ApplicationMessages.FileDoseNotExsits;
                    current.State = ActionState.Error;
                }
                else
                {
                    string defualtPath = ApplicationMessages.DefualtPath + "WorkSample";
                    var filename = Guid.NewGuid().ToString() + Image.FileName;
                    string path = defualtPath + filename;
                    Image.SaveAs(Server.MapPath(path));
                    current.Image = path;
                    SampleWorkModel model = current.ToSampleWorkModel();
                    var result = service.Create(model);
                    if (result == EntityAction.Added)
                    {
                        current.Message = ApplicationMessages.InsertSuccess;
                        current.State = ActionState.Success;
                    }
                    else {
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
            return View(current);
        }


        public ActionResult List()
        {


            return View();
        }


        public ActionResult Edit(int id)
        {
            var tmp = service.Get(id);
            SampleWorkViewModel model = new SampleWorkViewModel(tmp);
            return View("Index", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowUploadSafeFiles]
        public ActionResult Edit(SampleWorkViewModel current, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {

                if (Image != null)
                {
                    string defualtPath = Server.MapPath(ApplicationMessages.DefualtPath + "WorkSample");
                    var filename = Guid.NewGuid().ToString() + Image.FileName;
                    string path = Path.Combine(defualtPath, filename);
                    Image.SaveAs(path);
                    current.Image = path;

                }
                SampleWorkModel model = current.ToSampleWorkModel();
                var result = service.Update(model);
                if (result == EntityAction.Updated)
                {
                    current.Message = ApplicationMessages.UpdateSuccess;
                    current.State = ActionState.Success;
                }
                else {
                    current.Message = ApplicationMessages.ErrorHasBeen;
                    current.State = ActionState.Error;
                }
            }
            else
            {
                current.Message = ApplicationMessages.ErrorHasBeen;
                current.State = ActionState.Error;
            }
            return View("index",current);
        }

        [Route(Name = "Admin_Pagger")]
        public ActionResult SampleWorkList(int page = 1)
        {
            int skip = (page - 1) * 10;
            int take = 10;
            var list = service.SelectPaging(skip, take);
            int count = service.Count();
            var model = new SampleWorkListViewModel()
            {
                WorkSamples = list,
                CurrentPage = page,
                PageSize = take,
                TotalItemCount = count
            };
            return PartialView(model);
        }

        public ActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return RedirectToAction("List");
        }
    }
}