using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_run_tool.IO
{
    public static class DirectoryExtension
    {
        public static List<string> GetFiles(string path,params string[] extensions)
        {
            var list = new List<string>();

            try
            {
                var files = System.IO.Directory.GetFiles(path);

                foreach (var item in files)
                {
                    var extension = System.IO.Path.GetExtension(item);

                    if (extensions.Contains(extension))
                        list.Add(item);
                }

                return list;
            }
            catch
            {
                return list;
            }
        }
    }
}
