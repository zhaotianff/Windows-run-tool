using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_run_tool.Model;

namespace Windows_run_tool.Compare
{
    public class RunItemComparer : IEqualityComparer<RunItem>
    {     
        public bool Equals(RunItem x, RunItem y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(RunItem obj)
        {
            return obj.GetHashCode();
        }
    }
}
