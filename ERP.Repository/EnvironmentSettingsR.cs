using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Infrastructure.Data;
using ERP.Domain.Entity;
using ERP.Domain.IRepository;

namespace ERP.Repository
{
    public class EnvironmentSettingsR : RepositoryBaseT<EnvironmentSettings>, IEnvironmentSettingsR
    {
        /// <summary>
        /// 获得环境变量信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetInfo(string code)
        {
            const string sql = "select paramvalue from Sys_EnvironmentSettings where paramcode=@code";
            return QueryStringValue(sql, new { code = code });
        }
    }
}
