using System;
using System.Collections.Generic;
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
            await LoadRegisterRunItem();
        }

        private async Task<List<RunItem>> LoadSystem32DirItemAsync()
        {
            var list = new List<RunItem>();

            try
            {
                await Task.Run(()=> {
                    var windir = Environment.GetEnvironmentVariable("windir");

                    if (string.IsNullOrEmpty(windir))
                    {
                        windir = "C:\\Windows";
                    }

                    var sys32dir = System.IO.Path.Combine(windir, "System32");
                    var files = DirectoryExtension.GetFiles(sys32dir, ".msc", ".cpl");
                    list =  files.Select(x => new RunItem() { Name = System.IO.Path.GetFileName(x), Path = x, Description = FileExtension.GetFileDescription(x) }).ToList();
                });

                return list;
            }
            catch
            {
                return list;
            }
        }

        private async Task<List<RunItem>> LoadRegisterRunItem()
        {
            var list = new List<RunItem>();

            try
            {
                await Task.Run(() =>
                {
                    var appList1 = RegisterExtension.GetRegItem(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths");
                    var appList2 = RegisterExtension.GetRegItem(Microsoft.Win32.Registry.ClassesRoot, @"Applications");

                    foreach (var item in appList1)
                    {
                        var runitem = new RunItem();
                        runitem.Name = item;
                        var fullPath = RegisterExtension.GetRegValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + item, null);

                        if (string.IsNullOrEmpty(fullPath))
                            continue;

                        fullPath = fullPath.Replace('"', ' ');

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
    }
}
