using System;

namespace FrameWork.Application
{
    public struct PersianDate
    {
        public static DateTime Now
        {
            get { return DateTime.Now.ToPersian(); }
        }
    }
}