using ERP.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ERP.Controllers
{
    /// <summary>
    /// 控制器父类
    /// 统计返回值，日志
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 返回信息
        /// ResResult->Code=0：正常，Code=-2：错误，Code=-4：程序异常
        /// </summary>
        protected ResResult<object> result = new ResResult<object>();

        /// <summary>
        /// 请求的控制器名,方法名
        /// </summary>
        protected string controlName = string.Empty, actionName = string.Empty;
        /// <summary>
        /// 继承初始化方法
        /// 分析请求的控制器，方法名
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            var routDic = requestContext.RouteData.Values;
            controlName = routDic["controller"].ToString();
            actionName = routDic["action"].ToString();

            //如果session丢失，则直接打开登录页
            var userAccount = WebHelper.GetSession("useraccount");
            if (!controlName.Equals("Login") && (userAccount == null || string.IsNullOrWhiteSpace(userAccount)))
            {
                requestContext.RouteData.Values["controller"] = "Login";
                requestContext.RouteData.Values["action"] = "Index";
            }
            base.Initialize(requestContext);

            result = new ResResult<object>() { code = 0, msg = "操作成功", data = string.Empty };
        }

        /// <summary>
        /// 异常错误日志编写
        /// 一般用不到，所有异常默认在控制器中吃掉
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            // 错误日志编写    
            string exception = filterContext.Exception.ToString();
            string param = filterContext.HttpContext.Request.Params.ObjectToJson();
            Log.ErrorFormat(controlName, actionName, exception, param);
            // 执行基类中的OnException    
            base.OnException(filterContext);
        }

        // <summary>
        /// 错误结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ResResult<object> ErrResult(string msg)
        {
            result.code = -2;
            result.msg = msg;
            return result;
        }

        /// <summary>
        /// 异常结果
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ResResult<object> ExceptResult(string msg)
        {
            result.code = -4;
            result.msg = msg;
            return result;
        }

        /// <summary>
        /// 成功返回
        /// 记录日志，保证业务错误的证据
        /// </summary>
        /// <returns></returns>
        protected JsonResult SuccessReturn()
        {
            Log.InfoFormat(controlName, actionName, result.msg);
            return Json(result);
        }

        /// <summary>
        /// 错误返回，记录错误日志
        /// </summary>
        /// <returns></returns>
        protected JsonResult ErrReturn(string errInfo = "")
        {
            result.msg = errInfo.FormatSub();
            Log.InfoFormat(controlName, actionName, errInfo);
            return Json(result);
        }
    }
}
