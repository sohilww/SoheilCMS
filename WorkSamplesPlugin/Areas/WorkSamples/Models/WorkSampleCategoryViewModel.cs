using System.Collections.Generic;
using PluginBase;

namespace WorkSamplesPlugin.Areas.WorkSamples.Models
{
    public class CategoryShowAndListViewModel: BaseViewModel
    {
        public WorkCategoryViewModel Model { get; set; }


        public List<WorkCategoryViewModel> Lists { get; set; }
    }
}