using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_run_tool.Helper
{
    public class WebHelper
    {
        public async static Task<string> GetHtmlSource(string url)
        {
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            using (Stream stream = await httpClient.GetStreamAsync(url))
            {
                using(StreamReader sr = new StreamReader(stream,Encoding.UTF8))
                {
                    return await sr.ReadToEndAsync();
                }
            }
        }
    }
}
