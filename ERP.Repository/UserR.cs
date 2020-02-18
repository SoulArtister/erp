using ERP.Domain.Entity;
using ERP.Infrastructure.Data;
using Finance.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Infrastructure.Common;

namespace ERP.Repository
{
    public class UserR : RepositoryBaseT<User>, IUserR
    {
        public bool IsExist(string account, string pass)
        {
            pass = pass.EncryptToBase64();
            return IsExist(i => i.Account == account && i.Password == pass);
        }
    }
}
