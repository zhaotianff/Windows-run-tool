﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Windows_run_tool
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoadLanguage();
        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }

        private void LoadLanguage()
        {
            var lang = CultureInfo.CurrentCulture.Name;
            var path = "";

            if(lang == "zh-CN")
            {
                path = "Resources/lang/zh-CN.xaml";
            }
            else
            {
                path = "Resources/lang/en-US.xaml";
            }

            ResourceDictionary resourceDictionary = new ResourceDictionary() { Source = new Uri(path, UriKind.Relative) };
            System.Windows.Application.Current.Resources.MergedDictionaries[0] = resourceDictionary;
        }
    }
}
