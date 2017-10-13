using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc.Html;
using System.Web.Mvc;


namespace System.Web
{
    /// <summary>
    /// by
    /// </summary>
    public static class HtmlHelpers
    {
        /// <summary>
        /// 获取指定URL参数的值(此方法可防止取不到路由里定义参数的值)
        /// </summary>
        /// <param name="html"></param>
        /// <param name="key">参数键名</param>
        /// <returns></returns>
        public static String QueryString(this HtmlHelper html,string key)
        {
             
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            var dict = new System.Web.Routing.RouteValueDictionary(html.ViewContext.RouteData.Values);
            if (queryString[key] == null)
            {
                return   HttpContext.Current.Server.UrlDecode((string)dict[key]??"");
            }
            else
            {
                return HttpContext.Current.Server.UrlDecode(queryString[key]??"");
            }
        }

    }
}
