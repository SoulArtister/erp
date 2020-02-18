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
        IList<Menu> GetMenuList(string account);
    }
}
