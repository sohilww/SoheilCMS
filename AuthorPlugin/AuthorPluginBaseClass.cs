using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PluginBase;

namespace AuthorPlugin
{
    public class AuthorPluginBase: IPluginBase
    {
        RequestContext context;
        object area;

        public AuthorPluginBase()
        {
            area = new { area = "Author" };
        }
        public MenuItem GetMenuItem(RequestContext requestContext)
        {
            context = requestContext;
            var menu = new MenuItem()
            {
                Name = "نویسندگان",
                Url = new UrlHelper(context).Action("Index", "AuthorAdmin", area)

            };

            return menu;
        }

        public List<MenuItem> GetChildMenuItem(RequestContext requestContext)
        {
            var menus = new List<MenuItem>();
            menus.Add(new MenuItem()
            {
                Name = "نویسندگان",
                Url = new UrlHelper(context).Action("List", "AuthorAdmin", area)
            });
            menus.Add(new MenuItem()
            {
                Name = "تعریف نویسنده",
                Url = new UrlHelper(context).Action("Create", "AuthorAdmin", area)
            });
            
            return menus;
        }

        public RequestContext RequestContextPlugin { get; set; }
        public void RegisterRoutes(RouteCollection routes)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterBundles(BundleCollection bundles)
        {
            throw new System.NotImplementedException();
        }
    }
}