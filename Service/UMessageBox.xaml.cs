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

namespace ListViewData.Service
{
    /// <summary>
    /// UMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class UMessageBox : Window
    {
        public UMessageBox()
        {
            InitializeComponent();
        }
        public new string Title
        {
            get { return this.title.Text; }
            set { this.title.Text = value; }
        }

        public ImageSource IconSource
        {
            get { return this.icon.Source; }
            set { this.icon.Source = value; }
        }

        public string Message
        {
            get { return this.tipContent.Text; }
            set
            {
                if (value.Length > 50)
                {
                    this.tipContent.Margin = new Thickness(10, 5, 10, 5);
                }
                else
                {
                    this.tipContent.Margin = new Thickness(10, 20, 10, 5);
                }
                this.tipContent.Text = value;
            }
        }
        private static bool? _result;
        public bool? Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public static bool? Show(string msg, string title = "提示", MessageType m = MessageType.Yes)
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                var msgBox = new UMessageBox();
                msgBox.Title = title;
                msgBox.Message = msg;
                msgBox.yesno.Visibility = Visibility.Collapsed;
                msgBox.yes.Visibility = Visibility.Collapsed;
                msgBox.yesnocancel.Visibility = Visibility.Collapsed;
                switch (m)
                {
                    case MessageType.YesNO:
                        msgBox.yesno.Visibility = Visibility.Visible;
                        msgBox.IconSource = new BitmapImage(new Uri(@"../images/m_question.png", UriKind.Relative));
                        break;
                    case MessageType.Yes:
                        msgBox.IconSource = new BitmapImage(new Uri(@"../images/m_message.png", UriKind.Relative));
                        msgBox.yes.Visibility = Visibility.Visible;
                        break;
                    case MessageType.YesNoCancel:
                        msgBox.IconSource = new BitmapImage(new Uri(@"../images/m_message.png", UriKind.Relative));
                        msgBox.yesnocancel.Visibility = Visibility.Visible;
                        break;
                    case MessageType.Error:
                        msgBox.IconSource = new BitmapImage(new Uri(@"../images/m_error.png", UriKind.Relative));
                        msgBox.yes.Visibility = Visibility.Visible;
                        break;
                    case MessageType.Warn:
                        msgBox.IconSource = new BitmapImage(new Uri(@"../images/m_warn.png", UriKind.Relative));
                        msgBox.yes.Visibility = Visibility.Visible;
                        break;
                    default:
                        msgBox.IconSource = new BitmapImage(new Uri(@"../images/m_message.png", UriKind.Relative));
                        msgBox.yes.Visibility = Visibility.Visible;
                        break;
                }
                msgBox.ShowDialog();
            }));
            return _result;
        }
        public enum MessageType
        {
            YesNO = 1,
            Yes = 0,
            YesNoCancel = 2,
            Error = 3,
            Warn = 4
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Result = true;
            this.DragMove();
        }

        private void Button_YES_Click(object sender, RoutedEventArgs e)
        {
            Result = false;
            this.Close();
        }

        private void Button_NO_Click(object sender, RoutedEventArgs e)
        {
            Result = null;
            this.Close();
        }

        private void Button_CANCEL_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
