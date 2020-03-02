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
        /// 获得当前菜单html
        /// </summary>
        /// <param name="topId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult MenuHtml(int topId)
        {
            string account = WebHelper.GetSession("useraccount");
            var list = new RepMenuApp().MenuList(account, topId);
            string htmls = string.Empty;
            foreach (var item in list.Where(i => i.ParentId == i.TopMenuId))
            {
                var lid = "menu" + item.Id;
                string urlandparam = "";
                if (string.IsNullOrWhiteSpace(item.IniParam))
                {
                    urlandparam = item.UrlRoute + "?id=" + item.Id;
                }
                string iconname = "layui-icon layui-icon-" + item.Icon;
                htmls += "<li id='" + lid + "' data-name='" + item.Icon + "' class='layui-nav-item'>";
                htmls += @"<a href='javascript:void(0);' lay-tips='" + item.UrlRoute + "' lay-direction='2' onclick=\"gotoPage('" + item.Id + "', '" + urlandparam + "', '" + item.MenuName + "') \">";
                htmls += " <i class='" + iconname + "'></i>";
                htmls += " <cite>" + item.MenuName + "</cite>";
                htmls += " </a>";
                var childs = list.Where(i => i.ParentId == item.Id).OrderBy(i => i.Sno).ToList();
                if (childs == null || childs.Count == 0)
                    continue;
                htmls += " <dl class='layui-nav-child'>";
                foreach (var c in childs)
                {
                    var did = "menu" + c.Id;
                    htmls += "  <dd data-name='console' id='" + did + "'>";
                    htmls += "  <a lay-href='javascript:void(0);' onclick=\"gotoPage('" + c.Id + "', '" + c.UrlRoute + "', '" + c.MenuName + "')\">" + c.MenuName + "</a>";
                    htmls += " </dd>";
                }
                htmls += "</dl></li>";
            }
            result.data = htmls;
            return SuccessReturn();
        }

        /// <summary>
        /// 检查登录互斥
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckLoginMutex()
        {
            var isNeedCheck = new HomeApp().GetEnvironmentInfo("LoginMutex");
            //环境变量中关闭了登录互斥
            if (isNeedCheck == "0")
            {
                result.data = "0";
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
