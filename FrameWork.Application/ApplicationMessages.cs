using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Application
{
    public static class ApplicationMessages
    {
        public static string ErrorHasBeen
        {
            get { return "خطایی رخ داده است"; }
        }

        public static string InsertSuccess
        {
            get { return "درج  با موفقیت انجام پذیرفت"; }
        }

        public static string DeleteSuccess
        {
            get { return "حذف با موفقیت انجام شد"; }
        }

        public static string UpdateSuccess
        {
            get { return "ویرایش با موفقیت انجام پذیرفت"; }
        }

        public static string ParentIdAndIdCannotBeEquals
        {
            get { return "پدر نمی تواند خود المان باشد"; }
        }

        public static string DefualtPath
        {
            get { return "~/Upload/"; }
        }

        public static string FileDoseNotExsits { get { return "فایل را آپلود نمایید"; } }
    }
}
