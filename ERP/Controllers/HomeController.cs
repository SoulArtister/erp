using ERP.Application;
using ERP.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// index页面索引
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// home主页内容
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// 检查登录互斥
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckLoginMutex() {
            var isNeedCheck = new HomeApp().GetEnvironmentInfo("LoginMutex");
            //环境变量中关闭了登录互斥
            if (isNeedCheck == "0")
            { 
                result.data="0";
                return SuccessReturn();
            }
            if (WebHelper.CheckLoginMutex())
            {
                string msg = string.Format("当前账号于{0}在别处登录，您被迫下线！若非本人操作，请注意账户安全！",
                                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Log.InfoFormat(controlName, actionName, msg);
                result.msg = msg;
                result.data = "1";
            }
            return SuccessReturn();
        }
    }
}
