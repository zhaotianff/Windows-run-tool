using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Windows_run_tool.Helper
{
    public class WinAPI
    {
        private const int MAX_PATH = 260;

        [DllImport("Kernel32.dll")]
        private static extern int GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, int cchBuffer);

        /// <summary>
        /// https://www.cnblogs.com/zhaotianff/p/12524947.html
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ShortenPath(string path)
        {          
            StringBuilder shortPath = new StringBuilder(MAX_PATH);
            GetShortPathName(path, shortPath, MAX_PATH);
            return shortPath.ToString();
        }
    }
}
