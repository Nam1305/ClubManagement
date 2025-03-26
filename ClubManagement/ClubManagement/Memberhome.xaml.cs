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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess.Models;
using Microsoft.Identity.Client.NativeInterop;
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for Memberhome.xaml
    /// </summary>
    public partial class Memberhome : Window
    {
        private readonly int userId;

        public Memberhome()
        {

        }

        public Memberhome(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }


        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            Window EditProfile = new UpdateMemeberProfile(userId);
            EditProfile.WindowState = WindowState.Maximized;
            EditProfile.Show();

        }

        private void btnListAllClub_Click(object sender, RoutedEventArgs e)
        {
            Window ListALlClub = new ListAllClub(userId);
            ListALlClub.WindowState = WindowState.Maximized;
            ListALlClub.Show();

        }

        private void btnViewClubJoined_Click(object sender, RoutedEventArgs e)
        {
            Window ViewClubJoined = new ListJoinedClub(userId);
            ViewClubJoined.WindowState = WindowState.Maximized;
            ViewClubJoined.Show();

        }

        private void btnEvent_Click(object sender, RoutedEventArgs e)
        {
            Window ListEventJoined = new ListEventsParticipant(userId);
            ListEventJoined.WindowState = WindowState.Maximized;
            ListEventJoined.Show();

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void btnJoinEvent_Click(object sender, RoutedEventArgs e)
        {
            Window JoinEvent = new JoinEvent(userId);
            JoinEvent.WindowState = WindowState.Maximized;
            JoinEvent.Show();
        }
    }
}
