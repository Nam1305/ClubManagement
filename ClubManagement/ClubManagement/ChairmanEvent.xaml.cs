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
using Microsoft.VisualBasic;
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for ChairmanEvent.xaml
    /// </summary>
    public partial class ChairmanEvent : Window
    {
        private readonly int clubId;
        private readonly int userId;
        ChairManService service;
        public ChairmanEvent()
        {
        }

        public ChairmanEvent(int userId , int clubId)
        {
            InitializeComponent();
            this.clubId = clubId;
            this.userId = userId;
            GetAll();
        }

        private void GetAll()
        {
            service = new ChairManService();
            dgEvents.ItemsSource = service.GetAllEvent(clubId);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            service = new ChairManService();
            Event ev = new Event();
            ev.EventName = txtEventName.Text;
            ev.Status = cbStatus.Text;
            ev.Description = txtDescription.Text;
            ev.EventDate = DateOnly.FromDateTime(dpdate.SelectedDate.Value);
            ev.Location = txtLocation.Text;
            ev.ClubId = clubId;

            service.AddEvent(ev);
            GetAll();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            service = new ChairManService();
            Event ev = new Event();
            ev.EventId = Int32.Parse(txtEventId.Text);
            ev.EventName = txtEventName.Text;
            ev.Status = cbStatus.Text;
            ev.Description = txtDescription.Text;
            ev.EventDate = DateOnly.FromDateTime(dpdate.SelectedDate.Value);
            ev.Location = txtLocation.Text;
            ev.ClubId = clubId;
            service.UpdateEvent(ev);
            GetAll();
        }



        private void dgEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Event ev = dgEvents.SelectedItem as Event;
            if (ev != null) { 
                txtEventId.Text = ev.EventId.ToString();
                txtEventName.Text = ev.EventName;
                cbStatus.Text = ev.Status;
                txtDescription.Text = ev.Description;
                dpdate.Text = ev.EventDate.ToString();
                txtLocation.Text = ev.Location;
                txtClubId.Text = ev.ClubId.ToString();
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
                service = new ChairManService();
                Event ev = new Event();
                ev.EventId = Int32.Parse(txtEventId.Text);
                ev.EventName = txtEventName.Text;
                ev.Status = cbStatus.Text;
                ev.Description = txtDescription.Text;
                ev.EventDate = DateOnly.FromDateTime(dpdate.SelectedDate.Value);
                ev.Location = txtLocation.Text;
                ev.ClubId = clubId;
                service.DeleteEvent(ev);
                GetAll();
            }
        }
    }
}
