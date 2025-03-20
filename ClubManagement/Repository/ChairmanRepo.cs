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
                .Where(x => x.UserClubs.Any(uc => uc.ClubId == clubId && (x.Role.RoleId == 3 || x.Role.RoleId == 4 || x.Role.RoleId == 5)))
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

                    //AppliedAt = user.UserClubs.FirstOrDefault().AppliedAt.ToDateTime(TimeOnly.MinValue),
                    //ApprovedAt = user.UserClubs.FirstOrDefault().ApprovedAt

                })
                .ToList(); 
        }

        public List<UserDTO> GetViceChairmanAndTeamLeader(int? clubId)
        {
            return clubManagementContext.Users
                .Include(x => x.Role)
                .Include(x => x.UserClubs).ThenInclude(x => x.Club)
                .Where(x => x.UserClubs.Any(uc => uc.ClubId == clubId && (x.Role.RoleId == 3 || x.Role.RoleId == 4)))
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

                    //AppliedAt = user.UserClubs.FirstOrDefault().AppliedAt.ToDateTime(TimeOnly.MinValue),
                    //ApprovedAt = user.UserClubs.FirstOrDefault().ApprovedAt

                })
                .ToList();
        }

        public List<UserDTO> SearchUsers(int? clubId , string txt)
        {
            return clubManagementContext.Users
                .Include(x => x.Role)
                .Include(x => x.UserClubs).ThenInclude(x => x.Club)
                .Where(x => x.UserClubs.Any(uc => uc.ClubId == clubId && (x.Role.RoleId == 3 || x.Role.RoleId == 4 || x.Role.RoleId == 5) && (x.FullName.Contains(txt)
                || x.StudentNumber.Contains(txt)))) // Chỉ lấy user thuộc club đó
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

                    //AppliedAt = user.UserClubs.FirstOrDefault().AppliedAt.,
                    //ApprovedAt = user.UserClubs.FirstOrDefault().ApprovedAt

                })
                .ToList(); 
        }



        public void AddUser(User user , int clubId)
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

        public void DeleteUser(int userId)
        {
            // Xóa tất cả các bản ghi UserClub liên quan trước
            UserClub userClubs = clubManagementContext.UserClubs
                .Where(uc => uc.UserId == userId).FirstOrDefault();
            User user = clubManagementContext.Users
                .Where(uc => uc.UserId == userId).FirstOrDefault();
            user.RoleId = 5;
            clubManagementContext.UserClubs.RemoveRange(userClubs);
            clubManagementContext.Users.Update(user);
            clubManagementContext.SaveChanges(); 

           
        }

        public List<ClubTask> GetAllTask(int clubId)
        {
            return clubManagementContext.ClubTasks.Where(x => x.ClubId == clubId).ToList();
        }

        public void AddTask(ClubTask ct)
        {
            clubManagementContext.ClubTasks.Add(ct);
            clubManagementContext.SaveChanges();
        }

        public void UpdateTask(ClubTask ct)
        {
            if (ct != null)
            {
                clubManagementContext.ClubTasks.Update(ct);
                clubManagementContext.SaveChanges();
            }
        }

        public void DeleteTask(ClubTask ct)
        {
            //ClubTask find = clubManagementContext.ClubTasks.Where(x => x.TaskId == ct.TaskId).FirstOrDefault();
            if (ct != null)
            {
                clubManagementContext.ClubTasks.Remove(ct);
                clubManagementContext.SaveChanges();
            }
        }

        public List<Event> GetAllEvents(int clubId)
        {
            return clubManagementContext.Events.Where(x => x.ClubId == clubId).ToList();
        }

        public List<Event> SearchEvents(int clubId , string txt)
        {
            return clubManagementContext.Events.Where(x => x.ClubId == clubId && (x.EventName.Contains(txt) || x.Location.Contains(txt))).ToList();
        }

        public void AddEvent(Event e)
        {
            clubManagementContext.Events.Add(e);
            clubManagementContext.SaveChanges();
        }

        public void UpdateEvent(Event e) { 
            clubManagementContext.Events.Update(e);
            clubManagementContext.SaveChanges();
        }

        public void DeleteEvent(Event e)
        {
            clubManagementContext.Events.Remove(e);
            clubManagementContext.SaveChanges();
        }

        public List<Report> GetAllReport(int clubId) { 
            return clubManagementContext.Reports.Where(x => x.ClubId==clubId).ToList();
        }

        public List<UserClub> GetAllUserClub(int clubId)
        {
            return clubManagementContext.UserClubs.Include(x => x.User).Include(x => x.Club).Where(x => x.ClubId == clubId).ToList();
        }

        public void UpdateStatus(UserClub uc)
        {

            clubManagementContext.UserClubs.Update(uc);
            clubManagementContext.SaveChanges();
        }
    }
}
