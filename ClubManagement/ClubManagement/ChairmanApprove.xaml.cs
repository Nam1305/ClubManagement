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
    /// Interaction logic for ChairmanApprove.xaml
    /// </summary>
    public partial class ChairmanApprove : Window
    {
        private readonly int userId;
        private readonly int clubId;
        ChairManService service;
        public ChairmanApprove()
        {
        }


        public ChairmanApprove(int userId , int clubId)
        {
            InitializeComponent();
            this.userId = userId;
            this.clubId = clubId;
            GetAll();
        }

        public void GetAll()
        {
            service = new ChairManService();
            this.dgApprove.ItemsSource = service.UserClubs(clubId);
        }

       

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string status = "approved";

                if (string.IsNullOrWhiteSpace(txtUserClubId.Text) || string.IsNullOrWhiteSpace(txtUserId.Text))
                {
                    MessageBox.Show("Vui lòng nhập UserClubId và UserId hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (dpAppliedAt.SelectedDate == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày AppliedAt!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                UserClub uc = new UserClub
                {
                    UserClubId = Int32.Parse(txtUserClubId.Text),
                    UserId = Int32.Parse(txtUserId.Text),
                    Status = status,
                    ClubId = clubId,
                    AppliedAt = DateOnly.FromDateTime(dpAppliedAt.SelectedDate.Value),
                    ApprovedAt = DateOnly.FromDateTime(DateTime.Now) // Gán ngày hiện tại
                };

                service = new ChairManService();
                service.UpdateUserClub(uc);

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                GetAll();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu! Vui lòng kiểm tra lại thông tin nhập vào.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void dgApprove_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserClub user = (UserClub)dgApprove.SelectedItem;
            if (user != null) {
                txtUserClubId.Text = user.UserClubId.ToString();
                txtUserId.Text = user.UserId.ToString();
                dpAppliedAt.Text = user.AppliedAt.ToString();
            }
        }

        private void btnDecline_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result != MessageBoxResult.OK)
            {
                MessageBox.Show("Hủy cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                string status = "disapproved";

                if (string.IsNullOrWhiteSpace(txtUserClubId.Text) || string.IsNullOrWhiteSpace(txtUserId.Text))
                {
                    MessageBox.Show("Vui lòng nhập UserClubId và UserId hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (dpAppliedAt.SelectedDate == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày AppliedAt!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                UserClub uc = new UserClub
                {
                    UserClubId = Int32.Parse(txtUserClubId.Text),
                    UserId = Int32.Parse(txtUserId.Text),
                    Status = status,
                    ClubId = clubId,
                    AppliedAt = DateOnly.FromDateTime(dpAppliedAt.SelectedDate.Value),
                    ApprovedAt = DateOnly.FromDateTime(DateTime.Now) // Gán ngày hiện tại
                };

                service = new ChairManService();
                service.UpdateUserClub(uc);

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                GetAll();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu! Vui lòng kiểm tra lại thông tin nhập vào.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
