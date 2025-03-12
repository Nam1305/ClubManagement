using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;

namespace Services
{
    public class AdminService
    {
        UserRepo userRepo;
        ClubRepo clubRepo;

        public AdminService()
        {
            userRepo = new UserRepo();
            clubRepo = new ClubRepo();
        }

        public List<User> LoadDataGridUser()
        {
            return userRepo.GetAllUsers();    
        }

        public List<User> SearchUserByStudentNumber(string studentNumber)
        {
            return userRepo.SearchByStudentNumber(studentNumber);
        }

        public List<User> SearchUserByFullName(string fullName)
        {
            return userRepo.SearchByFullName(fullName);
        }

        public List<User> SearchUserByEmail(string email)
        {
            return userRepo.SearchByEmail(email);
        }

        public List<User> SearchUserByUserName(string userName)
        {
            return userRepo.SearchByUserName(userName);
        }

        public bool AddNewUser(User user)
        {
            return userRepo.AddNewUser(user);
        }

        public bool UpdateUser(User user) 
        {
            return userRepo.UpdateUser(user);

        }

        public bool DeleteUser(string studentNumber) 
        {
            return userRepo.DeleteUser(studentNumber);
        }

        public List<User> GetUsersByCbRoleChanged(int roleId) 
        {
            return userRepo.GetUserByCbRoleChanged(roleId);
        }

        public List<Club> LoadDataGridClub()
        {
            return clubRepo.GetAllClub();
        }

        public List<Club> SearchClubByName(string clubName)
        {
            return clubRepo.SearchClubByName(clubName);
        }

        public bool AddNewClub(Club club)
        {
            return clubRepo.AddNewClub(club);
        }

        public bool UpdateClub(Club club)
        {
            return clubRepo.UpdateClub(club);

        }

        public bool DeleteClub(int clubId)
        {
            return clubRepo.DeleteClub(clubId);
        }
        //Het code cua Pham Hoang Nam
    }
}
