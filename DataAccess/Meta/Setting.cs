using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewData.Meta
{
    public class Setting
    {
        public string DBIP;
        public string DBName;
        public string DBUserName;
        public string DBPassword;

        public  Setting()
        {
            DBIP = "127.0.0.1";
            DBName = "TestDataBase";
            DBUserName = "root";
            DBPassword = "prince";
        }
    }
}
