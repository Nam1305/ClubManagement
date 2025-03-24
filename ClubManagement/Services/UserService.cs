using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;

namespace Services
{
    public class UserService
    {
        UserRepo userRepo;
        ClubRepo clubRepo;
        EventParticipantRepo eventParticipantRepo;
        EventRepo eventRepo;
        public UserService()
        {
            userRepo = new UserRepo();
            clubRepo = new ClubRepo();
            eventParticipantRepo = new EventParticipantRepo();
            eventRepo = new EventRepo();
        }

        public User GetUserByUserId(int userId)
        {
            return userRepo.GetUserByUserId(userId);
        }

        public bool UpdateMemberInformation(User user)
        {
            return userRepo.UpdateMember(user);
        }

        public List<Club> SearchClubByName(string name)
        {
            return clubRepo.SearchClubByName(name);
        }

        public bool JoinClub(int userId, int clubId)
        {
            return userRepo.JoinClub(userId, clubId);
        }

        public List<UserClub> GetClubJoinedByUserId(int userId)
        {
            return userRepo.GetAllClubJoinedByUserId(userId);
        }

        public List<UserClub> GetClubApprovingByUserId(int userId)
        {
            return userRepo.GetAllClubApprovingByUserId(userId);
        }

        public List<UserClub> SearchUserClub(int userId, string name)
        {
            return userRepo.SearchUserClub(userId, name);
        }

        public List<EventParticipant> GetAllEventsJoined(int userId)
        {
            return eventParticipantRepo.GetEventsParticipant(userId);
        }



    }
}
