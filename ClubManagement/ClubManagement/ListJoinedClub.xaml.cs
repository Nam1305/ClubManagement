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
    /// Interaction logic for ListJoinedClub.xaml
    /// </summary>
    public partial class ListJoinedClub : Window
    {
        private readonly int userId;
        UserService userService;
        public ListJoinedClub()
        {

        }

        public ListJoinedClub(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadDataDridClubJoined();
            LoadDataDridClubApproving();
            LoadUserInformation();
        }

        public void LoadDataDridClubJoined()
        {
            userService = new UserService();
            var data = userService.GetClubJoinedByUserId(userId);
            this.dgClubJoined.ItemsSource = data;
        }

        public void LoadDataDridClubApproving()
        {
            userService = new UserService();
            var data = userService.GetClubApprovingByUserId(userId);
            this.dgClubApproving.ItemsSource = data;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string querySearch = txtSearch.Text;
            var data = userService.SearchUserClub(userId, querySearch);
            this.dgClubJoined.ItemsSource = data;
        }

        public void LoadUserInformation()
        {
            userService = new UserService();
            var data = userService.GetUserByUserId(userId);
            txtStudentNumber.Text = data.StudentNumber;
            txtStudentName.Text = data.FullName;
            txtEmail.Text = data.Email;
        }

        private void dgClubJoined_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserClub clubs = (UserClub)dgClubJoined.SelectedItem as UserClub;
            if (clubs != null)
            {
                txtClubName.Text = clubs.Club.ClubName;
                txtDescription.Text = clubs.Club.Description;
                txtEstablishDate.Text = clubs.Club.EstablishedDate.ToString();
            }
        }

        private void dgClubApproving_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserClub clubs = (UserClub)dgClubApproving.SelectedItem as UserClub;
            if (clubs != null)
            {
                txtClubName.Text = clubs.Club.ClubName;
                txtDescription.Text = clubs.Club.Description;
                txtEstablishDate.Text = clubs.Club.EstablishedDate.ToString();
            }
        }
    }
}
