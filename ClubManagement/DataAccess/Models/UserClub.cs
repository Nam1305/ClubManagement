using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserClub
{
    public int UserClubId { get; set; }

    public int UserId { get; set; }

    public int ClubId { get; set; }

    public string? Status { get; set; }

    public DateOnly? AppliedAt { get; set; }

    public DateOnly? ApprovedAt { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
