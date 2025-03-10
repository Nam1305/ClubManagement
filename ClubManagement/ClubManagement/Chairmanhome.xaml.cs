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
    /// Interaction logic for Chairmanhome.xaml
    /// </summary>
    public partial class Chairmanhome : Window
    {
        ChairManService ChairManService;
        public Chairmanhome()
        {
            InitializeComponent();
            LoadComboboxRole();
            DisplayMember();
        }

        public void DisplayMember()
        {
            ChairManService = new ChairManService();
            dgMembers.ItemsSource = ChairManService.GetUsers();

        }

        public void LoadComboboxRole()
        {
            ChairManService = new ChairManService();
            cbRole.ItemsSource = ChairManService.GetAllRoles();
            this.cbRole.DisplayMemberPath = "RoleName";
            this.cbRole.SelectedValuePath = "RoleId";
            this.cbRole.SelectedIndex = 0;
        }

        private void dgMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = dgMembers.SelectedItem as User;
            if(user != null)
            {
                txtFullname.Text = user.FullName;
                txtEmail.Text = user.Email;
                cbRole.SelectedValue = user.Role;
                txtStudentNumber.Text = user.StudentNumber; 
                txtUsername.Text = user.Username;
            }
        }
    }
}
