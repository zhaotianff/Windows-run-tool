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

namespace Windows_run_tool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : TianXiaTech.BlurWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BlurWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var files = DirectoryExtension.GetFiles(@"C:\Windows\System32",".msc",".cpl");

            var list = files.Select(x=>new RunItem() {Name = System.IO.Path.GetFileName(x),Path = x,Description = FileExtension.GetFileDescription(x) }).ToList();


     

            this.listview.ItemsSource = list;
        }
    }
}
