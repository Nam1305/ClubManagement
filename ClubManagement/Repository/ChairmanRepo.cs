using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ChairmanRepo
    {
        ClubManagementContext clubManagementContext;
        public ChairmanRepo() {
           clubManagementContext  = new ClubManagementContext();
        }

        public List<object> GetUsers(int? clubId)
        {
            return clubManagementContext.Users
                .Include(x => x.Role)
                .Include(x => x.UserClubs).ThenInclude(x => x.Club)
                .Where(x => x.UserClubs.Any(uc => uc.ClubId == clubId)) // Lọc User có ClubId khớp
                .Select(user => new
                {
                    user.UserId,
                    user.FullName,
                    user.Email,
                    RoleName = user.Role != null ? user.Role.RoleName : "No Role",
                    user.StudentNumber,
                    user.Username,
                    ClubName = user.UserClubs.FirstOrDefault().Club.ClubName, // Lấy ClubName
                    AppliedAt = user.UserClubs.FirstOrDefault().AppliedAt,
                    ApprovedAt = user.UserClubs.FirstOrDefault().ApprovedAt
                })
                .ToList<object>(); // Ép kiểu List<object> để dùng được với DataGrid
        }




    }
}
