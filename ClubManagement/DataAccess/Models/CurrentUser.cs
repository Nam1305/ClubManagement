using DataAccess.Models;

namespace ClubManagement
{
    public static class CurrentUser
    {
        private static User _user;

        public static User User
        {
            get => _user;
            set => _user = value;
        }

        // Các thuộc tính tiện lợi để truy cập nhanh
        public static int UserId => _user?.UserId ?? 0;
        public static int? RoleId => _user?.RoleId;
        public static int? ClubId => _user?.UserClubs?.FirstOrDefault()?.ClubId;
        public static string FullName => _user?.FullName ?? "Unknown";
        public static string Username => _user?.Username ?? "Unknown";

        // Phương thức để xóa session (khi đăng xuất)
        public static void Clear()
        {
            _user = null;
        }
        public static void SetUser(User user)
        {
            _user = user;
        }

    }
}