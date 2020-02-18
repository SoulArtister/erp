using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure.Common
{
    public static class Json
    {
        /// <summary>
        /// 对象转json
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ObjectToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static string ObjectToJsonWithFormat(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// json转对象
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(this string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }

        /// <summary>
        /// json转对象
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static object JsonToObject(this string jsonStr)
        {
            return JsonConvert.DeserializeObject(jsonStr);
        }

        /// <summary>
        /// json转list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static List<T> JsonToList<T>(this string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonStr);
        }

        
    }
}
