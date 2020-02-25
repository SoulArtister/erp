using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ERP.Infrastructure.Data
{
    public interface IRepositoryBaseT<TEntity> where TEntity : class,new()
    {
        void SetCacheKey(string key);
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
        int Insert(TEntity entity, bool isCache = false);
        int Insert(List<TEntity> entitys, bool isCache = false);
        int Insert(IEnumerable<TEntity> entitys, bool isCache = false);
        int Update(TEntity entity, bool isCache = false);
        int Delete(TEntity entity, bool isCache = false);
        int Delete(Expression<Func<TEntity, bool>> predicate, bool isCache = false);
        TEntity FindEntity(Expression<Func<TEntity, bool>> predicate, bool isCache = false);
        IList<TEntity> IQueryable(bool isCache = false);
        IList<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate, bool isCache = false);

        IList<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, bool isCache = false);

        /*
         ***********************上面是dos.orm实现******************************
         ************************下面是dapper实现******************************
         */
        string QueryValue(string sql, object param, bool isCache = false);

        TEntity QueryEntity(string sql, object param, bool isCache = false);

        List<TEntity> QueryList(string sql, object param, bool isCache = false);

        /// <summary>
        /// 存储过程查询
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        List<TEntity> QueryListByPro(string proName, object param, bool isCache = false);

        int Excute(string sql, object param);

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int TranExcute(string sql, object param);
    }
}
