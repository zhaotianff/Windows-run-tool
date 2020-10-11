using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_run_tool.IO
{
    public static class FileExtension
    {
        public static string GetFileDescription(string filePath)
        {
            try
            {
                return System.Diagnostics.FileVersionInfo.GetVersionInfo(filePath).FileDescription;
            }
            catch
            {
                return "";
            }
        }
    }
}
