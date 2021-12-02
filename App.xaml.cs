using ListViewData.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ListViewData
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
       // public ManagerSetting SettingManager = new ManagerSetting();

        public static App CurrApp { get { return App.Current as App; } }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (new MainWindow().ShowDialog() ==true)
            {
                new MainWindow().ShowDialog();
            }
            Application.Current.Shutdown();
        }
    }
}
