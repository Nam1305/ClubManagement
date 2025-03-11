using System.Windows;
using Services;

namespace ClubManagement
{
    public partial class ResetPasswordWindow : Window
    {
        PasswordResetService resetService;
        LoginWindow loginWindow;

        public ResetPasswordWindow(LoginWindow parentWindow)
        {
            InitializeComponent();
            resetService = new PasswordResetService();
            loginWindow = new LoginWindow();
            loginWindow = parentWindow;
            loginWindow.Close();
        }

        private void btnSubmitReset_Click(object sender, RoutedEventArgs e)
        {
            string email = txtResetEmail.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter an email address.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (resetService.ResetPassword(email))
            {
                MessageBox.Show("A temporary password has been sent to your email. " +
                              "Please check your inbox (and spam folder).",
                              "Success",
                              MessageBoxButton.OK,
                              MessageBoxImage.Information);
                OpenLoginWindow();
            }
            else
            {
                MessageBox.Show("Email not found or error occurred while resetting password.",
                              "Error",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OpenLoginWindow();
        }

        private void OpenLoginWindow()
        {
            LoginWindow newLoginWindow = new LoginWindow();
            newLoginWindow.Show();
            this.Close();
        }
    }
}