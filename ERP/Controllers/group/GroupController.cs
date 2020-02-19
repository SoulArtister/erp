using ERP.Application;
using ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Infrastructure.Common;

namespace ERP.Controllers.group
{
    /// <summary>
    /// 集团
    /// 包括集团名称，品牌
    /// </summary>
    public class GroupController : BaseController
    {
        /// <summary>
        /// 集团页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.GroupName = new HomeApp().GetEnvironmentInfo("GroupName");
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
            var results = "";
            if (!new HomeApp().SaveEnvironment("GroupName", groupName, ref results))
            {
                return ErrReturn(results);
            }
            return SuccessReturn();
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
            base.result.Data = data;
            return SuccessReturn();
        }

        public ActionResult EditBrand()
        {
            return View();
        }

        /// <summary>
        /// 保存品牌，新增和修改
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveBrand(Brand brand)
        {
            var err = "";
            if (!new GroupApp().SaveBrand(brand, ref err))
            {
                return ErrReturn(err);
            }
            return SuccessReturn();
        }

        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteBrand(int id)
        {
            var err = "";
            if (!new GroupApp().DeleteBrand(id, ref err))
                return ErrReturn(err);
            return SuccessReturn();
        }

        #endregion

        public ActionResult Organize()
        {
            return View();
        }
    }
}
