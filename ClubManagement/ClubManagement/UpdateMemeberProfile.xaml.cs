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
            if (user.Status == "active")
            {
                rbActive.IsChecked = true;
            }

            if (user.Status == "inactive")
            {
                rbInactive.IsChecked = true;
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int userId = int.Parse(this.txtMemberId.Text);
            string studentNumber = this.txtStudentNumber.Text;
            string email = this.txtEmail.Text;
            string fullName = this.txtFullName.Text;
            string userName = this.txtUserName.Text;
            string status = "";
            string roleName = this.txtRole.Text;
            int roleId = 0;
            if(roleName == "Member")
            {
                roleId = 5;
            }
            if (rbActive.IsChecked == true)
            {
                status = "active";
            }
            if (rbInactive.IsChecked == true)
            {
                status = "inactive";
            }

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
                MessageBox.Show("Update user thất bị!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
