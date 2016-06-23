using System;
using MD.PersianDateTime;

namespace FrameWork.Application
{
    public static class DateTimeExtension
    {
        public static DateTime ToPersian(this DateTime d)
        {
            PersianDateTime result = new PersianDateTime(d);
            return result;
        }
    }
}