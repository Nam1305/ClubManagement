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
    /// Interaction logic for ChairmanTask.xaml
    /// </summary>
    public partial class ChairmanTask : Window
    {
        ChairManService ChairManService;
        private readonly int userId;
        private readonly int clubId;
        public ChairmanTask()
        {
        }

        public ChairmanTask(int userId, int clubId)
        {
            InitializeComponent();
            this.userId = userId;
            this.clubId = clubId;
        }

        private void GetAll()
        {
           dgTask.ItemsSource = ChairManService.GetMissions();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Mission m = new Mission();
            m.TaskName = txtTaskName.Text;
            m.Description = txtDescription.Text;
            m.Status = null;
            m.AssignedTo = 0;
            m.AssignedBy = userId;
            m.ClubId = clubId;

            m.DueDate = DateOnly.FromDateTime(dpDueDate.SelectedDate.Value);


            ChairManService.AddTask(m);
            GetAll();
        }
    }
}
