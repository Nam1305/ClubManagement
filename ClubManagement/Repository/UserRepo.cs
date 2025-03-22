// Trong Repository/UserRepo.cs
using DataAccess.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using ClubManagement;

namespace Repository
{
    public class UserRepo
    {
        private readonly ClubManagementContext context;

        public UserRepo()
        {
            context = new ClubManagementContext();
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool IsUsernameExists(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }

        public bool IsStudentNumberExists(string studentNumber)
        {
            return context.Users.Any(u => u.StudentNumber == studentNumber);
        }

        public bool IsEmailExists(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }

        public void CreateDate(User user)
        {
            user.Password = HashPassword(user.Password);
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            try
            {
                var find = context.Users
                    .Include(u => u.Role)
                    .Include(u => u.UserClubs)
                    .ThenInclude(uc => uc.Club)
                    .FirstOrDefault(u => u.Username == username);

                if (find == null || !BCrypt.Net.BCrypt.Verify(password, find.Password))
                {
                    return null;
                }

                CurrentUser.User = find; // Store user in CurrentUser
                return find;
            }
            catch (Exception ex)
            {
                throw new Exception("Error during login: " + ex.Message, ex);
            }
        }

        public List<User> GetGroupMembersForLeader(int groupId)
        {
            if (CurrentUser.RoleId != 4)
                throw new UnauthorizedAccessException("Only Group Leader can view group members.");

            var group = context.Groups.FirstOrDefault(g => g.GroupId == groupId && g.LeaderId == CurrentUser.UserId);
            if (group == null)
                throw new UnauthorizedAccessException("You are not the leader of this group.");

            return context.Users
                .Join(context.GroupMembers,
                    u => u.UserId,
                    gm => gm.UserId,
                    (u, gm) => new { User = u, GroupMember = gm })
                .Where(x => x.GroupMember.GroupId == groupId)
                .Select(x => x.User)
                .ToList();
        }

        public User GetByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email == email);
        }

        public string ResetPassword(string email)
        {
            var user = GetByEmail(email);
            if (user == null)
            {
                return null;
            }

            string tempPassword = GenerateTempPassword();
            user.Password = HashPassword(tempPassword);
            context.SaveChanges();

            return tempPassword;
        }

        private string GenerateTempPassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Role GetRoleByName(string roleName)
        {
            return context.Roles.FirstOrDefault(r => r.RoleName.ToLower() == roleName.ToLower());
        }

        public List<User> GetClubMembers(int clubId)
        {
            return context.Users
                .Join(context.UserClubs,
                    u => u.UserId,
                    uc => uc.UserId,
                    (u, uc) => new { User = u, UserClub = uc })
                .Where(x => x.UserClub.ClubId == clubId && x.UserClub.Status == "approved")
                .Select(x => x.User)
                .ToList();
        }

        public void UpdateUserByRole(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return context.Users
                .Include(x => x.Role)
                .ToList();
        }

        public List<User> SearchByStudentNumber(string studentNumber)
        {
            return context.Users
                .Include(x => x.Role)
                .Where(u => u.StudentNumber == studentNumber).ToList();
        }

        public List<User> SearchByFullName(string fullName)
        {
            return context.Users
                .Include(x => x.Role)
                .Where(u => u.FullName == fullName).ToList();
        }

        public List<User> SearchByEmail(string email)
        {
            return context.Users
                .Include(x => x.Role)
                .Where(u => u.Email == email).ToList();
        }

        public List<User> SearchByUserName(string userName)
        {
            return context.Users
                .Include(x => x.Role)
                .Where(u => u.Username == userName).ToList();
        }

        public bool AddNewUser(User user)
        {
            try
            {
                context.Users.Add(user);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var existingUser = context.Users.FirstOrDefault(u => u.StudentNumber == user.StudentNumber);
                if (existingUser == null)
                {
                    return false;
                }
                existingUser.FullName = user.FullName;
                existingUser.RoleId = user.RoleId;
                existingUser.StudentNumber = user.StudentNumber;
                existingUser.Status = user.Status;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateMember(User member)
        {
            try
            {
                var existingUser = context.Users.FirstOrDefault(u => u.StudentNumber == member.StudentNumber);
                if (existingUser == null)
                {
                    return false;
                }
                existingUser.FullName = member.FullName;
                existingUser.Email = member.Email;
                existingUser.RoleId = member.RoleId;
                existingUser.StudentNumber = member.StudentNumber;
                existingUser.Username = member.Username;
                existingUser.Status = member.Status;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteUser(string studentNumber)
        {
            try
            {
                var deleteStudent = GetAllUsers().Where(stud => stud.StudentNumber == studentNumber).FirstOrDefault();
                context.Remove(deleteStudent);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<User> GetUserByCbRoleChanged(int roleId)
        {
            return context.Users.Where(u => u.RoleId == roleId).ToList();
        }

        public User GetUserByUserId(int userId)
        {
            return context.Users
                .Include(u => u.Role)
                .Where(u => u.UserId == userId).FirstOrDefault();
        }

        public bool JoinClub(int userId, int clubId)
        {
            bool alreadyJoined = context.UserClubs.Any(uc => uc.UserId == userId && uc.ClubId == clubId);
            if (alreadyJoined)
            {
                return false;
            }
            var userClub = new UserClub()
            {
                UserId = userId,
                ClubId = clubId,
                Status = "pending",
                AppliedAt = DateOnly.FromDateTime(DateTime.Now),
                ApprovedAt = null
            };
            context.UserClubs.Add(userClub);
            context.SaveChanges();
            return true;
        }

        public List<UserClub> GetAllClubJoinedByUserId(int userId)
        {
            return context.UserClubs
                .Include(uc => uc.User)
                .Where(uc => uc.UserId == userId)
                .Where(uc => uc.Status.Equals("approved"))
                .Include(uc => uc.Club)
                .ToList();
        }

        public List<UserClub> GetAllClubApprovingByUserId(int userId)
        {
            return context.UserClubs
                .Include(uc => uc.User)
                .Where(uc => uc.UserId == userId)
                .Where(uc => uc.Status.Equals("pending"))
                .Include(uc => uc.Club)
                .ToList();
        }

        public List<UserClub> SearchUserClub(int userId, string name)
        {
            return context.UserClubs
                .Include(uc => uc.User)
                .Where(uc => uc.UserId == userId)
                .Where(uc => uc.Status.Equals("pending"))
                .Include(uc => uc.Club)
                .Where(uc => uc.Club.ClubName.Contains(name))
                .ToList();
        }
    }
}