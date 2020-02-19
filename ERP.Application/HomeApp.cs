using ERP.Domain.Entity;
using ERP.Infrastructure.ExtenalLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Infrastructure.Common;
using Finance.Domain.IRepository;
using System.Linq.Expressions;
using ERP.Domain.IRepository;
using ERP.Repository;
using System.Collections;
using System.Web;

namespace ERP.Application
{
    public class HomeApp
    {
        /// <summary>
        /// 获得环境变量信息
        /// </summary>
        /// <param name="enviCode"></param>
        /// <returns></returns>
        public string GetEnvironmentInfo(string enviCode)
        {
            IEnvironmentSettingsR environment = new EnvironmentSettingsR();
            return environment.GetInfo(enviCode);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SaveEnvironment(string code, string value, ref string err)
        {
            try
            {
                IEnvironmentSettingsR environment = new EnvironmentSettingsR();
                const string sql = "update Sys_EnvironmentSettings set paramvalue=@value where paramcode=@code";
                return environment.Excute(sql, new { value = value, code = code }) > 0;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="account"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public bool SaveSysLoginLog(string account, string timestamp)
        {
            long timestampLong = 0;
            if (!long.TryParse(timestamp, out timestampLong))
                return false;
            try
            {
                LoginLog log = new LoginLog()
                            {
                                AccountNo = account,
                                OccureTime = DateTime.Now,
                                UserHostAddress = WebHelper.UserHostAddress,
                                SessionId = WebHelper.SessionId,
                                IntTimeStamp = timestampLong
                            };

                return new LoginLogR().Insert(log) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
