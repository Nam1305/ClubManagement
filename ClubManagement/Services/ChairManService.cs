using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;
using Repository.DTO;

namespace Services
{
    public class ChairManService
    {
        ChairmanRepo repo;

        public ChairManService()
        {
            repo = new ChairmanRepo();
        }

        public List<UserDTO> GetUsers(int clubId) {
            return repo.GetUsers(clubId);
        }

        public void AddUser(User user , int clubId) { 
            repo.AddUser(user , clubId);
        }

        public void UpdateUser(User user, int? clubId) {
            repo.UpdateUser(user , clubId);
        }
        public void DeleteUser(int userId ) { 
            repo.DeleteUser(userId);
        }

        public void AddTask(ClubTask ct) {
            repo.AddTask(ct);
        }

        public List<ClubTask> GetMissions(int clubId) {
            return repo.GetAllTask(clubId);
        }

        public void UpdateTask(ClubTask ct)
        {
            repo.UpdateTask(ct);
        }

        public void DeleteTask(ClubTask ct)
        {
            repo.DeleteTask(ct);
        }

        public void AddEvent(Event e)
        {
            repo.AddEvent(e);
        }

        public List<Event> GetAllEvent(int clubId)
        {
            return repo.GetAllEvents(clubId);
        }

        public void UpdateEvent(Event e) { 
            repo.UpdateEvent(e);
        }

        public void DeleteEvent(Event e)
        {
            repo.DeleteEvent(e);
        }

        public List<Report> Reports(int clubId) { 
            return repo.GetAllReport(clubId);
        }

        public List<UserClub> UserClubs(int clubId)
        {
            return repo.GetAllUserClub(clubId);
        }
    }
}
