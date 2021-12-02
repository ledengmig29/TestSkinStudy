using ListViewData.Model;
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

namespace ListViewData.View.Page
{
    /// <summary>
    /// ListDataPage.xaml 的交互逻辑
    /// </summary>
    public partial class ListDataPage 
    {
        private ListViewDataMode ViewModel = new ListViewDataMode();
        public ListDataPage()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }
    }
}
