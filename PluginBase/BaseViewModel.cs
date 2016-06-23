using System.ComponentModel.DataAnnotations;

namespace PluginBase
{
    public class BaseViewModel
    {
        [ScaffoldColumn(false)]
        public ActionState State { get; set; }

        [ScaffoldColumn(false)]
        public string Message { get; set; }
    }
}