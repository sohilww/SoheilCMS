using System.Collections.Generic;
using System.ComponentModel;
using Articles.Contracts;
using System.ComponentModel.DataAnnotations;

namespace SoheilCMS.Areas.Admin.Models
{
    public class CategoryViewModel : CategoryModel
    {
        [ScaffoldColumn(false)]
        public override int Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }
        [DisplayName("پدر")]
        [Display(Name = "پدر")]
        public override bool IsParent
        {
            get
            {
                return base.IsParent;
            }

            set
            {
                base.IsParent = value;
            }
        }
        [ScaffoldColumn(false)]
        public override string LineAge
        {
            get
            {
                return base.LineAge;
            }

            set
            {
                base.LineAge = value;
            }
        }
        [DisplayName("نام")]
        [Display(Name = "نام")]
        public override string Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                base.Name = value;
            }
        }
        [DisplayName("تعداد پست")]
        public override int PostCount
        {
            get
            {
                return base.PostCount;
            }

            set
            {
                base.PostCount = value;
            }
        }
        [DisplayName("آدرس")]
        public override string Slug
        {
            get
            {
                return base.Slug;
            }

            set
            {
                base.Slug = value;
            }
        }

        
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