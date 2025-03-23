using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace Services
{
    public class ReportService
    {
        private readonly ClubManagementContext _context;

        public ReportService()
        {
            _context = new ClubManagementContext();
        }

        // Tính toán và trả về thông tin thay đổi thành viên dưới dạng văn bản
        public string CalculateMemberChanges(int clubId, DateTime semesterStart, DateTime semesterEnd)
        {
            // Lấy danh sách thành viên tại thời điểm bắt đầu kỳ (đã được phê duyệt trước hoặc tại semesterStart)
            var membersAtStart = _context.UserClubs
                .Where(uc => uc.ClubId == clubId
                    && uc.ApprovedAt.HasValue
                    && uc.ApprovedAt.Value.ToDateTime(TimeOnly.MinValue) <= semesterStart)
                .Select(uc => uc.UserId)
                .ToList();

            // Lấy danh sách thành viên tại thời điểm kết thúc kỳ (đã được phê duyệt trước hoặc tại semesterEnd)
            var membersAtEnd = _context.UserClubs
                .Where(uc => uc.ClubId == clubId
                    && uc.ApprovedAt.HasValue
                    && uc.ApprovedAt.Value.ToDateTime(TimeOnly.MinValue) <= semesterEnd)
                .Select(uc => uc.UserId)
                .ToList();

            // Tính số lượng thành viên mới (có trong membersAtEnd nhưng không có trong membersAtStart)
            var newMembers = membersAtEnd.Except(membersAtStart).Count();

            // Tính số lượng thành viên rời đi (có trong membersAtStart nhưng không có trong membersAtEnd)
            var leftMembers = membersAtStart.Except(membersAtEnd).Count();

            // Tạo chuỗi văn bản mô tả thay đổi
            return $"{newMembers} members joined, {leftMembers} members left";
        }

        // Tạo nội dung báo cáo dạng văn bản (dùng cho cột eventSummary)
        public string GenerateReportContent(int clubId, DateTime semesterStart, DateTime semesterEnd)
        {
            var events = _context.Events
                .Where(e => e.ClubId == clubId && e.EventDate.HasValue
                    && e.EventDate.Value >= DateOnly.FromDateTime(semesterStart)
                    && e.EventDate.Value <= DateOnly.FromDateTime(semesterEnd))
                .ToList();

            int totalEvents = events.Count;
            int completedEvents = events.Count(e => e.Status == "Completed");

            StringBuilder reportContent = new StringBuilder();
            reportContent.AppendLine("Club Report");
            reportContent.AppendLine("--------------------------------------------------");
            reportContent.AppendLine($"Semester: {semesterStart:dd/MM/yyyy} - {semesterEnd:dd/MM/yyyy}");
            reportContent.AppendLine($"Total Events: {totalEvents}");
            reportContent.AppendLine($"Completed Events: {completedEvents}");
            reportContent.AppendLine("Event Details:");
            foreach (var evt in events)
            {
                reportContent.AppendLine($"- {evt.EventName} ({evt.EventDate?.ToString("dd/MM/yyyy")}): {evt.Status}");
            }
            reportContent.AppendLine("--------------------------------------------------");

            return reportContent.ToString();
        }
    }
}