using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using ERP.Infrastructure.Common;
using System.Reflection;

namespace ERP.Infrastructure.ExtenalLibs
{
    public static class CallDataApi
    {
        /// <summary>
        /// 调数据api接口获得base数据
        /// </summary>
        /// <param name="entity">实体,泛型</param>
        /// <param name="dbUrl">数据apiUrl</param>
        /// <returns>json字符串返回值</returns>
        public static string Call<T>(T entity, string dbUrl) where T : class
        {
            var httpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var httpClient = new HttpClient(httpHandler);

            //实体参数
            HttpContent httpContent = entity.ToFormEntityParams();
            return httpClient.PostAsync(dbUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 调数据api接口获得base数据
        /// json
        /// 适用大数据量
        /// </summary>
        /// <param name="entity">实体,泛型</param>
        /// <param name="dbUrl">数据apiUrl</param>
        /// <returns>json字符串返回值</returns>
        public static string JsonCall<T>(T entity, string dbUrl) where T : class
        {
            var httpHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var httpClient = new HttpClient(httpHandler);

            //实体参数
            HttpContent httpContent = new StringContent(entity.ObjectToJson(), Encoding.UTF8, "text/json");
            return httpClient.PostAsync(dbUrl, httpContent).Result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 将实体转换成api实体参数，方便api到dataApi的数据访问
        /// </summary>
        /// <typeparam name="T">泛型实体类型</typeparam>
        /// <param name="entiy">实体</param>
        /// <returns>FormUrlEncodedContent</returns>
        public static FormUrlEncodedContent ToFormEntityParams<T>(this T entiy) where T : class
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Type type = typeof(T);
            PropertyInfo[] Properties = type.GetProperties();
            foreach (var item in Properties)
            {
                object value = item.GetValue(entiy, null);
                if (value == null)
                    continue;
                dic.Add(item.Name, value.ToString());
            }

            //把参数字典转成FormUrlEncodedContent
            FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(dic);
            return formUrlEncodedContent;
        }
    }
}
