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
using System.Windows.Shapes;
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginService loginService;
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close(); 
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            loginService = new LoginService();
            string username = txtUsername.Text;
            string password = pwdPassword.Password;
            var account = loginService.Login(username, password);
            if (account == null)
            {
                MessageBox.Show("Sai mật khẩu hoặc username", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Window targetWindow = null;
            //switch (account.Role.ToLower())
            //{
            //    case "admin":
            //        targetWindow = new Adminhome();
            //        break;
            //    case "chairman":
            //        targetWindow = new Chairmanhome();
            //        break;
            //    case "vicechairman":
            //        targetWindow = new ViceChairmanhome();
            //        break;
            //    case "member":
            //        targetWindow = new Memberhome();
            //        break;
            //    default:
            //        MessageBox.Show("Role không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        return;
            //}
            MessageBox.Show($"Đăng nhập thành công! Chào mừng {account.Username}.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            targetWindow.Show();
            this.Close();
        }
    }
}
