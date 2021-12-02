using ListViewData.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewData.Model
{
    public class ListViewDataMode : NotifyBase
    {
        private ObservableCollection<CloudPatient> cloudpatient;

        public ObservableCollection<CloudPatient> CloudPatients
        {
            get { return cloudpatient; }
            set { cloudpatient = value; Notify(); }
        }

        public ListViewDataMode()
        {
           // LoadData();
        }
        //public void LoadData(string keyword = null)
        //{
        //    DataTable dt = CloudPatientADO.QueryData(keyword);
        //    if (dt != null)
        //    {
        //        CloudPatients = ListViewData(dt);
        //    }
        //}
        private ObservableCollection<CloudPatient> ListViewData(DataTable dt)
        {
            ObservableCollection<CloudPatient> lists = new ObservableCollection<CloudPatient>();
            lists.Clear();
            CloudPatient d = null;
            foreach (DataRow Rows in dt.Rows)
            {
                d = new CloudPatient();
                if (!(Rows["realName"] is System.DBNull))
                {

                    d.RealName = Rows["realName"].ToString();
                }
                else
                {
                    d.RealName = null;
                }
                if (!(Rows["departmentName"] is System.DBNull))
                {
                    d.DepartName = Rows["departmentName"].ToString();
                }
                else
                {
                    d.DepartName = null;
                }
                if (!(Rows["mainInfo"] is System.DBNull))
                {
                    d.MainInfo = Rows["mainInfo"].ToString();
                }
                else
                {
                    d.MainInfo = null;
                }
                if (!(Rows["phone"] is System.DBNull))
                {
                    d.Phone = Rows["phone"].ToString();
                }
                else
                {
                    d.Phone = null;

                }
                if (!(Rows["sex"] is System.DBNull))
                {
                    d.Sex = Rows["sex"].ToString();
                }
                else
                {
                    d.Sex = null;
                }
                if (!(Rows["status"] is System.DBNull))
                {
                    d.Status = Rows["status"].ToString() == "4" ? "已审核" : "待审核";
                }
                else
                {
                    d.Status = null;
                }
                if (!(Rows["pdfurl"] is System.DBNull))
                {
                    d.Pdfurl = Rows["pdfurl"].ToString();
                }
                else
                {
                    d.Pdfurl = null;
                }
                if (!(Rows["pdfdate"] is System.DBNull))
                {
                    d.PdfDate = Convert.ToDateTime(Rows["pdfdate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    d.PdfDate = null;
                }
                lists.Add(d);
            }
            return lists;
        }
    }
}

public class CloudPatient : NotifyBase
{
    private string pdfurl;

    public string Pdfurl
    {
        get { return pdfurl; }
        set { pdfurl = value; Notify(); }
    }

    private string realName;

    public string RealName
    {
        get { return realName; }
        set { realName = value; Notify(); }
    }

    private string depart;

    public string DepartName
    {
        get { return depart; }
        set { depart = value; Notify(); }
    }

    private string mainInfo;

    public string MainInfo
    {
        get { return mainInfo; }
        set { mainInfo = value; Notify(); }
    }

    private string phone;

    public string Phone
    {
        get { return phone; }
        set { phone = value; Notify(); }
    }

    private string sex;

    public string Sex
    {
        get { return sex; }
        set { sex = value; Notify(); }
    }

    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; Notify(); }
    }

    private string pdfdate;

    public string PdfDate
    {
        get { return pdfdate; }
        set { pdfdate = value; Notify(); }
    }

}
