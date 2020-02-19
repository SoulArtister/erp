using ERP.Application;
using ERP.Domain.Entity;
using ERP.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginController : BaseController
    {

        /// <summary>
        /// 登录页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            RemoveSessions();
            return View();
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="chainNo"></param>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(string chainNo, string account, string password)
        {
            var user = new LoginApp().Login(account, password);
            if (user == null || string.IsNullOrWhiteSpace(user.Account))
            {
                return Json(base.ErrResult("用户名或密码错误"));
            }
            RepMenuApp rmApp = new RepMenuApp();
            var menuList = rmApp.MenuList(account);
            if (menuList == null || menuList.Count == 0)
                return Json(base.ErrResult("无权限"));

            string timeStamp = DataTrans.GetTimeStamp();
            WriteSession(menuList, user, timeStamp);
            SysLog(user.Account, timeStamp);
            WebHelper.UserToApplication(user.Account);

            return SuccessReturn();
        }



        /// <summary>
        /// 记录session
        /// </summary>
        /// <param name="menuList"></param>
        /// <param name="user"></param>
        private void WriteSession(IList<Menu> menuList, User user, string timeStamp)
        {
            WebHelper.WriteSession("menus", menuList.ObjectToJson());
            WebHelper.WriteSession("username", user.UserName);
            WebHelper.WriteSession("useraccount", user.Account);
            WebHelper.WriteSession("timestamp", timeStamp);
        }

        /// <summary>
        /// 记录登录日志到数据库
        /// </summary>
        /// <param name="account"></param>
        /// <param name="timeStamp"></param>
        private void SysLog(string account, string timeStamp)
        {
            new HomeApp().SaveSysLoginLog(account, timeStamp);
        }

        /// <summary>
        /// 清除session
        /// </summary>
        private void RemoveSessions()
        {
            //清理cookie 
            WebHelper.ClearCookie();
            WebHelper.ClearSession();
        }
    }
}
