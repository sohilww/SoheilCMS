using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PluginBase;
using WorkSamples.DomainModel;

namespace WorkSamplesPlugin.Areas.WorkSamples.Models
{
   
    public class WorkSampleCategoryViewModel : BaseViewModel
    {

        public WorkSampleCategoryViewModel()
        {

        }
        public WorkSampleCategoryViewModel(WorkCategory current)
        {
            this.Id = current.Id;
            this.Name = current.Title;
            this.Slug = current.Slug;
            this.ParentId = current.ParentId;
            this.WorkSampleCount = current.WorkSamples.Count;

        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        
        
        [DisplayName("نام")]
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Name { get; set; }

        [DisplayName("تعداد نمونه کار ها")]
        public int WorkSampleCount { get; set; }
        [DisplayName("آدرس")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Slug { get; set; }

        public int? ParentId { get; set; }

     

    }

    public class CategoryShowAndListViewModel
    {
        public WorkSampleCategoryViewModel Model { get; set; }


        public List<WorkSampleCategoryViewModel> Lists { get; set; }
    }
}