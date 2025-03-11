// Trong ClubManagement/RegisterWindow.xaml.cs
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Services;

namespace ClubManagement
{
    public partial class RegisterWindow : Window
    {
        private readonly RegisterService registerService;

        public RegisterWindow()
        {
            InitializeComponent();
            registerService = new RegisterService();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string studentNumber = txtStudentNumber.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = pwdPassword.Password.Trim();
            string roleName = "Member"; // Mặc định vai trò là Member

            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(studentNumber))
            {
                MessageBox.Show("Vui lòng nhập số sinh viên!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập username!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Gọi RegisterService
            bool isRegistered = registerService.RegisterUser(fullName, email, studentNumber, username, password, roleName);
            if (isRegistered)
            {
                MessageBox.Show("Đăng ký thành công! Bạn đã được đăng ký với vai trò Member.", "Thành công",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                // Chuyển hướng về LoginWindow sau khi đăng ký thành công
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Vui lòng kiểm tra lại thông tin.", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xử lý sự kiện Hyperlink_Click để chuyển hướng về LoginWindow
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        // Hàm kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}