using System.Collections.Generic;
using System.ComponentModel;
using Articles.Contracts;
using System.ComponentModel.DataAnnotations;
using Articles.DomainModel;
using FrameWork.Application;
using PluginBase;
using SoheilCMS.Models;

namespace SoheilCMS.Areas.Admin.Models
{
    public class CategoryViewModel :BaseViewModel
    {

        public CategoryViewModel()
        {
            
        }
        public CategoryViewModel(Category current)
        {
            this.Id = current.Id;
            this.IsParent = current.IsParent;
            this.Name = current.Name;
            this.LineAge = current.LineAge;
            this.Slug = current.Slug;
            
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        
        [DisplayName("پدر")]
        [Display(Name = "پدر")]
        public bool IsParent { get; set; }
        
        [ScaffoldColumn(false)]
        public string LineAge { get; set; }
        [DisplayName("نام")]
        [Display(Name = "نام")]
        [Required(ErrorMessage ="{0} را وارد نمایید")]
        public string Name { get; set; }
        
        [DisplayName("تعداد پست")]
        public int PostCount { get; set; }
        [DisplayName("آدرس")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Slug { get; set; }

        public int ParentId { get; set; }
        
        public CategoryModel ToCategoryModel()
        {
            return new CategoryModel()
            {
                Id = this.Id,
                IsParent = this.IsParent,
                LineAge = this.LineAge,
                Name = this.Name,
                PostCount = this.PostCount,
                Slug = this.Slug,
                ParentId = this.ParentId
            };
        }

    }

    public class CategoryShowAndListViewModel
    {
        public CategoryViewModel Model { get; set; }


        public List<CategoryViewModel> Lists { get; set; }
    }

}