using System;
using System.Collections.Generic;
using System.Linq;
 

namespace System.Web
{
    /// <summary>
    /// decimal 类型帮助类
    /// </summary>
    public static class DecimalHelper
    {
        /// <summary>
        /// 把当前时长(秒)显示为 00:00:00格式
        /// </summary>
        /// <param name="seconds">秒</param>
        /// <returns></returns>
        public static string ToTimeFormat(this decimal? seconds)
        {
            string s = "";
            s = string.Format("{0:00}:{1:00}:{2:00}", (int)seconds / 360, (int)(seconds % 360) / 60,(seconds % 360)%60);


            return s;
        }

    }
}