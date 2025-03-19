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
                    .Include(g => g.Leader) // Load Leader navigation property
                    .Include(g => g.Event)  // Load Event navigation property
                    .Where(g => g.ClubId == clubId)
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
            using (var context = new ClubManagementContext()) // Tạo một context mới để tránh cache
            {
                // Tìm nhóm cần cập nhật
                var group = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                if (group == null)
                {
                    throw new Exception("Group not found.");
                }

                // Kiểm tra xem leaderId có phải là thành viên của nhóm không
                var isMember = context.GroupMembers
                    .Any(gm => gm.GroupId == groupId && gm.UserId == leaderId);
                if (!isMember)
                {
                    throw new Exception("The selected leader is not a member of this group.");
                }

                // Cập nhật LeaderId cho nhóm
                group.LeaderId = leaderId;
                context.Groups.Update(group);
                context.SaveChanges();
            }
        }
    }
}