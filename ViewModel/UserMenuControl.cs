using ListViewData;
using ListViewData.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestSkin.ViewModel
{


  
    public  class UserMenuControl : NotifyBase
    {
        MainWindow mainWindow = new MainWindow();

        public CommandBase ColorChageBlueBtn { get; set; } = new CommandBase();
        public UserMenuControl()
        {
            this.ColorChageBlueBtn.DoExecute = new Action<object>((o) =>
            {
                mainWindow.WindowTitle.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#58BOED"));
            });


        }

    }
}
