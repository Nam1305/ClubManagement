using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string StudentNumber { get; set; }
        public string Username { get; set; }
        public string ClubName { get; set; }
        public DateTime? AppliedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
    }

}
