using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Infrastructure.Common;
using ERP.Domain.IRepository;
using ERP.Repository;
using ERP.Domain.Entity;

namespace ERP.Application
{
    public class GroupApp
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
        public bool Save(string code, string value, ref string err)
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
        /// 品牌列表
        /// </summary>
        /// <returns></returns>
        public IList<Brand> BrandList()
        {
            try
            {
                return new BrandR().FindList(i => 1 == 1);
            }
            catch
            {
                return null;
            }

        }
    }
}
