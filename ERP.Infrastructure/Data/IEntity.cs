using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure.Data
{
    /// <summary>
    /// 领域实体基类
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class IEntity<Tkey> : IDisposable
    {
        /// <summary>
        /// 构造函数注入标识Id
        /// </summary>
        /// <param name="id"></param>
        public IEntity(Tkey id)
        {
            Id = id;
        }

        /// <summary>
        /// 不可改变的标识
        /// </summary>
        public Tkey Id { get; private set; }

        public void Dispose()
        {
        }
    }
}
