using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;

namespace DataAccess.Models
{
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static int? ClubId { get; set; } // Chỉ lưu một ClubId duy nhất
        public static int RoleId { get; set; }
        public static string Username { get; set; }

        public static void SetUser(User user)
        {
            UserId = user.UserId;
            RoleId = user.RoleId ?? 0;
            Username = user.Username;

            // Chỉ lấy ClubId mà user có vai trò Vice Chairman (RoleId = 3)
            if (RoleId == 3)
            {
                ClubId = user.UserClubs?
                    .FirstOrDefault(uc => uc.Status == "approved")?.ClubId;
                if (ClubId == null)
                    throw new Exception("Vice Chairman must be assigned to a club.");
            }
            else
            {
                ClubId = null; // Các vai trò khác không cần ClubId ở đây
            }
        }

        public static void Clear()
        {
            UserId = 0;
            ClubId = null;
            RoleId = 0;
            Username = null;
        }
    }
}