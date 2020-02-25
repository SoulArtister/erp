using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;
using System.Configuration;

namespace ERP.Infrastructure.Data
{
    public class RepositoryCache<T> : IDisposable
    {
        string key = string.Empty;
        int time = 0;
        string host = string.Empty;//服务器
        int port = 6379;//端口

        /// <summary>
        /// 构造方法
        /// 声明缓存键值及声生命周期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="time">生命周期</param>
        public RepositoryCache(string key, int time = 0)
        {
            this.key = key;
            System.Collections.Specialized.NameValueCollection appsettings = ConfigurationManager.AppSettings;
            host = appsettings["cachehost"];
            int portSetting = port;
            if (int.TryParse(appsettings["cacheport"], out portSetting))
                port = portSetting;
        }

        /// <summary>
        /// 取得键值内容
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            using (var redis = new RedisClient(host, port))
            {
                return redis.Get<T>(this.key);
            }
        }

        /// <summary>
        /// 添加键值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Set(T obj)
        {
            using (var redis = new RedisClient(host, port))
            {
                try
                {
                    redis.Set<T>(this.key, obj);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Del(string key)
        {
            using (var redis = new RedisClient(host, port))
            {
                try
                {
                    redis.Del(key);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void Dispose() { }
    }
}
