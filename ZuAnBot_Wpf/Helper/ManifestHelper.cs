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
            var assembly = typeof(ManifestHelper).Assembly;
            var expectedSuffix = $".Assets.{jsonName}";
            var resourceName = assembly
                .GetManifestResourceNames()
                .FirstOrDefault(name => name.EndsWith(expectedSuffix, StringComparison.OrdinalIgnoreCase));

            if (resourceName == null)
            {
                throw new FileNotFoundException($"未能找到嵌入资源“{jsonName}”", jsonName);
            }

            var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException($"未能打开嵌入资源“{resourceName}”", resourceName);
            }

            return stream;
        }
    }
}
