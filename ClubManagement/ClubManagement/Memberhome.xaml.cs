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
        UserService userService;
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
            EditProfile.Show();
            this.Close();
        }

        private void btnListAllClub_Click(object sender, RoutedEventArgs e)
        {
            Window ListALlClub = new ListAllClub(userId);
            ListALlClub.Show();
            this.Close();
        }

        private void btnViewClubJoined_Click(object sender, RoutedEventArgs e)
        {
            Window ViewClubJoined = new ListJoinedClub(userId);
            ViewClubJoined.Show();  
            this.Close();
        }
    }
}
