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
    /// Interaction logic for ListEventsParticipant.xaml
    /// </summary>
    public partial class ListEventsParticipant : Window
    {
        private readonly int userId;
        UserService userService;
        public ListEventsParticipant()
        {

        }

        public ListEventsParticipant(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            userService = new UserService();
            var data = userService.GetAllEventsJoined(userId);
            this.dgData.ItemsSource = data;
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EventParticipant eventParticipant = dgData.SelectedItem as EventParticipant;
            if (eventParticipant != null)
            {
                txtEventId.Text = eventParticipant.EventId.ToString();
                txtDescription.Text = eventParticipant.Event.Description;
                txtDate.Text = eventParticipant.Event.EventDate.ToString();
                txtEventName.Text = eventParticipant.Event.EventName;
                txtHost.Text = eventParticipant.Event.Club.ClubName;
                txtLocation.Text = eventParticipant.Event.Location;
                txtStatus.Text = eventParticipant.Event.Status;
            }
        }
    }
}

