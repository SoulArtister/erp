using ERP.Domain.Entity;
using ERP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance.Domain.IRepository
{
    public interface IUserR : IRepositoryBaseT<User>
    {
        bool IsExist(string userName, string pass);
    }
}
