using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DALFactory
{
    public partial class AbstractFactory
    {
        private static readonly string assemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string nameSpace = ConfigurationManager.AppSettings["NameSpace"];

        /// <summary>
        /// 更具类的完整名称（命名空间+类名）创建实例
        /// </summary>
        /// <param name="fullName">命名空间+类名</param>
        /// <returns></returns>
        private static object CreateInstance(string fullName)
        {
            var assembly = Assembly.Load(assemblyPath);
            return assembly.CreateInstance(fullName);
        }
    }
}
