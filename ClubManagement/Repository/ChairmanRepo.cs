using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DTO;

namespace Repository
{
    public class ChairmanRepo
    {
        ClubManagementContext clubManagementContext;
        public ChairmanRepo() {
           clubManagementContext  = new ClubManagementContext();
        }

        public List<UserDTO> GetUsers(int? clubId)
        {
            return clubManagementContext.Users
                .Include(x => x.Role)
                .Include(x => x.UserClubs).ThenInclude(x => x.Club)
                .Where(x => x.UserClubs.Any(uc => uc.ClubId == clubId && (x.Role.RoleId == 3 || x.Role.RoleId == 4 || x.Role.RoleId == 5))) // Chỉ lấy user thuộc club đó
                .Select(user => new UserDTO
                {
                    UserId = user.UserId,
                    FullName = user.FullName,
                    Email = user.Email,
                    RoleName = user.Role != null ? user.Role.RoleName : "No Role",
                    StudentNumber = user.StudentNumber,
                    Username = user.Username,
                    Status = user.Status,
                    ClubName = user.UserClubs.FirstOrDefault().Club.ClubName,
                    
                    //AppliedAt = user.UserClubs.FirstOrDefault().AppliedAt,
                    //ApprovedAt = user.UserClubs.FirstOrDefault().ApprovedAt
                })
                .ToList(); // Trả về danh sách UserDTO
        }


        public void AddUser(User user , int? clubId)
        {
            clubManagementContext.Users.Add(user);
            clubManagementContext.SaveChanges();

            UserClub userClub = new UserClub
            {
                UserId = user.UserId,
                ClubId = clubId
            };

            clubManagementContext.UserClubs.Add(userClub);
            clubManagementContext.SaveChanges();

        }

        public void UpdateUser(User user , int? clubId)
        {
            clubManagementContext.Users.Update(user);
            clubManagementContext.SaveChanges();

            //UserClub userClub = new UserClub
            //{
            //    UserId = user.UserId,
            //    ClubId = clubId,
            //};
            //clubManagementContext.UserClubs.Update(userClub);
            //clubManagementContext.SaveChanges();
        }

    }
}
