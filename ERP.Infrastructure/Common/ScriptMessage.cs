using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ERP.Infrastructure.Common
{
    /// <summary>
    /// 调用js提示语
    /// </summary>
    public static class ScriptMessage
    {
        /// <summary>
        /// 警告提示
        /// </summary>
        /// <param name="message"></param>
        public static void AlertW(string message)
        {
            ResponseScript("alertW('" + message + "');");
        }

        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="message"></param>
        public static void Alert(string message)
        {
            ResponseScript("alert('" + message + "');");
        }

        /// <summary>
        /// 提示后跳转
        /// </summary>
        /// <param name="message"></param>
        public static void AlertThis(string message)
        {
            ResponseScript("alert('" + message + "');history.back(1);");
        }

        private static void ResponseScript(string script)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n//<![CDATA[\n");
            HttpContext.Current.Response.Write(script);
            HttpContext.Current.Response.Write("\n//]]>\n</script>\n");
        }

        /// <summary>
        /// 获得提示信息html
        /// 用于导入费用窗体
        /// </summary>
        /// <param name="message"></param>
        public static string GetMessage(string message)
        {
            return "<script>alert('" + message + "');history.back(1);</script>";
        }
    }
}
