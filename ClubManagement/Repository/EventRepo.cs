using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventRepo
    {
        private readonly ClubManagementContext context;

        public EventRepo()
        {
            context = new ClubManagementContext();
        }

        public List<Event> GetAvailableEventsForUser(int userId)
        {
            return context.Events
                .Where(e => e.Club.UserClubs.Any(uc => uc.UserId == userId))
                .Include(e => e.Club)
                .ToList();
        }




    }

}
