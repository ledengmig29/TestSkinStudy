using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewData.DataAccess
{
    static class LocalDBManngerAccess
    {
        public static MySqlConnection Conn { get; set; }
        public static MySqlCommand Comm { get; set; }
        public static MySqlDataAdapter Adap { get; set; }

        public static void Dispose()
        {
            if (Adap != null)
            {
                Adap.Dispose();
                Adap = null;
            }
            if (Comm != null)
            {
                Comm.Dispose();
                Comm = null;
            }
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }

        public static bool DBConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["demoDB"].ConnectionString;
            if (Conn == null)
                Conn = new MySqlConnection(connStr);
            try
            {
                Conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
