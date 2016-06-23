using System.Collections.Generic;
using System.Web.Optimization;
using System.Web.Routing;

namespace PluginBase
{
    public interface  IPluginBase
    {
        MenuItem GetMenuItem(RequestContext requestContext);

        List<MenuItem> GetChildMenuItem(RequestContext requestContext);

        RequestContext RequestContextPlugin { set; }

        void RegisterBundles(BundleCollection bundles);
        void RegisterRoutes(RouteCollection routes);

        object GetIoccBootstraper();

        TIocc GetIoccBootstraper<TIocc>();
    }
}