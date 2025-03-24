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

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void btnManageMember_Click(object sender, RoutedEventArgs e)
        {
            Window member = new MemberManagement();
            member.WindowState = WindowState.Maximized;
            member.Show();
        }

        private void btnManageClub_Click(object sender, RoutedEventArgs e)
        {
            Window club = new ClubManageForAdminWindow();
            club.WindowState = WindowState.Maximized;
            club.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
