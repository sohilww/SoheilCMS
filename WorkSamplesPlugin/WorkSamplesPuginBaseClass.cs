using System;

using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PluginBase;
using WorkSample.IOC.Bootstrap;

namespace WorkSamplesPlugin
{
    public class WorkSamplesPuginBase : IPluginBase
    {
        RequestContext context;
        object area;
        public WorkSamplesPuginBase()
        {
            
            area = new { area = "WorkSamples" };
        }

        public MenuItem GetMenuItem(RequestContext requestContext)
        {
            context = requestContext;
            var menu = new MenuItem()
            {
                Name = "نمونه کار ها",
                Url = new UrlHelper(context).Action("Index", "Home", area)

            };

            return menu;
        }

        public List<MenuItem> GetChildMenuItem(RequestContext requestContext)
        {
            var menus = new List<MenuItem>();
            menus.Add(new MenuItem()
            {
                Name = "دسته بندی نمونه کار",
                Url = new UrlHelper(context).Action("index", "WorkCategory", area)
            });
            menus.Add(new MenuItem()
            {
                Name = "ویرایش",
                Url = new UrlHelper(context).Action("Edit", "Home", area)
            });
            menus.Add(new MenuItem()
            {
                Name = "حذف",
                Url = new UrlHelper(context).Action("Delete", "Home", area)
            });
            return menus;

        }

        public RequestContext RequestContextPlugin { get; set; }

        public void RegisterBundles(BundleCollection bundles)
        {
            throw new NotImplementedException();
        }

        public void RegisterRoutes(RouteCollection routes)
        {
            throw new NotImplementedException();
        }

       
    }
}