using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure.Common
{
    /// <summary>
    /// 解析异常信息
    /// </summary>
    public static class ExceptionsAnalyze
    {
        static int length = 220;

        public static string FormatSub(this string mgs)
        {
            //取前length个字符
            if (mgs.Length > 220)
                mgs = mgs.Substring(0, length) + "...";
            return mgs;
        }

        /// <summary>
        /// 人性化错误消息
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="lastStackTrace"></param>
        /// <param name="exCount"></param>
        /// <returns></returns>
        public static string ExtractFormatSub(this Exception exception, string msg = null, int exCount = 1)
        {
            string exMessage = ExtractFormat(exception);
            return FormatSub(exMessage);
        }

        private static string ExtractFormat(this Exception exception, string msg = null, int exCount = 1)
        {
            var ex = exception;
            const string entryFormat = "#{0}: {1}"; 
            msg = msg ?? string.Empty; 
            msg += string.Format(entryFormat, exCount, FormatMessage(ex.Message));

            //递归添加内部异常 
            if ((ex = ex.InnerException) != null)
                return ex.ExtractFormat(string.Format("{0}\r\n\r\n", msg), ++exCount);
            return msg;
        }

        private static string FormatMessage(string msg)
        {
            string mret = msg;
            if (msg.IndexOf("服务器") > -1)
                mret = "服务器链接失败";
            if (msg.IndexOf("输入内容不正确") > -1)
                mret = "账套、用户名或密码错误";
            if (msg.IndexOf("令牌") > -1)
                mret = "没有有效的登录信息";
            if (msg.IndexOf("没有找到对应科目") > -1)
                mret = "账套内缺少必要的科目，请检查账套内科目";
            if (msg.IndexOf("错误的请求") > -1)
                mret = "账套、用户名或密码错误";
            if (msg.IndexOf(" ") > -1)
            {
                if (msg.ToLower().Replace(" ", "").Contains("keycannotbenull"))
                    mret = "登录状态过期，请重新登录";
            }
            return mret;
        }

        /// <summary>
        /// 异常消息
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="lastStackTrace"></param>
        /// <param name="exCount"></param>
        /// <returns></returns>
        public static string Extract(this Exception exception, string msg = null, int exCount = 1)
        {
            var ex = exception;
            const string entryFormat = "#{0}: {1}"; //修复最后一个堆栈跟踪参数 
            msg = msg ?? string.Empty; //添加异常的堆栈跟踪 
            msg += string.Format(entryFormat, exCount, ex.Message);

            //递归添加内部异常 
            if ((ex = ex.InnerException) != null)
                return ex.ExtractWithStackTrace(string.Format("{0}\r\n\r\n", msg), ++exCount);
            return msg;
        }

        /// <summary>
        /// 跟踪异常堆栈消息
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="lastStackTrace"></param>
        /// <param name="exCount"></param>
        /// <returns></returns>
        public static string ExtractWithStackTrace(this Exception exception, string lastStackTrace = null, int exCount = 1)
        {
            var ex = exception;
            const string entryFormat = "#{0}: {1}\r\n{2}"; //修复最后一个堆栈跟踪参数 
            lastStackTrace = lastStackTrace ?? string.Empty; //添加异常的堆栈跟踪 
            lastStackTrace += string.Format(entryFormat, exCount, ex.Message, ex.StackTrace);
            if (exception.Data.Count > 0)
            {
                lastStackTrace += "\r\n Data: ";
                foreach (var item in exception.Data)
                {
                    var entry = (DictionaryEntry)item;
                    lastStackTrace += string.Format("\r\n\t{0}: {1}", entry.Key, exception.Data[entry.Key]);
                }
            }
            //递归添加内部异常 
            if ((ex = ex.InnerException) != null)
                return ex.ExtractWithStackTrace(string.Format("{0}\r\n\r\n", lastStackTrace), ++exCount);
            return lastStackTrace;
        }
    }
}
