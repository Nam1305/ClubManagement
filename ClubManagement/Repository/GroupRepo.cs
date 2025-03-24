using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class GroupRepo
    {
        private readonly ClubManagementContext _context;

        public GroupRepo()
        {
            _context = new ClubManagementContext();
        }

        public List<User> GetEventParticipants(int eventId)
        {
            using (var context = new ClubManagementContext())
            {
                return context.EventParticipants
                    .Where(ep => ep.EventId == eventId)
                    .Select(ep => ep.User)
                    .ToList();
            }
        }

        public List<Group> GetGroupsByClubId(int clubId)
        {
            using (var context = new ClubManagementContext())
            {
                return context.Groups
                    .Include(g => g.Leader)
                    .Include(g => g.Event)
                    .Where(g => g.ClubId == clubId)
                    .ToList();
            }
        }

        public List<Group> GetGroupsByLeaderId(int leaderId)
        {
            using (var context = new ClubManagementContext())
            {
                return context.Groups
                    .Include(g => g.Leader)
                    .Include(g => g.Event)
                    .Where(g => g.LeaderId == leaderId)
                    .ToList();
            }
        }

        public List<User> GetGroupMembers(int groupId)
        {
            return _context.Users
                .Join(_context.GroupMembers,
                    u => u.UserId,
                    gm => gm.UserId,
                    (u, gm) => new { User = u, GroupMember = gm })
                .Where(x => x.GroupMember.GroupId == groupId)
                .Select(x => x.User)
                .ToList();
        }

        public void CreateGroup(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public void AddMembersToGroup(int groupId, List<int> memberIds)
        {
            foreach (var memberId in memberIds)
            {
                var groupMember = new GroupMember
                {
                    GroupId = groupId,
                    UserId = memberId,
                    JoinedAt = DateOnly.FromDateTime(DateTime.Now)
                };
                _context.GroupMembers.Add(groupMember);
            }
            _context.SaveChanges();
        }

        public void AssignLeaderToGroup(int groupId, int leaderId)
        {
            using (var context = new ClubManagementContext())
            {
                var group = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                if (group == null)
                {
                    throw new Exception("Không tìm thấy nhóm.");
                }

                var isMember = context.GroupMembers
                    .Any(gm => gm.GroupId == groupId && gm.UserId == leaderId);
                if (!isMember)
                {
                    throw new Exception("Người được chọn không phải là thành viên của nhóm này.");
                }

                group.LeaderId = leaderId;
                context.Groups.Update(group);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}