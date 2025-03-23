using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Repository;
using DataAccess.Models;

namespace ClubManagement
{
    public partial class TeamLeaderhome : Window
    {
        private readonly GroupRepo _groupRepo;
        private readonly TaskRepository _taskRepo;
        private readonly ClubManagementContext _context;
        private Group _selectedGroup;
        private ClubTask _selectedTask;

        public TeamLeaderhome()
        {
            if (CurrentUser.RoleId != 4)
            {
                throw new UnauthorizedAccessException("Only Group Leaders can access this page.");
            }

            InitializeComponent();
            _groupRepo = new GroupRepo();
            _taskRepo = new TaskRepository();
            _context = new ClubManagementContext();
            LoadGroups();
        }

        private void LoadGroups()
        {
            try
            {
                var groups = _groupRepo.GetGroupsByClubId(CurrentUser.ClubId.Value)
                    .Where(g => g.LeaderId == CurrentUser.UserId)
                    .ToList();
                GroupsComboBox.ItemsSource = groups;
                if (groups.Any())
                {
                    GroupsComboBox.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("You are not a leader of any group.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading groups: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GroupsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsComboBox.SelectedItem is Group selectedGroup)
            {
                _selectedGroup = selectedGroup;
                LoadMembers();
                LoadTasks();
            }
        }

        private void LoadMembers()
        {
            try
            {
                var members = _groupRepo.GetGroupMembers(_selectedGroup.GroupId);
                MembersListView.ItemsSource = members;
                AssignMemberComboBox.ItemsSource = members;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadTasks()
        {
            try
            {
                var tasks = _taskRepo.GetTasksByGroupId(_selectedGroup.GroupId);
                TasksListView.ItemsSource = tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TaskStatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.Tag is int taskId)
            {
                try
                {
                    var task = _context.ClubTasks.FirstOrDefault(t => t.TaskId == taskId);
                    if (task != null)
                    {
                        task.Status = comboBox.SelectedValue?.ToString();
                        _taskRepo.UpdateTask(task);
                        MessageBox.Show("Task status updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadTasks();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating task status: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AssignMemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int taskId)
            {
                _selectedTask = _context.ClubTasks.FirstOrDefault(t => t.TaskId == taskId);
                if (_selectedTask == null)
                {
                    MessageBox.Show("Task not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ConfirmAssignButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTask == null)
            {
                MessageBox.Show("Please select a task to assign.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (AssignMemberComboBox.SelectedItem is User selectedMember)
            {
                try
                {
                    _selectedTask.AssignedTo = selectedMember.UserId;
                    _taskRepo.UpdateTask(_selectedTask);
                    MessageBox.Show("Task assigned successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadTasks();
                    _selectedTask = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error assigning task: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a member to assign the task to.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedGroup == null)
            {
                MessageBox.Show("Please select a group first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CreateTaskForm.Visibility = Visibility.Visible;
        }

        private void SaveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TaskNameTextBox.Text))
                {
                    MessageBox.Show("Task Name is required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!DueDatePicker.SelectedDate.HasValue)
                {
                    MessageBox.Show("Due Date is required.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newTask = new ClubTask
                {
                    TaskName = TaskNameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    DueDate = DateOnly.FromDateTime(DueDatePicker.SelectedDate.Value),
                    GroupId = _selectedGroup.GroupId,
                    ClubId = _selectedGroup.ClubId,
                    AssignedBy = CurrentUser.UserId,
                    Status = "pending"
                };

                _taskRepo.CreateTask(newTask);
                MessageBox.Show("Task created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                CreateTaskForm.Visibility = Visibility.Collapsed;
                TaskNameTextBox.Text = string.Empty;
                DescriptionTextBox.Text = string.Empty;
                DueDatePicker.SelectedDate = null;
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating task: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelCreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTaskForm.Visibility = Visibility.Collapsed;
            TaskNameTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
            DueDatePicker.SelectedDate = null;
        }

        private void OpenMemberWindow_Click(object sender, RoutedEventArgs e)
        {
            //var memberWindow = new MemberWindow();
            //memberWindow.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            _context.Dispose();
            base.OnClosed(e);
        }
    }
}