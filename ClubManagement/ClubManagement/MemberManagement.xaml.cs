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
    public partial class MemberManagement : Window
    {
        AdminService adminService;
        RoleService roleService;
        public MemberManagement()
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
            this.cbRole.SelectedIndex = 2;

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


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một thành viên chưa
            if (string.IsNullOrEmpty(txtStudentNumber.Text))
            {
                MessageBox.Show("Vui lòng chọn một User để cập nhật!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string fullName = this.txtFullName.Text;
            int roleId = (int)cbRole.SelectedValue;
            string studentNumber = this.txtStudentNumber.Text;
            string status = "";
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


        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtStudentNumber.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            rbActive.IsChecked = true;
            rbInactive.IsChecked = false;
            cbRole.SelectedIndex = 2;
            txtStudentNumberSearch.Text = "";
            txtEmailSearch.Text = "";
            txtFullNameSearch.Text = "";
            txtUserNameSearch.Text = "";
            LoadDataGridUser();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            int roleId = (int)cbRole.SelectedValue;
            var users = adminService.GetUsersByCbRoleChanged(roleId);
            this.dgDataUser.ItemsSource = users;
        }

        private void txtStudentNumberSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string studentNumberSearch = this.txtStudentNumberSearch.Text;
            if (!studentNumberSearch.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var user = adminService.SearchUserByStudentNumber(studentNumberSearch);
                this.dgDataUser.ItemsSource = user;
            }
        }

        private void txtFullNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string fullNameSearch = this.txtFullNameSearch.Text;
            if (!fullNameSearch.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var user = adminService.SearchUserByFullName(fullNameSearch);
                this.dgDataUser.ItemsSource = user;
            }
        }

        private void txtEmailSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string email = this.txtEmailSearch.Text;
            if (!email.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var user = adminService.SearchUserByEmail(email);
                this.dgDataUser.ItemsSource = user;
            }
        }

        private void txtUserNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string userName = this.txtUserNameSearch.Text;
            if (!userName.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var user = adminService.SearchUserByUserName(userName);
                this.dgDataUser.ItemsSource = user;
            }
        }
    }
}
