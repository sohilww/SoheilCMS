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
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreateViewModel current)
        {
            if (ModelState.IsValid)
            {
                current.SendDate = PersianDate.Now;
                var model = current.ToPostCreateModel();
                model.AuthorId = UserManager.GetUserId(User.Identity.Name);
                EntityAction result = service.Create(model);
                if (result == EntityAction.Added)
                {
                    current.State = ActionState.Success;
                    current.Message = ApplicationMessages.InsertSuccess;
                }
            }
            else
            {
                current.State = ActionState.Error;
                current.Message = ApplicationMessages.ErrorHasBeen;
            }

            return View(current);
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var tmp= service.Get(id);
            PostCreateViewModel model = new PostCreateViewModel()
            {
                Author = tmp.Author,
                AuthorId = tmp.AuthorId,
                Category = tmp.Category,
                CategoryId = tmp.CategoryId,
                Content = tmp.Content,
                Description = tmp.Description,
                PostId = tmp.PostId,
                PostImage = tmp.PostImage,
                PublishedDate = tmp.PublishedDate,
                SendDate = tmp.SendDate,
                Slug = tmp.Slug,
                TagId = tmp.TagId,
                Title = tmp.Title,
                VisitCount = tmp.VisitCount
            };
            return View("Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostCreateViewModel current)
        {
            if (ModelState.IsValid)
            {
                var model = current.ToPostCreateModel();
                model.AuthorId = UserManager.GetUserId(User.Identity.Name);
                EntityAction result = service.Update(model);
                if (result == EntityAction.Updated)
                {
                    current.State = ActionState.Success;
                    current.Message = ApplicationMessages.UpdateSuccess;
                }
            }
            else
            {
                current.State = ActionState.Error;
                current.Message = ApplicationMessages.ErrorHasBeen;
            }

            return View("Create",current);
        }

    }
}