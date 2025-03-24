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
    }
}
