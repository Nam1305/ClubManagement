using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Repository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Threading;

namespace ClubManagement
{
    public partial class TeamLeaderhome : Window
    {
        private readonly GroupRepo _groupRepo;
        private readonly TaskRepo _taskRepo;
        private readonly ClubManagementContext _context;
        private DispatcherTimer _chatTimer;

        public TeamLeaderhome()
        {
            _context = new ClubManagementContext();
            _groupRepo = new GroupRepo();
            _taskRepo = new TaskRepo();

            InitializeComponent();

            if (CurrentUser.RoleId != 4)
            {
                MessageBox.Show("Bạn không có quyền truy cập trang này!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
                return;
            }

            _chatTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5) 
            };
            _chatTimer.Tick += (s, e) => LoadChatMessages();

            LoadGroups();
            LoadTasks();

            var tabControl = FindName("TabControl") as TabControl;
            if (tabControl != null)
            {
                tabControl.SelectionChanged += (s, args) =>
                {
                    if (tabControl.SelectedItem is TabItem selectedTab && selectedTab.Header.ToString() == "Chat")
                    {
                        LoadChatMessages();
                        _chatTimer.Start();
                    }
                    else
                    {
                        _chatTimer.Stop();
                    }
                };
            }
        }

        // Tải tin nhắn
        private void LoadChatMessages()
        {
            try
            {
                var clubId = _groupRepo.GetGroupsByLeaderId(CurrentUser.UserId)
                    .FirstOrDefault()?.ClubId;
                if (!clubId.HasValue)
                {
                    ChatListView.ItemsSource = null;
                    return;
                }

                var messages = _context.Messages
                    .Where(m => m.ClubId == clubId.Value)
                    .Join(_context.Users,
                        m => m.SenderId,
                        u => u.UserId,
                        (m, u) => new MessageDto
                        {
                            MessageId = m.MessageId,
                            SenderName = u.FullName,
                            Content = m.Content,
                            SentAt = m.SentAt
                        })
                    .OrderBy(m => m.SentAt)
                    .ToList();

                ChatListView.ItemsSource = messages;
                if (messages.Any())
                    ChatListView.ScrollIntoView(messages.Last());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải tin nhắn: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xử lý placeholder cho TextBox
        private void MessageTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MessageTextBox.Text == "Nhập tin nhắn...")
            {
                MessageTextBox.Text = "";
            }
        }

