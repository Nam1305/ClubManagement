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
using Repository.DTO;
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for ViceChairmanhome.xaml
    /// </summary>
    public partial class Chairmanhome : Window
    {
        private readonly int userId;
        private readonly int clubId;

        ChairManService ChairManService;
        RoleService RoleService;
        public Chairmanhome()
        {
        }


        public Chairmanhome(int userId, int clubId)
        {
            InitializeComponent();
            LoadCbRole();
            this.userId = userId;
            this.clubId = clubId;
            GetAllUserByClubId(clubId);
        }

        private void GetAllUserByClubId(int ClubId)
        {
            ChairManService = new ChairManService();
            dgMembers.ItemsSource = ChairManService.GetUsers(ClubId);
        }

        private void LoadCbRole()
        {
            RoleService = new RoleService();
            cbRole.ItemsSource = RoleService.GetRoleOfChairman();
            cbRole.DisplayMemberPath = "RoleName";
            cbRole.SelectedValuePath = "RoleId";
            cbRole.SelectedIndex = 0;
        }

        private void dgMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            UserDTO user = dgMembers.SelectedItem as UserDTO;
            if (user != null)
            {
                txtUserId.Text = user.UserId.ToString();
                txtFullname.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtStudentNumber.Text = user.StudentNumber;
                txtUsername.Text = user.Username;
                cbRole.Text = user.RoleName;
            }


        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserId.Text) || string.IsNullOrWhiteSpace(txtFullname.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtStudentNumber.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) || cbRole.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn người dùng nào!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            User user = new User();
            user.UserId = Int32.Parse(txtUserId.Text);
            user.FullName = txtFullname.Text;
            user.Email = txtEmail.Text;
            user.RoleId = (int)cbRole.SelectedValue;
            user.StudentNumber = txtStudentNumber.Text;
            user.Username = txtUsername.Text;
            ChairManService = new ChairManService();

            ChairManService.UpdateUser(user, clubId);
            GetAllUserByClubId(clubId);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserId.Text)){
                MessageBox.Show("Bạn chưa chọn người dùng nào!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int userId = Int32.Parse(txtUserId.Text);
            ChairManService.DeleteUser(userId);
            GetAllUserByClubId(clubId);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChairManService = new ChairManService();
            dgMembers.ItemsSource = ChairManService.SearchUser(clubId, txtSearch.Text);
        }
    }
}