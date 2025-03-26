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
    /// Interaction logic for JoinEvent.xaml
    /// </summary>
    public partial class JoinEvent : Window
    {
        private readonly int userId;
        UserService userService;
        public JoinEvent()
        {
            
        }

        public JoinEvent(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            userService = new UserService();
            var data = userService.GetAvailableEventsForUser(userId);
            this.dgData.ItemsSource = data;
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Event events = dgData.SelectedItem as Event;
            if (events != null) 
            {
                txtEventId.Text = events.EventId.ToString();
                txtEventName.Text = events.EventName;
                txtDescription.Text = events.Description;
                txtDate.Text = events.EventDate.ToString();
                txtLocation.Text = events.Location;
                txtClubHost.Text = events.Club.ClubName;
            }
        }

        private void btnJoinEvent_Click(object sender, RoutedEventArgs e)
        {
            userService = new UserService();
            if (string.IsNullOrWhiteSpace(txtEventId.Text))
            {
                MessageBox.Show("Vui lòng chọn một sự kiện trước khi tham gia!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int eventId = int.Parse(txtEventId.Text);
            bool isRegistered = userService.RegisterUserForEvent(userId, eventId);

            if (isRegistered)
            {
                MessageBox.Show("Bạn đã đăng ký tham gia sự kiện thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGrid(); // Cập nhật lại danh sách sự kiện khả dụng
            }
            else
            {
                MessageBox.Show("Bạn đã đăng ký sự kiện này trước đó.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
