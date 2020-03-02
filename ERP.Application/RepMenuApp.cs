using ERP.Domain.Entity;
using ERP.Domain.IRepository;
using ERP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Application
{
    /// <summary>
    /// 权限菜单app
    /// </summary>
    public class RepMenuApp
    {
        #region 菜单

        /// <summary>
        /// 是否有菜单权限
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool IsHaveMenuResponse(string account)
        {
            try
            {
                if (account.Equals("@ADMIN") || account.Equals("ADMIN"))
                    return true;
                return new MenuR().IsHaveMenu(account);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 用户菜单列表
        /// 带用户权限
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public IList<Menu> MenuList(string account, int topId)
        {
            try
            {
                IMenuR menuR = new MenuR();
                //权限最大
                if (account.Equals("@ADMIN"))
                    return menuR.IQueryable(i => i.TopMenuId == topId);
                //除系统级外都显示
                if (account.Equals("ADMIN"))
                    return menuR.IQueryable(i => i.TopMenuId == topId && i.Hiding == false && i.Stopping == false);
                return menuR.GetMenuList(account, topId);
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 按顶级菜单获得全部菜单
        /// 无权限
        /// </summary>
        /// <param name="topId">顶级菜单</param>
        /// <returns></returns>
        public IList<Menu> AllMenus(int topId)
        {
            IMenuR menuR = new MenuR();
            return menuR.FindList(i => i.TopMenuId == topId || i.Id == topId);
        }

        /// <summary>
        /// 获得单个菜单
        /// </summary>
        /// <param name="topId"></param>
        /// <returns></returns>
        public Menu GetMenu(int id)
        {
            MenuR mr = new MenuR();
            return mr.FindEntity(i => i.Id == id);
        }

        /// <summary>
        /// 获得大菜单
        /// </summary>
        /// <returns></returns>
        public IList<Menu> GetTopMenus()
        {
            return new MenuR().FindList(i => i.TopMenuId == 0);
        }

        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool SaveMenu(Menu m, ref string err)
        {
            try
            {
                var mr = new MenuR();
                if (m.Id > 0)
                    return mr.Update(m) > 0;
                return mr.Insert(m) > 0; ;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteMenu(int id, ref string err)
        {
            try
            {
                return new MenuR().Delete(i => i.Id == id) > 0;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 按钮

        /// <summary>
        /// 获得按钮列表
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="mid"></param>
        /// <returns></returns>
        public IList<Button> GetButtons(string account, int mid)
        {
            try
            {
                var br = new ButtonR();
                if (account.Equals("@ADMIN"))
                    return br.FindList(i => i.MenuId == mid);
                else if (account.Equals("ADMIN"))
                    return br.FindList(i => i.MenuId == mid && i.Stopping == false);

                const string sql = @"select b.Id,b.ButtonName,b.ClassName,b.FuncName,b.Stopping,b.MenuId 
                                    from Sys_ButtonUserMap a
                                    left join Sys_Button b on a.ButtonId=b.Id
                                    left join G_Users u on a.UserId=u.Id
                                    where u.Account=@Account
                                          and Stopping=0";
                return br.QueryList(sql, new { Account = account });
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得按钮列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Button GetButton(int id)
        {
            try
            {
                return new ButtonR().FindEntity(i => i.Id == id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SaveButton(Button btn, ref string err)
        {
            try
            {
                var br = new ButtonR();
                if (btn.Id > 0)
                    return br.Update(btn) > 0;
                return br.Insert(btn) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteButton(int id, ref string err)
        {
            try
            {
                return new ButtonR().Delete(i => i.Id == id) > 0;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
