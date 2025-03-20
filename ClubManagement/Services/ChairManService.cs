using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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

        public List<UserDTO> GetViceChairmanAndTeamLeader(int clubId)
        {
            return repo.GetViceChairmanAndTeamLeader(clubId);
        }

        public List<UserDTO> SearchUser(int clubId , string txt)
        {
            return repo.SearchUsers(clubId,txt);
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

        public List<Event> SearchEvent(int clubId , string txt)
        {
            return repo.SearchEvents(clubId , txt);
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

        public void UpdateUserClub(UserClub club)
        {
            repo.UpdateStatus(club);
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Credentials = new NetworkCredential("thangditto2231977@gmail.com", "seww dcst gqnl phyg");
                client.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("thangditto2231977@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                client.Send(mail);
            }
        }

        public void SendEmailToAllUsers(string eventName, string eventDate, string location , int clubId)
        {
            List<string> emails = repo.GetEmailByClubId(clubId);
            string subject = "New Event: " + eventName;
            string body = $"Dear Member,\n\nWe have a new event: {eventName}.\nDate: {eventDate}\nLocation: {location}\n\nBest regards,\nClub Management.";

            foreach (var email in emails)
            {
                SendEmail(email, subject, body);
            }
        }
    }
}
