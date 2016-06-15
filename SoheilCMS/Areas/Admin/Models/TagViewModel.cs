using System.ComponentModel;
using SoheilCMS.Models;

namespace SoheilCMS.Areas.Admin.Models
{
    public class TagViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [DisplayName("نام")]
        public string Name { get; set; }
        [DisplayName("تعداد پست ها")]
        public int PostCount { get; set; }
    }
}