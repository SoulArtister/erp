using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ERP.Infrastructure.Data
{
    public class RepositoryBaseT<TEntity> : IRepositoryBaseT<TEntity> where TEntity : IEntityValue, new()
    {
        public DbSession context = DosContext.dosContext;



        public bool IsExist(Expression<Func<TEntity, bool>> predicate)
        {
            return context.From<TEntity>().Where(predicate).Count() > 0;
        }

        public int Insert(TEntity entity)
        {
            return context.Insert<TEntity>(entity);
        }


        public int Insert(List<TEntity> entitys)
        {
            return context.Insert(entitys);
        }

        public int Insert(IEnumerable<TEntity> entitys)
        {
            return context.Insert(entitys);
        }

        public int Update(TEntity entity)
        {
            return context.Update(entity);
        }


        public int Delete(TEntity entity)
        {
            return context.Delete(entity);
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Delete<TEntity>(predicate);
        }

        public TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return context.From<TEntity>().Where(predicate).ToFirstDefault();
        }


        public IList<TEntity> IQueryable()
        {
            return context.From<TEntity>().ToList();
        }


        public IList<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return context.From<TEntity>().Where(predicate).ToList();
        }


        public IList<TEntity> FindList(Expression<Func<TEntity, bool>> predicate)
        {
            return context.From<TEntity>().Where(predicate).ToList();
        }

        //public int FindCount(string sql, DbParameter[] dbParameter = null)
        //{
        //    SqlSection ss = new SqlSection(context, sql);
        //    if (dbParameter != null)
        //        ss.AddParameter(dbParameter);
        //    return ss.ToScalar<int>();
        //}

        //public string FindStringValue(string sql, DbParameter[] dbParameter = null)
        //{
        //    SqlSection ss = new SqlSection(context, sql);
        //    if (dbParameter != null)
        //        ss.AddParameter(dbParameter);
        //    return ss.ToScalar<string>();
        //}

        //public List<TEntity> FindList(string strSql)
        //{
        //    return context.FromSql(strSql).ToList<TEntity>();
        //}


        //public List<TEntity> FindList(string strSql, DbParameter[] dbParameter)
        //{
        //    SqlSection ss = new SqlSection(context, strSql);
        //    ss.AddParameter(dbParameter);
        //    return ss.ToList<TEntity>();
        //}

        /*
         ***********************上面是dos.orm实现******************************
         ************************下面是dapper实现******************************
         */

        public string QueryValue(string sql, object param)
        {
            using (var con = OpenConnection())
            {
                return con.Query<string>(sql, param).FirstOrDefault();
            }
        }

        public TEntity QueryEntity(string sql, object param)
        {
            using (var con = OpenConnection())
            {
                return con.Query<TEntity>(sql, param).FirstOrDefault();
            }
        }

        public List<TEntity> QueryList(string sql, object param)
        {
            using (var con = OpenConnection())
            {
                return con.Query<TEntity>(sql, param).ToList();
            }
        }

        /// <summary>
        /// 存储过程查询
        /// </summary>
        /// <param name="proName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<TEntity> QueryListByPro(string proName, object param)
        {
            using (var con = OpenConnection())
            {
                return con.Query<TEntity>(proName, param, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }

        public int Excute(string sql, object param)
        {
            using (var con = OpenConnection())
            {
                return con.Execute(sql, param);
            }
        }

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int TranExcute(string sql, object param)
        {
            using (var con = OpenConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        int result = con.Execute(sql, param, tran, null, null);
                        tran.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return -1;
                        throw ex;
                    }

                }
            }
        }

        private IDbConnection OpenConnection()
        {
            IDbConnection con = new SqlConnection(context.Db.ConnectionString);
            if (!string.IsNullOrEmpty(context.Db.ConnectionString) && con.State != ConnectionState.Open)
                con.Open();
            return con;
        }
    }
}
