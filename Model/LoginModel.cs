using ListViewData.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewData.Model
{
    public class LoginModel : NotifyBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                this.DoNotify();
            }
        }

        private string _passWord;

        public string Password
        {
            get { return _passWord; }
            set
            {
                _passWord = value;
                this.DoNotify();
            }
        }

        private string _validationCode;

        public string ValidationCode
        {
            get { return _validationCode; }
            set { 
                _validationCode = value;
                this.DoNotify();
            }
        }

    }
}
