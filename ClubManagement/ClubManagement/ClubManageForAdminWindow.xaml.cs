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
using Microsoft.VisualBasic.ApplicationServices;
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for ClubManageForAdminWindow.xaml
    /// </summary>
    public partial class ClubManageForAdminWindow : Window
    {
        AdminService adminService;

        public ClubManageForAdminWindow()
        {
            InitializeComponent();
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
            if(clubs != null)
            {
                txtClubId.Text = clubs.ClubId.ToString();
                txtClubName.Text = clubs.ClubName;
                txtDescription.Text = clubs.Description;
                dpEstablishDate.SelectedDate = clubs.EstablishedDate.Value.ToDateTime(TimeOnly.MinValue);
                if (clubs.Status == "active")
                {
                    rbActive.IsChecked = true;
                }

                if (clubs.Status == "inactive")
                {
                    rbInactive.IsChecked = true;
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string clubName = this.txtClubNameSearch.Text;
            if (!clubName.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var club = adminService.SearchClubByName(clubName);
                this.dgDataClub.ItemsSource = club;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string clubName = this.txtClubName.Text;
            string desciption = this.txtDescription.Text;
            DateOnly establishDate = DateOnly.FromDateTime(dpEstablishDate.SelectedDate.Value);
            Club club = new Club()
            {
                ClubName = clubName,
                Description = desciption,
                EstablishedDate = establishDate,
                Status = "active"
            };

            if (adminService.AddNewClub(club))
            {
                MessageBox.Show("Thêm Club thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGridClub();
            }
            else
            {
                MessageBox.Show("Thêm Club thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Club selectedClub = (Club)dgDataClub.SelectedItem;
            string clubName = this.txtClubName.Text;
            string desciption = this.txtDescription.Text;
            DateOnly establishDate = DateOnly.FromDateTime(dpEstablishDate.SelectedDate.Value);
            string status = "";
            if (rbActive.IsChecked == true)
            {
                status = "active";
            }
            if (rbInactive.IsChecked == true)
            {
                status = "inactive";
            }
            Club updatedClub = new Club()
            {
                ClubId = selectedClub.ClubId,
                ClubName = clubName,
                Description = desciption,
                EstablishedDate = establishDate,
                Status = status
            };
            if (adminService.UpdateClub(updatedClub))
            {
                MessageBox.Show("Update Club thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGridClub();
            }
            else
            {
                MessageBox.Show("Update Club thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int clubId = int.Parse( this.txtClubId.Text);
            if (adminService.DeleteClub(clubId))
            {
                MessageBox.Show("Delete Club thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGridClub();
            }
            else
            {
                MessageBox.Show("Thêm Club thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btnReset_Click_1(object sender, RoutedEventArgs e)
        {
            txtClubId.Text = "";
            txtClubName.Text = "";
            txtClubNameSearch.Text = "";
            txtDescription.Text = "";
            dpEstablishDate.SelectedDate = null;
            rbActive.IsChecked = false;
            rbInactive.IsChecked = false;
            LoadDataGridClub();
        }
    }
}
