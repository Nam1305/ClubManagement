namespace Services
{
    using Microsoft.EntityFrameworkCore; // Thêm dòng này
    using DataAccess.Models;
    using Repository.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MemberService
    {
        private readonly ClubManagementContext _context;

        public MemberService()
        {
            _context = new ClubManagementContext();
        }

        public List<MemberParticipationDto> GetClubMembersWithParticipation(int clubId, string term, int? eventId = null, string participationStatus = null)
        {
            var season = term.Substring(0, term.Length - 4);
            var year = int.Parse(term.Substring(term.Length - 4));

            // Sử dụng Include để tải trước dữ liệu liên quan
            var members = _context.UserClubs
                .Where(uc => uc.ClubId == clubId && uc.Status == "approved")
                .Include(uc => uc.User) // Đảm bảo Include hoạt động
                .Select(uc => uc.User)
                .Distinct()
                .ToList();

            var events = _context.Events
                .Where(e => e.ClubId == clubId && e.EventDate.HasValue &&
                            e.EventDate.Value.Year == year &&
                            ((season == "Spring" && e.EventDate.Value.Month >= 1 && e.EventDate.Value.Month <= 4) ||
                             (season == "Summer" && e.EventDate.Value.Month >= 5 && e.EventDate.Value.Month <= 8) ||
                             (season == "Fall" && e.EventDate.Value.Month >= 9 && e.EventDate.Value.Month <= 12)))
                .ToList();

            var eventIds = events.Select(e => e.EventId).ToList();
            var eventParticipants = _context.EventParticipants
                .Where(ep => eventIds.Contains(ep.EventId))
                .ToList();

            var result = new List<MemberParticipationDto>();
            foreach (var member in members)
            {
                var userEvents = eventParticipants.Where(ep => ep.UserId == member.UserId).ToList();
                var totalEvents = events.Count;
                var participatedEvents = userEvents.Count(ep => ep.Status == "Đã tham gia");
                var participationPercentage = totalEvents > 0 ? (double)participatedEvents / totalEvents * 100 : 0;

                var activityLevel = participationPercentage switch
                {
                    >= 80 => "Rất tích cực",
                    >= 50 => "Tích cực",
                    >= 30 => "Bình thường",
                    _ => "Thấp"
                };

                // Lấy trạng thái tham gia sự kiện được chọn
                string eventParticipationStatus = "Chưa đăng ký";
                if (eventId.HasValue)
                {
                    var participant = eventParticipants.FirstOrDefault(ep => ep.EventId == eventId.Value && ep.UserId == member.UserId);
                    eventParticipationStatus = participant?.Status ?? "Chưa đăng ký";
                }

                // Lọc theo trạng thái tham gia nếu có
                if (participationStatus != null && participationStatus != "All" && eventParticipationStatus != participationStatus)
                {
                    continue;
                }

                result.Add(new MemberParticipationDto
                {
                    UserId = member.UserId,
                    FullName = member.FullName,
                    StudentNumber = member.StudentNumber,
                    Email = member.Email,
                    ParticipationPercentage = participationPercentage,
                    ActivityLevel = activityLevel,
                    EventParticipationStatus = eventParticipationStatus
                });
            }

            return result;
        }
    }
}