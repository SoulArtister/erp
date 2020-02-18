using log4net;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using ERP.Infrastructure.Common;

namespace ERP.Controllers
{
    /// <summary>
    /// 接口控制器基类
    /// </summary>
    public class ApiBase : ApiController
    {
        /// <summary>
        /// 返回信息
        /// ResResult->CodeReturn=0：正常，ErrCode=-2：错误，ErrCode=-4：程序异常
        /// </summary>
        protected ResResult<object> result = new ResResult<object>();

        /// <summary>
        /// 请求的方法名
        /// </summary>
        protected string methodName = string.Empty;

        /// <summary>
        /// 请求的控制器名
        /// </summary>
        protected string controlName = string.Empty;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        /// <param name="controllerContext"></param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            controlName = controllerContext.ControllerDescriptor.ControllerName;
            methodName = controllerContext.Request.RequestUri.Segments.LastOrDefault();
            result = new ResResult<object>() { CodeReturn = 0, Message = "成功", ErrInfo = string.Empty, ResultData = string.Empty };
        }

        /// <summary>
        /// 错误结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ResResult<object> ErrResult(string msg)
        {
            result.CodeReturn = -2;
            result.Message = msg;
            //result.ErrInfo = msg;
            return result;
        }

        /// <summary>
        /// 异常结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ResResult<object> ExceptResult(string msg)
        {
            result.CodeReturn = -4;
            result.Message = msg;
            //result.ErrInfo = msg;
            return result;
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        /// <returns></returns>
        protected HttpResponseMessage ReturnMessage(string info = "")
        {
            if (!string.IsNullOrWhiteSpace(info))
                result.ErrInfo += "," + info;
            Log.InfoFormat(controlName, methodName, result.ErrInfo);
            Dispose(true);
            return result.ToHttpResponseMessage();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {

        }
    }
}