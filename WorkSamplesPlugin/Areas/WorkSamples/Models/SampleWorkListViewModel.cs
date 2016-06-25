using System.Collections.Generic;
using PluginBase;
using WorkSample.Contracts;

namespace WorkSamplesPlugin.Areas.WorkSamples.Models
{
    public class SampleWorkListViewModel:PageViewModel
    {
        public List<WorkSampleListDTO> WorkSamples { get; set; }
    }
}