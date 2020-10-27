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
                runItem.Description = RegexGetSpanValue(tdList[i].Groups["td"].Value);
                var match = Regex.Match(tdList[i + 1].Groups["td"].Value,mssettingPattern);

                if (match.Success == false)
                    continue;

                if(match.Value.Contains("<br>") || match.Value.Contains("<br/>"))
                {
                    var subSettingArray = match.Value.Replace("<br>", ";").Replace("<br/>", ";").Split(';');
                    foreach (var subSetting in subSettingArray)
                    {
                        if (Regex.IsMatch(subSetting, mssettingPattern) == false)
                            continue;

                        RunItem subRunItem = new RunItem();
                        subRunItem.Description = runItem.Description;
                        subRunItem.Name = RegexReplaceChinese(RegexReplaceSpan(subSetting));
                        subRunItem.Path = subRunItem.Name;
                        list.Add(subRunItem);                           
                    }
                }
                else
                {
                    runItem.Name = RegexReplaceChinese(RegexReplaceSpan(match.Value));
                    runItem.Path = runItem.Name;
                    list.Add(runItem);
                }               
            }

            return list;
        }

        private static string RegexGetSpanValue(string input)
        {
            //只测试了英文和中文
            input = input.Replace("&amp;", " ");
            var spanPattern = "(?<=>)[a-zA-Z\\s\u0391-\uFFE5-_]+(?=</)";
            var match = Regex.Match(input,spanPattern);

            if (match.Success)
                return match.Value;
            else
                return input;
        }

        private static string RegexReplaceSpan(string input)
        {
            var spanPattern = "<span(.*)\">|</span>|<span";
            return Regex.Replace(input, spanPattern, "");
        }

        private static string RegexReplaceChinese(string input)
        {
            var kanjiPattern = "[\u0391-\uFFE5]+";
            return Regex.Replace(input, kanjiPattern, "");
        }
    }
}
