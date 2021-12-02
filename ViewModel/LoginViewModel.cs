using ListViewData.Common;
using ListViewData.DataAccess;
using ListViewData.Model;
using ListViewData.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ListViewData.ViewModel
{
    public class LoginViewModel : NotifyBase
    {
        public CommandBase CloseWindowCommand { get; set; } = new CommandBase();
        public LoginModel LoginModel { get; set; } = new LoginModel();
        public CommandBase LoginCommand { get; set; } = new CommandBase();

        /// <summary>
        /// 登录错误信息
        /// </summary>
        private string _errorMsg;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set
            {
                _errorMsg = value; this.Notify();
            }
        }
        /// <summary>
        /// 登录响应进度条
        /// </summary>
        private Visibility _showProgress = Visibility.Collapsed;
        public Visibility ShowProgress
        {
            get { return _showProgress; }
            set
            {
                _showProgress = value;
                this.Notify();
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private Visibility _showError;

        public Visibility ShowError
        {
            get { return _showError; }
            set
            {
                _showError = value;
                this.Notify();
            }
        }

        public LoginViewModel()
        {
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();

            });

            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) =>
            {
                return true;
            });

            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) =>
            {
                return true;
            });
        }

        public void DoLogin(object o)
        {

            this.ShowProgress = Visibility.Visible;
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMsg = "请输入账户";
                this.ShowError = Visibility.Visible;
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMsg = "请输入密码";
                this.ShowError = Visibility.Visible;
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.ValidationCode))
            {
                this.ErrorMsg = "请填写验证码";
                this.ShowError = Visibility.Visible;
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if (LoginModel.ValidationCode.ToLower() != "etu4")
            {
                this.ErrorMsg = "验证码错误";
                this.ShowError = Visibility.Visible;
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            Task.Run(new Action(async () =>
            {
                await Task.Delay(2000);
                try
                {
                    var userInfo = LocalUserDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, LoginModel.Password);
                    if (userInfo == null)
                        throw new Exception("登录失败,用户名或密码错误！");

                    GlobalValues.UserInfo = userInfo;

                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        (o as Window).DialogResult = true;
                    }));
                }
                catch (Exception ex)
                {
                    this.ErrorMsg = ex.Message;
                    this.ShowError = Visibility.Visible;
                }
                finally
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        this.ShowProgress = Visibility.Collapsed;
                    }));
                }
            }));
        }
    }
}
