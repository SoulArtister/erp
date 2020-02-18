using ERP.Domain.Entity;
using ERP.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.IRepository
{
    public interface IEnvironmentSettingsR : IRepositoryBaseT<EnvironmentSettings>
    {
        string GetInfo(string code);
    }
}
