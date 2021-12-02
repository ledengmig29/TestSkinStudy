using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewData.Service
{
   public class ADOHelper
    {
        public static void InitDB()
        {
            try
            {
                //ManngerDatabase.DeleteDatabase();
                //ManngerDatabase.CreateBatabase();

                UMessageBox.Show("数据库重置完成！", "提示");
            }
            catch (Exception e)
            {
                UMessageBox.Show(e.Message, "提示");
            }
        }
    }
}
