using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess.Models;
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for UpdateMemeberProfile.xaml
    /// </summary>
    public partial class UpdateMemeberProfile : Window
    {
        private readonly int userId;

        UserService userService;
        AdminService adminService;
        public UpdateMemeberProfile()
        {

        }

        public UpdateMemeberProfile(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            User user = GetUser(userId);
            GetUserInformation(user);
        }

        public User GetUser(int userId)
        {
            this.userService = new UserService();
            return userService.GetUserByUserId(userId);
        }

        public void GetUserInformation(User user)
        {
            txtMemberId.Text = userId.ToString();
            txtEmail.Text = user.Email;
            txtFullName.Text = user.FullName;
            txtStudentNumber.Text = user.StudentNumber;
            txtUserName.Text = user.Username;
            txtRole.Text = user.Role.RoleName;
            txtStatus.Text = user.Status;

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.adminService = new AdminService();
            int userId = int.Parse(this.txtMemberId.Text);
            string studentNumber = this.txtStudentNumber.Text;
            string email = this.txtEmail.Text;
            string fullName = this.txtFullName.Text;
            string userName = this.txtUserName.Text;
            if (string.IsNullOrWhiteSpace(studentNumber))
            {
                MessageBox.Show("Student Number không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Full Name không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("user Name không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Regex kiểm tra email
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (adminService.IsEmailAnotherExists(userId, email))
            {
                MessageBox.Show("Email đã tồn tại vui lòng sử dụng mail khác", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (adminService.IsStudentNumberAnotherExists(userId, studentNumber))
            {
                MessageBox.Show("StudentNumber đã tồn tại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (adminService.IsUsernameAnotherExists(userId, userName))
            {
                MessageBox.Show("user name đã tồn tại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string roleName = this.txtRole.Text;
            int roleId = 0;
            if (roleName == "Member")
            {
                roleId = 5;
            }
            string status = this.txtStatus.Text;


            User updatedUser = new User()
            {
                UserId = userId,
                StudentNumber = studentNumber,
                Email = email,
                FullName = fullName,
                Username = userName,
                RoleId = roleId,
                Status = status
            };


            if (userService.UpdateMemberInformation(updatedUser))
            {
                MessageBox.Show("Update user thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Update user thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
