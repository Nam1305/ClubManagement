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

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for ViceChairmanhome.xaml
    /// </summary>
    public partial class Chairmanhome : Window
    {
        private readonly int userId;

        public Chairmanhome(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
    }
}