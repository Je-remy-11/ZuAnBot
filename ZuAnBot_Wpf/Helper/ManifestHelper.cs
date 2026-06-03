using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZuAnBot_Wpf.Helper
{
    /// <summary>
    /// 清单资源工具类
    /// </summary>
    public static class ManifestHelper
    {
        public static Stream GetManifestStream(string jsonName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();
            var targetName = $"Assets.{jsonName}";
            var resourceName = resourceNames.FirstOrDefault(name => name.EndsWith(targetName));
            
            if (resourceName != null)
            {
                return assembly.GetManifestResourceStream(resourceName);
            }
            
            return null;
        }
    }
}
