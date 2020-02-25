using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ERP.Infrastructure.Common
{
    public class DllInvoke : IDisposable
    {
        Type speClass;
        object activeObj;

        /// <summary>
        /// 加载dll并创建实例
        /// </summary>
        /// <param name="dllPath"></param>
        /// <param name="className"></param>
        public void Init(string dllPath, string className)
        {
            Assembly assembly = Assembly.LoadFrom(dllPath);
            speClass = assembly.GetType(className);
            activeObj = Activator.CreateInstance(speClass);
        }

        /// <summary>
        /// 加载dll并创建实例
        /// </summary>
        /// <param name="dllPath"></param>
        /// <param name="className"></param>
        public T Init<T>(string dllPath, string className)
        {
            Assembly assembly = Assembly.LoadFrom(dllPath);
            Type speClass = assembly.GetType(className);
            return (T)Activator.CreateInstance(speClass);
        }

        /// <summary>
        /// 调用dll中的方法
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="paramTypes"></param>
        /// <param name="objs"></param>
        /// <returns></returns>
        public object Invoke(string methodName, Type[] paramTypes, object[] objs)
        {
            MethodInfo method = speClass.GetMethod(methodName, paramTypes);
            return method.Invoke(activeObj, objs);
        }

        public void Dispose()
        {

        }
    }
}
