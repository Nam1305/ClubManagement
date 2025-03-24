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
            if (clubs != null)
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


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string clubName = this.txtClubName.Text;
            string desciption = this.txtDescription.Text;
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(clubName) || string.IsNullOrEmpty(desciption) || dpEstablishDate.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Club!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DateOnly establishDate = DateOnly.FromDateTime(dpEstablishDate.SelectedDate.Value);
            // Kiểm tra ClubName có trùng không
            if (adminService.IsDuplicateName(clubName))
            {
                MessageBox.Show("Tên Club đã tồn tại. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
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
            if (selectedClub == null)
            {
                MessageBox.Show("Vui lòng chọn 1 Club nếu muốn update", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
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

        private void txtClubNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string clubName = this.txtClubNameSearch.Text;
            if (!clubName.IsNullOrEmpty())
            {
                adminService = new AdminService();
                var club = adminService.SearchClubByName(clubName);
                this.dgDataClub.ItemsSource = club;
            }
        }
    }
}
