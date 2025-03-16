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
    /// Interaction logic for ChairmanReport.xaml
    /// </summary>
    public partial class ChairmanReport : Window
    {
        private readonly int userId;
        private readonly int clubId;

        ChairManService service;
        public ChairmanReport()
        {
        }

        public ChairmanReport(int userId, int clubId)
        {
            InitializeComponent();
            this.userId = userId;
            this.clubId = clubId;
            GetAll();
        }

        private void GetAll()
        {
            service = new ChairManService();
            dgReports.ItemsSource = service.Reports(clubId);
        }

        private void dgReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Report report = dgReports.SelectedItem as Report;
            if (report != null)
            {
                txtReportId.Text = report.ReportId.ToString();
                txtCreateDate.Text = report.CreatedDate.ToString();
                txtSemester.Text = report.Semester.ToString();
                txtMemberChanges.Text = report.MemberChanges.ToString();
                txtEventSummary.Text = report.EventSummary;
                txtParticipationStatus.Text = report?.ParticipationStatus;
                txtClubId.Text = report.ClubId.ToString();
            }
        }
    }
}
