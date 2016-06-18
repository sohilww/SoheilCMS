using System.Collections.Generic;
using Articles.Contracts;

using SoheilCMS.Models;

namespace SoheilCMS.Areas.Admin.Models
{
    public class PostListViewModel : PagingAndBaseViewModel
    {
        public List<PostListModel> PostList { get; set; }
    }
}