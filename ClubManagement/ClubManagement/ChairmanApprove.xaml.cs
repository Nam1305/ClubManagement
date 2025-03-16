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
using Services;

namespace ClubManagement
{
    /// <summary>
    /// Interaction logic for ChairmanApprove.xaml
    /// </summary>
    public partial class ChairmanApprove : Window
    {
        private readonly int userId;
        private readonly int clubId;
        ChairManService service;
        public ChairmanApprove()
        {
        }


        public ChairmanApprove(int userId , int clubId)
        {
            InitializeComponent();
            this.userId = userId;
            this.clubId = clubId;
            GetAll();
        }

        public void GetAll()
        {
            service = new ChairManService();
            this.dgApprove.ItemsSource = service.UserClubs(clubId);
        }

    }
}
