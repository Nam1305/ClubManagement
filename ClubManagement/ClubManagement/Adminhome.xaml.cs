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
using Microsoft.IdentityModel.Tokens;
using Repository;
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for Adminhome.xaml
    /// </summary>
    public partial class Adminhome : Window
    {
        AdminService adminService;
        RoleService roleService;
        public Adminhome()
        {
            InitializeComponent();
            LoadDataGridUser();
            LoadComboBoxRole();
        }

        public void LoadDataGridUser()
        {
            adminService = new AdminService();
            var users = adminService.LoadDataGridUser();
            this.dgDataUser.ItemsSource = users;
        }

        public void LoadComboBoxRole()
        {
            roleService = new RoleService();
            var roles = roleService.GetRoles();
            this.cbRole.ItemsSource = roles;
            this.cbRole.DisplayMemberPath = "RoleName";
            this.cbRole.SelectedValuePath = "RoleId";
            //this.cbRole.SelectedIndex = 0;

        }

        private void dgDataUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             User users = (User)dgDataUser.SelectedItem as User;
            if (users != null) 
            {
                txtStudentNumber.Text = users.StudentNumber;
                txtFullName.Text = users.FullName;
                txtEmail.Text = users.Email;
                txtUserName.Text = users.Username;
                if (users.Status == "active")
                {
                    rbActive.IsChecked = true;
                }

                if (users.Status == "inactive")
                {
                    rbInactive.IsChecked = true;
                }
                cbRole.SelectedValue = users.RoleId;
            }

        }

        private void btnSearch_StudentNumber_Click(object sender, RoutedEventArgs e)
        {
            string studentNumberSearch = this.txtStudentNumberSearch.Text;
            if (!studentNumberSearch.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var user = adminService.SearchUserByStudentNumber(studentNumberSearch);
                this.dgDataUser.ItemsSource = user;
            }
        }

        private void btnSearch_FullName_Click(object sender, RoutedEventArgs e)
        {
            string fullNameSearch = this.txtFullNameSearch.Text;
            if (!fullNameSearch.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var user = adminService.SearchUserByFullName(fullNameSearch);
                this.dgDataUser.ItemsSource = user;
            }
        }

        private void btnSearch_Email_Click(object sender, RoutedEventArgs e)
        {
            string email = this.txtEmailSearch.Text;
            if (!email.IsNullOrEmpty()) 
            {
                adminService = new AdminService();
                var user = adminService.SearchUserByEmail(email);
                this.dgDataUser.ItemsSource = user;
            }
        }

        private void btnSearch_UserName_Click(object sender, RoutedEventArgs e)
        {
            string userName = this.txtUserNameSearch.Text;
            if (!userName.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var user = adminService.SearchUserByUserName(userName);
                this.dgDataUser.ItemsSource = user;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string fullName = this.txtFullName.Text;
            string email = this.txtEmail.Text;
            string passwordDefault = "Nbn@m11345";
            int roleId =(int)cbRole.SelectedValue;
            string studentNumber = this.txtStudentNumber.Text;
            string userName = this.txtUserName.Text;
            User user = new User()
            {
                FullName = fullName,
                Email = email,
                Password = passwordDefault,
                RoleId = roleId,
                StudentNumber = studentNumber,
                Username = userName,
                Status = "active"
            };

            if (adminService.AddNewUser(user))
            {
                MessageBox.Show("Thêm user thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGridUser();
            }

            else 
            {
                MessageBox.Show("Thêm user thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string fullName = this.txtFullName.Text;
            int roleId = (int)cbRole.SelectedValue;
            string studentNumber = this.txtStudentNumber.Text;
            string status = "";
            if(rbActive.IsChecked == true)
            {
                status = "active";
            }
            if (rbInactive.IsChecked == true) 
            {
                status = "inactive";
            }
            User updatedUser = new User()
            {
                FullName = fullName,
                RoleId = roleId,
                StudentNumber = studentNumber,
                Status = status
            };

            if (adminService.UpdateUser(updatedUser))
            {
                MessageBox.Show("Update user thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGridUser();
            }

            else
            {
                MessageBox.Show("Update user thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string studentNumber = this.txtStudentNumber.Text;
            if (adminService.DeleteUser(studentNumber))
            {
                MessageBox.Show("Delete user thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGridUser();
            }
            else
            {
                MessageBox.Show("Delete user thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int roleId = (int)cbRole.SelectedValue;
            var users = adminService.GetUsersByCbRoleChanged(roleId);
            this.dgDataUser.ItemsSource = users;

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtStudentNumber.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            rbActive.IsChecked = false;
            rbInactive.IsChecked = false;
            txtStudentNumberSearch.Text = "";
            txtEmailSearch.Text = "";
            txtFullNameSearch.Text = "";
            txtUserNameSearch.Text = "";
            LoadDataGridUser();
        }
    }
}
