using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Windows_run_tool.Helper;

namespace Windows_run_tool.Model
{
    public class RunItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            if(Name.StartsWith("ms-settings"))
            {
                return $"{Name.PadRight(100, ' ')}{Description}";
            }
            else
            {
                return $"{Name.PadRight(45, ' ')}{WinAPI.ShortenPath(Path).PadRight(55, ' ')}{Description}";
            }
           
        }
    }
}
