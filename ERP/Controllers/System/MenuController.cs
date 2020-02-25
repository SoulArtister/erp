using ERP.Application;
using ERP.Domain.Entity;
using ERP.Infrastructure.Common;
using ERP.ViewEntity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers.System
{
    /// <summary>
    /// 全局菜单的增删改查
    /// 只能超级管理员可用
    /// </summary>
    public class MenuController : BaseController
    {
        /// <summary>
        /// 主页
        /// 菜单列表的管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        #region 菜单

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <param name="topId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult QueryMenus(int topId)
        {
            RepMenuApp rmapp = new RepMenuApp();
            var menuList = rmapp.AllMenus(topId);
            var treelist = MenuTree(menuList);
            return Json(treelist);
        }

        /// <summary>
        /// 递归获得用于界面显示的菜单树
        /// </summary>
        /// <param name="mlist"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        private List<MenuTreeEntity> MenuTree(IList<Menu> mlist, int pid = 0)
        {
            var pList = mlist.Where(i => i.ParentId == pid);
            if (pList == null || pList.Count() == 0)
                return null;

            List<MenuTreeEntity> list = new List<MenuTreeEntity>();
            foreach (var p in pList)
            {
                var obj = new MenuTreeEntity();
                obj.id = p.Id;
                string isHide = p.Hiding == true ? "隐藏" : "显示";
                string isStop = p.Stopping == true ? "停用" : "启用";
                obj.title = p.MenuName + " | " + p.UrlRoute + " | " + p.Icon + " | " + p.Sno + " | " + isHide + " | " + isStop;

                var childs = MenuTree(mlist, p.Id);
                if (childs != null)
                    obj.children = childs;
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// 菜单编辑视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditMenuView(int id, int pid)
        {
            if (id == 0 && pid > 0)
                ViewBag.Data.ParentId = pid;
            else
                ViewBag.Data = new RepMenuApp().GetMenu(id);
            return View();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Save(Menu m)
        {
            string err = string.Empty;
            if (!new RepMenuApp().SaveMenu(m, ref err))
                return ErrReturn(err);
            return SuccessReturn();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int id)
        {
            string err = string.Empty;
            if (!new RepMenuApp().DeleteMenu(id, ref err))
                return ErrReturn(err);
            return SuccessReturn();
        }

        #endregion

        #region 按钮

        /// <summary>
        /// 获得按钮
        /// </summary>
        /// <param name="mid">菜单id</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetBtns(int mid)
        {
            string account = WebHelper.GetSession("useraccount");
            var list = new RepMenuApp().GetButtons(account, mid);
            if (list == null)
                return ErrReturn("数据加载失败");
            result.count = list.Count;
            result.data = list;
            return SuccessReturn();
        }

        /// <summary>
        /// 按钮编辑页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public ActionResult BtnEditView(int id, int mid)
        {
            Button btn = new Button();
            if (mid > 0)
            {
                btn.MenuId = mid;
                ViewBag.Data = btn;
            }
            else
            {
                btn = new RepMenuApp().GetButton(id);
                ViewBag.Data = btn;
            }
            return View();
        }

        /// <summary>
        /// 保存按钮信息
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveBtn(Button btn)
        {
            string err = string.Empty;
            if (!new RepMenuApp().SaveButton(btn, ref err))
                return ErrReturn(err);
            return SuccessReturn();
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteBtn(int id)
        {
            string err = string.Empty;
            if (!new RepMenuApp().DeleteButton(id, ref err))
                return ErrReturn(err);
            return SuccessReturn();
        }

        #endregion
    }
}
