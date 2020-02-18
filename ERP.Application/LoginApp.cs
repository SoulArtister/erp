using ERP.Domain.Entity;
using Finance.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Infrastructure.Common;
using ERP.Repository;

namespace ERP.Application
{
    public class LoginApp
    {
        IUserR userRes;

        public User Login(string account, string pass)
        {
            try
            {
                userRes = new UserR();
                return userRes.FindEntity(i => i.Account == account && i.Password == pass.EncryptToBase64());
            }
            catch
            {
                return null;
            }
        }
    }
}
