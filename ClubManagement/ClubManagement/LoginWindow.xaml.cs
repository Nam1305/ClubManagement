// Trong ClubManagement/LoginWindow.xaml.cs
using System.Windows;
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginService loginService;
        private readonly PasswordResetService resetService;

        public LoginWindow()
        {
            InitializeComponent();
            loginService = new LoginService();
            resetService = new PasswordResetService();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = pwdPassword.Password;

            var account = loginService.Login(username, password);
            if (account == null)
            {
                MessageBox.Show("Sai mật khẩu hoặc username", "Đăng nhập thất bại",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Window targetWindow = null;
            // Kiểm tra vai trò dựa trên Role.RoleName
            switch (account.Role?.RoleName?.ToLower())
            {
                case "admin":
                    targetWindow = new Adminhome();
                    break;
                case "chairman":
                    targetWindow = new Chairmanhome(account.UserId); // Chỉ truyền UserId
                    break;
                case "vicechairman":
                    targetWindow = new ViceChairmanhome(account.UserId); // Chỉ truyền UserId
                    break;
                case "teamleader":
                    targetWindow = new TeamLeaderhome(account.UserId); // Chỉ truyền UserId
                    break;
                case "member":
                    targetWindow = new Memberhome();
                    break;
                default:
                    MessageBox.Show("Role không hợp lệ!", "Lỗi",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
            }

            MessageBox.Show($"Đăng nhập thành công! Chào mừng {account.Username}.",
                "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            targetWindow.Show();
            this.Close();
        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ResetPasswordWindow resetPasswordWindow = new ResetPasswordWindow(this);
            resetPasswordWindow.ShowDialog();
        }
    }
}