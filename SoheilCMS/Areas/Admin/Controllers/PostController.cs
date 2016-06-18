using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Articles.Application.BussinessService;
using FrameWork.Application;
using SoheilCMS.Areas.Admin.Models;
using SoheilCMS.Models;

namespace SoheilCMS.Areas.Admin.Controllers
{
    public class PostController : Controller
    {

        IPostService service;
        public PostController(IPostService ser)
        {
            service = ser;
        }
        // GET: Admin/Post
        public ActionResult Index()
        {
            PostListViewModel model = new PostListViewModel();
            return View(model);
        }
        
        public ActionResult PostList(int page = 1)
        {
            int skip = (page - 1) * 10;
            int take = 10;
            var postList = new PostListViewModel()
            {
                PostList = service.Select(skip, take),
                TotalItemCount = service.Count(),
                CurrentPage = page,
                PageSize = take
            };
            return PartialView(postList);
        }


        public ActionResult Delete(int id)
        {
            if (id == 0)
                return HttpNotFound();
            EntityAction result = service.Delete(id);
            var model = new PostListViewModel();
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

        public ActionResult Create()
        {
            PostCreateViewModel model = new PostCreateViewModel();
            model.SendDate = PersianDate.Now;
            return View();
        }

    }
}