using System.Collections.Generic;
using Authors.Contracts;
using PluginBase;

namespace AuthorPlugin.Areas.Author.Models
{
    public class AuthorListPagingAndViewModel: IPageViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalItemCount { get; set; }
        public int PageSize { get; set; }

       public  List<AuthorAdminListDTO> Author { get; set; }

    }
}