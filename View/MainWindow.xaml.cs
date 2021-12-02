using ListViewData.Meta;
using ListViewData.Service;
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
using ListViewData.ViewModel;

namespace ListViewData
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
           this.DataContext = new MainViewModel();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TestMainWindow != null)
            {
                if (TestMainWindow.WindowState == WindowState.Maximized)
                {
                    TestMainWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    TestMainWindow.WindowState = WindowState.Maximized;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TestMainWindow != null)
            {
                TestMainWindow.WindowState = WindowState.Minimized;
            }
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            POP.IsPopupOpen = true;
        }

       
    }
}
