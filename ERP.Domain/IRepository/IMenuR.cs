using ERP.Domain.Entity;
using ERP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.IRepository
{
    public interface IMenuR : IRepositoryBaseT<Menu>
    {
        bool IsHaveMenu(string account);
        IList<Menu> GetMenuList(string account,int topId);
    }
}
