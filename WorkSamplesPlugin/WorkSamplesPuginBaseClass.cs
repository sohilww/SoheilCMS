using System;
using System.Collections.Generic;
using System.Web.Optimization;
using System.Web.Routing;
using PluginBase;

namespace WorkSamplesPlugin
{
    public class WorkSamplesPuginBaseClass: IPluginBase
    {
        public MenuItem GetMenuItem(RequestContext requestContext)
        {
            var menu = new MenuItem()
            {
                 Name="نمونه کار ها",
                  Url="/Test/Test"
            };

            return menu;
        }

        public List<MenuItem> GetChildMenuItem(RequestContext requestContext)
        {
            throw new NotImplementedException();
        }

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