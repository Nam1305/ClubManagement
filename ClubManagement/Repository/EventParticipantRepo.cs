using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventParticipantRepo
    {
        public EventParticipantRepo()
        {
            context = new ClubManagementContext();
        }
        private readonly ClubManagementContext context;
        public List<EventParticipant> GetEventsParticipant(int userId)
        {
            return context.EventParticipants
                .Where(ep => ep.UserId == userId)
                .Include(ep => ep.Event)
                .ThenInclude(ep => ep.Club)
                .ToList();
        }

        public bool RegisterUserForEvent(int userId, int eventId)
        {
            var existingRegistration = context.EventParticipants
                .FirstOrDefault(ep => ep.UserId == userId && ep.EventId == eventId);

            if (existingRegistration == null)
            {
                var newParticipant = new EventParticipant
                {
                    UserId = userId,
                    EventId = eventId,
                    Status = "Đã đăng kí"
                };
                context.EventParticipants.Add(newParticipant);
            }

            else
            {
                // Nếu đã đăng ký rồi thì không làm gì cả, trả về false
                return false;
            }

            context.SaveChanges();
            return true;



        }
    }
}
