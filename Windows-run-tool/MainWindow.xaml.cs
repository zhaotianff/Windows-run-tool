using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            var list = app1List.Union(app2List,new RunItemComparer()).Union(app3List,new RunItemComparer());
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
            var lang = CultureInfo.CurrentCulture.Name;
            var html = await WebHelper.GetHtmlSource(MsSettingsUrl.Replace("{lang}", lang));
            return RegexHelper.MatchRunItems(html);
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
            System.Diagnostics.Process.Start(this.tbox_Command.Text.Trim());
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
        #endregion
    }
}
