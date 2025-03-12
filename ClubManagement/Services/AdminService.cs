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

        public AdminService()
        {
            userRepo = new UserRepo();
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


        //Het code cua Pham Hoang Nam
    }
}
