using ERP.Domain.Entity;
using ERP.Domain.IRepository;
using ERP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class MenuR : RepositoryBaseT<Menu>, IMenuR
    {
        /// <summary>
        /// 获得菜单
        /// </summary>
        /// <param name="account"></param>
        /// <param name="topId"></param>
        /// <returns></returns>
        public bool IsHaveMenu(string account)
        {
            const string sql = @"select count(1) from Sys_MenuUserMap a
                                left join Sys_Menu b on a.MenuId=b.Id
                                left join G_Users u on a.UserId=u.Id
                                where u.Account=@Account
                                        and b.TopMenuId>0
                                        and Hiding=0
                                        and Stopping=0";//左侧主要菜单
            return QueryintValue(sql, new { Account = account }) > 0;
        }

        /// <summary>
        /// 获得菜单
        /// </summary>
        /// <param name="account"></param>
        /// <param name="topId"></param>
        /// <returns></returns>
        public IList<Menu> GetMenuList(string account, int topId)
        {
            const string sql = @"select b.Id,b.MenuName,b.UrlRoute,b.Icon,b.ParentId,b.Sno,b.TopMenuId,b.HaveBtn,b.IniParam from Sys_MenuUserMap a
                                left join Sys_Menu b on a.MenuId=b.Id
                                left join G_Users u on a.UserId=u.Id
                                where u.Account=@Account
                                        and b.TopMenuId=@TopMenuId
                                        and Hiding=0
                                        and Stopping=0";//左侧主要菜单
            return QueryList(sql, new { Account = account, TopMenuId = topId });

        }
    }
}
