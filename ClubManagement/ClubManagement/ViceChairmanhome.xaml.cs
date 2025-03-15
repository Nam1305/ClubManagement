﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Repository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubManagement
{
    public partial class ViceChairmanhome : Window
    {
        private readonly GroupRepo _groupRepo;
        private readonly UserRepo _userRepo;
        private readonly TaskRepository _taskRepo;
        private readonly ClubManagementContext _context;

        public ViceChairmanhome()
        {
            InitializeComponent();
            _groupRepo = new GroupRepo();
            _userRepo = new UserRepo();
            _taskRepo = new TaskRepository();
            _context = new ClubManagementContext();

            if (CurrentUser.RoleId != 3 || !CurrentUser.ClubId.HasValue)
            {
                MessageBox.Show("You do not have permission or are not assigned to a club.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
                return;
            }

            LoadGroups();
            LoadEvents();
        }

        private void LoadGroups()
        {
            var groups = _groupRepo.GetGroupsByClubId(CurrentUser.ClubId.Value);
            GroupsListView.ItemsSource = groups;
            GroupComboBox.ItemsSource = groups;
        }

        private void LoadEvents()
        {
            var events = _context.Events.Where(e => e.ClubId == CurrentUser.ClubId.Value).ToList();
            EventsListView.ItemsSource = events;
        }

        private void CreateGroupButton_Click(object sender, RoutedEventArgs e)
        {
            var groupName = Microsoft.VisualBasic.Interaction.InputBox("Enter group name:", "Create Group", "New Group");
            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Group name cannot be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var members = _userRepo.GetClubMembers(CurrentUser.ClubId.Value);
                if (members == null || !members.Any())
                {
                    MessageBox.Show("No members available in the club!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var selectWindow = new Window
                {
                    Title = "Create Group and Assign Members",
                    Width = 400,
                    Height = 500,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };

                var grid = new Grid { Margin = new Thickness(10) };
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

                var lblMembers = new Label { Content = "Select Members:", Style = (Style)FindResource("FormLabelStyle") };
                Grid.SetRow(lblMembers, 0);

                var membersListBox = new ListBox
                {
                    ItemsSource = members,
                    DisplayMemberPath = "FullName",
                    SelectionMode = SelectionMode.Multiple,
                    Style = (Style)FindResource("ListBoxStyle")
                };
                Grid.SetRow(membersListBox, 1);

                var lblLeader = new Label { Content = "Select Leader:", Style = (Style)FindResource("FormLabelStyle") };
                Grid.SetRow(lblLeader, 2);

                var leaderComboBox = new ComboBox
                {
                    DisplayMemberPath = "FullName",
                    Style = (Style)FindResource("FormInputStyle")
                };
                Grid.SetRow(leaderComboBox, 3);

                membersListBox.SelectionChanged += (s, args) =>
                {
                    var selectedMembers = membersListBox.SelectedItems.Cast<User>().ToList();
                    leaderComboBox.ItemsSource = selectedMembers;
                    if (selectedMembers.Any()) leaderComboBox.SelectedIndex = 0;
                };

                var confirmButton = new Button { Content = "Create Group", Style = (Style)FindResource("ConfirmButtonStyle") };
                bool isConfirmed = false;
                confirmButton.Click += (s, args) => { isConfirmed = true; selectWindow.Close(); };

                var cancelButton = new Button { Content = "Cancel", Style = (Style)FindResource("CancelButtonStyle") };
                cancelButton.Click += (s, args) => selectWindow.Close();

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                grid.Children.Add(lblMembers);
                grid.Children.Add(membersListBox);
                grid.Children.Add(lblLeader);
                grid.Children.Add(leaderComboBox);
                grid.Children.Add(confirmButton);
                grid.Children.Add(cancelButton);
                Grid.SetRow(confirmButton, 4);
                Grid.SetRow(cancelButton, 4);
                Grid.SetColumn(confirmButton, 0);
                Grid.SetColumn(cancelButton, 1);

                selectWindow.Content = grid;
                selectWindow.ShowDialog();

                if (!isConfirmed) return;

                var selectedMembers = membersListBox.SelectedItems.Cast<User>().ToList();
                if (!selectedMembers.Any())
                {
                    MessageBox.Show("Please select at least one member for the group!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var selectedLeader = leaderComboBox.SelectedItem as User;
                if (selectedLeader == null)
                {
                    MessageBox.Show("Please select a leader for the group!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newGroup = new Group
                {
                    GroupName = groupName,
                    ClubId = CurrentUser.ClubId.Value,
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    LeaderId = selectedLeader.UserId,
                    Status = "Active"
                };
                _groupRepo.CreateGroup(newGroup); // Tạo nhóm
                var memberIds = selectedMembers.Select(m => m.UserId).ToList();
                _groupRepo.AddMembersToGroup(newGroup.GroupId, memberIds); // Thêm thành viên vào nhóm

                // Đảm bảo làm mới dữ liệu từ cơ sở dữ liệu
                LoadGroups();
                MessageBox.Show($"Group '{groupName}' created successfully with {selectedLeader.FullName} as leader and {selectedMembers.Count} members!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AssignLeader_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int groupId)
            {
                var members = _groupRepo.GetGroupMembers(groupId);
                if (members == null || !members.Any())
                {
                    MessageBox.Show("No members available in the group!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var leaderWindow = new Window
                {
                    Title = "Assign Leader",
                    Width = 300,
                    Height = 200,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };

                var grid = new Grid { Margin = new Thickness(10) };
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

                var lblLeader = new Label { Content = "Select Leader:", Style = (Style)FindResource("FormLabelStyle") };
                Grid.SetRow(lblLeader, 0);

                var leaderComboBox = new ComboBox
                {
                    ItemsSource = members,
                    DisplayMemberPath = "FullName",
                    Style = (Style)FindResource("FormInputStyle")
                };
                Grid.SetRow(leaderComboBox, 1);

                var buttonPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                var confirmButton = new Button { Content = "Confirm", Style = (Style)FindResource("ConfirmButtonStyle") };
                var cancelButton = new Button { Content = "Cancel", Style = (Style)FindResource("CancelButtonStyle") };

                bool isConfirmed = false;
                confirmButton.Click += (s, args) =>
                {
                    isConfirmed = true;
                    leaderWindow.Close();
                };
                cancelButton.Click += (s, args) => leaderWindow.Close();

                buttonPanel.Children.Add(confirmButton);
                buttonPanel.Children.Add(cancelButton);
                Grid.SetRow(buttonPanel, 2);

                grid.Children.Add(lblLeader);
                grid.Children.Add(leaderComboBox);
                grid.Children.Add(buttonPanel);

                leaderWindow.Content = grid;
                leaderWindow.ShowDialog();

                if (!isConfirmed) return;

                var selectedLeader = leaderComboBox.SelectedItem as User;
                if (selectedLeader == null)
                {
                    MessageBox.Show("Please select a leader!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    _groupRepo.AssignLeaderToGroup(groupId, selectedLeader.UserId);
                    LoadGroups();
                    MessageBox.Show($"Leader {selectedLeader.FullName} assigned successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskNameTextBox.Text) || GroupComboBox.SelectedItem == null || DueDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please fill in all task details.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var selectedGroup = GroupComboBox.SelectedItem as Group;
                var newTask = new ClubTask
                {
                    TaskName = TaskNameTextBox.Text,
                    ClubId = CurrentUser.ClubId.Value,
                    GroupId = selectedGroup.GroupId,
                    AssignedBy = CurrentUser.UserId,
                    AssignedTo = GetAssignedToUserId(selectedGroup.GroupId),
                    DueDate = DueDatePicker.SelectedDate.HasValue ? DateOnly.FromDateTime(DueDatePicker.SelectedDate.Value) : null,
                    Status = "pending"
                };
                _taskRepo.CreateTask(newTask);
                MessageBox.Show("Task created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                TaskNameTextBox.Text = "Enter task name";
                GroupComboBox.SelectedItem = null;
                DueDatePicker.SelectedDate = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int GetAssignedToUserId(int groupId)
        {
            var members = _groupRepo.GetGroupMembers(groupId);
            if (members == null || !members.Any())
            {
                throw new Exception("No members found in the selected group to assign the task to.");
            }
            return members.First().UserId;
        }

        private void CreateEventButton_Click(object sender, RoutedEventArgs e)
        {
            var eventWindow = new Window
            {
                Title = "Create Event",
                Width = 300,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            var grid = new Grid { Margin = new Thickness(10) };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

            var lblEventName = new Label { Content = "Event Name:", Style = (Style)FindResource("FormLabelStyle") };
            Grid.SetRow(lblEventName, 0);

            var eventNameTextBox = new TextBox { Style = (Style)FindResource("FormInputStyle") };
            Grid.SetRow(eventNameTextBox, 1);

            var lblEventDate = new Label { Content = "Event Date:", Style = (Style)FindResource("FormLabelStyle") };
            Grid.SetRow(lblEventDate, 2);

            var eventDatePicker = new DatePicker { Style = (Style)FindResource("FormInputStyle") };
            Grid.SetRow(eventDatePicker, 3);

            var buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            var confirmButton = new Button { Content = "Create", Style = (Style)FindResource("ConfirmButtonStyle") };
            var cancelButton = new Button { Content = "Cancel", Style = (Style)FindResource("CancelButtonStyle") };

            bool isConfirmed = false;
            confirmButton.Click += (s, args) =>
            {
                if (string.IsNullOrEmpty(eventNameTextBox.Text) || eventDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                isConfirmed = true;
                eventWindow.Close();
            };
            cancelButton.Click += (s, args) => eventWindow.Close();

            buttonPanel.Children.Add(confirmButton);
            buttonPanel.Children.Add(cancelButton);
            Grid.SetRow(buttonPanel, 4);

            grid.Children.Add(lblEventName);
            grid.Children.Add(eventNameTextBox);
            grid.Children.Add(lblEventDate);
            grid.Children.Add(eventDatePicker);
            grid.Children.Add(buttonPanel);

            eventWindow.Content = grid;
            eventWindow.ShowDialog();

            if (!isConfirmed) return;

            try
            {
                var newEvent = new Event
                {
                    EventName = eventNameTextBox.Text,
                    ClubId = CurrentUser.ClubId.Value,
                    EventDate = DateOnly.FromDateTime(eventDatePicker.SelectedDate.Value),
                    Status = "Upcoming",
                    Location = "TBD",
                    Description = "New event"
                };
                _context.Events.Add(newEvent);
                _context.SaveChanges();
                LoadEvents();
                MessageBox.Show($"Event '{newEvent.EventName}' created successfully for {newEvent.EventDate}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditEvent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int eventId)
            {
                var eventToEdit = _context.Events.FirstOrDefault(e => e.EventId == eventId);
                if (eventToEdit == null) return;

                var editWindow = new Window
                {
                    Title = "Edit Event",
                    Width = 300,
                    Height = 200,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };

                var grid = new Grid { Margin = new Thickness(10) };
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

                var lblEventName = new Label { Content = "Event Name:", Style = (Style)FindResource("FormLabelStyle") };
                Grid.SetRow(lblEventName, 0);

                var eventNameTextBox = new TextBox
                {
                    Text = eventToEdit.EventName,
                    Style = (Style)FindResource("FormInputStyle")
                };
                Grid.SetRow(eventNameTextBox, 1);

                var lblEventDate = new Label { Content = "Event Date:", Style = (Style)FindResource("FormLabelStyle") };
                Grid.SetRow(lblEventDate, 2);

                var eventDatePicker = new DatePicker
                {
                    SelectedDate = eventToEdit.EventDate.HasValue ? eventToEdit.EventDate.Value.ToDateTime(new TimeOnly()) : null,
                    Style = (Style)FindResource("FormInputStyle")
                };
                Grid.SetRow(eventDatePicker, 3);

                var buttonPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                var confirmButton = new Button { Content = "Update", Style = (Style)FindResource("ConfirmButtonStyle") };
                var cancelButton = new Button { Content = "Cancel", Style = (Style)FindResource("CancelButtonStyle") };

                bool isConfirmed = false;
                confirmButton.Click += (s, args) =>
                {
                    if (string.IsNullOrEmpty(eventNameTextBox.Text) || eventDatePicker.SelectedDate == null)
                    {
                        MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    isConfirmed = true;
                    editWindow.Close();
                };
                cancelButton.Click += (s, args) => editWindow.Close();

                buttonPanel.Children.Add(confirmButton);
                buttonPanel.Children.Add(cancelButton);
                Grid.SetRow(buttonPanel, 4);

                grid.Children.Add(lblEventName);
                grid.Children.Add(eventNameTextBox);
                grid.Children.Add(lblEventDate);
                grid.Children.Add(eventDatePicker);
                grid.Children.Add(buttonPanel);

                editWindow.Content = grid;
                editWindow.ShowDialog();

                if (!isConfirmed) return;

                try
                {
                    eventToEdit.EventName = eventNameTextBox.Text;
                    eventToEdit.EventDate = DateOnly.FromDateTime(eventDatePicker.SelectedDate.Value);
                    _context.Events.Update(eventToEdit);
                    _context.SaveChanges();
                    LoadEvents();
                    MessageBox.Show("Event updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateGroupStatus_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int groupId)
            {
                var group = _context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                if (group == null) return;

                if (CurrentUser.RoleId != 3 && group.LeaderId != CurrentUser.UserId)
                {
                    MessageBox.Show("You do not have permission to update this group's status!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var statusWindow = new Window
                {
                    Title = "Update Group Status",
                    Width = 300,
                    Height = 150,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };

                var grid = new Grid { Margin = new Thickness(10) };
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

                var lblStatus = new Label { Content = "Select Status:", Style = (Style)FindResource("FormLabelStyle") };
                Grid.SetRow(lblStatus, 0);

                var statusComboBox = new ComboBox
                {
                    ItemsSource = new List<string> { "Active", "Inactive", "Completed" },
                    SelectedItem = group.Status,
                    Style = (Style)FindResource("FormInputStyle")
                };
                Grid.SetRow(statusComboBox, 1);

                var buttonPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                var confirmButton = new Button { Content = "Update", Style = (Style)FindResource("ConfirmButtonStyle") };
                var cancelButton = new Button { Content = "Cancel", Style = (Style)FindResource("CancelButtonStyle") };

                bool isConfirmed = false;
                confirmButton.Click += (s, args) =>
                {
                    isConfirmed = true;
                    statusWindow.Close();
                };
                cancelButton.Click += (s, args) => statusWindow.Close();

                buttonPanel.Children.Add(confirmButton);
                buttonPanel.Children.Add(cancelButton);
                Grid.SetRow(buttonPanel, 2);

                grid.Children.Add(lblStatus);
                grid.Children.Add(statusComboBox);
                grid.Children.Add(buttonPanel);

                statusWindow.Content = grid;
                statusWindow.ShowDialog();

                if (!isConfirmed) return;

                group.Status = statusComboBox.SelectedItem as string ?? group.Status;
                _context.Groups.Update(group);
                _context.SaveChanges(); // Đảm bảo lưu thay đổi vào cơ sở dữ liệu

                // Làm mới giao diện
                LoadGroups();
                MessageBox.Show($"Group status updated to {group.Status}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UpdateEventStatus_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int eventId)
            {
                var eventToEdit = _context.Events.FirstOrDefault(e => e.EventId == eventId);
                if (eventToEdit == null) return;

                if (CurrentUser.RoleId != 3 && CurrentUser.RoleId != 2)
                {
                    MessageBox.Show("You do not have permission to update this event's status!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var statusWindow = new Window
                {
                    Title = "Update Event Status",
                    Width = 300,
                    Height = 150,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };

                var grid = new Grid { Margin = new Thickness(10) };
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

                var lblStatus = new Label { Content = "Select Status:", Style = (Style)FindResource("FormLabelStyle") };
                Grid.SetRow(lblStatus, 0);

                var statusComboBox = new ComboBox
                {
                    ItemsSource = new List<string> { "Upcoming", "Ongoing", "Completed", "Cancelled" },
                    SelectedItem = eventToEdit.Status,
                    Style = (Style)FindResource("FormInputStyle")
                };
                Grid.SetRow(statusComboBox, 1);

                var buttonPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                var confirmButton = new Button { Content = "Update", Style = (Style)FindResource("ConfirmButtonStyle") };
                var cancelButton = new Button { Content = "Cancel", Style = (Style)FindResource("CancelButtonStyle") };

                bool isConfirmed = false;
                confirmButton.Click += (s, args) =>
                {
                    isConfirmed = true;
                    statusWindow.Close();
                };
                cancelButton.Click += (s, args) => statusWindow.Close();

                buttonPanel.Children.Add(confirmButton);
                buttonPanel.Children.Add(cancelButton);
                Grid.SetRow(buttonPanel, 2);

                grid.Children.Add(lblStatus);
                grid.Children.Add(statusComboBox);
                grid.Children.Add(buttonPanel);

                statusWindow.Content = grid;
                statusWindow.ShowDialog();

                if (!isConfirmed) return;

                eventToEdit.Status = statusComboBox.SelectedItem as string ?? eventToEdit.Status;
                _context.Events.Update(eventToEdit);
                _context.SaveChanges();

                LoadEvents();
                MessageBox.Show($"Event status updated to {eventToEdit.Status}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int eventId)
            {
                var result = MessageBox.Show("Are you sure you want to delete this event?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var eventToDelete = _context.Events.FirstOrDefault(e => e.EventId == eventId);
                        if (eventToDelete != null)
                        {
                            _context.Events.Remove(eventToDelete);
                            _context.SaveChanges();
                            LoadEvents();
                            MessageBox.Show("Event deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}