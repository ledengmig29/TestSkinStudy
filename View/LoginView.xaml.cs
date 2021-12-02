using ListViewData.ViewModel;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace ListViewData.View
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 绑定视频文件
            MediaPlayer.Source = new Uri("D:/TestCode/ListViewData/Images/video.mp4");

            // 交互式控制
            MediaPlayer.LoadedBehavior = MediaState.Manual;

            // 添加元素加载完成事件 -- 自动开始播放
            MediaPlayer.Loaded += new RoutedEventHandler(MediaPlayer_MediaEnded);

            MediaPlayer.MediaEnded += new RoutedEventHandler(MediaPlayer_MediaEnded);
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            (sender as MediaElement).Stop();
            (sender as MediaElement).Play();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

        }
    }
}
