using MvcAjaxPager;

namespace SoheilCMS.Models
{
    public static class CustomePagerOptions
    {
        public static PagerOptions CustomePageOptions(string targetId = "divtarget",
            string id = "ListPager")
        {
            return new PagerOptions()
            {
                AjaxUpdateTargetId = targetId,
                Id = id,
                PrevPageText = "قبلی",
                NextPageText = "بعدی",
                LastPageText = "آخرین",
                FirstPageText = "اولین"
            };
        }
    }
}