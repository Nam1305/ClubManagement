﻿using System;
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
using Microsoft.EntityFrameworkCore.Diagnostics;
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
            try
            {
                service = new ChairManService();
                Event ev = new Event();

                if (string.IsNullOrWhiteSpace(txtEventName.Text))
                {
                    throw new Exception("Event Name cannot be empty.");
                }
                ev.EventName = txtEventName.Text;

                if (cbStatus.SelectedItem == null)
                {
                    throw new Exception("Please select an event status.");
                }
                ev.Status = cbStatus.Text;

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    throw new Exception("Description cannot be empty.");
                }
                ev.Description = txtDescription.Text;

                if (dpdate.SelectedDate == null)
                {
                    throw new Exception("Event Date cannot be empty.");
                }
                ev.EventDate = DateOnly.FromDateTime(dpdate.SelectedDate.Value);

                if (string.IsNullOrWhiteSpace(txtLocation.Text))
                {
                    throw new Exception("Location cannot be empty.");
                }
                //ev.Location = txtLocation.Text;

                ev.ClubId = clubId;

                service.AddEvent(ev);
                GetAll();
                service.SendEmailToAllUsers(txtEventName.Text, dpdate.Text, txtLocation.Text , clubId);
                MessageBox.Show("Event Created & Notifications Sent!");
                MessageBox.Show("Event added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                service = new ChairManService();
                Event ev = new Event();

                if (string.IsNullOrWhiteSpace(txtEventId.Text))
                {
                    throw new Exception("Event ID cannot be empty.");
                }
                if (!int.TryParse(txtEventId.Text, out int eventId))
                {
                    throw new Exception("Event ID must be a number.");
                }
                ev.EventId = eventId;

                if (string.IsNullOrWhiteSpace(txtEventName.Text))
                {
                    throw new Exception("Event Name cannot be empty.");
                }
                ev.EventName = txtEventName.Text;

                if (cbStatus.SelectedItem == null)
                {
                    throw new Exception("Please select an event status.");
                }
                ev.Status = cbStatus.Text;

                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    throw new Exception("Description cannot be empty.");
                }
                ev.Description = txtDescription.Text;

                if (dpdate.SelectedDate == null)
                {
                    throw new Exception("Event Date cannot be empty.");
                }
                ev.EventDate = DateOnly.FromDateTime(dpdate.SelectedDate.Value);

                if (string.IsNullOrWhiteSpace(txtLocation.Text))
                {
                    throw new Exception("Location cannot be empty.");
                }
                //ev.Location = txtLocation.Text;

                ev.ClubId = clubId;

                service.UpdateEvent(ev);
                GetAll();

                MessageBox.Show("Event updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                //txtLocation.Text = ev.Location;
                txtClubId.Text = ev.ClubId.ToString();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this event?",
                                                          "Confirm Delete",
                                                          MessageBoxButton.YesNo,
                                                          MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                {
                    return; 
                }

                service = new ChairManService();
                Event ev = new Event();

                if (string.IsNullOrWhiteSpace(txtEventId.Text))
                {
                    throw new Exception("Event ID cannot be empty.");
                }
                if (!int.TryParse(txtEventId.Text, out int eventId))
                {
                    throw new Exception("Event ID must be a number.");
                }
                ev.EventId = eventId;

                service.DeleteEvent(ev);
                GetAll();

                MessageBox.Show("Event deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtSearchEvent_TextChanged(object sender, TextChangedEventArgs e)
        {
            service = new ChairManService();
            string search = txtSearchEvent.Text;
            //dgEvents.ItemsSource = service.SearchEvent(clubId, search);
        }
    }
}
