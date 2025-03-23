using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Report
{
    public DateOnly? CreatedDate { get; set; }

    public int ReportId { get; set; }

    public string? Semester { get; set; }

    public string? MemberChanges { get; set; }

    public string? EventSummary { get; set; }

    public string? ParticipationStatus { get; set; }

    public int ClubId { get; set; }

    public virtual Club Club { get; set; } = null!;
}
