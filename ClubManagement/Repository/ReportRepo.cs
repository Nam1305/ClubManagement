using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ReportRepo
    {
        private readonly ClubManagementContext _context;

        public ReportRepo()
        {
            _context = new ClubManagementContext();
        }

        // Lấy tất cả báo cáo theo ClubId
        public List<Report> GetReportsByClubId(int clubId)
        {
            return _context.Report
                .Where(r => r.ClubId == clubId)
                .Include(r => r.Club)
                .ToList();
        }

        // Lấy báo cáo theo ReportId
        public Report GetReportById(int reportId)
        {
            return _context.Report
                .Include(r => r.Club)
                .FirstOrDefault(r => r.ReportId == reportId);
        }

        // Tạo báo cáo mới
        public void CreateReport(Report report)
        {
            _context.Report.Add(report);
            _context.SaveChanges();
        }

        // Cập nhật trạng thái báo cáo (Approved/Rejected)
        public void UpdateReportStatus(int reportId, string status)
        {
            var report = _context.Report.FirstOrDefault(r => r.ReportId == reportId);
            if (report != null)
            {
                report.ParticipationStatus = status;
                _context.Report.Update(report);
                _context.SaveChanges();
            }
        }
    }
}