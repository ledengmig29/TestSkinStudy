using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ListViewData.Common
{
    public class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata("",
            new PropertyChangedCallback(OnPropertyChanged)));

        public static string GetPassword(DependencyObject d)
        {
            return d.GetValue(PasswordProperty).ToString();
        }

        public static void SetPassword(DependencyObject d,string Values)
        {
            d.SetValue(PasswordProperty, Values);
        }

        public static readonly DependencyProperty AttachProperty =
           DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PasswordHelper), new FrameworkPropertyMetadata(default(bool),
           new PropertyChangedCallback(OnAttached)));

        public static bool GetAttach(DependencyObject d)
        {
            return (bool)d.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject d, bool Values)
        {
            d.SetValue(AttachProperty, Values);
        }

        static bool _updating = false;

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged -= Password_PasswordChanged;
            if(!_updating)
            password.Password = e.NewValue?.ToString();
            password.PasswordChanged += Password_PasswordChanged;
        }

        private static void OnAttached(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged += Password_PasswordChanged;
        }

        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            _updating = true;
            SetPassword(passwordBox, passwordBox.Password);
            _updating = false;
        }
    }
}
