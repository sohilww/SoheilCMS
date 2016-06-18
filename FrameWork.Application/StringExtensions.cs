using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrameWork.Application
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checking Slug Has White Space And Symbole Correcter
        /// </summary>
        /// <param name="slug">URL</param>
        /// <returns></returns>
        public static string CreateFreandlySlug(this string slug)
        {
            slug = slug.ToLower();
            //\u0600-\u06FF\uFB8A\u067E\u0686\u06AF 
            //Chacking Persian Correcter
            slug = new Regex(@"[^0-9 a-z \u0600-\u06FF\uFB8A\u067E\u0686\u06AF -]").Replace(slug, string.Empty);
            slug = slug.Replace(' ', '-');
           return slug;

        }
    }
}
