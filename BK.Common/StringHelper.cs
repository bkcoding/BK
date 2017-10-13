using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 字符串操作类
    /// </summary>
    public static class StringHelper
    {


        /// <summary>
        /// decimal 类型转换为字符串，自动去掉小数点后面的0
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string DecimalToString(this decimal? val)
        {

            if (val == null)
            {
                return "";
            }
            else
            {
                string temp = val.ToString();
                if (val == 0 && temp.Equals("0"))
                {
                    return "";
                }
                if (val.ToString().Contains("."))
                {
                    return val.ToString().TrimEnd('0').TrimEnd('.');
                }
                else
                {
                    return val.ToString();
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="zero">是否显示为0.0的值等于0数</param>
        /// <returns></returns>
        public static string DecimalToString(this decimal? val, bool zero)
        {


            if (val == null)
            {
                return "";
            }
            else
            {
                if (!zero && val == 0 && val.ToString().Contains("0.0"))
                {
                    return "";
                }
                if (val.ToString().Contains("."))
                {
                    return val.ToString().TrimEnd('0').TrimEnd('.');
                }
                else
                {
                    return val.ToString();
                }

            }
        }



        /// <summary>
        /// 字符长度大小
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ByteLenght(this String str)
        {
            if (str.IsNull())
            {
                return 0;
            }
            byte[] bwrite = Encoding.GetEncoding("GB2312").GetBytes(str.ToCharArray());
           
            return bwrite.Length;
        }

        public static string MySubString(this String str, int start)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }


            str = str.Trim();
            return str.Substring(start);
        }

        public static string MySubString(this String str, int start, int len)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }

            str = str.Trim();
            return str.Substring(start, len);
        }
        /// <summary>
        /// 取指定长度字符串后+"..."
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string MyCutString(this string str, int len)
        {
            if (str.IsNull())
            {
                return "";
            }

            str = str.Trim();

            if (str.Length > len)
            {
                str = str.Substring(0, len - 3) + "...";
            }

            return str;
        }

        /// <summary>
        /// 取指定长度字符串后不+"..."
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string LenghtTrim(this string str, int len)
        {
            if (str.IsNull())
            {
                return "";
            }
            if (len < 1)
            {
                return "";
            }
            if (str.Length > len)
            {
                return str.Substring(0, len);
            }
            return str;
        }

        public static string MyLeft(this String str, int len)
        {
            if (str.IsNull())
            {
                return "";
            }

            str = str.Trim();

            len = str.Length > len ? len : str.Length;

            return str.Substring(0, len);
        }
        /// <summary>
        /// 从右边开始读取指定长度子串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string MyRight(this String str, int len)
        {
            if (str.IsNull())
            {
                return "";
            }

            str = str.Trim();

            int start = str.Length - len > 0 ? str.Length - len : 0;

            len = str.Length > len ? len : str.Length;

            return str.Substring(start, len);
        }
        /// <summary>
        /// 转换成为HTML格式代码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToHtml(this String str)
        {
            if (str.IsNull())
            {
                return "";
            }

            str = str.Replace("&quot;", "" + (char)34);
            str = str.Replace("&lt;", "<");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&#146;", "'");
            str = str.Replace("<br/>", "\n");
            str = str.Replace("&amp;", "&");

            return str;
        }
        /// <summary>
        /// 过滤html代码
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static string FilterHtml(this string content)
        {
            if (content.IsNull())
            {
                return "";
            }
            string Param = @"<(\S*?)[^>]*>|</.*[^<]>|&nbsp;|\s";

            return Regex.Replace(content, Param, "");
        }
        /// <summary>
        /// 过滤html代码(用于英文版)
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static string EFilterHtml(this string content)
        {
            if (content.IsNull())
            {
                return "";
            }
            string Param = @"<(\S*?)[^>]*>|</.*[^<]>|\r|\n|\t|(&nbsp;)+|\s";

            var aa = Regex.Replace(content, Param, " ");
            return aa;
        }
        /// <summary>
        /// 过滤html代码(用于英文版),并截取字符串
        /// </summary>
        /// <param name="content"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string EFilterHtml(this string content, int count)
        {
            if (content.IsNull())
            {
                return "";
            }
            string Param = @"<(\S*?)[^>]*>|</.*[^<]>|\r|\n|\t|(&nbsp;)+|\s";

            var aa = Regex.Replace(content, Param, " ").MyCutString(count);

            return aa;
        }

        /// <summary>
        /// 固定从文章中取出的图片大小
        /// </summary>
        /// <param name="conent"></param>
        /// <returns></returns>
        public static string StandardOfImg(this string conent)
        {
            if (conent.IsNull())
            {
                return "";
            }
            int start = conent.IndexOf("width=");
            int end1 = conent.IndexOf("height=\"") + 10;
            if (start < 0 || end1 < 0)
            {
                return conent;
            }
            int end = conent.IndexOf("\"", end1);
            if (conent.Length < start || conent.Length < end || end < 0)
            {
                return conent;
            }
            string s = conent.MySubString(start, end - start + 1);
            conent = conent.Replace(s, "width=\"80\"  height=\"150\"");
            return conent;

        }


        /// <summary>
        /// 固定从文章中取出的图片大小
        /// </summary>
        /// <param name="conent">图片标签</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string StandardOfImg(this string conent, int width, int height)
        {
            if (conent.IsNull())
            {
                return "../../Content/images/NotImage.jpg";
            }
            int start = conent.IndexOf("width=");
            int end1 = conent.IndexOf("height=\"") + 10;
            if (start < 0 || end1 < 0)
            {
                return conent;
            }
            int end = conent.IndexOf("\"", end1);
            if (conent.Length < start || conent.Length < end || end < 0)
            {
                return conent;
            }
            string s = conent.MySubString(start, end - start + 1);
            conent = conent.Replace(s, "width=\"" + width.ToString() + "\"  height=\"" + height.ToString() + "\"");
            return conent;

        }

        /// <summary>
        /// 有图片返回转换好的图片路径，没有返回默认图片路径
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        public static string ConvertPhoto(this string pic)
        {
            if (pic != "")
            {
                pic = "../../" + pic;
            }
            else
            {
                pic = "../../Content/images/NotImage.jpg";
            }
            return pic;
        }

        public static string ToChines(this int num)
        {
            string[] str = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };
            if (num >= str.Length)
            {
                return "";
            }
            else
            {
                return str[num];
            }
        }

    }
}
