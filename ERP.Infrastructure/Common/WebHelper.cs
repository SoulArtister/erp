using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ERP.Infrastructure.Common
{
    public class WebHelper
    {
        /// <summary>
        /// 把session中的字符串转成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetSessionEntity<T>(string key) where T : class
        {
            string jsonStr = GetSession(key);
            return jsonStr.JsonToObject<T>();
        }

        /// <summary>
        /// 把session中的字符串转成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IList<T> GetSessionList<T>(string key) where T : class
        {
            string jsonStr = GetSession(key);
            return jsonStr.JsonToObject<IList<T>>();
        }

        #region Session操作

        /// <summary>
        /// 写Session
        /// </summary>
        /// <typeparam name="T">Session键值的类型</typeparam>
        /// <param name="key">Session的键名</param>
        /// <param name="value">Session的键值</param>
        public static void WriteSession<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            HttpContext.Current.Session[key] = value;
        }

        /// <summary>
        /// 写Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        /// <param name="value">Session的键值</param>
        public static void WriteSession(string key, string value)
        {
            value = value.EncryptToBase64();
            WriteSession<string>(key, value);
        }

        /// <summary>
        /// 读取Session的值
        /// </summary>
        /// <param name="key">Session的键名</param>        
        public static string GetSession(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return string.Empty;
            var value = HttpContext.Current.Session[key];
            if (value == null)
            {
                value = GetCookie(key);
                WriteSession(key, value.ToString());
            }
            return (value as string).DecryptToString();
        }

        /// <summary>
        /// 删除指定Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        public static void RemoveSession(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            HttpContext.Current.Session.Contents.Remove(key);
        }

        /// <summary>
        /// 清除Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        public static void ClearSession()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Contents.Clear();
        }

        #endregion

        #region Cookie操作

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            strValue = strValue.EncryptToBase64();
            cookie.Value = HttpUtility.UrlEncode(strValue, EncodMe());
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(小时)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            strValue = strValue.EncryptToBase64();
            cookie.Value = HttpUtility.UrlEncode(strValue, EncodMe());
            cookie.Expires = DateTime.Now.AddHours(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString().DecryptToString();
            }
            return "";
        }

        /// <summary>
        /// 删除Cookie对象
        /// </summary>
        /// <param name="CookiesName">Cookie对象名称</param>
        public static void RemoveCookie(string CookiesName)
        {
            HttpCookie objCookie = new HttpCookie(CookiesName.Trim());
            objCookie.Expires = DateTime.Now.AddYears(-5);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        /// <summary>
        /// 删除所有Cookie
        /// </summary>
        /// <param name="CookiesName">Cookie对象名称</param>
        public static void ClearCookie()
        {
            HttpContext.Current.Response.Cookies.Clear();
        }
        #endregion

        /// <summary>
        /// 编码
        /// </summary>
        /// <returns></returns>
        private static Encoding EncodMe()
        {
            string browser = HttpContext.Current.Request.Browser.Type.ToUpper();
            if (browser.Contains("IE") == true)
            {
                return Encoding.Default;
            }
            else
            {
                return Encoding.UTF8;
            }
        }
    }
}
