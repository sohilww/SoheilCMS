using PluginBase;

namespace SoheilCMS.Models
{
    public class PagingAndBaseViewModel :BaseViewModel,IPageViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalItemCount { get; set; }
        public int PageSize { get; set; }
    }
}