using ERP.Application;
using ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers.group
{
    /// <summary>
    /// 集团
    /// 包括集团名称，品牌
    /// </summary>
    public class GroupController : Controller
    {
        /// <summary>
        /// 集团页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.GroupName = new GroupApp().GetEnvironmentInfo("GroupName");
            return View();
        }

        /// <summary>
        /// 保存集团名称
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveGroupName(string groupName)
        {
            var results = "保存成功";
            var code = 0;
            if (!new GroupApp().Save("GroupName", groupName, ref results))
                code = -1;
            return Json(new { code = code, data = results });
        }

        #region 品牌

        /// <summary>
        /// 品牌列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Brands()
        {
            var data = new GroupApp().BrandList();
            return Json(new { data = data });
        }

        public ActionResult EditBrand()
        {
            return View();
        }

        /// <summary>
        /// 保存品牌
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveBrand(Brand brand)
        {
            var reslut = "";
            if (brand.Id == 0)
                reslut = "新增";
            else
                reslut = "修改";
            return Json(new { msg = reslut });
        }

        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteBrand(int id)
        {
            return Json(new { msg = "d" });

        }

        #endregion

        public ActionResult Organize()
        {
            return View();
        }
    }
}
