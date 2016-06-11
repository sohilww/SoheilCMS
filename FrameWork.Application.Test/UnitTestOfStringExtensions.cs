using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameWork.Application.Test
{
    [TestClass]
    public class UnitTestOfStringExtensions
    {
        [TestMethod]
        public void Test_Create_Freandly_Slug()
        {
            string slug = "ایرانی قهرمان * a";
            string newSlug = slug.CreateFreandlySlug();


            bool notContainsStar = newSlug.Contains("*");

            bool notContainsSpace = newSlug.IndexOf(' ') > 0;


            Assert.IsFalse(notContainsSpace);
            Assert.IsFalse(notContainsStar);
        }
    }
}
