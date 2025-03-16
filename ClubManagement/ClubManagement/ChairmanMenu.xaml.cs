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
    /// Interaction logic for ChairmanMenu.xaml
    /// </summary>
    public partial class ChairmanMenu : Window
    {
        private readonly int userId;
        private readonly int clubId;
        public ChairmanMenu()
        {
        }
        public ChairmanMenu(int userId , int clubId)
        {
            InitializeComponent();
            this.userId = userId;
            this.clubId = clubId;
        }

        private void btnMembers_Click(object sender, RoutedEventArgs e)
        {
            Window menu = new Chairmanhome(userId , clubId);
            menu.Show();
            this.Close();
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            Window task = new ChairmanTask(userId , clubId);
            task.Show();
            this.Close();
        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            Window events = new ChairmanEvent(userId , clubId); 
            events.Show();
            this.Close();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Window reports = new ChairmanReport(userId, clubId);
            reports.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            Window approve = new ChairmanApprove(userId , clubId);
            approve.Show();
            this.Close();
        }
    }
}
