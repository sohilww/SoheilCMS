using PluginBase;

namespace SoheilCMS.Models
{
    public class LoadModel:IBaseViewModel
    {
        public LoadModel()
        {
            SeoModel = new SeoModel();
        }
        public SeoModel SeoModel { get; set; }
    }
}