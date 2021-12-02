using ListViewData.Common;
using ListViewData.Meta;
using ListViewData.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewData.DataAccess
{
    public class LocalUserDataAccess
    {
        private static LocalUserDataAccess instance;
        private LocalUserDataAccess() { }
        public static LocalUserDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalUserDataAccess());
        }
        public static MySqlConnection Conn { get; set; }
        public static MySqlCommand Comm { get; set; }
        public static MySqlDataAdapter Adap { get; set; }

        public void Dispose()
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

        public bool DBConnection()
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

        public UserData CheckUserInfo(string userName, string pwd)
        {
            try
            {
                if (DBConnection())
                {
                    string Sql = "select * from user where user_name=@user_name and password=@pwd and is_validation=1";
                    Adap = new MySqlDataAdapter(Sql, Conn);
                    Adap.SelectCommand.Parameters.Add(new MySqlParameter("@user_name", MySqlDbType.VarChar) { Value = userName });
                    Adap.SelectCommand.Parameters.Add(new MySqlParameter("@pwd", MySqlDbType.VarChar) { Value = MD5Provider.GetMD5String(pwd + "@" + userName) });
                    DataTable dataTable = new DataTable();
                    int count = Adap.Fill(dataTable);
                    
                    DataRow dr = dataTable.Rows[0];

                    if (count <= 0)
                        throw new Exception("用户名或密码不正确！");

                    if (dr.Field<Int32>("is_can_login") == 0)
                        throw new Exception("当前用户无权限使用此平台！");

                    UserData userData = new UserData();
                    userData.UserName = dr.Field<string>("user_name");
                    userData.RealName = dr.Field<string>("real_name");
                    userData.PassWord = dr.Field<string>("password");
                    userData.IsCanLogin = dr.Field<Int32>("is_can_login") == 1;
                    userData.Avatar = dr.Field<string>("avatar");
                    userData.Gender = dr.Field<Int32>("gender");
                    return userData;
                }
            }
            catch (Exception )
            {
                
            }
            finally
            {
                Dispose();
            }
            return null;
        }

    }

}

