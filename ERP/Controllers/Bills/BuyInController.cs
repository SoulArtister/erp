using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers.Bills
{
    /// <summary>
    /// 采购入库单
    /// </summary>
    public class BuyInController : Controller
    {
        /// <summary>
        /// 单据首页
        /// 加载数据列表和查询条件
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新建单据
        /// </summary>
        /// <returns></returns>
        public ActionResult NewBill()
        {
            return View();
        }

    }
}
