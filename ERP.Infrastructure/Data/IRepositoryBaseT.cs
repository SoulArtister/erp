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
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
        int Insert(TEntity entity);
        int Insert(List<TEntity> entitys);
        int Insert(IEnumerable<TEntity> entitys);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        TEntity FindEntity(Expression<Func<TEntity, bool>> predicate);
        IList<TEntity> IQueryable();
        IList<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> FindList(Expression<Func<TEntity, bool>> predicate);

        //List<TEntity> FindList(string strSql);

        //int FindCount(string sql, DbParameter[] dbParameter = null);

        //string FindStringValue(string sql, DbParameter[] dbParameter = null);

        //List<TEntity> FindList(string strSql, DbParameter[] dbParameter);

        /*
         ***********************上面是dos.orm实现******************************
         ************************下面是dapper实现******************************
         */
        string QueryValue(string sql, object param);

        TEntity QueryEntity(string sql, object param);

        List<TEntity> QueryList(string sql, object param);

        /// <summary>
        /// 存储过程查询
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        List<TEntity> QueryListByPro(string proName, object param);

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
