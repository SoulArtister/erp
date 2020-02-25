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
        public int code { get; set; }
        public int count { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }

        public string Err { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }

    }
}