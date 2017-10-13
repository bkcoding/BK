using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 时间格式操作类
    /// </summary>
    public static class DateTimeHelper
    {

        /// <summary>
        /// 返回指定日期是本周的第几天，周日为第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int DayOfWeeks(this DateTime date)
        {
            int day = 1;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    day = 6;
                    break;
                case DayOfWeek.Monday:
                    day = 2;
                    break;
                case DayOfWeek.Saturday:
                    day = 7;
                    break;
                case DayOfWeek.Sunday:
                    day = 1;
                    break;
                case DayOfWeek.Thursday:
                    day = 5;
                    break;
                case DayOfWeek.Tuesday:
                    day = 3;
                    break;
                case DayOfWeek.Wednesday:
                    day = 4;
                    break;
                default:
                    day = 1;
                    break;
            }
            return day;

        }

        /// <summary>
        /// 返回本周的周日的日期，用于求本周的日期算法
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime DateOfWeeks(this DateTime date)
        {
            int day = date.DayOfWeeks();
            day--;
            return date.AddDays(-1 * (day));

        }
        /// <summary>
        /// 返回离指定日期的天数
        /// </summary>
        /// <param name="enddate">指定日期</param>
        /// <returns></returns>
        public static int DateDiff(this DateTime? enddate)
        {
            TimeSpan ts = Convert.ToDateTime(enddate) - DateTime.Now;
            return Convert.ToInt32(ts.TotalDays);

        }
        /// <summary>
        /// 返回开始时间离结束时间的天数
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns></returns>
        public static int DateDiff(this DateTime? startdate, DateTime? enddate)
        {
            TimeSpan ts = Convert.ToDateTime(enddate) - Convert.ToDateTime(startdate);
            return Convert.ToInt32(ts.TotalDays);
        }
        /// <summary>
        ///返回开始时间离结束时间的时间差
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="model">返回模式（d:返回天数，M:返回月数,y:返回年数，h:返回小数数,m:返回月份，s:返回秒数,其他字符：返回天数）</param>
        /// <returns></returns>
        public static int DateDiff(this DateTime? startdate, DateTime? enddate, string model)
        {
            TimeSpan ts = Convert.ToDateTime(enddate) - Convert.ToDateTime(startdate);
            switch (model)
            {
                case "d":
                    return (int)ts.TotalDays;


                case "M":
                    return (int)ts.TotalDays / 30;

                case "y":
                    return (int)ts.TotalDays / 365;

                case "h":
                    return (int)ts.TotalHours;

                case "m":
                    return (int)ts.TotalMinutes;

                case "s":
                    return (int)ts.TotalSeconds;

                default:
                    return (int)ts.TotalDays;

            }


        }

        /// <summary>
        /// 返回离指定日期的天数
        /// </summary>
        /// <param name="enddate">指定日期</param>
        /// <returns></returns>
        public static int DateDiff(this DateTime enddate)
        {
            TimeSpan ts = enddate - DateTime.Now;
            return Convert.ToInt32(ts.TotalDays);

        }
        /// <summary>
        /// 返回开始时间离结束时间的天数
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns></returns>
        public static int DateDiff(this DateTime startdate, DateTime enddate)
        {
            TimeSpan ts = enddate - startdate;
            return Convert.ToInt32(ts.TotalDays);
        }
        /// <summary>
        ///返回开始时间离结束时间的时间差
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="model">返回模式（d:返回天数，M:返回月数,y:返回年数，h:返回小数数,m:返回月份，s:返回秒数,其他字符：返回天数）</param>
        /// <returns></returns>
        public static int DateDiff(this DateTime startdate, DateTime enddate, string model)
        {
            TimeSpan ts = enddate - startdate;
            switch (model)
            {
                case "d":
                    return (int)ts.TotalDays;
                    

                case "M":
                    return (int)ts.TotalDays / 30;
                    
                case "y":
                    return (int)ts.TotalDays / 365;
                    
                case "h":
                    return (int)ts.TotalHours;
                    
                case "m":
                    return (int)ts.TotalMinutes;
                    
                case "s":
                    return (int)ts.TotalSeconds;
                    
                default:
                    return (int)ts.TotalDays;
                    
            }


        }
        /// <summary>
        /// 返回 yyyy-MM-dd HH:mm:ss格式的字符串，如传入null则返回""
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToStringFormat(this DateTime? datetime)
        {
            if (datetime == null)
            {
                return "";
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd HH:mm:ss}", datetime);
            }
        }
        /// <summary>
        /// 返回 yyyy-MM-dd  格式的字符串，如传入null则返回""
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToStringDateFormat(this DateTime? datetime)
        {
            if (datetime == null)
            {
                return "";
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd}", datetime);
            }
        }

        /// <summary>
        /// 返回 yyyy-MM-dd HH:mm:ss格式的字符串，如传入null则返回""
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToStringFormat(this DateTime datetime)
        {
            if (datetime == null)
            {
                return "";
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd HH:mm:ss}", datetime);
            }
        }

        /// <summary>
        /// 传入分钟,显示{0}天{1}小时{0}分
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToTimeFormat(this decimal d)
        {
            
            int day = (int)d / 1440;
            int hour = (int)((d % 1440) / 60);
            int min = (int)((d % 60));
            if (day > 0)
            {
                return string.Format("{0}天{1}小时{2}分", day, hour, min);
            }
            else
            {
                if (hour > 0)
                {
                    return string.Format("{0}小时{1}分", hour, min);
                }
                else
                {
                    return string.Format("{0}分", min);
                }
            }


        }
        /// <summary>
        /// 传入秒,显示 {1}:{2}:{3}
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToSecondsFormat(this decimal d)
        {
            int h = (int)(d / 3600);
            int m = (int)((d % 3600) / 60);
            int s = (int)((d % 60));
            if (h > 0)
            {
                return string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
            }
            else
            {
                if (m > 0)
                {
                    return string.Format("{0:00}:{1:00}", m, s);
                }
                else
                {
                    if (true)
                    {
                        return string.Format("00:{0:00}", s);
                    }

                }
            }


        }
    }
}
