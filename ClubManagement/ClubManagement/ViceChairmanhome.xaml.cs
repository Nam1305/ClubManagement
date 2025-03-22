using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Repository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Windows.Data;
using ClosedXML.Excel;
using Repository.DTO;

namespace ClubManagement
{
    public partial class ViceChairmanhome : Window
    {
        private readonly GroupRepo _groupRepo;
        private readonly UserRepo _userRepo;
        private readonly TaskRepository _taskRepo;
        private readonly ReportRepo _reportRepo;
        private readonly ClubManagementContext _context;
        private readonly MemberService _memberService;
        private readonly ReportService _reportService;

        public ViceChairmanhome()
        {
            InitializeComponent();
            _groupRepo = new GroupRepo();
            _userRepo = new UserRepo();
            _taskRepo = new TaskRepository();
            _reportRepo = new ReportRepo();
            _context = new ClubManagementContext();
            _memberService = new MemberService();
            _reportService = new ReportService();

            if (CurrentUser.RoleId != 3 || !CurrentUser.ClubId.HasValue)
            {
                MessageBox.Show("You do not have permission or are not assigned to a club.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
                return;
            }

            LoadGroups();
            LoadEvents();
            LoadTerms();
            LoadMembers(TermComboBox.SelectedItem?.ToString() ?? "Fall" + DateTime.Now.Year);
            LoadReports();
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

        private void LoadTerms()
        {
            var terms = new List<string>();
            int currentYear = DateTime.Now.Year;
            string[] seasons = { "Spring", "Summer", "Fall" };

            for (int year = currentYear; year >= currentYear - 2; year--)
            {
                foreach (var season in seasons)
                {
                    terms.Add($"{season}{year}");
                }
            }

            TermComboBox.ItemsSource = terms;
            TermComboBox.SelectedIndex = 0;
        }

        private void LoadMembers(string term)
        {
            var memberData = _memberService.GetClubMembersWithParticipation(CurrentUser.ClubId.Value, term);
            MembersListView.ItemsSource = memberData;
        }

        private void LoadReports()
        {
            var reports = _reportRepo.GetReportsByClubId(CurrentUser.ClubId.Value);
            ReportsListView.ItemsSource = reports;
        }

        private void ExportToExcelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MembersListView.Items.Count == 0)
                {
                    MessageBox.Show("No data to export!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Members");

                    // Thêm tiêu đề cột
                    worksheet.Cell(1, 1).Value = "Full Name";
                    worksheet.Cell(1, 2).Value = "Student Number";
                    worksheet.Cell(1, 3).Value = "Email";
                    worksheet.Cell(1, 4).Value = "Participation (%)";
                    worksheet.Cell(1, 5).Value = "Activity Level";

                    // Định dạng tiêu đề
                    var headerRange = worksheet.Range("A1:E1");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                    // Thêm dữ liệu từ MembersListView
                    var members = MembersListView.Items.Cast<MemberParticipationDto>().ToList();
                    for (int i = 0; i < members.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = members[i].FullName;
                        worksheet.Cell(i + 2, 2).Value = members[i].StudentNumber;
                        worksheet.Cell(i + 2, 3).Value = members[i].Email;
                        worksheet.Cell(i + 2, 4).Value = members[i].ParticipationPercentage;
                        worksheet.Cell(i + 2, 5).Value = members[i].ActivityLevel;
                    }

                    // Tự động điều chỉnh độ rộng cột
                    worksheet.Columns().AdjustToContents();

                    // Lưu file Excel
                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                        FileName = $"Members_{TermComboBox.SelectedItem}_{DateTime.Now:yyyyMMdd}.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Exported to Excel successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateReportButton_Click(object sender, RoutedEventArgs e)
        {
            var reportWindow = new Window
            {
                Title = "Create Report",
                Width = 300,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            var grid = new Grid { Margin = new Thickness(10) };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

            var lblSemester = new Label { Content = "Select Semester Start Date:", Style = (Style)FindResource("FormLabelStyle") };
            Grid.SetRow(lblSemester, 0);

            var semesterDatePicker = new DatePicker { Style = (Style)FindResource("FormInputStyle") };
            Grid.SetRow(semesterDatePicker, 1);

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
                if (semesterDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Please select a semester start date!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                isConfirmed = true;
                reportWindow.Close();
            };
            cancelButton.Click += (s, args) => reportWindow.Close();

            buttonPanel.Children.Add(confirmButton);
            buttonPanel.Children.Add(cancelButton);
            Grid.SetRow(buttonPanel, 2);

            grid.Children.Add(lblSemester);
            grid.Children.Add(semesterDatePicker);
            grid.Children.Add(buttonPanel);

            reportWindow.Content = grid;
            reportWindow.ShowDialog();

            if (!isConfirmed) return;

            try
            {
                var semesterStart = semesterDatePicker.SelectedDate.Value;
                var semesterEnd = semesterStart.AddMonths(4); // Giả sử mỗi kỳ kéo dài 4 tháng

                // Tính toán thay đổi thành viên dưới dạng văn bản
                string memberChanges = _reportService.CalculateMemberChanges(CurrentUser.ClubId.Value, semesterStart, semesterEnd);

                // Tạo nội dung báo cáo cho cột eventSummary
                string eventSummary = _reportService.GenerateReportContent(CurrentUser.ClubId.Value, semesterStart, semesterEnd);

                // Tạo báo cáo mới
                var newReport = new Report
                {
                    CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                    Semester = DateOnly.FromDateTime(semesterStart),
                    MemberChanges = memberChanges, // Lưu dạng văn bản
                    EventSummary = eventSummary,
                    ParticipationStatus = "Pending",
                    ClubId = CurrentUser.ClubId.Value
                };

                _reportRepo.CreateReport(newReport);
                LoadReports();
                MessageBox.Show("Report created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating report: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportReportToExcel_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int reportId)
            {
                var report = _reportRepo.GetReportById(reportId);
                if (report == null)
                {
                    MessageBox.Show("Report not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Report");

                        // Thêm tiêu đề báo cáo
                        worksheet.Cell(1, 1).Value = "Club Report";
                        worksheet.Range("A1:D1").Merge();
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Thêm thông tin báo cáo
                        worksheet.Cell(3, 1).Value = "Report ID";
                        worksheet.Cell(3, 2).Value = report.ReportId;
                        worksheet.Cell(4, 1).Value = "Created Date";
                        worksheet.Cell(4, 2).Value = report.CreatedDate.ToString("dd/MM/yyyy");
                        worksheet.Cell(5, 1).Value = "Semester";
                        worksheet.Cell(5, 2).Value = report.Semester.ToString("dd/MM/yyyy");
                        worksheet.Cell(6, 1).Value = "Member Changes";
                        worksheet.Cell(6, 2).Value = report.MemberChanges; // Hiển thị dạng văn bản
                        worksheet.Cell(7, 1).Value = "Event Summary";
                        worksheet.Cell(7, 2).Value = report.EventSummary;
                        worksheet.Cell(8, 1).Value = "Status";
                        worksheet.Cell(8, 2).Value = report.ParticipationStatus;

                        // Định dạng tiêu đề cột
                        var headerRange = worksheet.Range("A3:A8");
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                        // Tự động điều chỉnh độ rộng cột
                        worksheet.Columns().AdjustToContents();

                        // Lưu file Excel
                        var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                        {
                            Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                            FileName = $"Report_{reportId}_{DateTime.Now:yyyyMMdd}.xlsx"
                        };

                        if (saveFileDialog.ShowDialog() == true)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Report exported to Excel successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting report to Excel: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RefreshReportsButton_Click(object sender, RoutedEventArgs e)
        {
            LoadReports();
        }

        private void TermComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TermComboBox.SelectedItem != null)
            {
                string selectedTerm = TermComboBox.SelectedItem.ToString();
                LoadMembers(selectedTerm);
            }
        }

        private void RefreshMembersButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedTerm = TermComboBox.SelectedItem?.ToString() ?? "Fall" + DateTime.Now.Year;
            LoadMembers(selectedTerm);
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
                var events = _context.Events.Where(e => e.ClubId == CurrentUser.ClubId.Value).ToList();
                if (events == null || !events.Any())
                {
                    MessageBox.Show("No events available in the club!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

                var lblEvent = new Label { Content = "Select Event:", VerticalAlignment = VerticalAlignment.Center };
                Grid.SetRow(lblEvent, 0);
                var eventComboBox = new ComboBox
                {
                    ItemsSource = events,
                    DisplayMemberPath = "EventName"
                };
                Grid.SetRow(eventComboBox, 1);

                var lblMembers = new Label { Content = "Select Members:", VerticalAlignment = VerticalAlignment.Center };
                Grid.SetRow(lblMembers, 2);
                var membersListBox = new ListBox
                {
                    SelectionMode = SelectionMode.Multiple,
                    Height = 150
                };
                Grid.SetRow(membersListBox, 3);

                eventComboBox.SelectionChanged += (s, args) =>
                {
                    if (eventComboBox.SelectedItem is Event selectedEvent)
                    {
                        var participants = _context.EventParticipants
                            .Where(ep => ep.EventId == selectedEvent.EventId)
                            .Include(ep => ep.User)
                            .Select(ep => ep.User)
                            .ToList();
                        if (!participants.Any())
                        {
                            MessageBox.Show("No participants registered for this event!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            membersListBox.ItemsSource = null;
                            return;
                        }
                        membersListBox.ItemsSource = participants;
                        membersListBox.DisplayMemberPath = "FullName";
                    }
                    else
                    {
                        membersListBox.ItemsSource = null;
                    }
                };

                var confirmButton = new Button { Content = "Create Group", Width = 100, Background = System.Windows.Media.Brushes.Green, Foreground = System.Windows.Media.Brushes.White };
                bool isConfirmed = false;
                confirmButton.Click += (s, args) =>
                {
                    if (eventComboBox.SelectedItem == null || !membersListBox.SelectedItems.Cast<User>().Any())
                    {
                        MessageBox.Show("Please select an event and at least one member!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    isConfirmed = true;
                    selectWindow.Close();
                };

                var cancelButton = new Button { Content = "Cancel", Width = 100, Background = System.Windows.Media.Brushes.Red, Foreground = System.Windows.Media.Brushes.White };
                cancelButton.Click += (s, args) => selectWindow.Close();

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                grid.Children.Add(lblEvent);
                grid.Children.Add(eventComboBox);
                grid.Children.Add(lblMembers);
                grid.Children.Add(membersListBox);
                grid.Children.Add(confirmButton);
                grid.Children.Add(cancelButton);
                Grid.SetRow(confirmButton, 4);
                Grid.SetRow(cancelButton, 4);
                Grid.SetColumn(confirmButton, 0);
                Grid.SetColumn(cancelButton, 1);

                selectWindow.Content = grid;
                selectWindow.ShowDialog();

                if (!isConfirmed) return;

                var selectedEvent = eventComboBox.SelectedItem as Event;
                var selectedMembers = membersListBox.SelectedItems.Cast<User>().ToList();

                var newGroup = new Group
                {
                    GroupName = groupName,
                    ClubId = CurrentUser.ClubId.Value,
                    EventId = selectedEvent.EventId,
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    LeaderId = null,
                    Status = "Active"
                };
                _groupRepo.CreateGroup(newGroup);
                var memberIds = selectedMembers.Select(m => m.UserId).ToList();
                _groupRepo.AddMembersToGroup(newGroup.GroupId, memberIds);

                AssignLeaderAfterCreation(newGroup.GroupId, selectedMembers);
                LoadGroups();
                MessageBox.Show($"Group '{groupName}' created successfully for event '{selectedEvent.EventName}' with {selectedMembers.Count} members! Leader assigned.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AssignLeaderAfterCreation(int groupId, List<User> members)
        {
            var leaderWindow = new Window
            {
                Title = "Assign Leader to Group",
                Width = 300,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            var grid = new Grid { Margin = new Thickness(10) };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

            var lblLeader = new Label { Content = "Select Leader:", VerticalAlignment = VerticalAlignment.Center };
            Grid.SetRow(lblLeader, 0);

            var leaderComboBox = new ComboBox
            {
                ItemsSource = members,
                DisplayMemberPath = "FullName",
                SelectedIndex = 0
            };
            Grid.SetRow(leaderComboBox, 1);

            var buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            var confirmButton = new Button { Content = "Confirm", Width = 100, Background = System.Windows.Media.Brushes.Green, Foreground = System.Windows.Media.Brushes.White };
            var cancelButton = new Button { Content = "Cancel", Width = 100, Background = System.Windows.Media.Brushes.Red, Foreground = System.Windows.Media.Brushes.White };

            bool isConfirmed = false;
            confirmButton.Click += (s, args) =>
            {
                if (leaderComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a leader!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
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
            if (selectedLeader != null)
            {
                try
                {
                    var group = _context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                    if (group != null)
                    {
                        group.LeaderId = selectedLeader.UserId;
                        _context.Groups.Update(group);

                        if (selectedLeader.RoleId != 4)
                        {
                            selectedLeader.RoleId = 4;
                            _context.Users.Update(selectedLeader);
                        }
                        _context.SaveChanges();
                        MessageBox.Show($"Leader {selectedLeader.FullName} assigned successfully and promoted to Team Leader!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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

        private void ViewGroupMembers_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int groupId)
            {
                var members = _groupRepo.GetGroupMembers(groupId);
                if (members == null || !members.Any())
                {
                    MessageBox.Show("No members in this group!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var memberWindow = new Window
                {
                    Title = "Group Members",
                    Width = 400,
                    Height = 300,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };

                var listView = new ListView
                {
                    Margin = new Thickness(10),
                    ItemsSource = members
                };
                listView.View = new GridView
                {
                    Columns =
                    {
                        new GridViewColumn { Header = "Full Name", DisplayMemberBinding = new Binding("FullName"), Width = 150 },
                        new GridViewColumn { Header = "Student Number", DisplayMemberBinding = new Binding("StudentNumber"), Width = 120 }
                    }
                };

                memberWindow.Content = listView;
                memberWindow.ShowDialog();
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

        private void ViewParticipants_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int eventId)
            {
                var participants = _groupRepo.GetEventParticipants(eventId);
                if (participants == null || !participants.Any())
                {
                    MessageBox.Show("No participants in this event!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var participantWindow = new Window
                {
                    Title = "Event Participants",
                    Width = 400,
                    Height = 300,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };

                var listView = new ListView
                {
                    Margin = new Thickness(10),
                    ItemsSource = participants
                };
                listView.View = new GridView
                {
                    Columns =
                    {
                        new GridViewColumn { Header = "Full Name", DisplayMemberBinding = new Binding("FullName"), Width = 150 },
                        new GridViewColumn { Header = "Student Number", DisplayMemberBinding = new Binding("StudentNumber"), Width = 120 }
                    }
                };

                participantWindow.Content = listView;
                participantWindow.ShowDialog();
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
                _context.SaveChanges();

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

        protected override void OnClosed(EventArgs e)
        {
            _context.Dispose();
            base.OnClosed(e);
        }
    }
}