using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_run_tool.Reg
{
    public static class RegisterExtension
    {
        public static List<string> GetRegItem(Microsoft.Win32.RegistryKey key,string path)
        {            
            try
            {
                var regKey = key.OpenSubKey(path);
                return regKey.GetSubKeyNames().ToList();               
            }
            catch
            {
                return new List<string>();
            }
        }

        public static string GetRegValue(Microsoft.Win32.RegistryKey key,string path,string name)
        {
            try
            {
                var regKey =  key.OpenSubKey(path);
                return regKey.GetValue(name,"").ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
