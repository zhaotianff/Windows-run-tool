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
                var shortPath = WinAPI.ShortenPath(Path);

                if(string.IsNullOrEmpty(shortPath))
                {
                    shortPath = Path;
                }

                return $"{Name.PadRight(45, ' ')}{shortPath.PadRight(55, ' ')}{Description}";
            }
           
        }
    }
}
