using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Articles.Application.BussinessService;
using Articles.Contracts;
using SoheilCMS.Areas.Admin.Models;

namespace SoheilCMS.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        ITagService service;
        public TagController(ITagService _ser)
        {
            service = _ser;
        }
        // GET: Admin/Tag
        public ActionResult Index()
        {
            List<TagViewModel> tags = service.Select().Select(a => new TagViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                PostCount = a.PostCount
            }).ToList();
            TagViewListModel model = new TagViewListModel()
            {
                TagViewModel = tags,
                PageSize = 10,
                CurrentPage = 1,
                TotalItemCount = service.Count()
            };


            return View(model);
        }

        public PartialViewResult TagList(int page = 1)
        {
            int skip = ((page - 1)*10);
            List<TagViewModel> tags = service.Select(skip,10).Select(a => new TagViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                PostCount = a.PostCount
            }).ToList();
            TagViewListModel model = new TagViewListModel()
            {
                TagViewModel = tags,
                PageSize = 10,
                CurrentPage = page,
                TotalItemCount = service.Count()
            };


            return PartialView(model);
        }
    }
}