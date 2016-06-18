namespace PluginBase
{
    public interface IPageViewModel
    {


        int CurrentPage { get; set; }



        int TotalItemCount { get; set; }
        int PageSize { get; set; }

    }
    public class PageViewModel : IPageViewModel
    {

        public int CurrentPage { get; set; }

        public int TotalItemCount { get; set; }
        public int PageSize { get; set; }
    }
}