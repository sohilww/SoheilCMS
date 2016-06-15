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
            return View(tags);
        }
    }
}