        private void MessageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MessageTextBox.Text))
            {
                MessageTextBox.Text = "Nhập tin nhắn...";
            }
        }

        // Gửi tin nhắn
        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MessageTextBox.Text) || MessageTextBox.Text == "Nhập tin nhắn...")
                {
                    MessageBox.Show("Vui lòng nhập nội dung tin nhắn!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var clubId = _groupRepo.GetGroupsByLeaderId(CurrentUser.UserId)
                    .FirstOrDefault()?.ClubId;
                if (!clubId.HasValue)
                {
                    MessageBox.Show("Bạn chưa thuộc câu lạc bộ nào!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newMessage = new DataAccess.Models.Message
                {
                    SenderId = CurrentUser.UserId,
                    ReceiverId = null, // Tin nhắn chung trong câu lạc bộ
                    ClubId = clubId.Value,
                    Content = MessageTextBox.Text,
                    SentAt = DateTime.Now,
                    IsRead = false
                };

                _context.Messages.Add(newMessage);
                _context.SaveChanges();

                MessageTextBox.Text = "Nhập tin nhắn...";
                LoadChatMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi tin nhắn: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadGroups()
        {
            try
            {
                var groups = _groupRepo.GetGroupsByLeaderId(CurrentUser.UserId);
                GroupsListView.ItemsSource = groups;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhóm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadTasks()
        {
            try
            {
                var groupIds = _groupRepo.GetGroupsByLeaderId(CurrentUser.UserId)
                    .Select(g => g.GroupId)
                    .ToList();
                var tasks = _taskRepo.GetTasksByGroupIds(groupIds);
                TasksListView.ItemsSource = tasks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhiệm vụ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewGroupMembers_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int groupId)
            {
                try
                {
                    var members = _groupRepo.GetGroupMembers(groupId);
                    string memberList = string.Join("\n", members.Select(m => m.FullName));
                    MessageBox.Show($"Danh sách thành viên:\n{memberList}", "Thành viên nhóm");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xem thành viên: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateGroupStatus_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int groupId)
            {
                try
                {
                    var group = _context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                    if (group == null)
                    {
                        MessageBox.Show("Không tìm thấy nhóm!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var statusCombo = new ComboBox
                    {
                        ItemsSource = new List<string> { "Active", "Inactive", "Completed" },
                        SelectedItem = group.Status,
                        Width = 150,
                        Margin = new Thickness(0, 0, 0, 10)
                    };
                    var submitButton = new Button { Content = "Cập nhật", Width = 100 };

                    submitButton.Click += (s, args) =>
                    {
                        if (statusCombo.SelectedItem is string newStatus)
                        {
                            group.Status = newStatus;
                            _context.Groups.Update(group);
                            _context.SaveChanges();
                            LoadGroups();
                            MessageBox.Show($"Đã cập nhật trạng thái nhóm {group.GroupName} thành {newStatus}", "Thành công");
                            (submitButton.Parent as Window)?.Close();
                        }
                    };

                    var dialog = new Window
                    {
                        Title = "Cập nhật trạng thái nhóm",
                        Width = 200,
                        Height = 150,
                        Content = new StackPanel { Children = { statusCombo, submitButton }, Margin = new Thickness(10) }
                    };
                    dialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật trạng thái nhóm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateTaskStatus_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int taskId)
            {
                try
                {
                    var task = _context.ClubTasks.FirstOrDefault(t => t.TaskId == taskId);
                    if (task == null)
                    {
                        MessageBox.Show("Không tìm thấy nhiệm vụ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var statusCombo = new ComboBox
                    {
                        ItemsSource = new List<string> { "pending", "in progress", "completed" },
                        SelectedItem = task.Status,
                        Width = 150,
                        Margin = new Thickness(0, 0, 0, 10)
                    };
                    var submitButton = new Button { Content = "Cập nhật", Width = 100 };

                    submitButton.Click += (s, args) =>
                    {
                        if (statusCombo.SelectedItem is string newStatus)
                        {
                            task.Status = newStatus;
                            _taskRepo.UpdateTask(task);
                            LoadTasks();
                            MessageBox.Show($"Đã cập nhật trạng thái nhiệm vụ {task.TaskName} thành {newStatus}", "Thành công");
                            (submitButton.Parent as Window)?.Close();
                        }
                    };

                    var dialog = new Window
                    {
                        Title = "Cập nhật trạng thái nhiệm vụ",
                        Width = 200,
                        Height = 150,
                        Content = new StackPanel { Children = { statusCombo, submitButton }, Margin = new Thickness(10) }
                    };
                    dialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật trạng thái nhiệm vụ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int taskId)
            {
                try
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhiệm vụ này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                    var task = _context.ClubTasks.FirstOrDefault(t => t.TaskId == taskId);
                    if (task == null)
                    {
                        MessageBox.Show("Không tìm thấy nhiệm vụ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    _context.ClubTasks.Remove(task);
                    _context.SaveChanges();
                    LoadTasks();
                    MessageBox.Show($"Đã xóa nhiệm vụ '{task.TaskName}' thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa nhiệm vụ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var groups = _groupRepo.GetGroupsByLeaderId(CurrentUser.UserId);
                if (!groups.Any())
                {
                    MessageBox.Show("Bạn chưa quản lý nhóm nào!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var groupCombo = new ComboBox { ItemsSource = groups, DisplayMemberPath = "GroupName", Margin = new Thickness(0, 0, 0, 10) };
                var taskNameText = new TextBox { Width = 200, Margin = new Thickness(0, 0, 0, 10), Text = "Nhập tên nhiệm vụ" };
                var assignedToCombo = new ComboBox { Width = 200, Margin = new Thickness(0, 0, 0, 10) };
                var dueDatePicker = new DatePicker { Width = 200, Margin = new Thickness(0, 0, 0, 10) };
                var submitButton = new Button { Content = "Giao nhiệm vụ", Width = 100 };

                groupCombo.SelectionChanged += (s, args) =>
                {
                    if (groupCombo.SelectedItem is Group selectedGroup)
                    {
                        var members = _groupRepo.GetGroupMembers(selectedGroup.GroupId);
                        assignedToCombo.ItemsSource = members;
                        assignedToCombo.DisplayMemberPath = "FullName";
                    }
                };

                submitButton.Click += (s, args) =>
                {
                    if (groupCombo.SelectedItem is Group selectedGroup && assignedToCombo.SelectedItem is User selectedUser)
                    {
                        var newTask = new ClubTask
                        {
                            TaskName = taskNameText.Text,
                            AssignedTo = selectedUser.UserId,
                            ClubId = selectedGroup.ClubId,
                            GroupId = selectedGroup.GroupId,
                            DueDate = dueDatePicker.SelectedDate.HasValue ? DateOnly.FromDateTime(dueDatePicker.SelectedDate.Value) : null
                        };

                        _taskRepo.CreateTask(newTask);
                        LoadTasks();
                        MessageBox.Show($"Đã giao nhiệm vụ '{newTask.TaskName}' cho {selectedUser.FullName}", "Thành công");
                        (submitButton.Parent as Window)?.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn nhóm và thành viên!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                };

                var dialog = new Window
                {
                    Title = "Thêm nhiệm vụ mới",
                    Width = 300,
                    Height = 250,
                    Content = new StackPanel { Children = { groupCombo, taskNameText, assignedToCombo, dueDatePicker, submitButton }, Margin = new Thickness(10) }
                };
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhiệm vụ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            _context.Dispose();
            base.OnClosed(e);
        }
    }
}