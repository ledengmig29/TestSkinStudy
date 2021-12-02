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

namespace ListViewData.View.UserControl
{
    /// <summary>
    /// TestUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class TestUserControl
    {
        public TestUserControl()
        {
            InitializeComponent();
        }
        public ImageSource Imagesource { 
            get 
            { 
                return image.Source;
            }
            set 
            { 
                image.Source = value; 
            } 
        }

        public string text1
        {
            get
            {
                return Text1.Text;
            }
            set
            {
                Text1.Text = value;
            }
        }
        public string text2
        {
            get
            {
                return Text2.Text;
            }
            set
            {
                Text2.Text = value;
            }
        }
    }
}
