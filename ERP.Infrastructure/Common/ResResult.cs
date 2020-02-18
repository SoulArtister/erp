using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure.Common
{
    /// <summary>
    /// 统一接口返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResResult<T> where T : class
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int CodeReturn { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrInfo { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T ResultData { get; set; }

    }
}