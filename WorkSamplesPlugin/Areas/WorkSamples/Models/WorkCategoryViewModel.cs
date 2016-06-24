using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PluginBase;
using WorkSample.Contracts;


namespace WorkSamplesPlugin.Areas.WorkSamples.Models
{
    public class WorkCategoryViewModel : BaseViewModel
    {
        public WorkCategoryViewModel()
        {
            
        }

        public WorkCategoryViewModel(WorkCategoryModel model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.Description = model.Description;
            this.CategoryImage = model.CategoryImage;
            this.KeyWord = model.KeyWord;
            this.ParentId = model.ParentId;
            this.ParentName = model.ParentName;
            this.Slug = model.Slug;
            
        }

        [ScaffoldColumn(false)]
       
        public int Id { get; set; }

        [DisplayName("نام")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        public string Title { get; set; }


        [DisplayName("ادرس")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        public string Slug { get; set; }


        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        public string Description { get; set; }


        [DisplayName("keywords")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمایید")]
        [UIHint("TagSeprator")]
        public string KeyWord { get; set; }

        [DisplayName("توضیحات")]
        public string CategoryImage { get; set; }

        [DisplayName("پدر")]
        public int? ParentId { get; set; }
        [DisplayName("پدر")]
        public string ParentName { get; set; }

        public WorkCategoryModel ToWrkCategoryModel()
        {
            return new WorkCategoryModel()
            {
                CategoryImage = CategoryImage,
                Description = Description,
                Id = Id,
                KeyWord = KeyWord,
                ParentId = ParentId,
                ParentName = ParentName,
                Slug = Slug,
                Title = Title

            };
        }
    }
}