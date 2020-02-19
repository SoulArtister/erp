using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace ERP.Infrastructure.Common
{
    /// <summary>
    /// 数据格式转换
    /// </summary>
    public static class DataTrans
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }  

        /// <summary>
        /// 把连加字符串中重复的数据改为乘法
        /// 如：1+1+2转为1*2+2
        /// </summary>
        /// <param name="strAllPlus"></param>
        /// <returns></returns>
        public static string RepeatPlusToMuti(this string strAllPlus)
        {
            string[] str = strAllPlus.Split('+');
            string MutiStr = string.Empty;
            for (var i = 0; i < str.Length; i++)
            {
                string thisStr = str[i];
                int c = str.Where(x => x.Equals(thisStr) && x != "0").Count();

                //重复
                if (c > 1)
                {
                    MutiStr += thisStr + "*" + c + "+";
                    for (var j = 0; j < str.Length; j++)
                    {
                        if (str[j].Equals(thisStr))
                            str[j] = "0";
                    }
                }
                else if (c == 1)
                {
                    MutiStr += str[i] + "+";
                }
            }
            return MutiStr.TrimEnd('+');
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime ToTime(this long timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        public static long ToTimeStramp(this DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 把泛型实体类型result转化为json消息
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static HttpResponseMessage ToHttpResponseMessage(this object result)
        {
            return new HttpResponseMessage()
            {
                Content =
                   new StringContent(JsonConvert.SerializeObject(result), System.Text.Encoding.UTF8,
                       "application/json")
            };
        }

        /// <summary>
        /// 返回html内容的HttpResponseMessage
        /// 主要是alert错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static HttpResponseMessage ToHttpResponseScriptMessage(this string message)
        {
            string scriptMessage = ScriptMessage.GetMessage(message);
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StringContent(scriptMessage, Encoding.UTF8);
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return httpResponseMessage;
        }

        public static void HttpContextResponse(this string message)
        {
            HttpContext.Current.Response.Write(message);
        }
    }
}
