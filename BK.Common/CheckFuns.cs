using System;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 格式验证
    /// </summary>
    public static class CheckFuns
    {
        /// <summary>
        /// 检测登录名格式
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public static bool IsLoginName(this String LoginName)
        {
            if (LoginName.IsNull())
            {
                return false;
            }

            string Param = @"([a-zA-Z0-9]|[\u4e00-\u9fa5]){4,20}";

            if (Regex.IsMatch(LoginName, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 检测密码格式,6到20位
        /// </summary>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public static bool IsPassWord(this String PassWord)
        {
            if (PassWord.IsNull())
            {
                return false;
            }

            string Param = @"([a-zA-Z0-9]){6,20}";

            if (Regex.IsMatch(PassWord, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测是否为空.空->返回true
        /// </summary>
        /// <param name="NotNullString"></param>
        /// <returns>空,返回true</returns>
        public static bool IsNull(this String NotNullString)
        {
            //string str = NotNullString.Trim();

            if (String.IsNullOrEmpty(NotNullString) || NotNullString.Trim().Length < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

        /// <summary>
        /// 检测日期格式
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static bool IsDate(this String Time)
        {
            if (Time.IsNull())
            {
                return false;
            }

            DateTime dt=new DateTime ();
            if (DateTime.TryParse(Time,out dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测是否是decimal类型
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string text)
        {
            decimal value;

            if (decimal.TryParse(text, out  value))
            {
                return true ;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 检测是否是Double类型
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsDouble(this string text)
        {
            Double value;

            if (Double.TryParse(text, out  value))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 检测是否是Int类型
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsInt(this string text)
        {
            int value;

            if (int.TryParse(text, out  value))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
       

        /// <summary>
        /// 检测是否是纯数字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsNumber(this String num)
        {
            if (num.IsNull())
            {
                return false;
            }


            string Param = @"-?\d+$";

            if (Regex.IsMatch(num, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测是否是正整数,是返回true
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsInteger(this String num)
        {
            if (num.IsNull())
            {
                return false;
            }
            string Param = @"^\d+$";

            if (Regex.IsMatch(num, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     
        /// <summary>
        /// 检测是否是金额 
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static bool IsMoney(this String money)
        {
            if (money.IsNull())
            {
                return false;
            }

            string Param = @"\d+[.]?\d{0,2}$";

            if (Regex.IsMatch(money, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测邮箱格式
        /// </summary>
        /// <param name="email">邮箱名</param>
        /// <returns></returns>
        public static bool IsEmail(this String email)
        {
            if (email.IsNull())
            {
                return false;
            }

            string Param = @"[a-zA-Z0-9]+[\w-]*(\.[\w-]+)*@([a-zA-Z0-9]+[\w-]*){2,}(\.([a-zA-Z0-9]+[\w-]*){2,})+$";

            if (Regex.IsMatch(email, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


      

        /// <summary>
        /// 验证http
        /// </summary>
        /// <param name="http">http</param>
        /// <returns></returns>
        public static bool IsHttp(this String http)
        {
            if (http.IsNull())
            {
                return false;
            }

            string Param = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

            if (Regex.IsMatch(http, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否是URL地址
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static bool IsUrl(this String http)
        {
            if (http.IsNull())
            {
                return false;
            }

            string Param = @"^(http|https|ftp|mailto)\:\/\/([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";

            if (Regex.IsMatch(http, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 验证电话号码
        /// </summary>
        /// <param name="tel">电话号码</param>
        /// <returns></returns>
        public static bool IsTel(this  string tel)
        {
            if (tel.IsNull())
            {
                return false;
            }

           
            string Param = @"^(\d{3,4})?([ ]|[-])?\d{7,8}$";

            if (Regex.IsMatch(tel, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="tel">手机号码</param>
        /// <returns></returns>
        public static bool IsMobile(this  string tel)
        {
            if (tel.IsNull())
            {
                return false;
            }

           
            string Param = @"^(0?)1\d{10}$";

            if (Regex.IsMatch(tel, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static bool IsPost(this string post)
        {
            if (post.IsNull())
            {
                return false;
            }
            string Param = @"^\d{6}$";

            if (Regex.IsMatch(post, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证QQ
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static bool IsQQ(this string qq)
        {
            if (qq.IsNull())
            {
                return false;
            }
            string Param = @"^\d{5,12}$";

            if (Regex.IsMatch(qq, Param))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
               

        /// <summary>
        /// 检测参数是否含有sql注入语句(尚未完成)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsSqlInject(this string value)
        {
            string Param = @"delete|update|select|insert|drop.*?";

            if (Regex.IsMatch(value.ToLower(), Param))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
