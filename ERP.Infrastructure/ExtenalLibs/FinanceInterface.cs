using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinanceLibrary;
using Finance.Infrastructure.Libs;

namespace Finance.Infrastructure.ExtenalLibs
{
    public class FinanceInterface : IDisposable
    {
        #region 凭证

        Finances finance = null;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="interfaceNum">接口编号</param>
        /// <param name="url">接口地址</param>
        /// <returns></returns>
        public void Init(string interfaceNum, string url)
        {
            finance = FiFactory.InitialInterface(int.Parse(interfaceNum));
            finance.url = url;
        }

        /// <summary>
        /// 创建凭证
        /// </summary>
        /// <param name="finance"></param>
        /// <param name="baseInfo"></param>
        /// <param name="externalCode"></param>
        /// <param name="voucherType"></param>
        /// <param name="createDate"></param>
        /// <param name="list"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CreateCertifi(object baseInfo, string externalCode, string voucherType, string createDate, List<object> list, string code = "")
        {
            return finance.CreateCertifi(baseInfo, externalCode, voucherType, createDate, list, code);
        }

        /// <summary>
        /// 批量创建凭证
        /// </summary>
        /// <param name="baseInfo"></param>
        /// <param name="voucherType"></param>
        /// <param name="voucherDates"></param>
        /// <param name="dic"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public bool CreateCertifiByBatch(object baseInfo, string voucherType, List<string> voucherDates, Dictionary<string, List<object>> dic, string p2)
        {
            return finance.CreateCertifiByBatch(baseInfo, voucherType, voucherDates, dic, p2);
        }

        #endregion

        #region 金蝶

        /// <summary>
        /// 批量创建收款单和应收单
        /// </summary>
        /// <param name="baseInfo"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string CreateKingdeeBatch(string url, object baseInfo, Dictionary<string, object> param)
        {
            string dllPath = AppDomain.CurrentDomain.BaseDirectory + "/bin/Kingdee/KingdeeLib.dll";
            string className = "KingdeeLib.Kingdee";
            string result = string.Empty;
            using (var lib = new DllInvoke(dllPath, className))
            {
                //设置接口地址
                lib.Invoke("SetUrl", new Type[] { typeof(string) }, new object[] { url });
                //组织参数创建单据
                Type[] type = new Type[] { typeof(object), typeof(Dictionary<string, object>) };
                object[] ps = new object[] { baseInfo, param };
                result = lib.Invoke("CreateReceiptReceivableByBatch", type, ps).ToString();
            }

            return result;
        }

        #endregion

        public void Dispose()
        {
            //this.Dispose();
        }
    }
}
