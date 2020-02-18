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
    public class LoginController : Controller
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
        public ActionResult Login(string chainNo, string account, string password)
        {
            var user = new LoginApp().Login(account, password);
            if (user == null)
                return Json(new { msg = "用户名或密码错误" });
            RepMenuApp rmApp = new RepMenuApp();
            var menuList = rmApp.MenuList(account);
            if (menuList == null || menuList.Count == 0)
                return Json(new { msg = "无权限" });

            WebHelper.WriteSession("menus", menuList.ObjectToJson());
            WebHelper.WriteSession("username", user.UserName );
            WebHelper.WriteSession("useraccount", user.Account);

            return Redirect("/Home/Index");
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
