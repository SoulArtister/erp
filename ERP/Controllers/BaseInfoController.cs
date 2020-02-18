using ERP.Application;
using ERP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERP.Infrastructure.Common;
using System.Data;

namespace ERP.Controllers
{
    /// <summary>
    /// 基础数据维护
    /// ResResult->CodeReturn=0：正常，ErrCode=-2：错误，ErrCode=-4：程序异常
    /// </summary>
    public class BaseInfoController : ApiBase
    {

        /// <summary>
        /// 获得账户信息
        /// </summary>
        /// <param name="no">接口编号</param>
        /// <param name="chainOrgId">商户编号</param>
        /// <param name="orgId">分店Id</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetBaseAccoutInfo(string no, string chainOrgId, string orgId)
        {
            //try
            //{
            //    if (string.IsNullOrWhiteSpace(chainOrgId) || string.IsNullOrWhiteSpace(orgId))
            //    {
            //        return ErrResult("组织机构不明确").ToHttpResponseMessage();
            //    }
            //    OrgAccount orgAccount = new OrgAccountApp().GetOrgAccount(chainOrgId, orgId);
            //    if (orgAccount == null)
            //    {
            //        return ErrResult("找不到该机构信息").ToHttpResponseMessage();
            //    }
            //    result.ResultData = orgAccount;
            //    return result.ToHttpResponseMessage();
            //}
            //catch (Exception ex)
            //{
            //    Log.ErrorFormat(controlName, methodName, ex.ExtractWithStackTrace(), orgId);
            //    return ExceptResult(ex.ExtractFormatSub()).ToHttpResponseMessage();
            //}
            return "".ToHttpResponseMessage();
        }

        /// <summary>
        /// 更新账套、账户信息
        /// </summary>
        /// <param name="no"></param>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostBaseAccountInfo(string no, string jsonStr)
        {
            //try
            //{
            //    if (string.IsNullOrWhiteSpace(jsonStr))
            //    {
            //        return ErrResult("参数错误").ToHttpResponseMessage();
            //    }
            //    string err = string.Empty;
            //    if (!new OrgAccountApp().UpdateOrg(jsonStr, ref err))
            //    {
            //        return ErrResult(err).ToHttpResponseMessage();
            //    }
            //    return base.result.ToHttpResponseMessage();
            //}
            //catch (Exception ex)
            //{
            //    Log.ErrorFormat(controlName, methodName, ex.ExtractWithStackTrace(), jsonStr);
            //    return ExceptResult(ex.ExtractFormatSub()).ToHttpResponseMessage();
            //}
            return "".ToHttpResponseMessage();
        }
    }
}
