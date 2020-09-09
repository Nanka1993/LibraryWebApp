using System;
using System.IO;
using System.Reflection;

namespace LibraryWebApp.Extensions
{
    public static class PathRootExtensions
    {
        public static string GetDataPath(this string fileDir, string fileName)
        {
            var ending = Assembly.GetEntryAssembly()?.GetName().Name;
            var filePath = Environment.CurrentDirectory;
            var i = 0;

            while (true)
            {
                var directoryName = Path.GetDirectoryName(filePath);
                filePath = directoryName;
                if (i == 1)
                {
                    filePath = directoryName + @"\";
                }

                if (filePath.EndsWith(ending ?? throw new InvalidOperationException($"Can not get path for {fileName}"))
                )
                {
                    return Path.Combine(filePath, fileDir, fileName);
                }

                i++;
            }
        }
    }
}
