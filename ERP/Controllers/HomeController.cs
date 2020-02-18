using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class HomeController : Controller
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
    }
}
