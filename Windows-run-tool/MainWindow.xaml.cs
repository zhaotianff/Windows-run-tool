using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows_run_tool.Compare;
using Windows_run_tool.Helper;
using Windows_run_tool.IO;
using Windows_run_tool.Model;
using Windows_run_tool.Reg;

namespace Windows_run_tool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : TianXiaTech.BlurWindow
    {
        private static readonly string MsSettingsUrl = "https://docs.microsoft.com/{lang}/windows/uwp/launch-resume/launch-settings-app";
        private static readonly string CanonicalNamesUrl = "https://docs.microsoft.com/{lang}/windows/win32/shell/controlpanel-canonical-names";

        private static readonly string CurrentCultureName = CultureInfo.CurrentCulture.Name;

        List<RunItem> runList = new List<RunItem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BlurWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRunList();
        }

        private async void LoadRunList()
        {
            var app1List = await LoadExecutableItemAsync();
            var app2List = await LoadRegisterRunItemAsync();
            var app3List = await LoadMsSettingsAsync();
            var app4List = await LoadControlPanelItemAsync();
            var app5List = await LoadRundll32ItemFromResAsync();
            var list = app1List.Union(app2List,new RunItemComparer()).Union(app3List,new RunItemComparer()).Union(app4List, new RunItemComparer()).Union(app5List);
            this.listview.ItemsSource = list;
        }

        private async Task<IEnumerable<RunItem>> LoadExecutableItemAsync()
        {
            var list = new List<RunItem>();

            try
            {
                await Task.Run(()=> {
                    var path = Environment.GetEnvironmentVariable("Path");
                    var pathText = Environment.GetEnvironmentVariable("PathExt");

                    var pathArray = path.Split(';');
                    var pathTextArray = pathText.Split(';');
                    pathTextArray = pathTextArray.ToList().Select(x => x.ToLower()).ToArray();

                    if (pathTextArray.Contains(".cpl") == false)
                    {
                        pathTextArray = pathTextArray.Append(".cpl").ToArray();
                    }

                    foreach (var item in pathArray)
                    {
                        if (System.IO.Directory.Exists(item) == false)
                            continue;

                        var files = DirectoryExtension.GetFiles(item, pathTextArray);
                        var runItems =  files.Select(x => new RunItem() { Name = System.IO.Path.GetFileName(x), Path = x, Description = FileExtension.GetFileDescription(x) });
                        list.AddRange(runItems);
                    }                                     
                });

                return list;
            }
            catch
            {
                return list;
            }
        }

        private async Task<IEnumerable<RunItem>> LoadRegisterRunItemAsync()
        {
            var appPath1 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
            //var appPath2 = @"Applications";

            var appList1 = await GetAppListAsync(Microsoft.Win32.Registry.LocalMachine, appPath1);

            //右键菜单 
            //var appList2 = await GetAppListAsync(Microsoft.Win32.Registry.ClassesRoot, appPath2);

            return appList1;
        }

        private async Task<List<RunItem>> GetAppListAsync(Microsoft.Win32.RegistryKey registryKey, string path)
        {
            var list = new List<RunItem>();

            try
            {
                await Task.Run(() =>
                {
                    var appList = RegisterExtension.GetRegItem(registryKey, path);

                    foreach (var item in appList)
                    {
                        var runitem = new RunItem();
                        runitem.Name = item;
                        var fullPath = RegisterExtension.GetRegValue(registryKey, path + "\\" + item, null);

                        if (string.IsNullOrEmpty(fullPath))
                            continue;

                        fullPath = fullPath.Replace('"', ' ').Trim();

                        if (System.IO.File.Exists(fullPath))
                            runitem.Path = fullPath;
                        else
                            runitem.Path = System.IO.Path.Combine(fullPath, item);

                        runitem.Description = FileExtension.GetFileDescription(runitem.Path);
                        list.Add(runitem);
                    }
                });

                return list;
            }
            catch
            {
                return list;
            }
        }

        private async Task<IEnumerable<RunItem>> LoadMsSettingsAsync()
        {
            var html = await WebHelper.GetHtmlSource(MsSettingsUrl.Replace("{lang}", CurrentCultureName));
            return RegexHelper.MatchMsSettingRunItems(html);
        }

        private async Task<IEnumerable<RunItem>> LoadControlPanelItemAsync()
        {
            var html = await WebHelper.GetHtmlSource(CanonicalNamesUrl.Replace("{lang}", CurrentCultureName));
            return RegexHelper.MatchControlPanelRunItems(html);
        }

        private async Task<IEnumerable<RunItem>> LoadRundll32ItemFromResAsync()
        {
            List<RunItem> list = new List<RunItem>();

            await Task.Run(()=> {
                byte[] buffer = Encoding.UTF8.GetBytes(Properties.Resources.rundll32);

                using (System.IO.MemoryStream ms = new MemoryStream(buffer))
                {
                    using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
                    {
                        var tempList = new List<string>();
                        var str = sr.ReadLine();

                        while (!string.IsNullOrEmpty(str))
                        {
                            tempList.Add(str);
                            str = sr.ReadLine();
                        }

                        for (int i = 0; i < tempList.Count -2; i+=3)
                        {
                            RunItem runItem = new RunItem();
                            runItem.Path = tempList[i + 2];
                            runItem.Name = runItem.Path.Replace("rundll32.exe ","");

                            if (CurrentCultureName == "zh-CN")
                            {
                                runItem.Description = tempList[i + 1];
                            }
                            else
                            {
                                runItem.Description = tempList[i];
                            }                       
                            list.Add(runItem);
                        }
                    }
                }

            });

            return list;
        }

        private bool ExportToFile(System.Collections.IEnumerable itemsSource, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine($"Windows-Run-Tool");
                        sw.WriteLine(Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\t" + DateTime.Now.ToString());
                        sw.WriteLine();
                        var headerInfo = $"{FindResource("RunItem").ToString().PadRight(45, ' ')}" +
                            $"{FindResource("Path").ToString().PadRight(55, ' ')}" +
                            $"{FindResource("Description").ToString()}";
                        sw.WriteLine(headerInfo);
                        foreach (RunItem runItem in itemsSource)
                        {
                            sw.WriteLine(runItem.ToString());
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region Event
        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listview.SelectedIndex == -1)
                return;

            this.tbox_Command.Text = (listview.SelectedItem as RunItem).Path;
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            var path = this.tbox_Command.Text.Trim();
            var controlCommand = "control ";
            var rundll32Command = "rundll32.exe ";

            //TODO 修改RunItem结构 增加启动参数
            //控制面板项以传参方式启动
            if(path.StartsWith(controlCommand))
            {
                System.Diagnostics.Process.Start(controlCommand.Trim(),path.Replace(controlCommand,""));
            }
            else if(path.StartsWith(rundll32Command))
            {
                System.Diagnostics.Process.Start(rundll32Command.Trim(), path.Replace(rundll32Command, ""));
            }
            else
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(tbox_Command.Text))
                return;

            Clipboard.SetText(tbox_Command.Text);
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = $"{FindResource("ExportFileType")}|*.txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if(saveFileDialog.ShowDialog() == true)
            {
                var result = ExportToFile(listview.ItemsSource, saveFileDialog.FileName);

                if(result == true)
                {
                    MessageBox.Show(FindResource("ExportSuccess").ToString());
                }
                else
                {
                    MessageBox.Show(FindResource("ExportFailed").ToString());
                }
            }
        }

        #endregion

        
    }
}
