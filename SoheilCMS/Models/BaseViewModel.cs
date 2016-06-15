using System.ComponentModel.DataAnnotations;

namespace SoheilCMS.Models
{
    public class BaseViewModel
    {
        [ScaffoldColumn(false)]
        public ActionState State { get; set; }

        [ScaffoldColumn(false)]
        public string Message { get; set; }
    }

    public enum ActionState
    {
        None,
        Error,
        Success
    }
}