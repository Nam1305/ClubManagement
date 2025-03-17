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
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for ListAllClub.xaml
    /// </summary>
    public partial class ListAllClub : Window
    {
        private readonly int userId;
        AdminService adminService;
        UserService userService;
        public ListAllClub()
        {

        }

        public ListAllClub(int userId)
        {
            
            InitializeComponent();
            this.userId = userId;
            LoadDataGridClub();
        }

        public void LoadDataGridClub()
        {
            adminService = new AdminService();
            var clubs = adminService.LoadDataGridClub();
            this.dgDataClub.ItemsSource = clubs;
        }

        private void dgDataClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Club clubs = (Club)dgDataClub.SelectedItem as Club;
            if (clubs != null)
            {
                txtClubId.Text = clubs.ClubId.ToString();
                txtClubName.Text = clubs.ClubName;
                txtDescription.Text = clubs.Description;
                dpEstablishDate.SelectedDate = clubs.EstablishedDate.Value.ToDateTime(TimeOnly.MinValue);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = this.txtSearch.Text;
            userService = new UserService();
            if (!searchQuery.IsNullOrEmpty())
            {
                var club = userService.SearchClubByName(searchQuery);
                this.dgDataClub.ItemsSource = club;
            }
        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            int clubId = int.Parse(txtClubId.Text); 
            userService = new UserService();
            bool success = userService.JoinClub(userId, clubId);
            if (success)
            {
                MessageBox.Show("Yêu cầu tham gia câu lạc bộ đã được gửi!");
            }
            else
            {
                MessageBox.Show("Bạn đã gửi yêu cầu trước đó!");
            }

        }
    }
}
