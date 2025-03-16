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
            GetAll();
        }

        private void GetAll()
        {
            ChairManService = new ChairManService();
            dgTask.ItemsSource = ChairManService.GetMissions(clubId);
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClubTask ct = new ClubTask();
            ct.TaskName = txtTaskName.Text;
            ct.Description = txtDescription.Text;
            ct.Status = null;

            ct.AssignedTo = Int32.Parse(txtAssignedTo.Text);
            ct.AssignedBy = userId;
            ct.ClubId = clubId;

            ct.DueDate = DateOnly.FromDateTime(dpDueDate.SelectedDate.Value);

            ChairManService = new ChairManService();
            ChairManService.AddTask(ct);
            GetAll();
        }





        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            ChairManService = new ChairManService();
            ClubTask ct = new ClubTask();
            ct.TaskId = Int32.Parse(txtTaskId.Text);
            ct.TaskName = txtTaskName.Text;
            ct.Description = txtDescription.Text;
            ct.Status = null;
            ct.AssignedTo = Int32.Parse(txtAssignedTo.Text);
            ct.AssignedBy = userId;
            ct.ClubId = clubId;
            ct.DueDate = DateOnly.FromDateTime(dpDueDate.SelectedDate.Value);
            ChairManService.UpdateTask(ct);
            GetAll();
        }

        private void dgTask_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ClubTask ct = dgTask.SelectedItem as ClubTask;
            if (ct != null)
            {
                txtTaskId.Text = ct.TaskId.ToString();
                txtTaskName.Text = ct.TaskName;
                txtDescription.Text = ct.Description;
                txtAssignedTo.Text = ct.AssignedTo.ToString();
                dpDueDate.Text = ct.DueDate.Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa nhiệm vụ này không?",
            "Xác nhận xóa",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                ChairManService = new ChairManService();
                ClubTask ct = new ClubTask();
                ct.TaskId = Int32.Parse(txtTaskId.Text);
                ct.TaskName = txtTaskName.Text;
                ct.Description = txtDescription.Text;
                ct.Status = null;
                ct.AssignedTo = Int32.Parse(txtAssignedTo.Text);
                ct.AssignedBy = userId;
                ct.ClubId = clubId;
                ct.DueDate = DateOnly.FromDateTime(dpDueDate.SelectedDate.Value);

                ChairManService.DeleteTask(ct);
                GetAll(); 
            }
        }
    }
}
