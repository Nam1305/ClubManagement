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
    /// Interaction logic for ViceChairmanhome.xaml
    /// </summary>
    public partial class Chairmanhome : Window
    {
        private readonly int userId;
        private readonly int? clubId;

        ChairManService ChairManService;
        public Chairmanhome() : this(0, null) // Truyền giá trị mặc định (0, null)
        {
        }


        public Chairmanhome(int userId, int? clubId)
        {
            InitializeComponent();
            this.userId = userId;
            this.clubId = clubId;
            GetAllUserByClubId(1);
        }
        void GetAllUserByClubId(int? ClubId)
        {
            ChairManService = new ChairManService();
            dgMembers.ItemsSource = ChairManService.GetUsers(ClubId);
        }



    }
}