using System;
using System.Text.RegularExpressions;
using System.Windows;
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
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string studentNumber = txtStudentNumber.Text;
            string username = txtUsername.Text;
            string password = pwdPassword.Password;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(studentNumber) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var (success, message) = registerService.RegisterUser(fullName, email, studentNumber, username, password);
                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng ký thất bại: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}