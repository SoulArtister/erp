using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure.Common
{
    public static class Log
    {
        //static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static ILog log = log4net.LogManager.GetLogger("->");

        public static void ErrorFormat(string message)
        {
            log.ErrorFormat("[Message:{0}]", message);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="control"></param>
        /// <param name="method"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <param name="param"></param>
        public static void ErrorFormat(string control, string method, string message, string param)
        {
            log.ErrorFormat("[Controller:{0}][Method:{1}][Message:{2}][Param:{3}]", control, method,message, param);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="control"></param>
        /// <param name="method"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <param name="param"></param>
        public static void ErrorFormat(string control, string method, string message, object result, string param)
        {
            log.ErrorFormat("[Controller:{0}][Method:{1}][Message:{2}][Param:{3}]", control, method, result, param);
        }

        /// <summary>
        /// log记录信息
        /// </summary>
        /// <param name="control"></param>
        /// <param name="method"></param>
        /// <param name="result"></param>
        public static void InfoFormat(string control, string method, string result)
        {
            log.InfoFormat("[Controller:{0}][Method:{1}][Result:{2}]", control, method, result);
        }
    }
}
