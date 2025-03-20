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
        public ChairmanMenu(int userId, int clubId)
        {
            InitializeComponent();
            this.userId = userId;
            this.clubId = clubId;
        }

        private void btnMembers_Click(object sender, RoutedEventArgs e)
        {
            Window menu = new Chairmanhome(userId, clubId);
            menu.WindowState = WindowState.Maximized;

            menu.Show();
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            Window task = new ChairmanTask(userId, clubId);
            task.WindowState = WindowState.Maximized;
            task.Show();
        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {
            Window events = new ChairmanEvent(userId, clubId);
            events.WindowState = WindowState.Maximized;
            events.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Window reports = new ChairmanReport(userId, clubId);
            reports.WindowState = WindowState.Maximized;
            reports.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            Window approve = new ChairmanApprove(userId, clubId);
            approve.WindowState = WindowState.Maximized;
            approve.Show();
        }
    }
}
