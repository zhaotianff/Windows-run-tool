using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows_run_tool.Model;

namespace Windows_run_tool.Helper
{
    public class RegexHelper
    {
        public static List<RunItem> MatchRunItems(string input)
        {
            //学艺不精啊哎          
            var tdPattern = "<td>(?<td>(.*))</td>";
            var mssettingPattern = "ms-settings:\\S+";

            var list = new List<RunItem>();
            var tdList = Regex.Matches(input, tdPattern);

            for (int i = 0; i < tdList.Count; i +=2)
            {              
                RunItem runItem = new RunItem();
                runItem.Description = RegexReplaceSpan(tdList[i].Groups["td"].Value);
                var match = Regex.Match(tdList[i + 1].Groups["td"].Value,mssettingPattern);

                if (match.Success == false)
                    continue;

                if(match.Value.Contains("<br>"))
                {
                    var subSettingArray = match.Value.Replace("<br>", ";").Split(';');
                    foreach (var subSetting in subSettingArray)
                    {
                        RunItem subRunItem = new RunItem();
                        subRunItem.Description = runItem.Description;
                        subRunItem.Name = RegexReplaceSpan(subSetting);
                        subRunItem.Path = subRunItem.Name;
                        list.Add(subRunItem);
                    }
                }
                else
                {
                    runItem.Name = RegexReplaceSpan(match.Value);
                    runItem.Path = runItem.Name;
                    list.Add(runItem);
                }
                
            }

            return list;
        }

        private static string RegexReplaceSpan(string input)
        {
            var spanPattern = "<span(.*)\">|</span>|<span";
            return Regex.Replace(input, spanPattern, "");
        }
    }
}
