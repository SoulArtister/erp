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
        public IList<Menu> MenuList(string account)
        {
            IMenuR menuR = new MenuR();
            if (account.Equals("ADMIN") || account.Equals("@ADMIN"))
                return menuR.IQueryable();
            return menuR.GetMenuList(account);
        }
    }
}
