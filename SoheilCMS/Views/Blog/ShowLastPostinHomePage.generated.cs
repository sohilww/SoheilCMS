﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using SoheilCMS;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Blog/ShowLastPostinHomePage.cshtml")]
    public partial class _Views_Blog_ShowLastPostinHomePage_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<Articles.Contracts.PostShowHomePage>>
    {
        public _Views_Blog_ShowLastPostinHomePage_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 6 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
        
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
         foreach (var item in Model)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-xs-12\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"alert alert-dismissable\"");

WriteLiteral(">\r\n                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 367), Tuple.Create("\"", 443)
            
            #line 12 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
, Tuple.Create(Tuple.Create("", 374), Tuple.Create<System.Object, System.Int32>(Url.Action("Post", "Blog", new {Id = item.PostId, Name = item.Slug})
            
            #line default
            #line hidden
, 374), false)
);

WriteLiteral(">");

            
            #line 12 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
                                                                                                       Write(item.Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                    </div>\r\n               " +
"     <div");

WriteLiteral(" class=\"col-xs-12\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"label label-default\"");

WriteLiteral(">\r\n                            <span>نام نویسنده</span>\r\n                        " +
"    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 710), Tuple.Create("\"", 795)
            
            #line 18 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
, Tuple.Create(Tuple.Create("", 717), Tuple.Create<System.Object, System.Int32>(Url.Action("Name", "Autor", new {Id = item.AuthorId, Name = item.AuthorName})
            
            #line default
            #line hidden
, 717), false)
);

WriteLiteral(">");

            
            #line 18 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
                                                                                                                Write(item.AuthorName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"label label-success\"");

WriteLiteral(">\r\n                            <span>دسته بندی</span>\r\n                          " +
"  <a");

WriteAttribute("href", Tuple.Create(" href=\"", 992), Tuple.Create("\"", 1081)
            
            #line 22 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
, Tuple.Create(Tuple.Create("", 999), Tuple.Create<System.Object, System.Int32>(Url.Action("Name","UserCategory",new {Id=item.CategoryId,Name=item.CategoryName})
            
            #line default
            #line hidden
, 999), false)
);

WriteLiteral(">");

            
            #line 22 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
                                                                                                                    Write(item.CategoryName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                    </div>\r\n               " +
"     <div");

WriteLiteral(" class=\"col-xs-12\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 26 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
                   Write(Html.Raw(item.Summary));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"continueBtn\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"btn btn-success\"");

WriteAttribute("href", Tuple.Create(" \r\n                           href=\"", 1386), Tuple.Create("\"", 1491)
            
            #line 30 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
, Tuple.Create(Tuple.Create("", 1422), Tuple.Create<System.Object, System.Int32>(Url.Action("Post", "Blog", new {Id = item.PostId, Name = item.Slug})
            
            #line default
            #line hidden
, 1422), false)
);

WriteLiteral(">");

            
            #line 30 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
                                                                                                   Write(item.Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");

            
            #line 34 "..\..\Views\Blog\ShowLastPostinHomePage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591