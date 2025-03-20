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
using Microsoft.IdentityModel.Tokens;
using Repository.DTO;
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
            GetAllMemeber();
        }

        private void GetAll()
        {
            ChairManService = new ChairManService();
            dgTask.ItemsSource = ChairManService.GetMissions(clubId);
        }

        private void GetAllMemeber()
        {
            ChairManService = new ChairManService();
            dgMember.ItemsSource = ChairManService.GetViceChairmanAndTeamLeader(clubId);
        }

        private void dgMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDTO user = dgMember.SelectedItem as UserDTO;
            if (user != null) {
                this.txtAssignedTo.Text = user.UserId.ToString();
            }
            
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClubTask ct = new ClubTask();
                ct.TaskName = txtTaskName.Text;
                ct.Description = txtDescription.Text;
                ct.Status = null;

                string AssignedTo = txtAssignedTo.Text;
                if (string.IsNullOrEmpty(AssignedTo))
                {
                    throw new Exception("You must assign the task to someone.");
                }
                if (!int.TryParse(AssignedTo, out int assignedToId))
                {
                    throw new Exception("AssignedTo must be a valid number.");
                }
                ct.AssignedTo = assignedToId;

                ct.AssignedBy = userId;
                ct.ClubId = clubId;

                if (dpDueDate.SelectedDate == null)
                {
                    throw new Exception("Due Date cannot be empty.");
                }
                ct.DueDate = DateOnly.FromDateTime(dpDueDate.SelectedDate.Value);

                ChairManService = new ChairManService();
                ChairManService.AddTask(ct);
                GetAll();

                MessageBox.Show("Task added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ChairManService = new ChairManService();
                ClubTask ct = new ClubTask();

                string TaskId = txtTaskId.Text;
                if (string.IsNullOrEmpty(TaskId) || !int.TryParse(TaskId, out int taskId))
                {
                    throw new Exception("TaskId is invalid. Please enter a valid number.");
                }
                ct.TaskId = taskId;

                if (string.IsNullOrWhiteSpace(txtTaskName.Text))
                {
                    throw new Exception("Task Name cannot be empty.");
                }
                ct.TaskName = txtTaskName.Text;

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    throw new Exception("Description cannot be empty.");
                }
                ct.Description = txtDescription.Text;

                ct.Status = null;

                string AssignedTo = txtAssignedTo.Text;
                if (string.IsNullOrEmpty(AssignedTo) || !int.TryParse(AssignedTo, out int assignedToId))
                {
                    throw new Exception("AssignedTo is invalid. Please enter a valid number.");
                }
                ct.AssignedTo = assignedToId;

                ct.AssignedBy = userId;
                ct.ClubId = clubId;

                if (dpDueDate.SelectedDate == null)
                {
                    throw new Exception("Due Date cannot be empty.");
                }
                ct.DueDate = DateOnly.FromDateTime(dpDueDate.SelectedDate.Value);

                ChairManService.UpdateTask(ct);
                GetAll();

                MessageBox.Show("Task updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            try
            {
                // Hỏi xác nhận trước khi xóa
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this task?",
                                                          "Confirm Delete",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                {
                    return; // Nếu chọn "No", thoát khỏi hàm
                }

                ChairManService = new ChairManService();
                ClubTask ct = new ClubTask();

                // Kiểm tra TaskId
                if (string.IsNullOrWhiteSpace(txtTaskId.Text))
                {
                    throw new Exception("Task ID cannot be empty.");
                }
                if (!int.TryParse(txtTaskId.Text, out int taskId))
                {
                    throw new Exception("Task ID must be a number.");
                }
                ct.TaskId = taskId;

                // Kiểm tra AssignedTo
                if (string.IsNullOrWhiteSpace(txtAssignedTo.Text))
                {
                    throw new Exception("AssignedTo cannot be empty.");
                }
                if (!int.TryParse(txtAssignedTo.Text, out int assignedTo))
                {
                    throw new Exception("AssignedTo must be a number.");
                }
                ct.AssignedTo = assignedTo;

                // Kiểm tra TaskName
                if (string.IsNullOrWhiteSpace(txtTaskName.Text))
                {
                    throw new Exception("Task Name cannot be empty.");
                }
                ct.TaskName = txtTaskName.Text;

                // Kiểm tra Description
                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    throw new Exception("Description cannot be empty.");
                }
                ct.Description = txtDescription.Text;

                // Kiểm tra DueDate
                if (dpDueDate.SelectedDate == null)
                {
                    throw new Exception("Due Date cannot be empty.");
                }
                ct.DueDate = DateOnly.FromDateTime(dpDueDate.SelectedDate.Value);

                ct.Status = null;
                ct.AssignedBy = userId;
                ct.ClubId = clubId;

                // Gọi hàm xóa task
                ChairManService.DeleteTask(ct);
                GetAll();

                MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
    }
}
