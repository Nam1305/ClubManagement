using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataAccess.Models;
using Repository.DTO;

namespace Services
{
    public class MemberService
    {
        private readonly ClubManagementContext _context;

        public MemberService()
        {
            _context = new ClubManagementContext();
        }

        public IEnumerable<MemberParticipationDto> GetClubMembersWithParticipation(int clubId, string term)
        {
            // Lấy danh sách thành viên của câu lạc bộ
            var members = _context.UserClubs
                .Where(uc => uc.ClubId == clubId)
                .Select(uc => uc.User)
                .ToList();

            // Lấy danh sách sự kiện của câu lạc bộ
            var events = _context.Events
                .Where(e => e.ClubId == clubId && e.EventDate.HasValue)
                .ToList();

            // Phân tích kỳ từ chuỗi term (ví dụ: "Fall2024" -> season: Fall, year: 2024)
            string season = term.Substring(0, term.Length - 4); // Lấy phần mùa (Fall, Summer, Spring)
            int year = int.Parse(term.Substring(term.Length - 4)); // Lấy phần năm (2024)

            // Lọc sự kiện theo kỳ cụ thể
            var termEvents = events.Where(e =>
            {
                int eventYear = e.EventDate.Value.Year;
                int eventMonth = e.EventDate.Value.Month;

                if (eventYear != year) return false;

                return season switch
                {
                    "Spring" => eventMonth >= 1 && eventMonth <= 4,  // Spring: Tháng 1-4
                    "Summer" => eventMonth >= 5 && eventMonth <= 8,  // Summer: Tháng 5-8
                    "Fall" => eventMonth >= 9 && eventMonth <= 12,   // Fall: Tháng 9-12
                    _ => false
                };
            }).ToList();

            var totalEvents = termEvents.Count;

            // Tính toán thông tin cho từng thành viên
            var memberData = members.Select(member =>
            {
                // Số sự kiện mà thành viên đã tham gia
                var eventIds = _context.EventParticipants
                    .Where(ep => ep.UserId == member.UserId && ep.Status == "approved")
                    .Select(ep => ep.EventId);

                var participatedEvents = termEvents
                    .Count(e => eventIds.Contains(e.EventId));

                double participationPercentage = totalEvents > 0
                    ? (double)participatedEvents / totalEvents * 100
                    : 0;

                string activityLevel = participationPercentage switch
                {
                    > 80 => "Tích cực",
                    >= 50 => "Bình thường",
                    _ => "Không tích cực"
                };

                return new MemberParticipationDto
                {
                    UserId = member.UserId,
                    FullName = member.FullName,
                    StudentNumber = member.StudentNumber,
                    Email = member.Email,
                    ParticipationPercentage = participationPercentage,
                    ActivityLevel = activityLevel
                };
            }).ToList();

            return memberData;
        }
    }
}