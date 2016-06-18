using System;
using System.Collections.Generic;
using Articles.Contracts;
using Articles.DomainModel;
using FrameWork.Application;
using SoheilCMS.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SoheilCMS.Areas.Admin.Models
{
    public class PostCreateViewModel : BaseViewModel
    {

        public DateTime SendDate
        {
            get { return PersianDate.Now; }
        }

        public int PostId { get; set; }

        [DisplayName("عنوان مطلب")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Title { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PublishedDate { get; set; }

        [ScaffoldColumn(false)]
        public int VisitCount { get; set; }

        [AllowHtml]
        [DisplayName("متن")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [DataType(DataType.MultilineText)]
        [UIHint("CkEditor")]
        public string Content { get; set; }


        [DisplayName("توضیحات")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public string PostImage { get; set; }

        [DisplayName("آدرس")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Slug { get; set; }

        [ScaffoldColumn(false)]
        public int AuthorId { get; set; }

        [ScaffoldColumn(false)]
        public int TagId { get; set; }

        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        public AuthorRefrence Author { get; set; }

        public Category Category { get; set; }

        public List<Tag> Tags { get; set; }
        public PostCreateModel ToPostCreateModel()
        {
            return new PostCreateModel()
            {
                Author = Author,
                AuthorId = AuthorId,
                Category = Category,
                CategoryId = CategoryId,
                Comments = null,
                Content = Content,
                Description = Description,
                PostId = PostId,
                PostImage = PostImage,
                PostTag = null,
                PublishedDate = PublishedDate,
                SendDate = SendDate,
                Slug = Slug,
                TagId = TagId,
                Title = Title,
                VisitCount = VisitCount
            };
        }

    }
}